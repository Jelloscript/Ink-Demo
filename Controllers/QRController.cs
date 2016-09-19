using Sabio.Web.Models.Responses;
using Sabio.Web.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.Common;

namespace Sabio.Web.Controllers
{
    [RoutePrefix("QRCode")]
    public class QRController : BaseController
    {
        // GET: QR
        [Route, HttpGet]
        [Authorize]
        public ActionResult GetImage()
        {
            string id = UserService.GetCurrentUserId();

            Bitmap UserQR = QRCodeService.GenerateQR(500, 500, id);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            UserQR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] byteImage = ms.ToArray();

            return File(byteImage, "image/jpg");
        }


        [Route("Reader")]
        public ActionResult Reader()
        {
            return View();
        }
    }
}