using System.Collections.Generic;
using System.Linq;
using EFTest.Domain;
using EFTest.Models;
using EFTest.Repository;
using Microsoft.Extensions.Configuration;

namespace EFTest.Service
{
    public class CompanyService: ICompanyService
    {
        private readonly IConfiguration _configuration;

        public CompanyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Shareholder> GetAllObjects()
        {
            using var unitOfWork = new UnitOfWork(_configuration);
            var repo = unitOfWork.GetRepository<Shareholder>();
            return repo.GetAll().ToList();
        }

        public List<CompanyStakeholder> GetAllCompaniesWithShareholders()
        {
            using var unitOfWork = new UnitOfWork(_configuration);
            var listOfCompaniesShareholders = new List<CompanyStakeholder>();
            var companies = unitOfWork.GetRepository<Company>().GetAll().ToList();
            var shareholderToCompany = unitOfWork.GetRepository<ShareholderToCompany>().GetAll().ToList();
            var shareholders = unitOfWork.GetRepository<Shareholder>().GetAll().ToList();
            foreach (var company in companies)
            {
                var companyShareholders = shareholderToCompany.Where(sc => sc.CompanyId == company.Id);
                foreach (var companyShareholder in companyShareholders)
                {
                    var shareholderName = shareholders.FirstOrDefault(x => x.Id == companyShareholder.ShareholderId)?.Name;
                    listOfCompaniesShareholders.Add(GetCompanyStakeholder(companyShareholder.Amount, company.Name, shareholderName));
                }
            }

            return listOfCompaniesShareholders;
        }

        private static CompanyStakeholder GetCompanyStakeholder(decimal amount, string companyName, string shareholderName)
        {
            return new()
            {
                Amount = amount,
                CompanyName = companyName,
                ShareholderName = shareholderName
            };
        }
    }
}