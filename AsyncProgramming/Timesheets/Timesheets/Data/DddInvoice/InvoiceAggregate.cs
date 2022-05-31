namespace Timesheets.Data.DddInvoice
{
    public class InvoiceAggregate
    {
        private IEnumerable<Invoice> _invoices;

        public InvoiceAggregate(IEnumerable<Invoice> invoices)
        {
            _invoices = invoices;
        }

        public void IncludeInvoice(Invoice newIvoice)
        {
            _invoices = _invoices.Append(newIvoice);
        }

        public bool IsPayed()
        {
            return _invoices.All(i => i.Status == Enums.InvoiceStatusEnum.Closed);
        }
        
        public bool IsInProgress()
        {
            return _invoices.All(i => i.Status == Enums.InvoiceStatusEnum.InProgress);
        }
        
        public bool IsOpen()
        {
            return _invoices.All(i => i.Status == Enums.InvoiceStatusEnum.Open);
        }
    }
}
