using HMSUserAPI.Exceptions;
using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.Context;
using HMSUserAPI.Models.DTOs;
using HMSUserAPI.Models.Logger;
using HMSUserAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;

namespace TestHMSUserAPI
{
    [TestClass]
    public class UnitTestBl2
    {

        public DbContextOptions<UserContext> TestInitialize()
        {

            var contextOptions = new DbContextOptionsBuilder<UserContext>()
                                    .UseInMemoryDatabase(databaseName: "userInMemory").
                                    ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                    .Options;
            return contextOptions;


        }



        [TestMethod]
        public async Task TestGetAllPatient()
        {

            using (var context = new UserContext(TestInitialize()))
            {


                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IPatientAction patientAction = new PatientService(repo, tokenGenerate, generatePassword);
                var user1 = await patientAction.GetAllDoctor();
                Assert.IsNotNull(user1);

            }
        }


        [TestMethod]
        public async Task TestPatientRegister()
        {

            using (var context = new UserContext(TestInitialize()))
            {


                var user = new User();
                user.Id = 5;
                user.Role = "doctor";
                user.Email = "madhanmani0601@gmail.com";
                user.PasswordHash = new byte[] { 1, 2, 3, 4 };
                user.HashKey = new byte[] { 1, 2, 3, 4 };
                user.UserDetail = new UserDetail();
                user.UserDetail.UserDetailID = 1;
                user.UserDetail.FirstName = "madhan";
                user.UserDetail.PhoneNUmber = "1234567890";
                user.UserDetail.LastName = "raj";
                user.UserDetail.Address = "test address";
                user.UserDetail.DateOfBirth = new DateTime();
                user.UserDetail.Gender = "male";
                user.UserDetail.Patient = new Patient();
                user.UserDetail.Patient.PatientID = 1;
                user.UserDetail.Patient.EmergencyContactName = "test";
                user.UserDetail.Patient.EmergencyContactPhone = "1245435354";
                user.UserDetail.Patient.BloodGroup = "a+";
                user.UserDetail.Doctor = new Doctor();
                user.UserDetail.Doctor.DoctorID = 1;
                user.UserDetail.Doctor.ApprovedStatus = "approved";
                user.UserDetail.Doctor.Active = "active";
                user.UserDetail.Doctor.ConsultingFees = 1000;
                user.UserDetail.Doctor.Specialization = "test";
                user.UserDetail.Doctor.YearOfExperience = 10;
                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IPatientAction patientAction = new PatientService(repo, tokenGenerate, generatePassword);
                await Assert.ThrowsExceptionAsync<UserException>(async () =>
                {
                    var user1 = await patientAction.PatientRegister(user);
                });
            }
        }


        [TestMethod]
        public async Task TestPatientRegister2()
        {

            using (var context = new UserContext(TestInitialize()))
            {


                var user = new User();
                user.Id = 5;
                user.Role = "doctor";
                user.Email = "madhanmani0601@gmail.com";
                user.PasswordHash = new byte[] { 1, 2, 3, 4 };
                user.HashKey = new byte[] { 1, 2, 3, 4 };
                user.UserDetail = new UserDetail();
                user.UserDetail.UserDetailID = 1;
                user.UserDetail.FirstName = "madhan";
                user.UserDetail.PhoneNUmber = "1234567890";
                user.UserDetail.LastName = "raj";
                user.UserDetail.Address = "test address";
                user.UserDetail.DateOfBirth = new DateTime();
                user.UserDetail.Gender = "male";
                user.UserDetail.Patient = new Patient();
                user.UserDetail.Patient.PatientID = 1;
                user.UserDetail.Patient.EmergencyContactName = "test";
                user.UserDetail.Patient.EmergencyContactPhone = "1245435354";
                user.UserDetail.Patient.BloodGroup = "a+";

                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IPatientAction patientAction = new PatientService(repo, tokenGenerate, generatePassword);
                await Assert.ThrowsExceptionAsync<UserException>(async () =>
                {
                    var user1 = await patientAction.PatientRegister(user);
                });
            }
        }

