using BusinessLayer.Repository.Interface;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementation
{
    public class Auth : Attribute, IAuthorizationFilter
    {
        private readonly List<string> _role;
        private readonly string _menu;
        public HallodocContext db;

        public Auth(string role, string menu = null)
        {
            _role = role.Split(',').Select(a => a.Trim()).ToList();
            _menu = menu;
        }
         

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            HallodocContext? _db = context.HttpContext.RequestServices.GetService<HallodocContext>();
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
                return;

            var jwtService = context.HttpContext.RequestServices.GetService<IJwtService>();
            if (jwtService == null)
            {
                return;
            }

            var token = context.HttpContext.Session.GetString("jwttoken");
            var mailid = context.HttpContext.Session.GetString("userid");
            var url = context.HttpContext.Request.Path;
            if (token == null || !jwtService.ValidateToken(token, out JwtSecurityToken jwtToken))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "PatientLogin" }));
                return;

            }

            var roleClaim = jwtToken.Claims.Where(a => a.Type == "role").FirstOrDefault();
            var rolevalue = roleClaim.Value;
            if (rolevalue == null)  
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "PatientLogin" }));
                return;
            }

            //if(string.IsNullOrWhiteSpace(_role) || rolevalue != _role)
            //{
            //    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "AccessDenied" }));
            //    return;
            //}


           if(!_role.Contains(rolevalue))
           {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "AccessDenied" }));
                return;
           }

            if (_menu != null)
            {
                //if (_role.Contains("admin"))
                if (rolevalue=="admin")
                {
                    int roleid = (int)_db.Admins.Where(a => a.AspNetUser.Email == mailid).FirstOrDefault().RoleId;
                    int menuid = (int)_db.Menus.Where(a => a.Name == _menu && a.AccountType == 1).FirstOrDefault().MenuId;
                    List<int> avimenu = _db.RoleMenus.Where(a => a.RoleId == roleid).Select(b => b.MenuId).ToList();
                    if (avimenu.Contains(menuid))
                    {
                        return;

                    }
                    else
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "AccessDenied" }));
                        return;
                    }
                //}else if (_role.Contains("provider"))
                }else if (rolevalue == "provider")
                {
                    int roleid = (int)_db.Physicians.Where(a => a.AspNetUser.Email == mailid).FirstOrDefault().RoleId;
                    int menuid = (int)_db.Menus.Where(a => a.Name == _menu && a.AccountType == 2).First().MenuId;
                    List<int> avimenu = _db.RoleMenus.Where(a => a.RoleId == roleid).Select(b => b.MenuId).ToList();
                    if (avimenu.Contains(menuid))
                    {
                        return;

                    }
                    else
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "AccessDenied" }));
                        return;
                    }
                }
            }

        }
    }
}
