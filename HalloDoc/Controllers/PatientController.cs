
using DataLayer.Models;
using DataLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using BusinessLayer.Utility;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using System.Globalization;
using BusinessLayer.Repository.Interface;
using BusinessLayer.Repository.Implementation;
using AspNetCoreHero.ToastNotification.Abstractions;


namespace HalloDoc.Controllers
{
    
    public class PatientController : Controller
    {
        public HallodocContext context;
        public readonly IHostingEnvironment _environment;
        public readonly IPatientRequest patientRequestService;
        public readonly IFamilyRequest familyRequestService;
        public readonly IBusinessRequest businessRequestService;
        public readonly IConciergeRequest conciergeRequestService;
        public readonly IRequestForMe requestForMeService;
        public readonly IJwtService jwtService;
        private readonly IEmailLogs emailLogService;
        private readonly IPatientService patientService;      
        const string CookieUserEmail = "UserId";
        IEmailSender _EmailSender;


        public PatientController(HallodocContext context, 
            IHostingEnvironment environment, 
            IEmailSender emailSender, 
            IPatientRequest patientRequest, 
            IFamilyRequest familyRequest, 
            IBusinessRequest businessRequest, 
            IConciergeRequest conciergeRequest, 
            IEmailLogs emailLog,
            IRequestForMe requestForMe, 
            IJwtService jwt,
            INotyfService notyf, 
            IPatientService patientService)
        {
            this.context = context;
            this.patientRequestService = patientRequest;
            this.familyRequestService = familyRequest;
            _environment = environment;
            _EmailSender = emailSender;
            this.businessRequestService = businessRequest;
            this.conciergeRequestService = conciergeRequest;
            this.emailLogService = emailLog;
            this.requestForMeService = requestForMe;
            this.jwtService = jwt;
            this.patientService = patientService;
        }

