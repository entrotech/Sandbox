using Sabio.Data;
using Sandbox.Web.Classes;
using Sandbox.Web.Domain;
using Sandbox.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sandbox.Web.Services
{
    public class PogService : BaseService
    {
        #region Pogs

        public static List<Pog> Search(PogSearchRequest model, out int rowCount)
        {
            List<Pog> list = null;
            Dictionary<int, Pog> dict = null;
            int pogId = 0;
            int rows = 0;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Pogs_Search"
                , inputParamMapper: delegate (SqlParameterCollection parms)
                {
                    parms.AddWithValue("@name", model.Name);
                    parms.AddWithValue("@fromInstant", model.FromInstant);
                    parms.AddWithValue("@toInstant", model.ToInstant);
                    parms.AddWithValue("@currentPage", model.CurrentPage);
                    parms.AddWithValue("@itemsPerPage", model.ItemsPerPage);
                }
                , map: delegate (IDataReader reader, short set)
                {
                    switch (set)
                    {
                        case 0:
                            Pog pog = MapPog(reader, out rows);
                            if (list == null)
                            {
                                list = new List<Pog>();
                            }
                            list.Add(pog);
                            if (dict == null)
                            {
                                dict = new Dictionary<int, Pog>();
                            }
                            dict.Add(pog.Id, pog);
                            break;
                        case 1:
                            PogFile pogFile = MapPogFile(reader, out pogId);
                            Pog parentPog = dict[pogId];
                            if (parentPog.PogFiles == null)
                            {
                                parentPog.PogFiles = new List<PogFile>();
                            }
                            parentPog.PogFiles.Add(pogFile);
                            break;
                    }
                });
            rowCount = rows;
            return list;
        }

        public static Pog SelectById(int id)
        {
            Pog pog = new Pog();
            int pogId = 0;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Pogs_SelectById"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }
                , map: delegate (IDataReader reader, short set)
                {
                    int totalRows = 0;
                    switch (set)
                    {
                        case 0:
                            pog = MapPog(reader, out totalRows);
                            break;
                        case 1:
                            PogFile pogFile = MapPogFile(reader, out pogId);
                            if (pog.PogFiles == null)
                            {
                                pog.PogFiles = new List<PogFile>();
                            }
                            pog.PogFiles.Add(pogFile);
                            break;
                    }
                });
            return pog;
        }

        public static int Insert(PogPostRequest model)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Pogs_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   MapPogParameters(model, paramCollection);
                   paramCollection.AddOutputParameter("@Id", System.Data.SqlDbType.Int);
               },
               returnParameters: delegate (SqlParameterCollection param)
               {
                   id = Convert.ToInt32(param["@Id"].Value);
               });
            return id;
        }

        public static void Update(PogPutRequest model)
        {
            //string UserId = UserService.GetCurrentUserId();
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Pogs_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", model.Id);
                   MapPogParameters(model, paramCollection);
               },
               returnParameters: null);
        }

        public static void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Pogs_Delete"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               },
               returnParameters: null);
        }

        #endregion

        #region PogFiles

        public static int InsertPogFile(PogFileAddRequest model)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PogFiles_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   MapPogFileParameters(model, paramCollection);
                   paramCollection.AddOutputParameter("@Id", System.Data.SqlDbType.Int);
               },
               returnParameters: delegate (SqlParameterCollection param)
               {
                   id = Convert.ToInt32(param["@Id"].Value);
               });
            return id;
        }
  
        public static void UpdatePogFile(PogFileUpdateRequest model)
        {
            //string UserId = UserService.GetCurrentUserId();
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PogFiles_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   MapPogFileParameters(model, paramCollection);
                   paramCollection.AddWithValue("@Id", model.Id);
               },
               returnParameters: null);
        }

        #endregion

        #region Helper Methods

        private static void MapPogParameters(PogPostRequest model, SqlParameterCollection pc)
        {
            pc.AddWithValue("@Name", model.Name);
            pc.AddWithValue("@Description", model.Description);
            pc.AddWithValue("@Email", model.Email);
            pc.AddWithValue("@Phone", model.Phone);
            pc.AddWithValue("@WhenInstant", model.WhenInstant);
            pc.AddWithValue("@WhenLocalDateTime", model.WhenLocalDateTime);
            pc.AddWithValue("@WhenDateTimeOffset", model.WhenDateTimeOffset);
        }

        private static Pog MapPog(IDataReader rdr, out int totalRows)
        {
            Pog c = new Pog();
            int ord = 0;

            c.Id = rdr.GetInt32(ord++);
            c.Name = rdr.GetString(ord++);
            c.Description = rdr.GetString(ord++);
            c.Email = rdr.GetSafeString(ord++);
            c.Phone = rdr.GetSafeString(ord++);
            c.WhenInstant = rdr.GetSafeUtcDateTimeNullable(ord++);
            c.WhenLocalDateTime = rdr.GetSafeDateTimeNullable(ord++);
            c.WhenDateTimeOffset = rdr.GetSafeDateTimeOffsetNullable(ord++);
            totalRows = rdr.GetSafeInt32(ord++);

            return c;
        }

        private static PogFile MapPogFile(IDataReader rdr, out int pogId)
        {
            PogFile pogFile = new PogFile();
            int ord = 0;
            pogFile.Id = rdr.GetInt32(ord++);
            pogId = rdr.GetSafeInt32(ord++);
            pogFile.FileKey = rdr.GetSafeString(ord++);
            pogFile.Caption = rdr.GetSafeString(ord++);
            pogFile.Url = ServiceConfig.GetUrlForFile(pogFile.FileKey);
            return pogFile;
        }

        private static void MapPogFileParameters(PogFileAddRequest model, SqlParameterCollection paramCollection)
        {
            paramCollection.AddWithValue("@PogId", model.PogId);
            paramCollection.AddWithValue("@Caption", model.Caption);
            paramCollection.AddWithValue("@FileKey", model.FileKey);
        }

        #endregion
    }
}