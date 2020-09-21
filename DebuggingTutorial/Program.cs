using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;

namespace DebuggingTutorial
{
    class Program
    {
        static void Main(string[] args)
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
                PrintInvitation(GetFullNameWithTitle(user));
                DoSomething(user);
                Console.WriteLine($"FullName: {fullName}");
                user.Note = "Sample Note";
                var shortName = user.FirstName.Substring(0, 2);
                var json = JsonConvert.SerializeObject(user);
                Console.WriteLine(json);
            }

            var totalScore = users.Where(x => x.FirstName == "Scott").Select(x => x.GetScore()).Sum();
            Console.WriteLine($"Total Score: {totalScore}");
            var fib = GetNthFibonacci_Rec(5);
            Console.WriteLine(fib);
        }

        private static void DoSomething(User user)
        {
            user.Note = "Do Something";
        }

        private static string GetFullName(string userFirstName, string userLastName)
        {
            var fullName = $"{userFirstName} {userLastName}";
            return fullName;
        }

        private static string GetFullNameWithTitle(User u)
        {
            var fullName = GetFullName(u.FirstName, u.LastName);
            return $"Mr. {fullName}";
        }

        private static void PrintInvitation(string fullName)
        {
            Console.WriteLine($"{fullName}, please be invited");
        }
        
        public static int GetNthFibonacci_Rec(int n)
        {  
            if ((n == 0) || (n == 1))  
            {  
                return n;  
            }  
            return GetNthFibonacci_Rec(n - 1) + GetNthFibonacci_Rec(n - 2);
        }  
    }

    //[DebuggerDisplay("{FirstName,nq} {LastName, nq}")]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GetScore() => new Random().Next(1000);
        public string Note { get; set; }
        //public override string ToString()
        //{
        //    return $"{FirstName} {LastName}";
        //}
    }
}