        [HttpGet]
        public IActionResult PatientLogin(string returnurl)
        {
            return View();
        }
        [HttpPost]
        public IActionResult PatientLogin(PatientLogin model, string returnurl)
        {
            ModelState.Remove("returnurl");
            if (ModelState.IsValid)
            {
                var email = model.Email;
                var password = model.Password;
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);

                Response.Cookies.Append(CookieUserEmail, model.Email, options);

                if (email != null || password != null)
                {
                    var user = patientService.GetAspNetUser(model.Email);

                    if (user != null)
                    {
                        if (user.PasswordHash == password)
                        {
                            var d = patientService.GetUserType(model.Email, "admin");

                            var p = patientService.GetUserType(model.Email, "provider");
                            if(p is not null)
                            {
                                string token = jwtService.GenerateToken(user.Email, "provider");
                                HttpContext.Session.SetString("jwttoken", token);
                                HttpContext.Session.SetString("userid", email);

                                var phy = patientService.GetPhysician(user.Id);
                                string name = phy.FirstName + ", " + phy.LastName;
                                Response.Cookies.Append("UserName", name, options);
                                Response.Cookies.Append("Role", "provider", options);

                                if (!string.IsNullOrEmpty(returnurl))
                                {
                                    return Redirect(returnurl);
                                }
                                return RedirectToAction("ProviderDashboard", "Provider");
                            }else if (d is not null)
                            {

                                string token = jwtService.GenerateToken(user.Email, "admin");

                                HttpContext.Session.SetString("jwttoken", token);
                                HttpContext.Session.SetString("userid", email);

                                var admin = patientService.GetAdmin(user.Id);
                                string name = admin.FirstName + ", " + admin.LastName;
                                Response.Cookies.Append("UserName", name, options);
                                Response.Cookies.Append("Role", "admin", options);

                                if (!string.IsNullOrEmpty(returnurl))
                                {
                                    return Redirect(returnurl);
                                }
                                return RedirectToAction("AdminDashboard", "Admin");
                            }
                            else
                            {
                                string token = jwtService.GenerateToken(user.Email, "user");

                                HttpContext.Session.SetString("jwttoken", token);
                                HttpContext.Session.SetString("userid", email);

                                var Users = patientService.GetUser(user.Id);
                                string name = Users.FirstName + ", " + Users.LastName;
                                Response.Cookies.Append("UserName", name, options);

                                if (!string.IsNullOrEmpty(returnurl))
                                {
                                    return Redirect(returnurl);
                                }
                                return RedirectToAction("PatientDashboardPage", "Patient");
                            }
                                
                          
                           
                        }
                        else
                        {
                            ModelState.AddModelError("", "Wrong Password");
                        }

                    }
                    else
                    {

                        ModelState.AddModelError("", "Failed to login");
                        return View(model);


                    }
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(ForgetPassword model)
        {
            string ResetPassLink = "https://localhost:44301/Patient/ResetPassword?email=" + model.email;

            EmailLogDto obj = new EmailLogDto()
            {
                Template = "https://localhost:44301/Patient/ResetPassword?email=" + model.email ,
                EmailId = model.email,               
                Subject = "Reset password"
            };

            emailLogService.addEmailLog(obj);
            _EmailSender.SendEmailAsync("vishva.rami@etatvasoft.com", "ResetPassword", ResetPassLink);

            return RedirectToAction("PatientLogin", "Patient");
        }
        [HttpGet]
        public IActionResult ResetPassword(string email)
        {
            TempData["email"] = email;
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPassword model)
        {
            string email = TempData["email"].ToString();
            patientService.ResetPassword(email, model.Password);
            return RedirectToAction("PatientLogin", "Patient");
        }
        [HttpGet]
        public IActionResult PatientRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PatientRequest(PatientRequestModel model)
        {
            patientRequestService.PatientRequestData(model);
           
            return RedirectToAction("Index", "Home");
        }

        public Boolean IsPatientPresent(string email)
        {
            bool res = patientService.IsPatientPresent(email);
            return res;
        }
        [HttpGet]
        public IActionResult FamilyRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FamilyRequest(FamilyRequestModel model)
        {
            familyRequestService.FamilyRequestData(model);
            _EmailSender.SendEmailAsync("vishva.rami@etatvasoft.com", "CreateAccount", "Please <a href=\"https://localhost:44301/Patient/CreatePatient\">login</a>");
            EmailLogDto obj = new EmailLogDto()
            {
                Template = "Please <a href=\"https://localhost:44301/Patient/CreatePatient\">login</a>",
                EmailId = model.P_Email,
                Subject = "CreateAccount"
            };

            emailLogService.addEmailLog(obj);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult BusinessRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BusinessRequest(BusinessRequestModel model)
        {
            businessRequestService.BusinessRequestData(model);
            _EmailSender.SendEmailAsync("vishva.rami@etatvasoft.com", "CreateAccount", "Please <a href=\"https://localhost:44301/Patient/CreatePatient\">login</a>");
            EmailLogDto obj = new EmailLogDto()
            {
                Template = "Please <a href=\"https://localhost:44301/Patient/CreatePatient\">login</a>",
                EmailId = model.P_Email,
                Subject = "CreateAccount"
            };

            emailLogService.addEmailLog(obj);
            return RedirectToAction("Index", "Home");
            
        }
        [HttpGet]
        public IActionResult ConciergeRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ConciergeRequest(ConciergeRequestModel model)
        {
            conciergeRequestService.ConciergeRequestData(model);
            _EmailSender.SendEmailAsync("vishva.rami@etatvasoft.com", "CreateAccount", "Please <a href=\"https://localhost:44301/Patient/CreatePatient\">login</a>");
            EmailLogDto obj = new EmailLogDto()
            {
                Template = "Please <a href=\"https://localhost:44301/Patient/CreatePatient\">login</a>",
                EmailId = model.P_email,
                Subject = "CreateAccount"
            };

            emailLogService.addEmailLog(obj);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePatient(CreatePatient model)
        {
            
                patientService.CreatePatient(model);
           
            return View();
        }
        [Auth("user")]
        public IActionResult PatientDashboardPage()
        {
            string? UserEmail = Request.Cookies[CookieUserEmail];
            List<PatientDashboard> data = patientService.GetPatientDashboardData(UserEmail);
            return View(data);
        }
        [Auth("user")]
        [HttpGet]
        public IActionResult PatientProfile()
        {
            string? UserEmail = Request.Cookies[CookieUserEmail];

            PatientProfile model = patientService.GetPatientProfile(UserEmail);
            return View(model);
        }
        [Auth("user")]
        [HttpPost]
        public IActionResult PatientProfile(PatientProfile model)
        {
            string? UserEmail = Request.Cookies[CookieUserEmail];

            patientService.EditPatientProfile(UserEmail, model);

            return View();
        }

        [HttpGet]
        public IActionResult ViewDocument(int RequestID)
        {
            ViewDocumentList doc = patientService.GetDocuments(RequestID);
            return View(doc);
        }
        public IActionResult Download(int Download)
        {
           
            string filePath = patientService.GetFilePath(Download);

            if (filePath == null)
            {
                return RedirectToAction("PatientDashboard", "Patient");
            }

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }

        [HttpPost]
        public void addDocument(IFormFile file, int requestid)
        {
            if (file != null)
            {
                patientService.UploadFile(file, requestid);

            }
            RedirectToAction("ViewDocument", requestid);
        }
        [Auth("user")]
        [Route("[controller]/[action]/{reqid}")]
        public IActionResult ReviewAgreement(string reqid)
        {
            TempData["agreeID"]=reqid;
            int id = int.Parse(reqid);

            string? UserEmail = Request.Cookies[CookieUserEmail];
            int userid1 = patientService.GetUserId(id);
            int userid2 = patientService.GetUserIdByMail(UserEmail);
           
            if (userid1 == userid2)
            {
                var status = patientService.GetReqStatus(id);
                if (status == 2)
                {
                    return View();

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public void Agree()
        {
            var id = (string)TempData["agreeID"];
            int reqid = int.Parse(id);
            patientService.Agree(reqid);
            RedirectToAction("PatientDashboardPage", "Patient");

        }
        public void CancelAgreement(string cancelnote)
        {
            var id = (string)TempData["agreeID"];
            int reqid = int.Parse(id);
            patientService.CancelAgreement(cancelnote, reqid);
            RedirectToAction("PatientDashboardPage", "Patient");

        }
        [HttpGet]
        public IActionResult RequestForMe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestForMe(PatientRequestModel model)
        {
            string? UserEmail = Request.Cookies[CookieUserEmail];
            requestForMeService.Requestforme(model, UserEmail);
            return RedirectToAction("PatientDashboardPage", "Patient");

        }

        [HttpGet]
        public IActionResult RequestForSomeoneElse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestForSomeoneElse(RequestForSomeoneElse model)
        {
            patientService.RequestForElse(model);

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
