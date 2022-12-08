namespace MCS.Services
{
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName)
        {
            byte[] imageData;

            using (var ms = new MemoryStream())
            {
                await pictureFile.CopyToAsync(ms);
                imageData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (var updloadStream = new MemoryStream(imageData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = "images",
                    File = new FileDescription(fileName, updloadStream),
                };

                uploadResult = await this.cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult?.SecureUrl.AbsoluteUri;
        }
    }
}
