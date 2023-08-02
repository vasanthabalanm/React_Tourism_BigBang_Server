using MakeMyTrip.Models;
using MakeMyTrip.Repository.AdminAllImages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakeMyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminGalleryController : ControllerBase
    {
        private readonly IAdminImageGallery _gallery;

        public AdminGalleryController(IAdminImageGallery gallery)
        {
            _gallery = gallery;
        }

        //to post
        [HttpPost]
        public async Task<ActionResult<AdminImageGallery>> AddImages([FromForm] AdminImageGallery admngalry)
        {
            try
            {

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately.
                // You can return a custom error response if needed.
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

    }
}
