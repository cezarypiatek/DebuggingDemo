using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DebuggingTutorial.Tests
{
    public class Ex1SteppingThroughTheCode
    {
        [Test]
        public void SteppingThroughTheCode()
        {
            var users = new List<User>()
            {
                new User {Id = 1, FirstName = "John", LastName = "Nash" },
                new User {Id = 2, FirstName = "Steve", LastName = "Jobs" },
                new User {Id = 3, FirstName = "Bill", LastName = "Gates" },
                new User {Id = 5, FirstName = "Scott", LastName = "Hanselman" },
                new User {Id = 6, FirstName = "Scott", LastName = "Walsh" },
            };

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"First Name: {user.FirstName}");
                Console.WriteLine($"Last Name: {user.LastName}");
                var fullName = GetFullName(user.FirstName, user.LastName);
                DoSomething(user);
                Console.WriteLine($"FullName: {fullName}");
                user.Note = "Sample Note";
                var shortName = user.FirstName.Substring(0, 2);
                var json = JsonConvert.SerializeObject(user);
                Console.WriteLine(json);
            }

            var totalScore = users.Where(x => x.FirstName == "Scott").Select(x => x.GetScore()).Sum();
            Console.WriteLine($"Total Score: {totalScore}");
        }

        private void DoSomething(User user)
        {
            user.Note = "Do Something";
        }

        private string GetFullName(string userFirstName, string userLastName)
        {
            var fullName = $"{userFirstName} {userLastName}";
            return fullName;
        }
    }


    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GetScore() => new Random().Next(1000);
        public string Note { get; set; }
    }
}
