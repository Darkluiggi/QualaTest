using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.BranchService.Dtos;
using System.Linq;
using Services.Mappings;
using Domain;
using Services.CurrencyService.Dtos;

namespace Services.BranchService.Queries
{
    public record SaveOrUpdateCurrencyCommand(Guid? Id, string Name, char symbol) : IRequest<CurrencyDto>;

    public class SaveOrUpdateCurrencyCommandHandler : IRequestHandler<SaveOrUpdateCurrencyCommand, CurrencyDto>
    {
        private readonly AppDbContext _context;

        public SaveOrUpdateCurrencyCommandHandler(AppDbContext context)
        {
            _context = new AppDbContext();
        }
        public async Task<CurrencyDto> Handle(SaveOrUpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = _context.Currencies.Where(c => c.Id == request.Id).FirstOrDefault();
           
            await Task.Run(() =>
            {
                if (currency == null)
                {
                    currency = new Currency(
                    new Guid(),
                    request.Name,
                    request.symbol);
                    currency = _context.Currencies.Add(currency).Entity;
                }
                else
                {
                    currency.Name = request.Name;
                    currency.Symbol = request.symbol;
                    _context.Entry(currency).State = EntityState.Modified;
                }
            });

            _context.SaveChanges();
            return currency.ToDto();
        }
    }
}
