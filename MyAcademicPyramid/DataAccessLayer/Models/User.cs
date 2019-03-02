//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using DataAccessLayer.Models;
    using DataAccessLayer.Repository;
    using System;
    using System.Collections.Generic;
    
    public partial class User : IEntity
    {
 
        public User()
        {
            this.ChildUsers = new HashSet<User>();
            this.Claims = new HashSet<Claim>();
        }


        public User(string userName, string firstname, string lastName, string role, DateTime birthDate, string location, string email, DateTime createdDate, string passwordHashed, int? parentUser_Id, string passwordQuestion1, string passwordQuestion2, string passwordQuestion3, string passwordAnswer1, string passwordAnswer2, string passwordAnswer3, ICollection<User> childUsers, User parentUser, ICollection<Claim> claims)
        {
            UserName = userName;
            Firstname = firstname;
            LastName = lastName;
            Role = role;
            BirthDate = birthDate;
            Location = location;
            Email = email;
            CreatedDate = createdDate;
            PasswordHash = passwordHashed;
            ParentUser_Id = parentUser_Id;
            PasswordQuestion1 = passwordQuestion1;
            PasswordQuestion2 = passwordQuestion2;
            PasswordQuestion3 = passwordQuestion3;
            PasswordAnswer1 = passwordAnswer1;
            PasswordAnswer2 = passwordAnswer2;
            PasswordAnswer3 = passwordAnswer3;
            ChildUsers = childUsers;
            ParentUser = parentUser;
            Claims = claims;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime BirthDate { get; set; }
        public String Location { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public String PasswordHash { get; set; }
        public Nullable<int> ParentUser_Id { get; set; }

        public String PasswordQuestion1 { get; set; }
        public String PasswordQuestion2 { get; set; }
        public String PasswordQuestion3 { get; set; }
        public String PasswordAnswer1 { get; set; }
        public String PasswordAnswer2 { get; set; }
        public String PasswordAnswer3 { get; set; }

        /// <summary>
        /// Children users below user.
        /// </summary>
        public virtual ICollection<User> ChildUsers { get; set; }
        /// <summary>
        /// Parent user above user.
        /// </summary>
        public virtual User ParentUser { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }

        /// <summary>
        /// Override Equals method.  The UserName of each User is unique.
        /// </summary>
        /// <param name="obj">Another User</param>
        /// <returns>Whether Users are equal or not</returns>
        public override bool Equals(object obj)
        {
            var user = obj as User;
            return UserName.Equals(user.UserName);
        }

        /// <summary>
        /// Override HashCode.  The UserName of each User is unique.
        /// </summary>
        /// <returns>UserName hashcode</returns>
        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }

        /// <summary>
        /// Override ToString.  Output username
        /// </summary>
        /// <returns>username</returns>
        public override string ToString()
        {
            return UserName;
        }
    }
}
