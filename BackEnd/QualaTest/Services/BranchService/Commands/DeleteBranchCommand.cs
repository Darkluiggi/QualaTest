using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.BranchService.Dtos;
using System.Linq;
using Services.Mappings;
using Domain;

namespace Services.BranchService.Queries
{
    public record DeleteBranchCommand(Guid? Id) : IRequest<bool>;

    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteBranchCommandHandler(AppDbContext context)
        {
            _context = new AppDbContext();
        }
        public async Task<bool> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = _context.Branches.Where(b => b.Id == request.Id).FirstOrDefault();
            if (branch == null)
            {
                throw new Exception($"Branch not found with Id: {request.Id}");
            }

            await Task.Run(() =>
            {
                branch.isActive = false;
                _context.Entry(branch).State = EntityState.Modified;
                
            });

            _context.SaveChanges();
            return true;
        }
    }
}
