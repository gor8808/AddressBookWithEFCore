using System;
using System.IO;
using QRCoder;

namespace AddressBookWithEFCore.Services
{
    public class QrCodeGeneratorService
    {
        public static string GenerateQrFrom(string text)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCode = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qr = new QRCode(qrCode);
            using var bitMap = qr.GetGraphic(20);
            using var ms = new MemoryStream();
            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            var byteImage = ms.ToArray();
            return "data:image/png;base64," + Convert.ToBase64String(byteImage);
        }
    }
}
