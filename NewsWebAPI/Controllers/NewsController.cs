using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FirstAPI.Models;
using Newtonsoft.Json;
using NewsWebAPI.Models;
using NewsAPP.Models;
using System.Reflection.PortableExecutable;
using System.Web.Http.Cors;

namespace FirstAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000/", headers: "*", methods: "*")]

    [Route("api/[controller]")]
    [ApiController]

    public class NewsController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public NewsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("get_users")]
        //public JsonResult GetUserData()


        public List<User> GetUserData()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("NewsAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("Select * from user_detail", con);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<User> newsList = new List<User>();
            Response response = new Response();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i<dt.Rows.Count; i++)
                {
                    User news = new User();
                    news.Id = Convert.ToInt32(dt.Rows[i]["user_id"]);
                    news.Name = Convert.ToString(dt.Rows[i]["user_name"]);
                    newsList.Add(news);

                }
            }
            return newsList;
        }



        [HttpPost]
        [Route("get_news")]

        public List<NewsDetail> GetNewsData(UserId user_id)
        {
            List<NewsDetail> newsDetail = new List<NewsDetail>();
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("NewsAppCon").ToString());
            con.Open();

            SqlCommand cmd = new SqlCommand("get_news_detail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_user_id", user_id.user_id);

            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                NewsDetail nd = new NewsDetail();
                nd.user_name = reader.GetString(0);
                nd.category_name = reader.GetString(1);
                nd.news_content = reader.GetString(2);
                nd.news_date = reader.GetDateTime(3).ToString();

                newsDetail.Add(nd);
            }
            return newsDetail;

            
        }


        [HttpPost]
        [Route("AddUser")]
        public List<AddUserResponse> AddUser(AddUser adduser)
        {
            
            //connection
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("NewsAppCon").ToString());
            con.Open();

            //procedure command 
            SqlCommand c = new SqlCommand("user_by_id", con);
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.AddWithValue("@id", adduser.UserId);
            int y = c.ExecuteNonQuery();
            int rows = 0;
            SqlDataReader reader = c.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                    rows++;
            con.Close();

            //connection
            con.Open();

            SqlCommand cmd = new SqlCommand("add_user", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DateTime createdDate = DateTime.Now;
            DateTime ModifiedDate = DateTime.Now;

            adduser.UserModifiedDate = ModifiedDate;
            adduser.UserCreatedDate = createdDate;

            cmd.Parameters.AddWithValue("@id", adduser.UserId);
            cmd.Parameters.AddWithValue("@name", adduser.UserName);
            /*cmd.Parameters.AddWithValue("@created_by", adduser.UserCreatedBy);
            cmd.Parameters.AddWithValue("@modified_by", adduser.UserModifiedBy);*/
            cmd.Parameters.AddWithValue("@isactive", adduser.UserIsactive);

            

            List<AddUserResponse> data = new List<AddUserResponse>();
            AddUserResponse res = new AddUserResponse();

            if (rows != 0)
            {
                res.statusCode = "404";
                res.statusMessage = "Id Already found";
                data.Add(res);
                return data;
            }
            cmd.ExecuteNonQuery();
            res.statusCode = "100";
            res.statusMessage = "Data added succesfully";
            data.Add(res);
            return data;
        }



        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public List<AddUserResponse> DeleteUser(string id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("NewsAppCon").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete_user", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Int32.Parse(id));
            cmd.ExecuteNonQuery();
            List<AddUserResponse> data = new List<AddUserResponse>();
            AddUserResponse res = new AddUserResponse();
            res.statusCode = "100";
            res.statusMessage = "User Deleted succesfully";
            data.Add(res);
            return data;
        }




        /*[HttpDelete]
        [Route("DeleteUser/{id}")]
        public List<AddUserResponse> DeleteUser(UserId userId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("NewsAppCon").ToString());
            con.Open();

            SqlCommand cmd = new SqlCommand("delete_user", con);
            cmd.CommandType = CommandType.StoredProcedure;

            *//*DateTime createdDate = DateTime.Now;
            DateTime ModifiedDate = DateTime.Now;

            adduser.UserModifiedDate = ModifiedDate;
            adduser.UserCreatedDate = createdDate;*//*

            cmd.Parameters.AddWithValue("@id", userId.user_id);
            *//*cmd.Parameters.AddWithValue("@name", adduser.UserName);
            cmd.Parameters.AddWithValue("@created_by", adduser.UserCreatedBy);
            cmd.Parameters.AddWithValue("@modified_by", adduser.UserModifiedBy);
            cmd.Parameters.AddWithValue("@isactive", adduser.UserIsactive);*//*

            cmd.ExecuteNonQuery();

            List<AddUserResponse> data = new List<AddUserResponse>();
            AddUserResponse res = new AddUserResponse();
            res.statusCode = "100";
            res.statusMessage = "User Deleted succesfully";
            data.Add(res);
            return data;
        }
*/

        [HttpGet]
        [Route("GetUserById/{id}")]
        public AddUser myuser(int id)
        {
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            /*SqlConnection con = new SqlConnection();*/

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("NewsAppCon").ToString());

            con.Open();
            com.Connection = con;
            com.CommandText = "select * from user_detail where user_id=@x";
            com.Parameters.AddWithValue("@x", id);
            dr = com.ExecuteReader();

            AddUser userList = new AddUser();
            Response response = new Response();

            while (dr.Read())
            {
                userList.UserId = Convert.ToInt32(dr["user_id"]);
                userList.UserName = Convert.ToString(dr["user_name"]);
                /*userList.UserCreatedDate = Convert.ToDateTime(dr["user_created_date"]);*/
                /*userList.UserCreatedBy = Convert.ToString(dr["user_created_by"]);*/
                /* userList.UserModifiedDate = DateTime.Now.Date;*/
                /*userList.UserModifiedBy = Convert.ToString(dr["user_modified_by"]);*/
                userList.UserIsactive = Convert.ToInt32(dr["user_isactive"]);

            }
            con.Close();

            return userList;
        }




        [HttpPost]
        [Route("EditUser")]
        public List<AddUserResponse> EditUser (EditUser editUser)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("NewsAppCon").ToString());
            con.Open();

            SqlCommand cmd = new SqlCommand("update_user", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", editUser.UserId);
            cmd.Parameters.AddWithValue("@name", editUser.UserName);
            
            /*cmd.Parameters.AddWithValue("@modified_by", editUser.UserModifiedBy);*/
            cmd.Parameters.AddWithValue("@isactive", Convert.ToBoolean(editUser.UserIsactive));
            cmd.ExecuteNonQuery();

            List<AddUserResponse> data = new List<AddUserResponse>();
            AddUserResponse res = new AddUserResponse();
            res.statusCode = "100";
            res.statusMessage = "User Edited succesfully";
            data.Add(res);
            return data;
        }


        /*[HttpPut]
        [Route("EditUser/{id}")]
        public List<AddUserResponse> EditUser(AddUser editUser)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("NewsAppCon").ToString());
            con.Open();

            SqlCommand cmd = new SqlCommand("update_user", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", editUser.UserId);
            cmd.Parameters.AddWithValue("@name", editUser.UserName);

            cmd.Parameters.AddWithValue("@modified_by", editUser.UserModifiedBy);
            cmd.Parameters.AddWithValue("@isactive", Convert.ToBoolean(editUser.UserIsactive));
            cmd.ExecuteNonQuery();

            List<AddUserResponse> data = new List<AddUserResponse>();
            AddUserResponse res = new AddUserResponse();
            res.statusCode = "100";
            res.statusMessage = "User Edited succesfully";
            data.Add(res);
            return data;
        }*/
    }
}


  