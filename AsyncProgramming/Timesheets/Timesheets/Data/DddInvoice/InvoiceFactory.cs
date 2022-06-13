namespace Timesheets.Data.DddInvoice
{
    public class InvoiceFactory
    {
        public Invoice Create(long contractId, decimal sum)
        {
            var entity = new Invoice();
            entity.Create(contractId, sum);
            return entity; 
        }
    }
}
