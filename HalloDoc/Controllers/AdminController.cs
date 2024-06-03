using BusinessLayer.Repository.Interface;
using DataLayer.DTO;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using BusinessLayer.Utility;
using BusinessLayer.Repository.Implementation;
using Castle.Core.Smtp;
using System.Globalization;
using NPOI.SS.Formula.Functions;
using static BusinessLayer.Utility.Export;
using NPOI.POIFS.Properties;
using NPOI.Util;
using Microsoft.AspNetCore.Components.Forms;
using NPOI.SS.Formula.Eval;
using System.Security.Policy;
using NPOI.POIFS.Crypt.Dsig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Configuration.Provider;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System;

namespace HalloDoc.Controllers
{

    public class AdminController : Controller
    {
        public readonly IHostingEnvironment _environment;
        private readonly IAdminDashboard adminDashboardService;
        private readonly IRequestTable requestTableService;
        private readonly IViewUploads viewUploadsService;
        private readonly ICreateRequest createRequestService;
        private readonly BusinessLayer.Utility.IEmailSender emailSenderService;
        private readonly IEncounterform encounterformService;
        private readonly ICloseCase closecaseService;
        private readonly IAdminProfile adminprofileService;
        private readonly IProviderData providerDataService;
        private readonly IAccessRoles accessRolesService;
        private readonly IProviderProfileEditByAdmin providerEditService;
        private readonly ICreateProviderAC createProviderACService;
        private readonly IUserAccess userAccessService;
        private readonly ICreateAdminAC createAdminACService;
        private readonly IProviderSchedule providerScheduleService;
        private readonly IProviderOnCall providerOnCallService;
        private readonly IRequestedShifts requestedShiftsService;
        private readonly IProviderLocation providerLocationService;
        private readonly IVendors vendorsService;
        private readonly ISearchRecords searchRecordsService;
        private readonly IEmailLogs emailLogService;
        private readonly ISMSLog smsLogService;
        private readonly IPatientHistroy patientHistroyService;
        private readonly IBlockHistroy BlockHistroyService;
        private readonly IFetchData fetchDataService;
        private readonly IViewCase ViewCaseService;




        public AdminController(
            IHostingEnvironment environment,
            IAdminDashboard adminDashboard,
            IRequestTable requestTable,
            IViewUploads viewUploads,
            BusinessLayer.Utility.IEmailSender emailSender,
            ICreateRequest createRequest,
            IEncounterform encounterform,
            ICloseCase closeCase,
            IAdminProfile adminProfile,
            IProviderData providerData,
            IAccessRoles accessRoles,
            IProviderProfileEditByAdmin providerProfileEditByAdmin,
            ICreateProviderAC createProviderAC,
            IUserAccess userAccess,
            ICreateAdminAC createAdminAC,
            IProviderSchedule providerSchedule,
            IProviderOnCall providerOnCall,
            IRequestedShifts shifttable,
            IProviderLocation providerLocation,
            IVendors vendors,
            ISearchRecords searchRecords,
            IEmailLogs emailLog,
            ISMSLog smslog,
            IPatientHistroy patientHistroy,
            IBlockHistroy blockHistroy,
            IFetchData fetchData,
            IViewCase viewCaseService)

        {
            this.adminDashboardService = adminDashboard;
            _environment = environment;
            this.requestTableService = requestTable;
            this.viewUploadsService = viewUploads;
            this.emailSenderService = emailSender;
            this.createRequestService = createRequest;
            this.encounterformService = encounterform;
            this.closecaseService = closeCase;
            this.adminprofileService = adminProfile;
            this.providerDataService = providerData;
            this.accessRolesService = accessRoles;
            this.providerEditService = providerProfileEditByAdmin;
            this.createProviderACService = createProviderAC;
            this.userAccessService = userAccess;
            this.createAdminACService = createAdminAC;
            this.providerScheduleService = providerSchedule;
            this.providerOnCallService = providerOnCall;
            this.requestedShiftsService = shifttable;
            this.providerLocationService = providerLocation;
            this.vendorsService = vendors;
            this.searchRecordsService = searchRecords;
            this.emailLogService = emailLog;
            this.smsLogService = smslog;
            this.patientHistroyService = patientHistroy;
            this.fetchDataService = fetchData;
            BlockHistroyService = blockHistroy;
            ViewCaseService = viewCaseService;
        }

