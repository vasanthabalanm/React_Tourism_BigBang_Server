using MakeMyTrip.Models;
using Microsoft.AspNetCore.Mvc;

namespace MakeMyTrip.Repository.AdminAllImages
{
    public interface IAdminImageGallery
    {
        Task<ActionResult<AdminImageGallery>> AddImages(AdminImageGallery imageGallery);
        Task<IEnumerable<AdminImageGallery>> GetAllImages(HttpRequest request);
        Task<IActionResult> UpdateEmployee(int id, AdminImageGallery imageGallery);
        Task<ActionResult<AdminImageGallery>> DeleteImage(int id);

    }
}
