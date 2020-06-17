using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Epic.Models;

namespace Epic.DAL.DAL_Models
{
    public class DAL_Tag
    {
        #region Create
        public static bool Create(Tag tagu)
        {
            var conn = DBHelper.GetConnection();
            try
            {
                var cmd = new SqlCommand("sp_Tags_Create", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", tagu.Name);
                cmd.Parameters.AddWithValue("@Description", tagu.Description);

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
        public static Tag Read(int? id)
        {
            var tagu = new Tag();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("sp_Tags_Read", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                if (id != null)
                {
                    cmd.Parameters.AddWithValue("@TagID", id);

                    conn.Open();
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        tagu.TagID = int.Parse(rdr["TagID"].ToString());
                        tagu.Description = rdr["Description"].ToString();
                        tagu.Name = rdr["Name"].ToString();
                    }
                    return tagu;
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
        public static bool Update(Tag tagu)
        {
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("sp_Tags_Update", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@TagID", tagu.TagID);
                cmd.Parameters.AddWithValue("@Description", tagu.Description);
                cmd.Parameters.AddWithValue("@Name", tagu.Name);

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

            var cmd = new SqlCommand("sp_Tags_Detele", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@TagID", id);

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

        #region ListTags
        public static List<Tag> ListTags()
        {
            var LstTag = new List<Tag>();
            var conn = DBHelper.GetConnection();
            var cmd = new SqlCommand("sp_Tags_GetAll", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var tagu = new Tag();
                tagu.TagID = int.Parse(rdr["TagID"].ToString());
                tagu.Name = rdr["Name"].ToString();
                tagu.Description = rdr["Description"].ToString();
                LstTag.Add(tagu);
            }
            return LstTag;
        }
        #endregion
    }
}