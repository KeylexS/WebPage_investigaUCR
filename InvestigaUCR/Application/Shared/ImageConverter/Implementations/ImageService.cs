using Application.Shared.ImageConverter;
using Domain.Shared.ImageConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Implementations
{
    internal class ImageService : IImageService
    {
        private readonly IImageConverter _converter;

        public ImageService(IImageConverter converter)
        {
            _converter = converter;
        }

        public byte[]? ConvertImageToByte(string url)
        {
            return _converter.ConvertImageToByte(url);
        }

        public string ConvertByteToImage(byte[] img)
		{
            return _converter.ConvertByteToImage(img);
		}

    }
}
