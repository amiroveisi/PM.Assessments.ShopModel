using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Assessments.ShopModel.Models.Domains.User;

namespace PM.Assessments.ShopModel.Models
{
    /// <summary>
    /// The base class for all users.
    /// </summary>
    public abstract class UserBase
    {
        /// <summary>
        /// The full name of the user.
        /// </summary>
        public required string FullName { get; init; }
        /// <summary>
        /// The username of the user. this field should be unique.
        /// </summary>
        public required string Username { get; init; }
        /// <summary>
        /// The address of the user. this address will be used as the billing/shipping address by default.
        /// </summary>
        public Address? Address { get; set; }
        /// <summary>
        /// The email address of the user.
        /// This email will be used in password reset operation and also delivering digital products.
        /// </summary>
        public required string Email { get; init; }
        
    }
}
