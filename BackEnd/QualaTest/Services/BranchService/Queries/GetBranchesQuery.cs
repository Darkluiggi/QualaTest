using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.BranchService.Dtos;
using System.Linq;
using Services.Mappings;

namespace Services.BranchService.Queries
{
    /// <summary>
    /// Query for getting all active branches
    /// </summary>
    public record GetBranchesQuery : IRequest<IList<BranchDto>>;

    /// <summary>
    /// Handler for the query
    /// </summary>
    public class GetBranchesQueryHandler : IRequestHandler<GetBranchesQuery, IList<BranchDto>>
    {
        /// <summary>
        /// Application db context
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor for the class handler
        /// </summary>
        /// <param name="context">Application db context</param>
        public GetBranchesQueryHandler(AppDbContext context)
        {
            _context = new AppDbContext();
        }

        /// <summary>
        /// Class handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
