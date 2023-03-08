using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.BranchService.Dtos;
using System.Linq;
using Services.Mappings;
using Domain;

namespace Services.BranchService.Queries
{
    /// <summary>
    /// Save or update branch command
    /// </summary>
    /// <param name="Id">Branch id</param>
    /// <param name="Code">Branch code</param>
    /// <param name="Description">Branch description</param>
    /// <param name="Address">Branch address</param>
    /// <param name="Identification">Branch identification</param>
    /// <param name="CreatedTime">Branch created time</param>
    /// <param name="CurrencyId">Branch churrency id</param>
    public record SaveOrUpdateBranchCommand(Guid? Id, int Code, string Description, string Address, string Identification, DateTime CreatedTime, Guid CurrencyId) : IRequest<BranchDto>;

    /// <summary>
    /// Command handler
    /// </summary>
    public class SaveOrUpdateBranchCommandHandler : IRequestHandler<SaveOrUpdateBranchCommand, BranchDto>
    {
        /// <summary>
        /// Application db context
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor for command handler
        /// </summary>
        /// <param name="context">Application db context</param>
        public SaveOrUpdateBranchCommandHandler(AppDbContext context)
        {
            _context = new AppDbContext();
        }

        /// <summary>
        /// Handler for the class
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