        [Auth("admin", "Dashboard")]
        public IActionResult AdminDashboard()
        {
            AdminDashboarddata data = adminDashboardService.countrequest();
            return View(data);

        }

        [Auth("admin")]
        public IActionResult NewState1(int reqStaus, int requesttype, string searchin, int page)
        {
            List<RequestTableData> data = getPaginatedData(reqStaus, requesttype, searchin, page);
            return PartialView("_NewTable", data);
        }
        public List<RequestTableData> getPaginatedData(int reqStaus, int requesttype, string searchin, int page)
        {
            List<RequestTableData> data = requestTableService.GetData(reqStaus, requesttype, searchin, page, out int Count);
            ViewBag.Count = Count;
            return (data);

        }

        [Auth("admin,provider")]
        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }
        [Auth("admin,provider")]
        [HttpPost]
        public IActionResult CreateRequest(CreateRequestData model)
        {
            if (ModelState.IsValid)
            {
                createRequestService.AdminRequest(model);

            }
            return View();
        }
        [Auth("admin", "MyProfile")]
        [HttpGet]
        public IActionResult Profile()
        {
            string? UserEmail = Request.Cookies["UserId"];
            int id = adminprofileService.getAdminId(UserEmail);
            ProfileData data = adminprofileService.AdminProfileDetails(id);
            return View(data);
        }

