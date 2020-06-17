using Epic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Epic.DAL.DAL_Models
{
    public class DAL_Post
    {
        #region Create
        public static bool Create(Post posti)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("dbo.sp_Posts_Create", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", posti.UserID);
                cmd.Parameters.AddWithValue("@Description", posti.Description);
                cmd.Parameters.AddWithValue("@PicPath", posti.PicPath);
                cmd.Parameters.AddWithValue("@Date", posti.Date);

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
        #endregion

        #region Read
        public static Post Read(int? id)
        {
            var posti = new Post();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("sp_Posts_Read", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                if (id != null)
                {
                    cmd.Parameters.AddWithValue("@PostID", id);

                    conn.Open();
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        posti.PostID = int.Parse(rdr["PostID"].ToString());
                        posti.Description = rdr["Description"].ToString();
                        posti.PicPath = rdr["PicPath"].ToString();
                        posti.Date = Convert.ToDateTime(rdr["Date"]);
                    }
                    return posti;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Update
        public static bool Update(Post posti)
        {
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("sp_Posts_Update", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Description", posti.Description);
                cmd.Parameters.AddWithValue("@PicPath", posti.PicPath);

                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DBHelper.CloseConnection(conn);
                cmd.Dispose();
            }
        }
        #endregion

        #region Delete
        public static bool Delete(int id)
        {
            var conn = DBHelper.GetConnection();

            var cmd = new SqlCommand("sp_Posts_Detele", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@PostID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                //return false;
                throw;
            }
            finally
            {
                DBHelper.CloseConnection(conn);
                cmd.Dispose();
            }
        }
        #endregion

        #region List My Posts
        public static List<Post> ListMyPost()
        {
            var LstPost = new List<Post>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("sp_Posts_GetAllMyPosts", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var posti = new Post();
                posti.PostID = int.Parse(rdr["PostID"].ToString());
                posti.Description = rdr["Description"].ToString();
                posti.PicPath = rdr["PicPath"].ToString();
                posti.Date = Convert.ToDateTime(rdr["Date"].ToString());
                posti.PicPath = rdr["PicPath"].ToString();

                LstPost.Add(posti);
            }
            return LstPost;
        }
        #endregion

        #region List All Posts
        public static List<Post> ListPost()
        {
            var LstPost = new List<Post>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("sp_Posts_GetAll", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var posti = new Post();
                posti.PostID = int.Parse(rdr["PostID"].ToString());
                posti.Description = rdr["Description"].ToString();
                posti.PicPath = rdr["PicPath"].ToString();
                posti.Date = Convert.ToDateTime(rdr["Date"].ToString());
                posti.PicPath = rdr["PicPath"].ToString();

                LstPost.Add(posti);
            }
            return LstPost;
        }
        #endregion
    }
}