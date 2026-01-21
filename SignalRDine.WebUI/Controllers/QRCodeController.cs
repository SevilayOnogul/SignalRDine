using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRDine.WebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            using(MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(memoryStream,ImageFormat.Png);
                    ViewBag.QRCodeImage="data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
                }

            }
            return View();
        }

        [HttpPost]
        public IActionResult Decode(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("Dosya seçilmedi.");

            using (var stream = file.OpenReadStream())
            {
                var bitmap = (Bitmap)Image.FromStream(stream);
                var reader = new ZXing.Windows.Compatibility.BarcodeReader();
                var result = reader.Decode(bitmap);

                if (result != null)
                    ViewBag.DecodedValue = result.Text; // QR içindeki metin
                else
                    ViewBag.DecodedValue = "QR Kod çözülemedi.";
            }
            return View("Index");
        }
    }
}
