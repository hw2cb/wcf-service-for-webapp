using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_for_wcf
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            GridView1.DataSource = client.getCustomers();
            
            GridView1.AutoGenerateSelectButton = true;
            GridView1.DataBind();
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            GridViewRow row = GridView1.SelectedRow;
            int id = Convert.ToInt32(row.Cells[4].Text);
            GridView2.DataSource = client.getOrders(id);
            GridView2.DataBind();
        }
    }
    
}