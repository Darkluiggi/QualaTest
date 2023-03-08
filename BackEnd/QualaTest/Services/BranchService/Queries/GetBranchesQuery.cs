using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.BranchService.Dtos;
using System.Linq;
using Services.Mappings;

namespace Services.BranchService.Queries
{
    public record GetBranchesQuery : IRequest<IList<BranchDto>>;

    public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, IList<BranchDto>>
    {
        private readonly AppDbContext _context;

        public GetBranchesQueryHandler(AppDbContext context)
        {
            _context = new AppDbContext();
        }
        public async Task<IList<BranchDto>> Handle(GetBranchesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<BranchDto>();
            var branches = _context.Branches.Include(b => b.Currency).Where(b => b.isActive).ToList();

            foreach (var branch in branches)
            {
                result.Add(branch.ToDto());
            }
            return result;
        }
    }
}
