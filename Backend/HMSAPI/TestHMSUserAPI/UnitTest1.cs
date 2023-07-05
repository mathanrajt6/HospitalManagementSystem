using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.Context;
using HMSUserAPI.Models.Logger;
using HMSUserAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;

namespace TestHMSUserAPI
{
    [TestClass]
    public class UnitTest1
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

        [TestMethod]
        public async Task TestADD1()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var user = new User();
                user.Id = 1;
                user.Role = "admin";
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
                //user.UserDetail.Patient = new Patient();
                //user.UserDetail.Patient.PatientID = 1;
                //user.UserDetail.Patient.EmergencyContactName = "test";
                //user.UserDetail.Patient.EmergencyContactPhone = "1245435354";
                //user.UserDetail.Patient.BloodGroup = "a+";
                //user.UserDetail.Doctor = new Doctor();
                //user.UserDetail.Doctor.DoctorID = 1;
                //user.UserDetail.Doctor.ApprovedStatus = "";
                //user.UserDetail.Doctor.Active = "active";
                //user.UserDetail.Doctor.ConsultingFees = 1000;
                //user.UserDetail.Doctor.Specialization = "test";
                //user.UserDetail.Doctor.YearOfExperience = 10;

                IRepo<User, int> repo = new UserRepo(context);

                var user1 = await repo.Add(user);
                Assert.IsNotNull(user1);
                Assert.IsNotNull(user1.UserDetail);
                
                Assert.AreEqual(user1.Id, user.Id);



            }
        }


        [TestMethod]
        public async Task TestADD2()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var user = new User();
                user.Id = 2;
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
                user.UserDetail.Gender = "male";
                

                IRepo<User, int> repo = new UserRepo(context);

                var user1 = await repo.Add(user);
                
                Assert.IsNull(user1?.UserDetail?.Doctor);



            }
        }
        [TestMethod]
        public async Task TestGetAll1()
        {
            using (var context = new UserContext(TestInitialize()))
            {
                var repo = new UserRepo(context);

                var users = await repo.GetAll();
                Assert.AreEqual(2, users?.Count);
                
            }
        }


       

        [TestMethod]
        public async Task TestGetALL2()
        {

            using (var context = new UserContext(TestInitialize()))
            {
                var repo = new UserRepo(context);

                var users = await repo.GetAll();
                Assert.IsNotNull(users);
            }
        }


        [TestMethod]
        public async Task TestGetByID1()
        {

            using (var context = new UserContext(TestInitialize()))
            {
                var repo = new UserRepo(context);

                var user = await repo.Get(-1);
                Assert.IsNull(user);
            }
        }

        [TestMethod]
        public async Task TestGetByID2()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var repo = new UserRepo(context);

                var user1 = await repo.Get(3);
                Assert.AreEqual(3, user1?.Id);
                Assert.AreEqual("madhan", user1?.UserDetail?.FirstName);

            }
        }

        [TestMethod]
        public async Task TestGetByI3()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var repo = new UserRepo(context);
                var user1 = await repo.Get(2);
                Assert.IsNull( user1?.UserDetail?.Patient);


            }
        }


        [TestMethod]
        public async Task TestUpdate1()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var user = new User();
                user.Id = 1;
                user.Role = "admin";
                user.Email = "madhanmani0601@gmail.com";
                user.PasswordHash = new byte[] { 1, 2, 3, 4 };
                user.HashKey = new byte[] { 1, 2, 3, 4 };
                user.UserDetail = new UserDetail();
                user.UserDetail.UserDetailID = 1;
                user.UserDetail.FirstName = "madhanmani";
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
                var repo = new UserRepo(context);
                var user1 = await repo.Update(user);
                


            }
        }

        [TestMethod]
        public async Task TestUpdate2()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var user = new User();
                user.Id = 4;
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
                user.UserDetail.Doctor = new Doctor();
                user.UserDetail.Doctor.DoctorID = 1;
                user.UserDetail.Doctor.ApprovedStatus = "approved";
                user.UserDetail.Doctor.Active = "active";
                user.UserDetail.Doctor.ConsultingFees = 1000;
                user.UserDetail.Doctor.Specialization = "test";
                user.UserDetail.Doctor.YearOfExperience = 10;
                var repo = new UserRepo(context);
                var user1 = await repo.Update(user);
                Assert.IsNull(user1);


            }
        }


     

        public async Task TestUpdate3()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var user = new User();
                user.Id = 4;
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
                user.UserDetail.Patient.EmergencyContactPhone = "123654859";
                user.UserDetail.Patient.BloodGroup = "a+";
                user.UserDetail.Doctor = new Doctor();
                user.UserDetail.Doctor.DoctorID = 1;
                user.UserDetail.Doctor.ApprovedStatus = "un-approved";
                user.UserDetail.Doctor.Active = "active";
                user.UserDetail.Doctor.ConsultingFees = 1000;
                user.UserDetail.Doctor.Specialization = "test";
                user.UserDetail.Doctor.YearOfExperience = 10;
                var repo = new UserRepo(context);
                var user1 = await repo.Update(user);
                Assert.IsNotNull(user1);
                Assert.AreEqual("un-approved", user1?.UserDetail?.Doctor?.ApprovedStatus);
                Assert.AreEqual("123654859", user1?.UserDetail?.Patient?.EmergencyContactPhone);



            }
        }

        [TestMethod]
        public async Task TestDelete1()
        {


            using (var context = new UserContext(TestInitialize()))
            {
                var repo = new UserRepo(context);
                var deleteUser = await repo.Get(2);
                var user1 = await repo.Delete(deleteUser);
                var afterDelete = await repo.Get(2);
                Assert.IsNull(afterDelete);

            }
        }

      





    }
}