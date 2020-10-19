using KTPMWEBW4.BLL;
using KTPMWEBW4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTPMWEBW4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Mouse> mouse = new MouseBUS().getAll();
            GridView1.DataSource = mouse;
            GridView1.DataBind();
        }
    }
}