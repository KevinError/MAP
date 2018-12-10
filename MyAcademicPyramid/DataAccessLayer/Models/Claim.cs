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
    using DataAccessLayer.Repository;
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// The class is used for user's claim
    /// </summary>
    public partial class Claim : IEntity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Claim()
        {
            this.Users = new HashSet<User>();
        }

        /// <summary>
        /// Overload constructor that take value of claim
        /// </summary>
        /// <param name="value"></param>
        public Claim(String value)
        {
            Value = value;
            this.Users = new HashSet<User>();
        }
    
        // Claim Id
        public int Id { get; set; }

        //Claim Value
        public string Value { get; set; }
    
        //Collection of Users that used for many-many relationship with user class 
        public virtual ICollection<User> Users { get; set; }
    }
}
