using DataAccessLayer;
using DataAccessLayer.Controllers;
using System;
using System.Collections.Generic;

namespace DemoProject
{
    class ProgramDAL
    {

        static void Main(string[] args)
        {
            // Get all users.
            Console.WriteLine("Get all users");
            IEnumerable<User> users = UserController.Get();

            // Output all userss
            Console.WriteLine("Output all users:");
            foreach(User u in users)
            {
                // User full name and email
                Console.WriteLine("\n" + u.FirstName + " " + u.MiddleName + " " + u.LastName + ", " + u.Email);

                // User claims
                foreach(Claim c in u.Claims)
                {
                    Console.Write(c.ID + ": " + c.Value + ", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("End");
            Console.ReadKey(true);
        }

        
    }
}