        [TestMethod]
        public async Task TestPatientRegister3()
        {

            using (var context = new UserContext(TestInitialize()))
            {


                var user = new User();
                user.Id = 5;
                user.Role = "doctor";
                user.Email = "madhanma1@gmail.com";
                user.PasswordHash = new byte[] { 1, 2, 3, 4 };
                user.HashKey = new byte[] { 1, 2, 3, 4 };
                user.UserDetail = new UserDetail();
                user.UserDetail.UserDetailID = 1;
                user.UserDetail.FirstName = "madhan";
                user.UserDetail.PhoneNUmber = "1234567890";
                user.UserDetail.LastName = "raj";
                user.UserDetail.Address = "test address";
                user.UserDetail.DateOfBirth = new DateTime();
                user.UserDetail.Gender = "male";
                user.UserDetail.Patient = new Patient();
                user.UserDetail.Patient.PatientID = 1;
                user.UserDetail.Patient.EmergencyContactName = "test";
                user.UserDetail.Patient.EmergencyContactPhone = "1245435354";
                user.UserDetail.Patient.BloodGroup = "a+";
                user.UserDetail.Doctor = new Doctor();
                user.UserDetail.Doctor.DoctorID = 1;
                user.UserDetail.Doctor.ApprovedStatus = "approved";
                user.UserDetail.Doctor.Active = "active";
                user.UserDetail.Doctor.ConsultingFees = 1000;
                user.UserDetail.Doctor.Specialization = "test";
                user.UserDetail.Doctor.YearOfExperience = 10;
                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IPatientAction patientAction = new PatientService(repo, tokenGenerate, generatePassword);
                Assert.IsNull(await patientAction.PatientRegister(user));
            }
        }



        [TestMethod]
        public async Task TestPatientUpdate1()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var patientUpdateDto = new PatientUpdateDTO
                {
                    Id = 3,
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Address = "123 Main Street",
                    Phone = "1234567890",
                    EmergencyContactName = "John Doe",
                    EmergencyContactPhone = "9876543210",
                    BloodGroup = "A+"
                };

                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IPatientAction patientAction = new PatientService(repo, tokenGenerate, generatePassword);
                var user = await patientAction.UpdatePatientDetails(patientUpdateDto);
                var doctorfiler = new UserDTO
                {
                    Id = 3
                };
                var updateUser = await repo.Get(3);
                Assert.IsNotNull(user);
                Assert.AreEqual("1234567890", updateUser.UserDetail.PhoneNUmber);

            }
        }

        [TestMethod]
        public async Task TestPatientUpdate2()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var patientUpdateDto = new PatientUpdateDTO
                {
                    Id = 6,
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Address = "123 Main Street",
                    Phone = "1234567890",
                    EmergencyContactName = "John Doe",
                    EmergencyContactPhone = "9876543210",
                    BloodGroup = "A+"
                };



                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IPatientAction patientAction = new PatientService(repo, tokenGenerate, generatePassword);
                Assert.IsNull(await patientAction.UpdatePatientDetails(patientUpdateDto));
            }


        }


        [TestMethod]
        public async Task TestGetPatient2()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var patientDTO = new UserDTO
                {
                    Id = 3
                };


                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IPatientAction patientAction = new PatientService(repo, tokenGenerate, generatePassword);
                var patient = await patientAction.GetPatientDetail(patientDTO);
                Assert.IsNotNull(patient);


            }


        }


        [TestMethod]
        public async Task TestGetDoctorbasedonFilter2()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var doctorFilterDTO = new DoctorFilterDTO
                {
                    Active="active"
                };


                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IPatientAction patientAction = new PatientService(repo, tokenGenerate, generatePassword);
                var patients = await patientAction.GetAllDoctorBasedOnFilters(doctorFilterDTO);
                Assert.IsNotNull(patients);


            }


        }




    }
}