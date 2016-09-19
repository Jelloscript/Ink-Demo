using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sabio.Web.Models.Requests;
using System.Data.SqlClient;
using System.Data;
using Sabio.Data;
using Sabio.Web.Domain;
using Sabio.Web.Models;
using Sabio.Web.Services.Interfaces;

namespace Sabio.Web.Services
{
    public class MediaService : BaseService, IMediaService
    {
        public int Post(MediaProfileRequest model)
        {
            int OutputId = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Media_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@MediaType", model.MediaType);
                   paramCollection.AddWithValue("@ContentType", model.ContentType);
                   paramCollection.AddWithValue("@UserId", model.UserId);
                   paramCollection.AddWithValue("@FilePath", model.FilePath);


                   SqlParameter p = new SqlParameter("@MediaId", System.Data.SqlDbType.Int);

                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);


               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@MediaId"].Value.ToString(), out OutputId);

               }
               );


            return OutputId;
        }

        public void Put(UsersProfilesMediaUpdateRequest model)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.UserProfile_UpdateAvatarById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", model.UserId);
                   paramCollection.AddWithValue("@MediaId", model.MediaId);


               }, returnParameters: delegate (SqlParameterCollection param)
               {

               }
               );

        }

        public void PutTheme(UsersProfilesMediaUpdateRequest model)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.UserProfile_UpdateThemeById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", model.UserId);
                   paramCollection.AddWithValue("@MediaId", model.MediaId);


               }, returnParameters: delegate (SqlParameterCollection param)
               {

               });
        }
    }
}