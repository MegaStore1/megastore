using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MegaStore.API.Helpers
{
    public static class FileManager
    {
        private static readonly List<string> imageExtension = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public async static Task<string> Upload(FormFile file, string path)
        {
            string folderName = Path.Combine("Resources", path);

            string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            string fileName = "";

            if (file.Length > 0)
            {
                fileName = DateTime.Now.Ticks + "-" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName!.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (Stream stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    string ext = Path.GetExtension(fileName);
                    if (isImageType(ext))
                    {
                        string thumbName = Path.GetFileNameWithoutExtension(fileName) + "_thumb" + ext;
                        string thumbPath = Path.Combine(pathToSave, thumbName);
                        Image image = Image.FromStream(stream);
                        Image thumb = image.GetThumbnailImage(150, 150, () => false, IntPtr.Zero);
                        thumb.Save(thumbPath);
                    }
                }
            }
            return fileName;
        }

        private static bool isImageType(string extension)
        {
            return imageExtension.Contains(extension.ToUpperInvariant());
        }
    }
}