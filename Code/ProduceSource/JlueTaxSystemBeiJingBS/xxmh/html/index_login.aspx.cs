﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JlueTaxSystemBeiJingBS.xxmh.html
{
    public partial class index_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string questionId = (Request.QueryString["questionId"] == null ? "" : Request.QueryString["questionId"].ToString());
                if (questionId != "")
                {
                    string userquestionId = Request.QueryString["userquestionId"].ToString();
                    string companyId = Request.QueryString["companyId"].ToString();
                    string classId = Request.QueryString["classid"].ToString();
                    string courseId = Request.QueryString["courseid"].ToString();
                    string userId = Request.QueryString["userid"].ToString();
                    string Name = Request.QueryString["Name"].ToString();

                    Session["questionId"] = questionId;
                    Session["userquestionId"] = userquestionId;
                    Session["companyId"] = companyId;
                    Session["classId"] = classId;
                    Session["courseId"] = courseId;
                    Session["userId"] = userId;
                    Session["Name"] = Name;

                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}