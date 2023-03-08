using Services.CurrencyService.Dtos;

namespace Services.BranchService.Dtos
{
    public record BranchDto(Guid Id, int Code, string Description, string Address, string Identification, DateTime CreatedTime, Guid CurrencyId, CurrencyDto Currency, bool IsActive);
}
