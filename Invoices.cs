using System;
using System.Collections.Generic;

namespace ManageInvoiceService.Models
{
    public partial class Invoices
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string InvoiceDescription { get; set; }
        public int UserId { get; set; }
        public int MembershipId { get; set; }
        public int InvoiceStatusId { get; set; }

        public virtual InvoiceStatus InvoiceStatus { get; set; }
        public virtual Memberships Membership { get; set; }
        public virtual Users User { get; set; }
    }
}
