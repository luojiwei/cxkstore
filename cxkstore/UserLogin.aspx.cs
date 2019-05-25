﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cxkstore
{
    public partial class UserLogin : System.Web.UI.Page
    {
        string cxkdb = System.Configuration.ConfigurationManager.ConnectionStrings["CXKdbConnectionString"].ConnectionString; //数据库连接字串

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ZCButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Zhucepage.aspx");
        }

        protected void LoginButton1_Click(object sender, EventArgs e)
        {
            string Name, Password;
            Name = userName.Text;
            Password = userPassword.Text;
            using (SqlConnection sc = new SqlConnection(cxkdb))
            {
                SqlCommand sqlc = sc.CreateCommand();
                sc.Open();
                sqlc.CommandText = string.Format(" Select* from Userdb where username = N'{0}' and password = @password", Name);
                //Select * from Userdb where username = N'蔡徐坤' and password = '14564'
                sqlc.Parameters.AddWithValue("@password", Password);//正常来说密码应该加密存储

                using (SqlDataReader reader = sqlc.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if(reader["password"].ToString()== Password)
                        {
                            Response.Redirect("Mainpage.aspx");
                        }
                        else
                        {
                           // LoginButton1.Text = "密码或用户名输入错误！"; 实际不走
                        }
                    }
                    if(reader.HasRows==false)
                    {
                        LoginButton1.Text = "密码或用户名输入错误！";
                    }
                }
                /*int m = sqlc.ExecuteNonQuery();
                if (m == 1)
                    Response.Redirect("Mainpage.aspx");
                else
                    LoginButton1.Text = "密码或用户名输入错误！";
                 */


            }


        }
    }
}