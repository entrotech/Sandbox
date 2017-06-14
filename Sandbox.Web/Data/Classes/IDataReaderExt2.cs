using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Classes
{
    public static class IDataReaderExt2
    {

        public static DateTimeOffset GetSafeDateTimeOffset(this IDataReader reader, Int32 ordinal)
        {
            if (reader[ordinal] != null && reader[ordinal] != DBNull.Value)
            {
                var rdr = reader as SqlDataReader;
                if (rdr != null)
                {
                    return rdr.GetDateTimeOffset(ordinal);
                }
                return default(DateTimeOffset);
            }
            else
            {
                return default(DateTime);
            }
        }

        public static DateTimeOffset? GetSafeDateTimeOffsetNullable(this IDataReader reader, Int32 ordinal)
        {
            if (reader[ordinal] != null && reader[ordinal] != DBNull.Value)
            {
                var rdr = reader as SqlDataReader;
                if (rdr != null)
                {
                    return rdr.GetDateTimeOffset(ordinal);
                }
                return null;
            }
            else
            {
                return null;
            }
        }


    }
}