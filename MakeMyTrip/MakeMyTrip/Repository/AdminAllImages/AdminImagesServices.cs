using MakeMyTrip.Data;
using MakeMyTrip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace MakeMyTrip.Repository.AdminAllImages
{
    public class AdminImagesServices : IAdminImageGallery
    {
        private readonly MakeTripContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public AdminImagesServices(MakeTripContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        //here we need to save the image in c#, because it is not mapped in db 
        public async Task<ActionResult<AdminImageGallery>> AddImages(AdminImageGallery imageGallery)
        {
            imageGallery.ImageName = await SaveImage(imageGallery.ImageFile);
            _context.AdminImagecheck.Add(imageGallery);
            await _context.SaveChangesAsync();

            return new ActionResult<AdminImageGallery>(imageGallery);
        }

        //the storage location is
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

    }
}
