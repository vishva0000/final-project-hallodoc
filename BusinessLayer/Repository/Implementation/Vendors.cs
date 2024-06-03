using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interface;
using DataLayer.DTO.AdminDTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.Formula.Functions;
using static DataLayer.DTO.AdminDTO.CreateBusinessData;
using static DataLayer.DTO.AdminDTO.ProviderProfileData;

namespace BusinessLayer.Repository.Implementation
{
    public class Vendors : IVendors
    {
        public HallodocContext db;

        public Vendors(HallodocContext db)
        {
            this.db = db;

        }



        public List<VendorsData> GetVendors(string profId, string search)
        {
            int type = int.Parse(profId);
            List<VendorsData> data = new();
            var ProfType = db.HealthProfessionalTypes.ToList();

            if (type == 0)
            {

                var healthProfe = db.HealthProfessionals.Where(a => (new BitArray(1, false) == a.IsDeleted)).ToList()
                    .Where(a => (search.IsNullOrEmpty() ||
                        a.VendorName.Contains(search, StringComparison.CurrentCultureIgnoreCase))).ToList();
               
                foreach (var item in healthProfe)
                {
                    VendorsData d = new();
                    d.vendorId = item.VendorId;
                    d.profession = ProfType.Where(a => a.HealthProfessionalId == item.Profession).FirstOrDefault().ProfessionName;
                    d.faxNumber = item.FaxNumber;
                    d.businessContact = item.BusinessContact;
                    d.phoneNumber = item.PhoneNumber;
                    d.vendorName = item.VendorName;
                    d.email = item.Email;

                    data.Add(d);
                }

            }
            else
            {
                var healthProfe = db.HealthProfessionals.Where(a => (new BitArray(1, false) == a.IsDeleted) && (a.Profession == type)).ToList()
                   .Where(a => (search.IsNullOrEmpty() ||
                       a.VendorName.Contains(search, StringComparison.CurrentCultureIgnoreCase))).ToList();
               
                foreach (var item in healthProfe)
                {
                    VendorsData d = new();
                    d.vendorId = item.VendorId;
                    d.profession = ProfType.Where(a => a.HealthProfessionalId == item.Profession).FirstOrDefault().ProfessionName;
                    d.faxNumber = item.FaxNumber;
                    d.businessContact = item.BusinessContact;
                    d.phoneNumber = item.PhoneNumber;
                    d.vendorName = item.VendorName;
                    d.email = item.Email;

                    data.Add(d);
                }

            }
            return data;

        }

        public void CreateBusiness(CreateBusinessData model)
        {
            HealthProfessional business = new HealthProfessional()
            {
                VendorName = model.BusinessName,
                Email = model.Email,
                FaxNumber = model.faxNumber,
                BusinessContact = model.BusinessContact,
                PhoneNumber = model.phoneNumber,
                Address = model.street,
                City = model.City,
                State = model.state,
                Zip = model.Zip,
                CreatedDate = DateTime.Now,
                Profession = model.Professionid,
                IsDeleted = new BitArray(new bool[1] { false })

            };

            db.HealthProfessionals.Add(business);
            db.SaveChanges();


        }

        public void DeleteVendor(int id)
        {
            var vendor = db.HealthProfessionals.Where(a => a.VendorId == id).FirstOrDefault();
            vendor.IsDeleted = new BitArray(new bool[1] { true });

            db.HealthProfessionals.Update(vendor);
            db.SaveChanges();
        }

        public CreateBusinessData getDataOfVendor(int id)
        {
            CreateBusinessData data = new CreateBusinessData();

            var vendor = db.HealthProfessionals.Where(a => a.VendorId == id).FirstOrDefault();

            var allprofessions = db.HealthProfessionalTypes.ToList();
            data.BusinessName = vendor.VendorName;
            data.vendorid = vendor.VendorId;
            data.Professionid = (int)vendor.Profession;
            data.faxNumber = vendor.FaxNumber;
            data.Email = vendor.Email;
            data.BusinessContact = vendor.BusinessContact;
            data.phoneNumber = vendor.PhoneNumber;
            data.street = vendor.Address;
            data.City = vendor.City;
            data.state = vendor.State;
            data.Zip = vendor.Zip;

            List<allprofession> lis = new();
            foreach (var item in allprofessions)
            {
                allprofession obj = new allprofession()
                {
                    profid = item.HealthProfessionalId,
                    name = item.ProfessionName
                };
                lis.Add(obj);
            }
            data.Professions = lis;


            return data;
        }

        public void UpdateVendorData(CreateBusinessData model)
        {
            var vendor = db.HealthProfessionals.Where(a => a.VendorId == model.vendorid).FirstOrDefault();

            vendor.VendorName = model.BusinessName;
            vendor.Email = model.Email;
            vendor.FaxNumber = model.faxNumber;
            vendor.BusinessContact = model.BusinessContact;
            vendor.PhoneNumber = model.phoneNumber;
            vendor.Address = model.street;
            vendor.City = model.City;
            vendor.State = model.state;
            vendor.Zip = model.Zip;
            vendor.Profession = model.Professionid;
            vendor.ModifiedDate = DateTime.Now;

            db.HealthProfessionals.Update(vendor);
            db.SaveChanges();

        }
    }
}
