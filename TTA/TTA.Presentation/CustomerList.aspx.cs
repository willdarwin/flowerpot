using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTA.BLL;
using TTA.ServiceProxy;
using TTA.Model;

namespace TTA.Presentation
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAllCustomers();
        }

        private void ShowAllCustomers()
        {
            Proxy service = new Proxy();
            List<CustomerBE> customers = service.GetAllCustomers();
            this.reapterCustomers.DataSource = customers;
            this.reapterCustomers.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Proxy service = new Proxy();
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.ToString() == "Delete")
            {
                service.DeleteCustomer(id);
                ShowAllCustomers();
                //reapterCustomers.DataBind();
            }
            else if (e.CommandName.ToString() == "Update")
            {
                Response.Redirect("CreateNewCustomer.aspx?id=" + id);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewCustomer.aspx");
        }

        protected void reapterCustomers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;

           // var item = (SPListItem)e.Item.DataItem;

            // uninteresting code

            var button2 = (Button)e.Item.FindControl("Button2");
            var button3 = (Button)e.Item.FindControl("Button3");
            //button.CommandArgument = item.ID.ToString();
            button2.ID = "button2_" + e.Item.ItemIndex;
            button3.ID = "button3_" + e.Item.ItemIndex;
            //button.Click += editCompanyButton_Click;
        }
    }
}