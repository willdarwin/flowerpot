using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTA.BLL;
using TTA.Model;
using TTA.ServiceProxy;

namespace TTA.Presentation
{
    public partial class CreateNewCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Proxy service = new Proxy();
            if (!IsPostBack)
            {
                this.dropListAddresses.DataSource = service.GetAllAddresses();// Post back
                this.dropListAddresses.DataTextField = "Country";
                this.dropListAddresses.DataValueField = "AddressId";
                this.dropListAddresses.DataBind();
            }


            string id = Request.QueryString["id"];
            if (id != null && this.labMethod.Text == "")
            {
                CustomerBE customer = service.GetCustomerById(Convert.ToInt32(id));
                this.txCustomerName.Text = customer.CustomerName;
                if (customer.CustomerGender)
                {
                    this.rblGender.SelectedValue = "1";
                }
                else
                {
                    this.rblGender.SelectedValue = "0";
                }
                this.dropListAddresses.SelectedValue = customer.Address.AddressId.ToString();
                this.btnCreateNewCustomer.Text = "Update";
                this.labId.Text = id;
                this.labMethod.Text = "Update";
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Proxy service = new Proxy();
            string id = this.labId.Text;

            string name = this.txCustomerName.Text.ToString().Trim();
            int genderInt = Convert.ToInt32(this.rblGender.SelectedValue);
            bool gender = genderInt == 1 ? true : false;
            int addressId = Convert.ToInt32(this.dropListAddresses.SelectedValue);
            CustomerBE customer = new CustomerBE();
            customer.CustomerName = name;
            customer.CustomerGender = gender;
            AddressBE address = new AddressBE();
            address.AddressId = addressId;
            address.City = "City";
            address.Country = "Country";
            address.DetailAddress = "Detail";
            address.Province = "Province";
            customer.Address = address;

            if (id != "")
            {
                customer.CustomerId = Convert.ToInt32(id);
                service.UpdateCustomer(customer);
            }
            else
            {
                service.InsertCustomer(customer);
            }
            Response.Redirect("CustomerList.aspx");
        }


    }
}