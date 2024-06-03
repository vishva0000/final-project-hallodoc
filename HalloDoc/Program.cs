
using DataLayer.Models;
using BusinessLayer.Repository.Implementation;
using BusinessLayer.Repository.Interface;
using BusinessLayer.Utility;

using Microsoft.EntityFrameworkCore;
using DataLayer.DTO.AdminDTO;
using AspNetCoreHero.ToastNotification.Extensions;
using AspNetCoreHero.ToastNotification;
using NPOI.Util;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HallodocContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSingleton<BusinessLayer.Utility.IEmailSender, EmailSender>();
builder.Services.AddTransient<IAdminDashboard, AdminDashboard>();
builder.Services.AddTransient<IRequestTable, RequestTable>();
builder.Services.AddTransient<IPatientRequest, PatientRequest>();
builder.Services.AddTransient<IFamilyRequest, FamilyRequest>();
builder.Services.AddTransient<IBusinessRequest, BusinessRequest>();
builder.Services.AddTransient<IConciergeRequest, ConciergeRequest>();
builder.Services.AddTransient<IRequestForMe, RequestForMe>();
builder.Services.AddTransient<IViewUploads, ViewUploads>();
builder.Services.AddTransient<ICreateRequest, CreateRequest>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<IEncounterform, Encounterform>();
builder.Services.AddTransient<ICloseCase, CloseCase>();
builder.Services.AddTransient<IAdminProfile, AdminProfile>();
builder.Services.AddTransient<IProviderData, ProviderData>();
builder.Services.AddTransient<IAccessRoles, AccessRoles>();
builder.Services.AddTransient<IProviderProfileEditByAdmin, ProviderProfileEditByAdmin>();
builder.Services.AddTransient<ICreateProviderAC, CreateProviderAC>();
builder.Services.AddTransient<IUserAccess, UserAccess>();
builder.Services.AddTransient<ICreateAdminAC, CreateAdminAC>();
builder.Services.AddTransient<IProviderSchedule, ProviderSchedule>();
builder.Services.AddTransient<IProviderOnCall, ProviderOnCall>();
builder.Services.AddTransient<IRequestedShifts, RequestedShifts>();
builder.Services.AddTransient<IProviderLocation, ProviderLocation>();
builder.Services.AddTransient<IVendors, Vendors>();
builder.Services.AddTransient<ISearchRecords, SearchRecords>();
builder.Services.AddTransient<IEmailLogs, EmailLogs>();
builder.Services.AddTransient<ISMSLog, SMSLog>();
builder.Services.AddTransient<IPatientHistroy, PatientHistroy>();
builder.Services.AddTransient<IBlockHistroy, BlockHistroy>();
builder.Services.AddTransient<IProviderDashboard, ProviderDashboard>();
builder.Services.AddTransient<IConcludeCare, ConcludeCare>();
builder.Services.AddTransient<IProviderProfile, ProviderProfile>();
builder.Services.AddTransient<IScheduleOfProvider, ScheduleOfProvider>();
builder.Services.AddTransient<IFetchData, FetchData>();
builder.Services.AddTransient<IViewCase, ViewCase>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseNotyf();
app.UseRotativa();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
