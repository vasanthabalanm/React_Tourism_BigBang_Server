using MakeMyTrip.Data;
using MakeMyTrip.GlobalErrorCheck;
using MakeMyTrip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakeMyTrip.Repository.Packages
{
    public class AllPackages : IAllPack
    {
        private readonly MakeTripContext _context;
        public AllPackages(MakeTripContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<PackageOffering>>> GetAllPackages()
        {
            var details = await _context.PackageOffering.ToListAsync();
            return details;
        }

        public async Task<List<PackageOffering>> PostPackages(PackageOffering package)
        {
            _context.Add(package);
            await _context.SaveChangesAsync();
            return await _context.PackageOffering.ToListAsync();
        }

        public async Task<ActionResult<List<PackageOffering>>> GetIntrestedPackages(string offertype, string destination, string vehicletype)
        {
            var details = await _context.PackageOffering.Where(x => x.OfferType == offertype && x.Destination == destination && x.VehicleType == vehicletype).ToListAsync();
            if (details == null)
            {
                throw new Exception(GlobalErrcheck.ExceptionMessages["Empty"]);
            }
            return details;
        }
    }
}
