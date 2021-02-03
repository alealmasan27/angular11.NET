using System.Collections.Generic;
using EFTest.Models;

namespace EFTest.Service
{
    public interface ICompanyService
    {
        List<CompanyStakeholder> GetAllCompaniesWithShareholders();
    }
}
