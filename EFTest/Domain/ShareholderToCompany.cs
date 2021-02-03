namespace EFTest.Domain
{
    public class ShareholderToCompany
    {
        public decimal Amount { get; set; }
        public int CompanyId { get; set; }
        public int ShareholderId { get; set; }
        public Company Company { get; set; }
        public Shareholder Shareholder { get; set; }
    }
}
