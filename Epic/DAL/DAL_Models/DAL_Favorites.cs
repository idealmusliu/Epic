using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Epic.DAL.DAL_Models
{
    public class DAL_Favorites
    {
        public static bool Create(string UserID, int PostID)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("TagPost", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PostID", PostID);

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
        #region FavoritePosts
        public static List<int> GetFavoritePostsByCurrentUser(string UserID)
        {
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("sp_FavoritePosts", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            List<int> postIds = null;
            try
            {
                cmd.Parameters.AddWithValue("@UserId",UserID);
                conn.Open();
                var reader=cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    postIds = new List<int>();
                    while (reader.Read())
                    {
                        int tempId = int.Parse(reader["PostID"].ToString());
                        postIds.Add(tempId);
                    }
                }

                return postIds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                DBHelper.CloseConnection(conn);
                cmd.Dispose();
            }

        }
        #endregion
    }
}