        public IActionResult AdminProfileEdit(int Adminid)
        {
         
            ProfileData data = adminprofileService.AdminProfileDetails(Adminid);
            return View(data);
        }
        public void SendLink(string emailAdd)
        {
            string? UserEmail = Request.Cookies["UserId"];
            int id = adminprofileService.getAdminId(UserEmail);
            EmailLogDto obj = new EmailLogDto()
            {
                Template = "Please <a href=\"https://localhost:44301/Patient/PatientRequest\">Create Request</a>",
                EmailId = emailAdd,
                AdminId = id,
                Subject = "Send Link"
            };
            emailLogService.addEmailLog(obj);
            emailSenderService.SendEmailAsync("vishva.rami@etatvasoft.com", "Create Request", "Please <a href=\"https://localhost:44301/Patient/PatientRequest\">Create Request</a>");
        }
        public IActionResult ExportCurrent(int reqStaus, int requesttype, int page)
        {
            List<RequestTableData> data = getPaginatedData(reqStaus, requesttype, null, page);
            if (data.Count > 0)
            {
                var file = ExcelHelper.CreateFile(data);
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "requests.xlsx");
            }
            return BadRequest();
           
        }

        public IActionResult ExportALLReq()
        {
            List<RequestTableData> data = requestTableService.requestTableData(0, 0, null);
            if (data.Count > 0)
            {
                var file = ExcelHelper.CreateFile(data);
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "requests.xlsx");
            }
            return BadRequest();
        }
        public void CancelCase(cancelcase model)
        {
            requestTableService.CancelCase(model);

        }

        public void AssignCase(int assign_req_id, string phy_region, string phy_id, string assignNote)
        {
            requestTableService.AssignCase(assign_req_id, phy_region, phy_id, assignNote);

        }

        public void TransferCase(int transfer_req_id, string phy_region, string phy_id, string transferNote)
        {

            requestTableService.TransferCase(transfer_req_id, phy_region, phy_id, transferNote);

        }
        public void BlockCase(int block_req_id, string blocknote)
        {
            requestTableService.BlockCase(block_req_id, blocknote);
        }
        public void ClearCase(int clear_req_id)
        {
            requestTableService.ClearCase(clear_req_id);
        }
        public void SendAgreement(int arg_req_id, string argPhone, string argEmail)
        {
            string url = "https://localhost:44301/Patient/ReviewAgreement/" + arg_req_id;

            string? UserEmail = Request.Cookies["UserId"];
            int id = adminprofileService.getAdminId(UserEmail);
            EmailLogDto obj = new EmailLogDto()
            {
                Template = url,
                EmailId = argEmail,
                AdminId = id,
                Subject = "Review Agreement"
            };
            emailLogService.addEmailLog(obj);

            emailSenderService.SendEmailAsync("vishva.rami@etatvasoft.com", "Review Agreement", url);
        }

        public IActionResult FetchRegions()
        {

            List<FetchDTO> data = fetchDataService.FetchRegions();
            data.Select(a => new
            {
                id = a.Id,
                name = a.Name
            });          

            return Ok(data);
        }

        public IActionResult FetchProfession()
        {
            List<FetchDTO> data = fetchDataService.FetchProfession();
            data.Select(a => new
            {
                typeid = a.Id,
                name = a.Name
            });           

            return Ok(data);
        }

        public IActionResult FetchPhysician(int selectregionid)
        {
            List<FetchDTO> data = fetchDataService.FetchPhysicianByRegion(selectregionid);
            data.Select(a => new
            {
                physicianid = a.Id,
                name = a.Name
            }).ToList();
          

            return Ok(data);
        }

        public IActionResult FetchBusiness(int businessid)
        {
            List<FetchDTO> data = fetchDataService.FetchBusiness(businessid);
            data.Select(a => new
            {
                businessid = a.Id,
                name = a.Name
            }).ToList();

            return Ok(data);
        }
        public IActionResult BusinessDetails(int businessid)
        {
            List<BusinessDetails> data = fetchDataService.FetchBusinessDetails(businessid);
            data.Select(r => new
            {
                businessid = r.Businessid,
                name = r.Name,
                contact = r.BusinessContact,
                email = r.Email,
                fax = r.FaxNumber
            }).ToList();

           
            return Ok(data);
        }

        [Auth("admin,provider", "RequestData")]
        [HttpGet]
        public IActionResult ViewUploads(int viewid)
        {
            ViewUploadsModel details = viewUploadsService.Uploadedfilesdata(viewid);

            return View(details);
        }
        public IActionResult Downloadfile(int docid)
        {
            string filePath = viewUploadsService.GetFilepath(docid);

            if (filePath == null)
            {
                return RedirectToAction("PatientDashboard", "Patient");
            }

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }
        public void DeleteFile(int fileid)
        {
            viewUploadsService.DeleteFile(fileid);

        }
        public void SendDocumentEmail(int id, List<string> files)
        {
            string? UserEmail = Request.Cookies["UserId"];
            int adminid = adminprofileService.getAdminId(UserEmail);
            EmailLogDto obj = new EmailLogDto()
            {
                Template = "files",
                EmailId = "vishva.rami@etatvasoft.com",
                AdminId = adminid,
                Subject = " files mail"
            };
            emailLogService.addEmailLog(obj);
            emailSenderService.SendFileAsync("vishva.rami@etatvasoft.com", "files", "message", files);
        }

        [HttpPost]
        public void addFiles(List<IFormFile> file, int reqid)
        {

            viewUploadsService.AddFiles(file, reqid);
            RedirectToAction("ViewUploads", reqid);
        }

        [Auth("admin,provider", "RequestData")]
        [HttpGet]
        public IActionResult ViewCase(int reqId)
        {

            ViewCaseData details = ViewCaseService.GetCaseData(reqId);
            return View(details);
        }

        [Auth("admin,provider", "RequestData")]
        [HttpPost]
        public ActionResult ViewCase(ViewCaseData model, int reqId)
        {

            ViewCaseService.UpdateCaseData(model, reqId);
            return RedirectToAction("ViewCase",new { reqId=reqId });
        }
        public IActionResult test()
        {
            return View();
        }

        [Auth("admin,provider", "RequestData")]
        [HttpGet]
        public ActionResult ViewNotes(int Requestid)
        {
            TempData["Requestid"] = Requestid;
           

            ViewNotesData notes = ViewCaseService.GetNotes(Requestid);
           
            return View(notes);

        }


        [Auth("admin,provider", "RequestData")]
        [HttpPost]
        public ActionResult ViewNotes(int Role, string Additional)
        {
            var requid = (int)TempData["Requestid"];
            if(Role == 1)
            {
                ViewCaseService.AddAdminNotes(Additional, requid);

            }
            else if(Role == 2)
            {
                ViewCaseService.AddPhysicianNote(Additional, requid);

            }
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [Auth("admin,provider", "SendOrder")]
        [HttpGet]
        public ActionResult AdminOrders(int ordreqid)
        {
            TempData["orderReqId"] = ordreqid;
            return View();
        }

        [Auth("admin,provider", "SendOrder")]
        [HttpPost]
        public ActionResult AdminOrders(OrderData model)
        {


            var id = (int)TempData["orderReqId"];
            ViewCaseService.AddOrders(model, id);


            return RedirectToAction("AdminDashboard");
        }


        [Auth("admin,provider","Encounter")]
        [HttpGet]
        public ActionResult Encounter(int encreqid)
        {
            TempData["encreqid"] = encreqid;
            EncounterFormData model = encounterformService.encounterformdata(encreqid);

            return View(model);

        }

        [HttpPost]
        public ActionResult Encounter(EncounterFormData model)
        {

            var id = (int)TempData["encreqid"];

            encounterformService.encounterSaveChanges(model, id);

            return View();
        }

        [Auth("admin")]
        [HttpGet]
        [Route("[controller]/[action]/{closeid:int}")]
        public IActionResult Closecase(int closeid)
        {

            ViewUploadsModel data = closecaseService.Closecasefiles(closeid);
            return View(data);
        }



        [HttpPost]
        public IActionResult Closecasesubmit(int closeid)
        {
            closecaseService.Closingcase(closeid);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        public void CloseCaseUpdateByAdmin(int id, string email, string phone)
        {
            closecaseService.UpdateDetails(id, email, phone);
        }
      
        [HttpPost]
        public IActionResult ProfileMailEdit(ProfileData model)
        {
            adminprofileService.editMail(model);
            return RedirectToAction("Profile", "Admin");
        }

        [HttpPost]
        public IActionResult AdminDetailsEdit(ProfileData model)
        {
            adminprofileService.adminDetailsEdit(model);
            return RedirectToAction("Profile", "Admin");
        }

        [HttpPost]
        public IActionResult ResetAdminPass(string Username, string Password)
        {
            adminprofileService.resetAdminPass(Username, Password);
            return RedirectToAction("Profile", "Admin");
        }


        [Auth("admin", "Provider")]
        public IActionResult Providers()
        {
            return View();
        }


        [Auth("admin")]
        public IActionResult ProviderDataTable(string search)
        {
            List<ProviderDetails> data = providerDataService.getProviderData(search);

            return PartialView("_ProviderTable", data);
        }

        public IActionResult ChangeinNotification(int phyid, bool ischeck)
        {
            providerDataService.ChangeinNotification(phyid, ischeck);
            return RedirectToAction("Providers", "Admin");
        }


        public IActionResult ContactProvider(int physicianid,int SelectType, string Message)
        {
            string? UserEmail = Request.Cookies["UserId"];
            int adminid = adminprofileService.getAdminId(UserEmail);

            if (SelectType == 1)
            {
                SMSSend sms = new SMSSend();
                sms.sendSMS(Message);
                smsLogService.AddSMSLog(physicianid, adminid, Message);
            }
            else if(SelectType == 2)
            {
                EmailLogDto obj = new EmailLogDto()
                {
                    Template = "Messgae sent by Admin :" + Message,
                    EmailId = "vishva.rami@etatvasoft.com",
                    PhysicianId = physicianid,
                    AdminId = adminid,
                    Subject = "Contact Provider"
                };

                emailLogService.addEmailLog(obj);
                emailSenderService.SendEmailAsync("vishva.rami@etatvasoft.com", "Messgae sent by Admin", Message);

            }
            else if(SelectType == 3)
            {
                EmailLogDto obj = new EmailLogDto()
                {
                    Template = "Messgae sent by Admin :" + Message,
                    EmailId = "vishva.rami@etatvasoft.com",
                    PhysicianId = physicianid,
                    AdminId = adminid,
                    Subject = "Contact Provider"
                };

                emailLogService.addEmailLog(obj);
                emailSenderService.SendEmailAsync("vishva.rami@etatvasoft.com", "Messgae sent by Admin", Message);

                SMSSend sms = new SMSSend();
                sms.sendSMS(Message);
            }
           
          

            return RedirectToAction("Profile", "Admin");
        }

        [Auth("admin,provider")]
        public IActionResult EditProvider(int Phyid)
        {
            ProviderProfileData data = providerEditService.getProviderProfileData(Phyid);
            return View(data);
        }


        [HttpPost]
        public IActionResult EditAccountInfo(ProviderProfileData model)
        {
            providerEditService.EditAccountInfo(model);
            return RedirectToAction("EditProvider", new { Phyid = model.ProviderId });
        }
        [HttpPost]
        public IActionResult EditPhysicianInfo(ProviderProfileData model)
        {
            string? UserEmail = Request.Cookies["UserId"];

            providerEditService.EditPhysicianInfo(model);
            return RedirectToAction("EditProvider", new { Phyid = model.ProviderId });

        }
        [HttpPost]
        public IActionResult EditPhyMailInfo(ProviderProfileData model)
        {
            providerEditService.EditPhyMailInfo(model);
            return RedirectToAction("EditProvider", new { Phyid = model.ProviderId });

        }
        public IActionResult EditOnboardingDoc(ProviderProfileData model)
        {
            providerEditService.EditDocs(model);
            return RedirectToAction("EditProvider", new { Phyid = model.ProviderId });

        }
        [HttpPost]
        public IActionResult EditPhyProfileInfo(ProviderProfileData model)
        {
            providerEditService.EditPhyProfileInfo(model);
            return RedirectToAction("EditProvider", new { Phyid = model.ProviderId });

        }

        [HttpPost]
        public IActionResult DeleteProviderAC(int ProviderId)
        {
            providerEditService.deleteAccount(ProviderId);
            return RedirectToAction("Providers", "Admin");
        }
        [Auth("admin")]
        [HttpGet]
        public IActionResult CreateProviderAccount()
        {
            ProviderProfileData data = createProviderACService.getallList();
            return View(data);
        }

        [Auth("admin")]
        [HttpPost]
        public IActionResult CreateProviderAccount(ProviderProfileData model)
        {
            if (ModelState.IsValid)
            {
                string? UserEmail = Request.Cookies["UserId"];
                createProviderACService.CreateAccount(model, UserEmail);
            }
            return RedirectToAction("Providers", "Admin");
        }
        [Auth("admin", "Accounts")]
        public IActionResult ManageAccess()
        {
            List<RoleData> data = accessRolesService.getAllRoles();
            return View(data);
        }
        [Auth("admin")]
        public IActionResult UserAccess()
        {
            return View();
        }


        public IActionResult GetUserAccess(string search)
        {
            List<UserAccessData> data = userAccessService.getData(search);
            return PartialView("_UserAccessTable", data);

        }

        [Auth("admin")]
        [HttpGet]
        public IActionResult CreateAdminAccount()
        {
            AdminAccountData data = createAdminACService.getAllList();
            return View(data);
        }

        [Auth("admin")]
        [HttpPost]
        public IActionResult CreateAdminAccount(AdminAccountData model)
        {
            if (ModelState.IsValid)
            {
                string? UserEmail = Request.Cookies["UserId"];

                createAdminACService.CreateAccount(model, UserEmail);

            }
            return RedirectToAction("UserAccess", "Admin");
        }

        [Auth("admin", "Role")]
        public IActionResult CreateRoleAll()
        {
            return View();
        }

        public void CreateRole(string RoleName, string AccountType, List<int> selectedMenu)
        {
            accessRolesService.CreateRole(RoleName, AccountType, selectedMenu);
        }

        public IActionResult GetMenus(string actype)
        {
            int type = int.Parse(actype);

            List<FetchDTO> data = fetchDataService.GetMenus(type);
            data.Select(a => new
            {
                id = a.Id,
                name = a.Name
            }).ToList();

            return Ok(data);


        }

        public IActionResult SelectedMenu(string actype, int roleid)
        {
            int type = int.Parse(actype);
            List<SelectedMenus> data = fetchDataService.GetSelectedMenu(type, roleid);
            data.Select(a => new
            {
                id = a.id,
                name = a.name,
                isSelected = a.isSelected
            }).ToList();

           

            return Ok(data);

        }

        [Auth("admin")]
        [HttpGet]
        public IActionResult EditRole(int editid)
        {

            RoleData data = accessRolesService.GetOneRole(editid);


            return View(data);
        }

        [Auth("admin")]
        [HttpPost]
        public IActionResult EditRole(RoleData model)
        {
            accessRolesService.SetOneRole(model);
            return View();
        }

        public IActionResult DeleteRole(int delete_id)
        {
            accessRolesService.deleteRole(delete_id);
            return RedirectToAction("ManageAccess", "Admin");
        }

        [Auth("admin", "Scheduling")]
        public IActionResult Scheduling()
        {
            return View();
        }

        public IActionResult GetShiftByMonth(int month, int? regionId)
        {
            List<ScheduleModel> data = providerScheduleService.GetShift(month, regionId);
            return Ok(data);
        }
        public IActionResult GetPhyscianDataForShift(int? region)
        {
            if (region == 0)
            {
                List<ScheduleModel> data = providerScheduleService.PhysicianAll();
                return Ok(data);
            }
            else
            {
                List<ScheduleModel> data = providerScheduleService.PhysicianByRegion(region);
                return Ok(data);
            }

        }

        public IActionResult IsShiftValid(int Regionid, int Physicianid, DateOnly Startdate, TimeOnly Starttime, TimeOnly Endtime, int Isrepeat, int[] WeekDayForRepeat, int Repeatupto)
        {
            string? UserEmail = Request.Cookies["UserId"];

            List<ValidShiftsData> response = providerScheduleService.isShiftValid(Regionid, Physicianid, Startdate, Starttime, Endtime, Isrepeat, WeekDayForRepeat, Repeatupto );
            providerScheduleService.CreateShift(response, UserEmail);
            return Ok();
        }
       

        public IActionResult GetShiftDetails(int shiftid)
        {


            shift obj = providerScheduleService.GetShiftDetails(shiftid);

            return Ok(obj);

        }

        public IActionResult ProviderOnCall()
        {
            return View();
        }
        public IActionResult GetProviders(string region)
        {
            List<OncallProviderData> data = providerOnCallService.getOnCallProviders(region);
            return PartialView("_ProvidersOnCall", data);
        }
        public IActionResult RequestedShifts()
        {

            return View();
        }

        public IActionResult ReturnShift(int id)
        {
            providerScheduleService.ReturnShift(id);
            return Ok();
        }

        public IActionResult DeleteShift(int id)
        {
            providerScheduleService.DeleteShift(id);
            return Ok();
        }

        public IActionResult EditShift(int shiftId, DateTime Startdate, TimeOnly Starttime, TimeOnly Endtime)
        {
            providerScheduleService.EditShift(shiftId, Startdate, Starttime, Endtime);
            return Ok();
        }

        public IActionResult GetShiftTable(string search, bool month)
        {
            List<ShiftTableData> data = requestedShiftsService.GetPendingShifts(search, month);
            return PartialView("_ShiftTable", data);
        }

        public IActionResult ApproveShifts(int[] shifts)
        {
            requestedShiftsService.ApproveShifts(shifts);
            return Ok();
        }

        public IActionResult DeleteShifts(int[] shifts)
        {
            requestedShiftsService.DeleteShift(shifts);
            return Ok();
        }
        [Auth("admin", "ProviderLocation")]
        public IActionResult ProviderLocation()
        {
            return View();

        }

        public IActionResult getProviderLocationData()
        {
            List<ProviderLocationData> data = providerLocationService.getProviderLocation();
            return Ok(data);
        }

        [Auth("admin", "VendorsInfo")]
        public IActionResult Vendors()
        {
            return View();
        }

        public IActionResult GetVendorsTable(string proId, string search)
        {
            List<VendorsData> data = vendorsService.GetVendors(proId, search);
            return PartialView("_VendorsTable", data);
        }
        public IActionResult FetchProfessions()
        {
            List<FetchDTO> data = fetchDataService.FetchProfession();

            data.Select(a => new
            {
                id = a.Id,
                name = a.Name
            }).ToList();          

            return Ok(data);
        }
        [HttpGet]
        public IActionResult AddBusiness()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBusiness(CreateBusinessData model)
        {
            vendorsService.CreateBusiness(model);
            return View();
        }

        public IActionResult DeleteVendor(int id)
        {
            vendorsService.DeleteVendor(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult UpdateBusiness(int vendorid)
        {
            CreateBusinessData model = vendorsService.getDataOfVendor(vendorid);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateBusiness(CreateBusinessData model)
        {
            vendorsService.UpdateVendorData(model);
            return RedirectToAction("Vendors", "Admin");
        }

        public IActionResult SearchRecords()
        {
            return View();
        }
        public IActionResult GetAllRecords()
        {
            List<SearchRecordData> data = searchRecordsService.getAllRequests();
            return PartialView("_SearchRecordsTable", data);
        }

        public IActionResult GetRecordsBySearch(int RequestStatus, string PatientName, int RequestType, DateTime FromDateOfService, DateTime ToDateOfService, string ProviderName, string Email, string Phone)
        {
            List<SearchRecordData> data = searchRecordsService.getRecordBySearch(RequestStatus, PatientName, RequestType, FromDateOfService, ToDateOfService, ProviderName, Email, Phone);
            return PartialView("_SearchRecordsTable", data);
        }
        public IActionResult ExportSearchRecords(int RequestStatus, string PatientName, int RequestType, DateTime FromDateOfService, DateTime ToDateOfService, string ProviderName, string Email, string Phone, Exception exception)
        {
            List<SearchRecordData> data = searchRecordsService.getRecordBySearch(RequestStatus, PatientName, RequestType, FromDateOfService, ToDateOfService, ProviderName, Email, Phone);
            if (data.Count > 0)
            {
                var file = ExcelHelper.CreateFile(data);
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "requests.xlsx");
            }

            return BadRequest();
        }
        public IActionResult DeleteRequestPermanently(int reqid)
        {
            searchRecordsService.DeleteRequest(reqid);
            return Ok();
        }
        [Auth("admin", "EmailLogs")]
        public IActionResult EmailLogs()
        {
            return View();
        } 
        public IActionResult FetchRoles()
        {

            List<FetchDTO> data= fetchDataService.FetchRoles();
            data.Select(a => new
            {
                id = a.Id,
                name = a.Name
            });


            return Ok(data);
        }
        public IActionResult GetAllEmails()
        {
            List<EmailLogData> data = emailLogService.getAllMail();
            return PartialView("_EmailLogTable", data);
        } 

        public IActionResult EmailBySearch(int Role, string ReceiverName, string Email, DateTime CreatedDate, DateTime SentDate)
        {
            List<EmailLogData> data = new();
           
                data = emailLogService.getEmailBySearch(Role, ReceiverName, Email, CreatedDate, SentDate);
            
            return PartialView("_EmailLogTable", data);
        }
        [Auth("admin", "SMSLogs")]
        public IActionResult SMSLogs()
        {
            return View();
        } 
        public IActionResult GetAllSMS()
        {
            List<SMSLogData> data = smsLogService.getAllSMS();

            return PartialView("_SMSLogTable", data);
        }

        public IActionResult SMSBySearch( int Role, string ReceiverName, string Mobile, DateTime CreatedDate, DateTime SentDate)
        {
            List<SMSLogData> data = smsLogService.getSMSBySearch(Role, ReceiverName, Mobile, CreatedDate, SentDate);

            return PartialView("_SMSLogTable", data);

        }
        [Auth("admin", "PatientRecords")]
        public IActionResult PatientRecords(int userid)
        {
            List<PatientRecordData> data = patientHistroyService.getPatientRecord(userid);
            return View(data);
        }

        [Auth("admin", "Histroy")]
        public IActionResult PatientHistroy()
        {
            return View();
        } 
        public IActionResult GetAllPatients()
        {
            List<PatientHistroyData> data = patientHistroyService.getAllUsers();
            return PartialView("_PatientHistroyTable", data);
        }
        public IActionResult GetPatientBySearch(string FirstName, string LastName, string Email, string Phone)
        {
            List<PatientHistroyData> data = patientHistroyService.getUsersBySearch(FirstName, LastName, Email, Phone);
            return PartialView("_PatientHistroyTable", data);
        }

        [Auth("admin", "BlockedHistory")]
        public IActionResult BlockedHistroy()
        {
            return View();
        }
        public IActionResult GetAllBlockRequest()
        {
            List<BlockHistroyData> data = BlockHistroyService.getAllRequest();

            return PartialView("_BlockHistroyTable", data);
        }
        public IActionResult BlockRequestSearch(string FirstName, DateTime Date, string Email,string Phone)
        {
            List<BlockHistroyData> data = BlockHistroyService.getBlockRequestBySearch(FirstName, Date, Email, Phone);

            return PartialView("_BlockHistroyTable", data);
        }
        public IActionResult UnblockRequest(string reqid)
        {
            BlockHistroyService.unblockRequest(reqid);
            return Ok();
        }
    }
}
