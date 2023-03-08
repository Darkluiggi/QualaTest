using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.BranchService.Dtos;
using System.Linq;
using Services.Mappings;
using Model;

namespace Services.BranchService.Queries
{
    public record SaveOrUpdateBranchCommand(Guid? Id, int Code, string Description, string Address, string Identification, DateTime CreatedTime, Guid CurrencyId) : IRequest<BranchDto>;

    public class SaveOrUpdateBranchCommandHandler : IRequestHandler<SaveOrUpdateBranchCommand, BranchDto>
    {
        private readonly AppDbContext _context;

        public SaveOrUpdateBranchCommandHandler(AppDbContext context)
        {
            _context = new AppDbContext();
        }
        public async Task<BranchDto> Handle(SaveOrUpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var currency = _context.Currencies.Where(c => c.Id == request.CurrencyId).FirstOrDefault();
            if (currency == null)
            {
                throw new Exception($"Currency not found with Id: {request.CurrencyId}");
            }

            var branch = _context.Branches.Where(b => b.Id == request.Id).FirstOrDefault();
            await Task.Run(() =>
            {
                if (branch == null)
                {
                    branch = new Branch(
                    new Guid(),
                    request.Code,
                    request.Description,
                    request.Address,
                    request.Identification,
                    request.CreatedTime,
                    currency);
                    branch = _context.Branches.Add(branch).Entity;
                }
                else
                {
                    branch.Code = request.Code;
                    branch.Description = request.Description;
                    branch.Address = request.Address;
                    branch.Identification = request.Identification;
                    branch.CreatedTime = request.CreatedTime;
                    _context.Entry(branch).State = EntityState.Modified;
                }
            });

            _context.SaveChanges();
            return branch.ToDto();
        }
    }
}
