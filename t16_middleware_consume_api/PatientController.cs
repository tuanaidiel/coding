// ASP.NET

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collection.Generic;

namespace LISBackend.Controllers
{

    public class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MedicalRecordNumber { get; set; }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime (1980, 5, 15),
                    Gender = "Female",
                    MedicalRecordNumber = "MRN001"
                },

                new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Tuan",
                    LastName = "Aidiel",
                    DateOfBirth = new DateTime (2001, 3, 06),
                    Gender = "Male",
                    MedicalRecordNumber = "MRN002"
                }
            };

            return Ok(patients);
        }
    }
}