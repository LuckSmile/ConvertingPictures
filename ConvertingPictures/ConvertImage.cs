using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace ConvertingPictures
{
    public class ConvertImage
    {
        public string ImageToString(string path)
        {
            MemoryStream memoryStream = new MemoryStream();
            Image answer = Image.FromFile(path);
            answer.Save(memoryStream, answer.RawFormat);
            byte[] bytes = memoryStream.ToArray();
            return Convert.ToBase64String(bytes);
        }
        public BitmapSource StringToBitmapSource(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                var decoder = BitmapDecoder.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                return decoder.Frames[0];
            }
        }
    }
}
