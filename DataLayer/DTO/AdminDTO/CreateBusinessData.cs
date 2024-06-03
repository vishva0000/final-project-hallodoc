using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class CreateBusinessData
    {
        [Required(ErrorMessage = "Business Name is required")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Please select Profession")]
        public int Professionid { get; set; }

        public string? faxNumber { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Business Contact is required")]
        public string? BusinessContact { get; set; }
        public string? City { get; set; }
        public string? street { get; set; }
        public string? state { get; set; }
        public string? Zip { get; set; }
        public int? vendorid { get; set; }

        public List<allprofession> Professions { get; set; }
        public class allprofession 
        { 
            public int profid { get; set; }
            public string name { get; set; }
        }


    }
}
