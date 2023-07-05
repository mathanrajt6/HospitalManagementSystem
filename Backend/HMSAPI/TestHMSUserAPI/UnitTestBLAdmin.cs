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
    public class UnitTestBlAdmin
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
                IAdminAction adminAction = new AdminService(repo);
                var user1 = await adminAction.GetAllDoctor();
                Assert.IsNotNull(user1);

            }
        }


     
        [TestMethod]
        public async Task TestAdminUpdate1()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var adminUpdate = new UserUpdateDTO
                {
                    Id = 1,
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Address = "123 Main Street",
                    Phone = "99999999999",
                 
                };

                IRepo<User, int> repo = new UserRepo(context);
                IAdminAction adminAction = new AdminService(repo);
                var user = await adminAction.UpdateAdminDetails(adminUpdate);
                var doctorfiler = new UserDTO
                {
                    Id = 1
                };
                var admin = new UserDTO
                {
                    Id = 1,
                };
                var updateUser = await adminAction.GetUserDetailDetail(admin);
                Assert.IsNotNull(user);
                Assert.AreEqual("99999999999", updateUser?.PhoneNUmber);

            }
        }

        [TestMethod]
        public async Task TestPatientUpdate2()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var adminUpdate = new UserUpdateDTO
                {
                    Id = 5,
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Address = "123 Main Street",
                    Phone = "99999999999",

                };

                IRepo<User, int> repo = new UserRepo(context);
                IAdminAction adminAction = new AdminService(repo);
                var user = await adminAction.UpdateAdminDetails(adminUpdate);
                var doctorfiler = new UserDTO
                {
                    Id = 1
                };
                var admin = new UserDTO
                {
                    Id = 1,
                };
                var updateUser = await adminAction.GetUserDetailDetail(admin);
                Assert.IsNull(user);
            }


        }


        [TestMethod]
        public async Task TestGetPatient2()
        {

            using (var context = new UserContext(TestInitialize()))
            {

                var admin = new UserDTO
                {
                    Id = 1
                };

                IRepo<User, int> repo = new UserRepo(context);
                IAdminAction adminAction = new AdminService(repo);
                var adminDetails = await adminAction.GetUserDetailDetail(admin);
                Assert.AreEqual(1, adminDetails?.UserDetailID);


            }


        }


        [TestMethod]
        public async Task TestGetDoctorbasedonFilter()
        {

            using (var context = new UserContext(TestInitialize()))
            {
                var doctorFilterDTO = new DoctorFilterDTO
                {
                    Status = "approved"
                };


                IRepo<User, int> repo = new UserRepo(context);
                IAdminAction adminAction = new AdminService(repo);
                var adminDetails = await adminAction.GetAllDoctorBasedOnStatus(doctorFilterDTO);
                Assert.IsNotNull(adminDetails);
                Assert.AreEqual(0, adminDetails.Count);
                


            }


        }


        [TestMethod]
        public async Task TestGetDoctorbasedonFilter2()
        {

            using (var context = new UserContext(TestInitialize()))
            {
                var doctorFilterDTO = new DoctorFilterDTO
                {
                    Status = "un-approved"
                };


                IRepo<User, int> repo = new UserRepo(context);
                IAdminAction adminAction = new AdminService(repo);
                var adminDetails = await adminAction.GetAllDoctorBasedOnStatus(doctorFilterDTO);
                Assert.AreEqual(1,adminDetails?.Count);



            }


        }

        [TestMethod]
        public async Task TestChnageDoctorStatus()
        {

            using (var context = new UserContext(TestInitialize()))
            {
                var doctorFilterDTO = new DoctorApproveDTO
                {
                    ID = 2,
                    Status = "un-approved"
                };


                IRepo<User, int> repo = new UserRepo(context);
                IAdminAction adminAction = new AdminService(repo);
                var adminDetails = await adminAction.ChangeApproveStatus(doctorFilterDTO);
                Assert.AreEqual("un-approved", adminDetails?.UserDetail.Doctor.ApprovedStatus);



            }


        }


          [TestMethod]
        public async Task TestLoginStatus()
        {

            using (var context = new UserContext(TestInitialize()))
            {
                var doctorFilterDTO = new UserDTO
                {
                    Email = "ml.com",
                    Password = "madh2023"
                };

                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IRepo<User, int> repo = new UserRepo(context);
                IUserAction userAction = new UserService(repo,tokenGenerate,generatePassword);
                await Assert.ThrowsExceptionAsync<UserException>(async () =>
                {
                    var adminDetails = await userAction.Login(doctorFilterDTO);

                });



            }


        }



        [TestMethod]
        public async Task TestPasswordStatus()
        {

            using (var context = new UserContext(TestInitialize()))
            {
                var doctorFilterDTO = new UserPasswordUpdateDTO
                {
                    ID=1,
                    NewPassword = "madh2023"
                };

                ITokenGenerate tokenGenerate = new TokenGenerateService();
                IGeneratePassword generatePassword = new GeneratePasswordService();
                IRepo<User, int> repo = new UserRepo(context);
                IUserAction userAction = new UserService(repo, tokenGenerate, generatePassword);
                var result = userAction.PasswordUpdate(doctorFilterDTO);
                Assert.IsNotNull(result);



            }


        }


    }
}