using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageInvoiceService.Models
{
    public partial class Users
    {
        public Users()
        {
            Invoices = new HashSet<Invoices>();
            Memberships = new HashSet<Memberships>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="Email is not valid")]
        public string Email { get; set; }

        [Phone]
        public string ContactNumber { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Memberships> Memberships { get; set; }
    }
}
