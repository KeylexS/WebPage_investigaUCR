using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Domain.Shared;
using Domain.Shared.ImageConverter;
using LanguageExt;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Shared.ImageConverter
{
    internal class ImageConverter : IImageConverter
    {
        /// <summary>
        /// Method <c>ConvertImageToByte</c> Converts an image into an array of bytes
        /// </summary>
        /// <param name="url">A string with the url of the image</param>
        /// <returns>An array of bytes</returns>
        public byte[]? ConvertImageToByte(string url)
        {
            try
            {
                #pragma warning disable CA1416 // Validar la compatibilidad de la plataforma
                Image img = Image.FromFile(url);
                #pragma warning restore CA1416 // Validar la compatibilidad de la plataforma
                using (var ms = new MemoryStream())
                {
                #pragma warning disable CA1416 // Validar la compatibilidad de la plataforma
                    img.Save(ms,
                             img.RawFormat);
                #pragma warning restore CA1416 // Validar la compatibilidad de la plataforma
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("IOException source: {0}", ex.Source);
                return null;
            }

        }

        /// <summary>
        /// Method <c>ConvertByteToImage</c> Converts an array of byte into a string that can be readed as an image.
        /// </summary>
        /// <param name="img">The array of bytes to convert</param>
        /// <returns>A string</returns>
        public string ConvertByteToImage(byte[] img)
		{
            return "data:image / bmp; base64," + @Convert.ToBase64String(img);
        }

    }
}
