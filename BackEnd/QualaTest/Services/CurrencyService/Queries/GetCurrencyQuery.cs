using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.BranchService.Dtos;
using System.Linq;
using Services.Mappings;
using Services.CurrencyService.Dtos;

namespace Services.BranchService.Queries
{
    public record GetCurrencyQuery : IRequest<IList<CurrencyDto>>;

    public class GetCurrencyQueryHandler : IRequestHandler<GetCurrencyQuery, IList<CurrencyDto>>
    {
        private readonly AppDbContext _context;

        public GetCurrencyQueryHandler(AppDbContext context)
        {
            _context = new AppDbContext();
        }
        public async Task<IList<CurrencyDto>> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            var result = new List<CurrencyDto>();
            var currencies = _context.Currencies.Where(b => b.isActive).ToList();

            foreach (var currency in currencies)
            {
                result.Add(currency.ToDto());
            }
            return result;
        }
    }
}
