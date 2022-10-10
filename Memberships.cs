using System;
using System.Collections.Generic;

namespace ManageInvoiceService.Models
{
    public partial class Memberships
    {
        public Memberships()
        {
            Invoices = new HashSet<Invoices>();
        }

        public int MembershipId { get; set; }
        public string MembershipCredits { get; set; }
        public string MembershipStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
