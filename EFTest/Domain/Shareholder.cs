using System;
using System.Collections.Generic;

namespace EFTest.Domain
{
    [Serializable]
    public class Shareholder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ShareholderToCompany> ShareholderToCompanies { get; set; }
    }
}
