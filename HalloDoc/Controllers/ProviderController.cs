using BusinessLayer.Repository.Implementation;
using BusinessLayer.Repository.Interface;
using BusinessLayer.Utility;
using DataLayer.DTO;
using DataLayer.DTO.AdminDTO;
using DataLayer.DTO.ProviderDTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;


namespace HalloDoc.Controllers
{
    public class ProviderController : Controller
    {

        private readonly IProviderDashboard providerDashboardService;
        private readonly IConcludeCare concludeCareService;
        private readonly IProviderProfile providerProfileService;
        private readonly IProviderProfileEditByAdmin providerProfileEditByAdmin;
        private readonly BusinessLayer.Utility.IEmailSender emailSenderService;
        private readonly IProviderSchedule providerScheduleService;
        private readonly IScheduleOfProvider scheduleOfProviderService;
        private readonly IFetchData fetchDataService;
        private readonly IEmailLogs emailLogService;
        private readonly IEncounterform encounterformService;

        public ProviderController(
            IProviderDashboard providerDashboard, 
            IConcludeCare concludeCare, 
            IProviderSchedule providerSchedule,
            IProviderProfile providerProfile,
            IEmailLogs emailLog,
            IEncounterform encounterform,
            IProviderProfileEditByAdmin providerProfileEditByAdmin,
            BusinessLayer.Utility.IEmailSender emailSenderService,
            IScheduleOfProvider scheduleOfProvider,
            IFetchData fetchData)
        {
      
            this.providerDashboardService = providerDashboard;
            this.concludeCareService = concludeCare;
            this.providerProfileService = providerProfile;
            this.providerProfileEditByAdmin = providerProfileEditByAdmin;
            this.providerScheduleService = providerSchedule;
            this.emailSenderService = emailSenderService;
            this.encounterformService = encounterform;
            this.emailLogService = emailLog;
            this.scheduleOfProviderService = scheduleOfProvider;
            this.fetchDataService = fetchData;
        }


        [Auth("provider")]
        public IActionResult ProviderDashboard()
        {
            string? UserEmail = Request.Cookies["UserId"];
            ProviderDashboardData obj = providerDashboardService.Count(UserEmail);
            return View(obj);
        }

        public IActionResult getRequestTable(int status, int requesttype, string search)
        {
            string? UserEmail = Request.Cookies["UserId"];

            List<ProviderRequestData> data = providerDashboardService.getRequestsForPhysician(status, requesttype, search, UserEmail);
            return PartialView("_RequestTable", data);
        }

      

        public IActionResult AcceptRequest(int reqid)
        {
            string? UserEmail = Request.Cookies["UserId"];

            providerDashboardService.AccepRequest(reqid, UserEmail);
            return Ok();
        }

        public IActionResult TranferReqAdmin(int transferid, string tranfernote)
        {
            string? UserEmail = Request.Cookies["UserId"];

            providerDashboardService.TransferReqToAdmin(transferid, tranfernote,UserEmail );

            return Ok();
        }
        public IActionResult SelectTypeOfCare(int careid, int selecttype)
        {
            providerDashboardService.SelectTypeOfCare(careid, selecttype);

            return Ok();
        }

        public IActionResult HousCallClick(int reqid)
        {
            providerDashboardService.HouseCallClick(reqid);

            return Ok();
        }

        [Auth("provider")]
        public IActionResult ConcludeCare(int reqId)
        {
            ConcludeCareData data = concludeCareService.getData(reqId);
            return View(data);
        }

