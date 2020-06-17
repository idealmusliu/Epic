using Epic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Epic.DAL.DAL_Models
{
    #region
    public class DAL_TagPost
    {
        public static bool Create(int PostID, int TagID)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("sp_TagPost", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PostID", PostID);
                cmd.Parameters.AddWithValue("@TagID", TagID);

                conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DBHelper.CloseConnection(conn);
                //cmd.Dispose();
            }
        }
    }
    #endregion
}