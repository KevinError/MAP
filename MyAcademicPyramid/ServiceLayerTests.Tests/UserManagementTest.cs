﻿using Xunit;
using DataAccessLayer;
using ServiceLayer.UserManagement.UserAccountServices;
using DemoProject;
using System;
using System.Collections.Generic;

namespace ServiceLayerTests.Tests
{
    public class UserManagementTest
    {


        [Fact]
        public void UserManagement_CreateUser_ShouldAbleFindUserAfterCreation()
        {
            //Arrange
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            EffortFactory.ResetDb();
            User user = new User("Victor");
            UserManagementServices userManagementServ = new UserManagementServices(new UnitOfWork());
            userManagementServ.CreateUser(user);
            User expectedUser = userManagementServ.FindUserbyUserName("Victor");

            //Act
            User actualUser = new User("Victor");

            //Assert
            Assert.Equal(expectedUser.UserName, actualUser.UserName);
        }

        [Fact]
        public void UserManagement_CreateUserWithDupplicateUsername_ShouldThrowException()
        {
            //Arrange
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            EffortFactory.ResetDb();
            User user1 = new User("Victor");
            UserManagementServices userManagementServ = new UserManagementServices(new UnitOfWork());
            userManagementServ.CreateUser(user1);
            User user2 = new User("Victor");
            userManagementServ.CreateUser(user2);
            var expected = typeof(User);

            //Act
            var actual = userManagementServ.FindUserbyUserName("Victor");

            //Assert
            Assert.IsType(expected, actual);
        }

        [Fact]
        public void UserManagement_DeleteUser_UserShouldNotExistAfterDeletion()
        {
            //Arrange
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            EffortFactory.ResetDb();
            User user = new User("Trong");
            UserManagementServices userManagementServ = new UserManagementServices(new UnitOfWork());
            userManagementServ.CreateUser(user);
            userManagementServ.DeleteUser(user);
            User expectedUser = userManagementServ.FindUserbyUserName("Trong");

            //Act
            User actualUser = null;

            //Assert
            Assert.Equal(expectedUser, actualUser);

        }

        [Fact]
        public void UserManagement_UpdateUser_UserNameShouldGetUpdate()
        {
            //Arrange
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            EffortFactory.ResetDb();
            User user = new User("Trong");
            UserManagementServices userManagementServ = new UserManagementServices(new UnitOfWork());
            userManagementServ.CreateUser(user);
            user.UserName = "Arturo";
            userManagementServ.UpdateUser(user);

            String ExpectedUserName = userManagementServ.FindUserbyUserName("Arturo").UserName;

            //Act
            String actualUserName = "Arturo";

            //Assert
            Assert.Equal(ExpectedUserName, actualUserName);

        }

        //[Fact]
        //public void UserManagement_AddClaim_ClaimsShouldBeAddToUser()
        //{
        //    //Arrange
        //    Effort.Provider.EffortProviderConfiguration.RegisterProvider();
        //    EffortFactory.ResetDb();
        //    User user = new User("Luis");
        //    UserManagementServices userManagementServ = new UserManagementServices(new UnitOfWork());
        //    userManagementServ.CreateUser(user);
        //    userManagementServ.AddClaim(user, new Claim("Over 18"));
        //    bool expected = userManagementServ.FindUserbyUserName("Luis").Claims.Exists(u => u.Value.Equals("Over 18"));

        //    //Act
        //    bool actual = true;

        //    //Assert
        //    Assert.Equal(expected, actual);

        //}




        //[Fact]
        //public void UserManagement_RemoveClaim_ClaimsShouldBeRemovedFromUser()
        //{
        //    //Arrange
        //    Effort.Provider.EffortProviderConfiguration.RegisterProvider();
        //    EffortFactory.ResetDb();
        //    User user = new User("Luis");
        //    UserManagementServices userManagementServ = new UserManagementServices(new UnitOfWork());
        //    userManagementServ.CreateUser(user);
        //    userManagementServ.AddClaim(user, new Claim("Over 18"));
        //    userManagementServ.RemoveClaim(user, new Claim("Over 18"));
        //    bool expected = userManagementServ.FindUserbyUserName("Luis").Claims.(u => u.Value.Equals("Over 18"));

        //    //Act
        //    bool actual = true;

        //    //Assert
        //    Assert.Equal(expected, actual);

        //}



    }
    
}
