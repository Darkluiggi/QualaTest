using Model;
using Services.BranchService.Dtos;
using Services.CurrencyService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings
{
    public static class DtoExtensions
    {
        public static BranchDto ToDto(this Branch branch) =>
            new BranchDto(branch.Id, branch.Code, branch.Description, branch.Identification, branch.Address, branch.CreatedTime, branch.CurrencyId, branch.Currency.ToDto(), branch.isActive);

        public static Branch ToModel(this BranchDto branch) =>
            new Branch(branch.Id, branch.Code, branch.Description, branch.Identification, branch.Address, branch.CreatedTime, branch.Currency.ToModel());


        public static CurrencyDto ToDto(this Currency currency) =>
            new CurrencyDto(currency.Id, currency.Name, currency.Symbol, currency.isActive);


        public static Currency ToModel(this CurrencyDto currency) =>
            new Currency(currency.Id, currency.Name, currency.Symbol);
    }
}
