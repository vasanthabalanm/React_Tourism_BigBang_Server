using MakeMyTrip.Data;
using MakeMyTrip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
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
        //to add image
        public async Task<ActionResult<AdminImageGallery>> AddImages(AdminImageGallery imageGallery)
        {
            imageGallery.ImageName = await SaveImage(imageGallery.ImageFile);
            _context.AdminImagecheck.Add(imageGallery);
            await _context.SaveChangesAsync();

            return new ActionResult<AdminImageGallery>(imageGallery);
        }

        //the storage location is
        //[NonAction]
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

        //to display all images
        public async Task<IEnumerable<AdminImageGallery>> GetAllImages(HttpRequest request)
        {
            return await _context.AdminImagecheck
                .Select(x => new AdminImageGallery()
                {
                    AdminImgsId = x.AdminImgsId,
                    LocationName = x.LocationName,
                    Locationdescription = x.Locationdescription,
                    ImageName = x.ImageName,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, x.ImageName)
                })
                .ToListAsync();
        }

        //to update image
        public async Task<IActionResult> UpdateEmployee(int id, AdminImageGallery imageGallery)
        {
            if (id != imageGallery.AdminImgsId)
            {
                return new BadRequestResult();
            }

            if (imageGallery.ImageFile != null)
            {
                DeleteImage(imageGallery.ImageName);
                imageGallery.ImageName = await SaveImage(imageGallery.ImageFile);
            }

            _context.Entry(imageGallery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return new NoContentResult();
        }

        //check already meadthod by bool
        private bool EmployeeModelExists(int id)
        {
            return _context.AdminImagecheck.Any(e => e.AdminImgsId == id);
        }


        //to delete image
        public async Task<ActionResult<AdminImageGallery>> DeleteImage(int id)
        {
            var delimg = await _context.AdminImagecheck.FindAsync(id);
            if (delimg == null)
            {
                return null;
            }

            DeleteImage(delimg.ImageName);

            _context.AdminImagecheck.Remove(delimg);
            await _context.SaveChangesAsync();

            return delimg;
        }

        //for both Update and delete functions
        //for update we need to write delete and allreadyimage exists check  by id
        //[NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
