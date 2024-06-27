using FisherImageProject.Models;
using System.Diagnostics;
using System.Reflection;

namespace FisherImageProject.Shared
{
    public class ControllerFunctionsShared
    {
        /// <summary>
        /// Take the passed in form file and saves is in an area based on the destination
        /// The file is placed randomly in the subdirectory
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <param name="uploadedFileDestination"></param>
        /// <returns></returns>
        public static async Task<string> ProcessFileUploadAsync(IFormFile uploadedFile, string uploadedFileDestination)
        {

            string rootFolder = AppDomain.CurrentDomain.BaseDirectory;
            string[] storageNames = { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            Directory.CreateDirectory($"{rootFolder}/{uploadedFileDestination}/{storageNames[0]}");
            string fileExt = Path.GetExtension(uploadedFile.FileName);
            string fileLocation = $"{storageNames[0]}/{storageNames[1]}{fileExt}";

            using (FileStream fileStream = System.IO.File.Create($"{rootFolder}/{uploadedFileDestination}/{fileLocation}"))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            return fileLocation;
        }

        /// <summary>
        /// Takes an object and a DTO of the object for updating and only applies non-null updates
        /// </summary>
        /// <typeparam name="TOne"></typeparam>
        /// <typeparam name="TTwo"></typeparam>
        /// <param name="databaseObject"></param>
        /// <param name="objectUpdateDTO"></param>
        /// <returns></returns>
        public static TOne PatchDatabaseObject<TOne, TTwo>(TOne databaseObject, TTwo objectUpdateDTO)
        {
            PropertyInfo[] currentImageProperties = databaseObject.GetType().GetProperties();
            PropertyInfo[] imageUpdateDTOProperties = objectUpdateDTO.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in currentImageProperties)
            {
                PropertyInfo? DTOPropertyInfo = imageUpdateDTOProperties.FirstOrDefault(DTOProp => DTOProp.Name == propertyInfo.Name);
                if (DTOPropertyInfo is not null)
                {
                    propertyInfo.SetValue(databaseObject, (DTOPropertyInfo.GetValue(objectUpdateDTO) ?? propertyInfo.GetValue(databaseObject)));
                }
            }
            return databaseObject;
        }
    }
}
