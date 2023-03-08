using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.BranchService.Dtos;
using System.Linq;
using Services.Mappings;
using Model;

namespace Services.BranchService.Queries
{
    public record DeleteCurrencyCommand(Guid? Id) : IRequest<bool>;

    public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteCurrencyCommandHandler(AppDbContext context)
        {
            _context = new AppDbContext();
        }
        public async Task<bool> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = _context.Currencies.Where(b => b.Id == request.Id).FirstOrDefault();
            if (currency == null)
            {
                throw new Exception($"Currency not found with Id: {request.Id}");
            }

            await Task.Run(() =>
            {
                currency.isActive = false;
                _context.Entry(currency).State = EntityState.Modified;
                
            });

            _context.SaveChanges();
            return true;
        }
    }
}
