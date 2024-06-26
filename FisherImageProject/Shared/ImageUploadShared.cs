using System.Diagnostics;

namespace FisherImageProject.Shared
{
    public class ImageUploadShared
    {
        public static async Task<string> ProcessImageUploadAsync(IFormFile imageFile, string imageDestination)
        {

            string rootFolder = AppDomain.CurrentDomain.BaseDirectory;
            string[] storageNames = { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            Directory.CreateDirectory($"{rootFolder}/{imageDestination}/{storageNames[0]}");
            string fileExt = Path.GetExtension(imageFile.FileName);
            string fileLocation = $"{storageNames[0]}/{storageNames[1]}{fileExt}";

            using (FileStream fileStream = System.IO.File.Create($"{rootFolder}/{imageDestination}/{fileLocation}"))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return fileLocation;
        }
    }
}
