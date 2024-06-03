using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTO
{
    public class ConciergeRequestModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string C_Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string C_Lastname { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string C_Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string C_Email { get; set; }

      
        public string? C_Street { get; set; }
        public string? C_State { get; set; }

        public string? C_Location { get; set; }
        public string? C_City { get; set; }
        public string? C_Zipcode { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string P_Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string P_Lastname { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime P_dob { get; set; }

        [Required(ErrorMessage = "Symptom is required")]
        public string P_symp { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string P_phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string P_email { get; set; }

        public string? P_Location { get; set; }
    }
}
