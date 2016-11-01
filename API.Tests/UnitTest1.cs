using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Models;
using System.Collections.Generic;
using API.Controllers;

namespace API.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddProfile()
        {
            var testProfiles = GetTestProfiles();
            var controller = new ProfilesController();
            var result = controller.PostProfile(testProfiles[0]);
            Assert.AreEqual(testProfiles[0], result);
        }

        private List<Profile> GetTestProfiles()
        {
            var testProfiles = new List<Profile>();

            testProfiles.Add(new Profile
            {
                Nickname = "Crunchy",
                Firstname = "Alison",
                Lastname = "Jarosz",
                Birthdate = new DateTime(1989,6,2),
                Email = "crunchy@prout.fr",
                Phone = "0628656565",
                Town = "Levallois",
                Active = true
            });

            testProfiles.Add(new Profile
            {
                Nickname = "Deedlith",
                Firstname = "Cindy",
                Lastname = "Vuillaume",
                Birthdate = new DateTime(1990, 1, 9),
                Email = "deed@prout.fr",
                Phone = "0628656565",
                Town = "Paris",
                Active = false
            });

            testProfiles.Add(new Profile
            {
                Nickname = "Zhaie",
                Firstname = "Charlotte",
                Lastname = "Dellanoy",
                Birthdate = new DateTime(1989, 3, 1),
                Email = "zhaie@prout.fr",
                Phone = "0628656565",
                Town = "Montréal",
                Active = true
            });
            return testProfiles;
        }
    }
}
