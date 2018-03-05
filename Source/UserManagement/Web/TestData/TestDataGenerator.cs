using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concepts;
using Domain.DataCollector.Update;
using Domain.DataCollector.Registering;
using Domain.DataCollector.PhoneNumber;
using Domain.StaffUser.PhoneNumber;
using Newtonsoft.Json;

namespace Web.TestData
{
    public static class TestDataGenerator
    {
        private static int numAdmins = 0;
        private static int numDataConsumers = 0;
        private static int numDataCoordinators = 0;
        private static int numDataOwners = 0;
        private static int numDataVerifiers = 0;
        private static int numSystemCoordinators = 0;

        private static readonly Random rng = new Random();

        private static readonly string[] names =
        {
            "Abraham Watson",
            "Vanessa Wallace",
            "Billie Mclaughlin"
        };

        private static readonly Guid[] nationalSocieties =
            Enumerable.Range(0, 10).Select(x => Guid.NewGuid()).ToArray();


        public static void GenerateAllTestData()
        {
            GenerateCorrectAddDataCollectorCommands();
            GenerateCorrectAddStaffUserCommands();
        }

        public static void GenerateCorrectAddDataCollectorCommands()
        {
            var languageValues = Enum.GetValues(typeof(Language));
            var sexValues = Enum.GetValues(typeof(Sex));
            var data = names.Select(name => new RegisterDataCollector
                {
                    DisplayName = name.Replace(' ', '_') + "DISP",
                    FullName = name,
                    GpsLocation = new Location(rng.NextDouble(), rng.NextDouble()),
                    PhoneNumbers = new List<string> {rng.Next(00000000, 99999999).ToString()},
                    NationalSociety = Guid.NewGuid(),
                    PreferredLanguage = (Language)languageValues.GetValue(rng.Next(languageValues.Length)),
                    Sex = (Sex)sexValues.GetValue(rng.Next(sexValues.Length)),
                    YearOfBirth = rng.Next(1920, 2018)
                })
                .ToList();


            using (var file = File.CreateText("./TestData/DataCollectors.json"))
            {
                file.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));   
            }
        }

        public static void GenerateCorrectAddStaffUserCommands()
        {
            // var data = new List<AddStaffUser>();
            // for (var i = 0; i < 100; i++)
            // {
            //     Role role = (Role)rng.Next(0, 6);

            //     switch (role)
            //     {
            //         case Role.Admin:
            //             data.Add(CreateAddAdminCommand());
            //             break;
            //         case Role.DataConsumer:
            //             data.Add(CreateAddDataConsumerCommand());
            //             break;
            //         case Role.DataCoordinator:
            //             data.Add(CreateAddDataCoordinatorCommand());
            //             break;
            //         case Role.DataOwner:
            //             data.Add(CreateAddDataOwnerCommand());
            //             break;
            //         case Role.DataVerifier:
            //             data.Add(CreateAddDataVerifierCommand());
            //             break;
            //         case Role.SystemCoordinator:
            //             data.Add(CreateAddSystemCoordinatorCommand());
            //             break;
            //     }
            // }
            // using (var file = File.CreateText("./TestData/StaffUsers.json"))
            // {
            //     file.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            // }

        }
        // private static AddStaffUser CreateAddAdminCommand()
        // {
        //     var name = "Admin" + numAdmins;
        //     var result = new AddStaffUser
        //     {
        //         Role = Role.Admin,
        //         FullName = name,
        //         DisplayName = name + " Display name",
        //         Email = name + "@mail.com"
        //     };
        //     numAdmins++;

        //     return result;
        // }
        // private static AddStaffUser CreateAddDataConsumerCommand()
        // {
        //     var name = "DataConsumer" + numDataConsumers;
        //     var result = new AddStaffUser
        //     {
        //         Role = Role.DataConsumer,
        //         FullName = name,
        //         DisplayName = name + " Display name",
        //         Email = name + "@mail.com",

        //         Location = new Location(rng.NextDouble(), rng.NextDouble())
        //     };
        //     numDataConsumers++;

        //     return result;
        // }
        // private static AddStaffUser CreateAddDataCoordinatorCommand()
        // {
        //     var name = "DataCoordinator" + numDataCoordinators;
        //     var languageValues = Enum.GetValues(typeof(Language));
        //     var sexValues = Enum.GetValues(typeof(Sex));
        //     var result = new AddStaffUser
        //     {
        //         Role = Role.DataCoordinator,
        //         FullName = name,
        //         DisplayName = name + " Display name",
        //         Email = name + "@mail.com",

        //         YearOfBirth = rng.Next(1900, 2018),
        //         Sex = (Sex)sexValues.GetValue(rng.Next(sexValues.Length)),
        //         NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
        //         PreferredLanguage = (Language)languageValues.GetValue(rng.Next(languageValues.Length)),
        //         Location = new Location(rng.NextDouble(), rng.NextDouble()),
        //         MobilePhoneNumber = new List<string> {rng.Next(00000000, 99999999).ToString()},
        //         AssignedNationalSocieties = new List<Guid> {nationalSocieties[rng.Next(nationalSocieties.Length)]}
        //     };
        //     numDataCoordinators++;

        //     return result;
        // }
        // private static AddStaffUser CreateAddDataOwnerCommand()
        // {
        //     var name = "DataOwner" + numDataOwners;
        //     var result = new AddStaffUser
        //     {
        //         Role = Role.DataOwner,
        //         FullName = name,
        //         DisplayName = name + " Display name",
        //         Email = name + "@mail.com",

        //         YearOfBirth = rng.Next(1900, 2018),
        //         Sex = (Sex)sexValues.GetValue(rng.Next(sexValues.Length)),
        //         NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
        //         PreferredLanguage = (Language)languageValues.GetValue(rng.Next(languageValues.Length)),
        //         Location = new Location(rng.NextDouble(), rng.NextDouble()),
        //         MobilePhoneNumber = new List<string> {rng.Next(00000000, 99999999).ToString()},
        //         AssignedNationalSocieties = new List<Guid> {nationalSocieties[rng.Next(nationalSocieties.Length)]},
        //         DutyStation = "Duty Station" + numDataOwners,
        //         Position = "Position" + numDataOwners
        //     };
        //     numDataOwners++;

        //     return result;
        // }
        // private static AddStaffUser CreateAddDataVerifierCommand()
        // {
        //     var name = "DataVerifier" + numDataVerifiers;
        //     var result = new AddStaffUser
        //     {
        //         Role = Role.DataVerifier,
        //         FullName = name,
        //         DisplayName = name + " Display name",
        //         Email = name + "@mail.com",

        //         YearOfBirth = rng.Next(1900, 2018),
        //         Sex = (Sex)sexValues.GetValue(rng.Next(sexValues.Length)),
        //         NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
        //         PreferredLanguage = (Language)languageValues.GetValue(rng.Next(languageValues.Length)),
        //         Location = new Location(rng.NextDouble(), rng.NextDouble()),
        //         MobilePhoneNumber = new List<string> {rng.Next(00000000, 99999999).ToString()},
        //         AssignedNationalSocieties = new List<Guid> {nationalSocieties[rng.Next(nationalSocieties.Length)]}
        //     };
        //     numDataVerifiers++;

        //     return result;
        // }
        // private static AddStaffUser CreateAddSystemCoordinatorCommand()
        // {
        //     var name = "SystemCoordinator" + numSystemCoordinators;
        //     var result = new AddStaffUser
        //     {
        //         Role = Role.SystemCoordinator,
        //         FullName = name,
        //         DisplayName = name + " Display name",
        //         Email = name + "@mail.com",

        //         YearOfBirth = rng.Next(1900, 2018),
        //         Sex = (Sex)sexValues.GetValue(rng.Next(sexValues.Length)),
        //         NationalSociety = nationalSocieties[rng.Next(nationalSocieties.Length)],
        //         PreferredLanguage = (Language)languageValues.GetValue(rng.Next(languageValues.Length)),
        //         Location = new Location(rng.NextDouble(), rng.NextDouble()),
        //         MobilePhoneNumber = new List<string> {rng.Next(00000000, 99999999).ToString()},
        //         AssignedNationalSocieties = new List<Guid> {nationalSocieties[rng.Next(nationalSocieties.Length)]}
        //     };
        //     numSystemCoordinators++;

        //     return result;
        // }
    }
}