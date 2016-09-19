using Sabio.Data;
using Sabio.Web.Domain;
using Sabio.Web.Enums;
using Sabio.Web.Models;
using Sabio.Web.Models.Requests;
using Sabio.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Web.Services
{
    public class ConnectionInviteService :BaseService
    {

        public static Boolean Post(RequestConnectionsRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.User_ConnectionInvites"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@RequesterId", model.RequesterId);
                   paramCollection.AddWithValue("@RequestedId", model.RequestedId);
                   paramCollection.AddWithValue("@Status", model.Status);
               }, returnParameters: delegate (SqlParameterCollection param)
               {

               }
               );
            return true;

        }


        public static List<ConnectionInvites> GetByInviter(string RequesterId)
        {
            List<ConnectionInvites> resp = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.ConnectionInvites_SelectByRequester"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@RequesterId", RequesterId);

               }

               , map: delegate (IDataReader reader, short set)
               {
                   int startingIndex = 0; //startingOrdinal

                   ConnectionInvites c = new ConnectionInvites();

                   c.ConnectionRequestId = reader.GetSafeInt32(startingIndex++);

                   c.RequesterId = reader.GetSafeString(startingIndex++);

                   c.RequestedId = reader.GetSafeString(startingIndex++);

                   c.Status = reader.GetSafeInt32(startingIndex++);

                   c.CreatedDate = reader.GetSafeDateTime(startingIndex++);

                   User u = new User();
                   u.ProfileName = reader.GetSafeString(startingIndex++);
                   u.ProfileEmail = reader.GetSafeString(startingIndex++);
                   u.ProfilePhone = reader.GetSafeString(startingIndex++);
                   u.ProfileMobile = reader.GetSafeString(startingIndex++);
                   u.ProfileWebsite = reader.GetSafeString(startingIndex++);
                   u.ProfileAddress = reader.GetSafeString(startingIndex++);
                   u.ProfileCompany = reader.GetSafeString(startingIndex++);
                   u.UserId = reader.GetSafeString(startingIndex++);

                   Medias m = new Medias();
                   m.MediasTableId = reader.GetSafeInt32(startingIndex++);
                   m.CreatedDate = reader.GetSafeDateTime(startingIndex++);
                   m.ModifiedDate = reader.GetSafeDateTime(startingIndex++);
                   m.MediaType = reader.GetSafeEnum<MediaType>(startingIndex++);
                   m.ContentType = reader.GetSafeString(startingIndex++);
                   m.UserId = reader.GetSafeString(startingIndex++);
                   m.FilePath = reader.GetSafeString(startingIndex++);

                   u.Avatar = m;

                   c.RequesterInfo = u;

                   User z = new User();
                   z.ProfileName = reader.GetSafeString(startingIndex++);
                   z.ProfileEmail = reader.GetSafeString(startingIndex++);
                   z.ProfilePhone = reader.GetSafeString(startingIndex++);
                   z.ProfileMobile = reader.GetSafeString(startingIndex++);
                   z.ProfileWebsite = reader.GetSafeString(startingIndex++);
                   z.ProfileAddress = reader.GetSafeString(startingIndex++);
                   z.ProfileCompany = reader.GetSafeString(startingIndex++);
                   z.UserId = reader.GetSafeString(startingIndex++);

                   Medias y = new Medias();
                   y.MediasTableId = reader.GetSafeInt32(startingIndex++);
                   y.CreatedDate = reader.GetSafeDateTime(startingIndex++);
                   y.ModifiedDate = reader.GetSafeDateTime(startingIndex++);
                   y.MediaType = reader.GetSafeEnum<MediaType>(startingIndex++);
                   y.ContentType = reader.GetSafeString(startingIndex++);
                   y.UserId = reader.GetSafeString(startingIndex++);
                   y.FilePath = reader.GetSafeString(startingIndex++);

                   z.Avatar = y;

                   c.RequestedInfo = z;

                   if (resp == null)
                   {
                       resp = new List<ConnectionInvites>();
                   }

                   resp.Add(c);
               }
               );


            return resp;
        }

        public static List<ConnectionInvites> GetByInvited(string RequesterId)
        {
            List<ConnectionInvites> resp = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.ConnectionInvites_SelectByRequested"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@RequestedId", RequesterId);

               }

               , map: delegate (IDataReader reader, short set)
               {
                   int startingIndex = 0; //startingOrdinal

                   ConnectionInvites c = new ConnectionInvites();

                   c.ConnectionRequestId = reader.GetSafeInt32(startingIndex++);

                   c.RequesterId = reader.GetSafeString(startingIndex++);

                   c.RequestedId = reader.GetSafeString(startingIndex++);

                   c.Status = reader.GetSafeInt32(startingIndex++);

                   c.CreatedDate = reader.GetSafeDateTime(startingIndex++);

                   User u = new User();
                   u.ProfileName = reader.GetSafeString(startingIndex++);
                   u.ProfileEmail = reader.GetSafeString(startingIndex++);
                   u.ProfilePhone = reader.GetSafeString(startingIndex++);
                   u.ProfileMobile = reader.GetSafeString(startingIndex++);
                   u.ProfileWebsite = reader.GetSafeString(startingIndex++);
                   u.ProfileAddress = reader.GetSafeString(startingIndex++);
                   u.ProfileCompany = reader.GetSafeString(startingIndex++);
                   u.UserId = reader.GetSafeString(startingIndex++);

                   Medias m = new Medias();
                   m.MediasTableId = reader.GetSafeInt32(startingIndex++);
                   m.CreatedDate = reader.GetSafeDateTime(startingIndex++);
                   m.ModifiedDate = reader.GetSafeDateTime(startingIndex++);
                   m.MediaType = reader.GetSafeEnum<MediaType>(startingIndex++);
                   m.ContentType = reader.GetSafeString(startingIndex++);
                   m.UserId = reader.GetSafeString(startingIndex++);
                   m.FilePath = reader.GetSafeString(startingIndex++);

                   u.Avatar = m;

                   c.RequesterInfo = u;

                   User z = new User();
                   z.ProfileName = reader.GetSafeString(startingIndex++);
                   z.ProfileEmail = reader.GetSafeString(startingIndex++);
                   z.ProfilePhone = reader.GetSafeString(startingIndex++);
                   z.ProfileMobile = reader.GetSafeString(startingIndex++);
                   z.ProfileWebsite = reader.GetSafeString(startingIndex++);
                   z.ProfileAddress = reader.GetSafeString(startingIndex++);
                   z.ProfileCompany = reader.GetSafeString(startingIndex++);
                   z.UserId = reader.GetSafeString(startingIndex++);

                   Medias y = new Medias();
                   y.MediasTableId = reader.GetSafeInt32(startingIndex++);
                   y.CreatedDate = reader.GetSafeDateTime(startingIndex++);
                   y.ModifiedDate = reader.GetSafeDateTime(startingIndex++);
                   y.MediaType = reader.GetSafeEnum<MediaType>(startingIndex++);
                   y.ContentType = reader.GetSafeString(startingIndex++);
                   y.UserId = reader.GetSafeString(startingIndex++);
                   y.FilePath = reader.GetSafeString(startingIndex++);

                   z.Avatar = y;

                   c.RequestedInfo = z;

                   if (resp == null)
                   {
                       resp = new List<ConnectionInvites>();
                   }

                   resp.Add(c);
               }
               );


            return resp;
        }
    }




}