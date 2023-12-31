﻿using MakeMyTrip.Models;
using Microsoft.AspNetCore.Mvc;

namespace MakeMyTrip.Repository.Packages
{
    public interface IAllPack
    {
        Task<ActionResult<List<PackageOffering>>> GetAllPackages();
        Task<List<PackageOffering>> PostPackages(PackageOffering package);
        Task<ActionResult<List<PackageOffering>>> GetIntrestedPackages(string offertype, string destination, string vehicletype);

        
    }
}
