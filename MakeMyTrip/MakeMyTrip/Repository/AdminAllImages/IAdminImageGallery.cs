using MakeMyTrip.Models;
using Microsoft.AspNetCore.Mvc;

namespace MakeMyTrip.Repository.AdminAllImages
{
    public interface IAdminImageGallery
    {
        Task<ActionResult<AdminImageGallery>> AddImages(AdminImageGallery imageGallery);

    }
}
