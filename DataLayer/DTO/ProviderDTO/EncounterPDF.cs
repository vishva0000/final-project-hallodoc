﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.ProviderDTO
{
    public class EncounterPDF
    {
        public string Patientname { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfService { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? HistoryOfIllness { get; set; }
        public string? MedicalHistroy { get; set; }
        public string? Medications { get; set; }
        public string Allergies { get; set; }
        public string? Temp { get; set; }
        public string? HR { get; set; }
        public string? RR { get; set; }
        public string? BloodPressureSystolic { get; set; }
        public string? BloodPressureDiastolic { get; set; }
        public string? O2 { get; set; }
        public string? Pain { get; set; }
        public string? Heent { get; set; }
        public string? CV { get; set; }
        public string? Chest { get; set; }
        public string? ABD { get; set; }
        public string? Extremeties { get; set; }
        public string? Skin { get; set; }
        public string? Neuro { get; set; }
        public string? Other { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }
        public string MedicationDispensed { get; set; }
        public string Procedures { get; set; }
        public string FollowUp { get; set; }

    }
}
