using Sabio.Data;
using Sandbox.Web.Domain;
using Sandbox.Web.Models.Requests;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sandbox.Web.Services
{
    public class PogTypeService : BaseService
    {

        public static int Insert(PogTypeAddRequest model)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PogType_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    MapCommonParameters(model, paramCollection);

                    SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
                    p.Direction = ParameterDirection.Output;
                    paramCollection.Add(p);

                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out id);
                }
            );

            return id;
        }

        public static void Update(PogTypeUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PogType_Update",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", model.Id);
                    MapCommonParameters(model, paramCollection);
                }
            );

            return;
        }

        

        public static void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PogType_Delete",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }
                );
            return;
        }

        public static PogType SelectById(int id)
        {
            PogType PogType = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.PogType_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                },
                map: delegate (IDataReader reader, short set)
                {
                    PogType = PogTypeMap(reader);
                }
                );
            return PogType;
        }

        

        public static List<PogType> SelectAll()
        {
            List<PogType> list = new List<PogType>();

            DataProvider.ExecuteCmd(GetConnection, "dbo.PogType_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    PogType p = PogTypeMap(reader);
                    list.Add(p);
                }
                );
            return list;
        }

        #region Helper Methods

        private static void MapCommonParameters(PogTypeAddRequest model, SqlParameterCollection paramCollection)
        {
            paramCollection.AddWithValue("@Name", model.Name);
            paramCollection.AddWithValue("@Code", model.Code);
            paramCollection.AddWithValue("@DisplayOrder", model.DisplayOrder);
            paramCollection.AddWithValue("@Inactive", model.Inactive);
        }

        private static PogType PogTypeMap(IDataReader reader)
        {
            PogType PogType = new PogType();
            int startingIndex = 0;

            PogType.Id = reader.GetSafeInt32(startingIndex++);
            PogType.Code = reader.GetSafeString(startingIndex++);
            PogType.Name = reader.GetSafeString(startingIndex++);
            PogType.Inactive = reader.GetSafeBool(startingIndex++);
            PogType.DisplayOrder = reader.GetSafeInt32(startingIndex++);
            return PogType;
        }

        #endregion

    }
}