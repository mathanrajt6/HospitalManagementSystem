﻿using HMSUserAPI.Models.DTOs;
using HMSUserAPI.Models;

namespace HMSUserAPI.Interfaces
{
    public interface IPatientAction 
    {
        public Task<List<DoctorDTO>?> GetAllDoctor();
        public Task<List<DoctorDTO>?> GetAllDoctorBasedOnFilters(DoctorFilterDTO doctorFilterDTO);
        public Task<UserDTO?> PatientRegister(User user);
        public Task<PatientUpdateDTO?> UpdatePatientDetails(PatientUpdateDTO patientUpdateDTO);
        public Task<PatientDTO?> GetPatientDetail(UserDTO userDTO);


    }
}
