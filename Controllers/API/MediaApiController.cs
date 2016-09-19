using Sabio.Web.Models.Requests;
using Sabio.Web.Models.Responses;
using Sabio.Web.Services;
using Sabio.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ZXing;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/media")]
    public class MediaApiController : ApiController
    {
        private IMediaService _mediaService { get; set; }
        public MediaApiController(IMediaService mediaService)
        {
            this._mediaService = mediaService;
        }
        [Authorize]
        [Route("{MediaType}"), HttpPost]
        public HttpResponseMessage Post(string MediaType)
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                bool amazonCall = false;
                string keyName = "";
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var localFilePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    var extentionType = Path.GetExtension(postedFile.FileName);
                    int themeId = 196;
                    keyName = Guid.NewGuid().ToString() + extentionType;//.Substring(0, 12);
                    postedFile.SaveAs(localFilePath);
                    amazonCall = MediaFileService.sendMyFileToS3(localFilePath, keyName);

                    //creating thumbnail of image and sending to database
                    var thumbPath = HttpContext.Current.Server.MapPath("~/thumbnail" + postedFile.FileName);
                    ThumbnailService.ResizeImage(localFilePath, thumbPath, 400, 400, ImageFormat.Jpeg);
                    amazonCall = MediaFileService.sendMyFileToS3(thumbPath, "thumbnail/" + keyName);

                    MediaProfileRequest request = new MediaProfileRequest();
                    request.MediaType = MediaType;
                    request.ContentType = MimeMapping.GetMimeMapping(postedFile.FileName);
                    request.UserId = UserService.GetCurrentUserId();
                    request.FilePath = ConfigService.uploadFileS3Prefix + "/" + keyName;
                    request.MediaThemeId = themeId++;
                    int MediaId = this._mediaService.Post(request);
                    ItemResponse<int> response = new ItemResponse<int>();
                    response.Item = MediaId;

                    docfiles.Add(localFilePath);
                    result = Request.CreateResponse(HttpStatusCode.OK, response);
                    return result;
                }
                result = Request.CreateResponse(HttpStatusCode.Created, keyName);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        [Route("QRMedia"), HttpPost]
        public HttpResponseMessage GetQR()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            foreach (string file in httpRequest.Files)
            {
                // create a barcode reader instance
                var barcodeReader = new BarcodeReader();
                var postedFile = httpRequest.Files[file];
                var localFilePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                postedFile.SaveAs(localFilePath);
                // create an in memory bitmap
                var barcodeBitmap = (Bitmap)Bitmap.FromFile(localFilePath);

                // decode the barcode from the in memory bitmap
                var barcodeResult = barcodeReader.Decode(barcodeBitmap);

                var response = barcodeResult;

                result = Request.CreateResponse(HttpStatusCode.OK, response);
                return result;
            }
            return result;
        }
    }
}