        public bool IsEncounterFinalized(int reqid)
        {
            bool res = providerDashboardService.IsFinalized(reqid);
            return res;
        }
        [Auth("provider", "MyProfile")]
        public IActionResult Profile()
        {
            string? UserEmail = Request.Cookies["UserId"];

            int id = providerProfileService.phyid(UserEmail);
            ProviderProfileData data = providerProfileEditByAdmin.getProviderProfileData(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult FileUploadConclude(List<IFormFile> ConcludeFiles, int concludeid)
        {
            providerDashboardService.fileUpload(ConcludeFiles, concludeid);
            return RedirectToAction("ConcludeCare", new { reqId =concludeid });
        }
        public IActionResult GeneratePDF(int requestId)
        {
            var encounterFormView = providerDashboardService.getEncounterForm(requestId);
            if (encounterFormView == null)
            {
                return NotFound();
            }
            // return View("EncounterFormDetails", encounterFormView);
            return new ViewAsPdf("EncounterFormDetails", encounterFormView)
            {
                FileName = "Encounter_Form.pdf"
            };

        }

        [Auth("provider", "Encounter")]
        public IActionResult EncounterFormDetails(EncounterPDF model)
        {

            return View(model);
        }

        [HttpPost]
        public IActionResult ConcludeRequest(int reqid, string note)
        {
            string? UserEmail = Request.Cookies["UserId"];

            concludeCareService.concludetherequest(reqid, UserEmail, note);
            return Ok();
        }

        public IActionResult SendRequestToAdminForProfile(string Message)
        {
            string? UserEmail = Request.Cookies["UserId"];
            int id = providerProfileService.phyid(UserEmail);

            EmailLogDto obj = new EmailLogDto()
            {
                Template = "Provider message :" + Message,
                EmailId = "vishva.rami@etatvasoft.com",
                PhysicianId = id,
                Subject = "Edit Provider Profile"
            };

            emailLogService.addEmailLog(obj);
            emailSenderService.SendEmailAsync("vishva.rami@etatvasoft.com", "Edit Provider Profile", "Provider message: "+ Message);

            return Ok();
        }

        public IActionResult EditPassword(int ProviderId, string Password)
        {

            providerProfileService.ResetPassword(ProviderId, Password);
            ProviderProfileData data = providerProfileEditByAdmin.getProviderProfileData(ProviderId);

            return RedirectToAction("Profile", data);
        }

        [Auth("provider","MySchedule")]
        public IActionResult ProvidersSchedule()
        {
            return View();
        }

        public IActionResult GetShiftByMonth(int month, int? regionId)
        {
            string? UserEmail = Request.Cookies["UserId"];
            int id = providerProfileService.phyid(UserEmail);

            List<ScheduleModel> data = scheduleOfProviderService.GetShift(month, regionId, id);
            return Ok(data);
        }
        public IActionResult GetPhyscianDataForShift(int? region)
        {
            string? UserEmail = Request.Cookies["UserId"];
            int id = providerProfileService.phyid(UserEmail);

            if (region == 0)
            {
                List<ScheduleModel> data = scheduleOfProviderService.PhysicianAll(id);
                return Ok(data);
            }
            else
            {
                List<ScheduleModel> data = scheduleOfProviderService.PhysicianByRegion(region, id);
                return Ok(data);
            }

        }
        public IActionResult FetchRegions()
        {
            string? UserEmail = Request.Cookies["UserId"];
            int id = providerProfileService.phyid(UserEmail);
            List<FetchDTO> data = fetchDataService.RegionsOfPhy(id);

            return Ok(data);
        }
        public IActionResult IsShiftValid(int Regionid, DateOnly Startdate, TimeOnly Starttime, TimeOnly Endtime, int Isrepeat, int[] WeekDayForRepeat, int Repeatupto)
        {
            string? UserEmail = Request.Cookies["UserId"];
            int id = providerProfileService.phyid(UserEmail);

            List<ValidShiftsData> response = scheduleOfProviderService.isShiftValid(Regionid, id, Startdate, Starttime, Endtime, Isrepeat, WeekDayForRepeat, Repeatupto);
            scheduleOfProviderService.CreateShift(response, UserEmail);
            return Ok();
        }
        [Auth("provider")]
        [HttpGet]
        public IActionResult EncounterProvider(int encreqid)
        {
            TempData["encreqid"] = encreqid;
            EncounterFormData model = encounterformService.encounterformdata(encreqid);
            return View(model);
        }
        [HttpPost]
        public IActionResult EncounterProvider(EncounterFormData model)
        {

            encounterformService.encounterSaveChanges(model, model.requestid);
            return View(model);
        }
        public IActionResult FinalizeTheEncForm(int RequestId)
        {
            encounterformService.Finalizeform(RequestId);

            return RedirectToAction("ProviderDashboard");
        } 
        public bool IsFormAvailable(int RequestId)
        {
            bool v = encounterformService.IsFormAvailable(RequestId);
            return v;

        }

       
    }
}
