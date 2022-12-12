using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Domain.Shared.ImageConverter
{
    /// <summary>
    /// Interface <c>IImageConverter</c> A shared service to convert images.
    /// </summary>
    public interface IImageConverter
    {
        /// <summary>
        /// Method <c>ConvertImageToByte</c> Converts an image into an array of bytes
        /// </summary>
        /// <param name="url">A string with the url of the image</param>
        /// <returns>An array of bytes</returns>
        byte[]? ConvertImageToByte(String url);

        /// <summary>
        /// Method <c>ConvertByteToImage</c> Converts an array of byte into a string that can be readed as an image.
        /// </summary>
        /// <param name="img">The array of bytes to convert</param>
        /// <returns>A string</returns>
        String ConvertByteToImage(byte[] img);
    }
}
