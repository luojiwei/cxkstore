﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cxkstore
{
    public partial class test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tt1.Text = Request.QueryString["phonename"];
        }
        public string ttttt= "test2.aspx?phonename=测试boot";
    }
}