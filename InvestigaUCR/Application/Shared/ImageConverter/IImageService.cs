using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.ImageConverter
{
    public interface IImageService
    {
        byte[]? ConvertImageToByte(String url);
        string ConvertByteToImage(byte[] img);
    }
}
