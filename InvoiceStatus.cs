using System;
using System.Collections.Generic;

namespace ManageInvoiceService.Models
{
    public partial class InvoiceStatus
    {
        public InvoiceStatus()
        {
            Invoices = new HashSet<Invoices>();
        }

        public int InvoiceStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
