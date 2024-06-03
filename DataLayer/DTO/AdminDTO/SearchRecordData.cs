﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.AdminDTO
{
    public class SearchRecordData
    {
        public string? PatientName { get; set; }
        public string? Requestor { get; set;}
        public int RequestId { get; set;}
        public DateTime? DateOfService { get; set; }
        public DateTime? CloseCaseDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? zip { get; set; }
        public int  ? RequestStatus { get; set; }
        public string? Physician { get; set; }
        public string? PhysicianNote { get; set; }
        public string? CancelledNote { get; set; }
        public string? AdminNote { get; set; }
        public string? PatientNote { get; set; }

    }
}
