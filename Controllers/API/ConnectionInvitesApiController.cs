using Sabio.Web.Domain;
using Sabio.Web.Models;
using Sabio.Web.Models.Requests;
using Sabio.Web.Models.Responses;
using Sabio.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/connectionInvites")]
    public class ConnectionInvitesApiController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage Insert(RequestConnectionsRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            string userId = UserService.GetCurrentUserId();
            model.RequesterId = userId;

            ItemResponse<Boolean> resp = new ItemResponse<Boolean>();

            resp.Item = ConnectionInviteService.Post(model);
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        [Route("sent"), HttpGet]
        public HttpResponseMessage GetCurrentSentInvites()
        {
            string userId = UserService.GetCurrentUserId();

            List<ConnectionInvites> userInvitations = ConnectionInviteService.GetByInviter(userId);

            ItemsResponse<ConnectionInvites> response = new ItemsResponse<ConnectionInvites>();

            response.Items = userInvitations;

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
        [Route("received"), HttpGet]
        public HttpResponseMessage GetCurrentRecievedInvites()
        {
            string userId = UserService.GetCurrentUserId();

            List<ConnectionInvites> userInvitations = ConnectionInviteService.GetByInvited(userId);

            ItemsResponse<ConnectionInvites> response = new ItemsResponse<ConnectionInvites>();

            response.Items = userInvitations;

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

    }
}
