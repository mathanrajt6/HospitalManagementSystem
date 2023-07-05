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
    public class UnitTest2
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
                IDoctorAction doctorAction = new DoctorService(repo, tokenGenerate, generatePassword);
                var user1 = await doctorAction.GetAllPatient();
                Assert.IsNotNull(user1);
                Assert.IsNotNull(user1);

            }
        }


        //[TestMethod]
        //public async Task TestADD1()
        //{


        //    using (var context = new UserContext(TestInitialize()))
        //    {
        //        var user = new User();
        //        user.Id = 1;
        //        user.Role = "admin";
        //        user.Email = "madhanmani0601@gmail.com";
        //        user.PasswordHash = new byte[] { 1, 2, 3, 4 };
        //        user.HashKey = new byte[] { 1, 2, 3, 4 };
        //        user.UserDetail = new UserDetail();
        //        user.UserDetail.UserDetailID = 1;
        //        user.UserDetail.FirstName = "madhan";
        //        user.UserDetail.PhoneNUmber = "1234567890";
        //        user.UserDetail.LastName = "raj";
        //        user.UserDetail.Address = "test address";
        //        user.UserDetail.DateOfBirth = new DateTime();
        //        user.UserDetail.Gender = "male";
        //        //user.UserDetail.Patient = new Patient();
        //        //user.UserDetail.Patient.PatientID = 1;
        //        //user.UserDetail.Patient.EmergencyContactName = "test";
        //        //user.UserDetail.Patient.EmergencyContactPhone = "1245435354";
        //        //user.UserDetail.Patient.BloodGroup = "a+";
        //        //user.UserDetail.Doctor = new Doctor();
        //        //user.UserDetail.Doctor.DoctorID = 1;
        //        //user.UserDetail.Doctor.ApprovedStatus = "";
        //        //user.UserDetail.Doctor.Active = "active";
        //        //user.UserDetail.Doctor.ConsultingFees = 1000;
        //        //user.UserDetail.Doctor.Specialization = "test";
        //        //user.UserDetail.Doctor.YearOfExperience = 10;

        //        IRepo<User, int> repo = new UserRepo(context);

        //        var user1 = await repo.Add(user);
        //        Assert.IsNotNull(user1);
        //        Assert.IsNotNull(user1.UserDetail);

        //        Assert.AreEqual(user1.Id, user.Id);



        //    }
        //}


        [TestMethod]
        public async Task TestADD2()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var user = new User();
                user.Id = 2;
                user.Role = "doctor";
                user.Email = "madhan0601@gmail.com";
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
                user.UserDetail.Doctor = new Doctor();
                user.UserDetail.Doctor.DoctorID = 1;
                user.UserDetail.Doctor.ApprovedStatus = "approved";
                user.UserDetail.Doctor.Active = "active";
                user.UserDetail.Doctor.ConsultingFees = 1000;
                user.UserDetail.Doctor.Specialization = "test";
                user.UserDetail.Doctor.YearOfExperience = 10;

                IRepo<User, int> repo = new UserRepo(context);

                var user1 = await repo.Add(user);

                Assert.IsNull(user1?.UserDetail?.Patient);



            }
        }

        [TestMethod]
        public async Task TestADD3()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var user = new User();
                user.Id = 3;
                user.Role = "patient";
                user.Email = "madhanmani@gmail.com";
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
                user.UserDetail.Gender = "male";


                IRepo<User, int> repo = new UserRepo(context);

                var user1 = await repo.Add(user);

                Assert.IsNull(user1?.UserDetail?.Doctor);



            }
        }

        [TestMethod]
        public async Task TestDoctorRegister()
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
                IDoctorAction doctorAction = new DoctorService(repo, tokenGenerate, generatePassword);
                await Assert.ThrowsExceptionAsync<UserException>(async () =>
                {
                    var user1 = await doctorAction.DoctorRegister(user);
                });
            }
        }


        [TestMethod]
        public async Task TestDoctorRegister2()
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
                IDoctorAction doctorAction = new DoctorService(repo, tokenGenerate, generatePassword);
                await Assert.ThrowsExceptionAsync<UserException>(async () =>
                {
                    var user1 = await doctorAction.DoctorRegister(user);
                });
            }
        }

        [TestMethod]
        public async Task TestDoctorRegister3()
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
                IDoctorAction doctorAction = new DoctorService(repo, tokenGenerate, generatePassword);
                Assert.IsNull(await doctorAction.DoctorRegister(user));
            }
        }



        [TestMethod]
        public async Task TestDoctorRegisterUpdate1()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var doctorUpdateDto = new DoctorUpdateDTO
                {
                    Id = 2,
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Address = "123 Main Street",
                    Phone = "1234567890",
                    ConsultingFees = 2000,
                    Specialization = "Cardiology",
                    YearOfExperience = 10
                };

                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IDoctorAction doctorAction = new DoctorService(repo, tokenGenerate, generatePassword);
                var user = await doctorAction.UpdateDoctorDetails(doctorUpdateDto);
                var doctorfiler = new UserDTO
                {
                    Id = 2
                };
                var updateUser = await repo.Get(2);
                Assert.IsNotNull(user);
                Assert.AreEqual(10, updateUser.UserDetail.Doctor.YearOfExperience);
            }
        }

        [TestMethod]
        public async Task TestDoctorRegisterUpdate2()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var doctorUpdateDto = new DoctorUpdateDTO
                {
                    Id = 10,
                    DateOfBirth = new DateTime(1980, 5, 15),
                    Address = "789 Park Avenue",
                    Phone = "9876543210",
                    ConsultingFees = 2000,
                    Specialization = "Cardiology",
                    YearOfExperience = 10
                };


                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IDoctorAction doctorAction = new DoctorService(repo, tokenGenerate, generatePassword);
                Assert.IsNull(await doctorAction.UpdateDoctorDetails(doctorUpdateDto));
            }


        }
            [TestMethod]
            public async Task TestDoctorToggelstatus1()
            {

                using (var context = new UserContext(TestInitialize()))
                {

                    var doctorUpdateDto = new DoctorFilterDTO
                    {
                       
                        Id = 2,
                        
                    };

                    var doctorfiler = new UserDTO
                    {
                        Id = 2
                    };
                    IRepo<User, int> repo = new UserRepo(context);
                    ITokenGenerate tokenGenerate = new TokenGenerateService();
                    IGeneratePassword generatePassword = new GeneratePasswordService();
                    IDoctorAction doctorAction = new DoctorService(repo, tokenGenerate, generatePassword);
                    var user= await doctorAction.ToggleActive(doctorUpdateDto);
                    var updatedUser = await doctorAction.GetDoctorDetails(doctorfiler);

                    Assert.AreEqual("in-active",updatedUser?.Doctor?.Active);
                }
            }


        [TestMethod]
        public async Task TestDoctorToggelstatus2()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var doctorUpdateDto = new DoctorFilterDTO
                {

                    Id = 5,

                };

                var doctorfiler = new UserDTO
                {
                    Id = 5
                };
                IRepo<User, int> repo = new UserRepo(context);
                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IDoctorAction doctorAction = new DoctorService(repo, tokenGenerate, generatePassword);
                var user = await doctorAction.ToggleActive(doctorUpdateDto);
                Assert.IsNull(user);
            }
        }



      



    }
}