using System;
using Microsoft.Practices.ObjectBuilder;
using TTA.Model;
using System.Collections.Generic;

namespace TTAPresentation.TTACustomer.Views
{
    public partial class CreateNewCustomer : BasePage, ICreateNewCustomerView
    {
        /// <summary>
        /// Country
        /// </summary>
        private const string Country = "Country";
        /// <summary>
        /// The Id of the Address
        /// </summary>
        private const string AddressId = "AddressId";

        private CreateNewCustomerPresenter _presenter;
        public string _strTitle = "Create New Customer";
        #region

        public string CustomerName { get; set; }
        public bool CustomerGender { get; set; }
        public int CustomerAddressId { get; set; }
        public int CustomerId { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    this.dropListAddresses.DataSource = _presenter.GetAllAddresses();
                    this.dropListAddresses.DataTextField = Country;
                    this.dropListAddresses.DataValueField = AddressId;
                    this.dropListAddresses.DataBind();
                }
                catch (System.Exception ex)
                {
                    this.ShowErrorMessage(ex);
                }
            }

            string id = Request.QueryString["id"];
            this.CustomerId = Convert.ToInt32(id);
            if (id != null && this.labMethod.Text == "")
            {
                this._strTitle = "Update New Customer";
                this.Title = "Update New Customer";
                CustomerBE customer = _presenter.GetCustomerById();
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

        [CreateNew]
        public CreateNewCustomerPresenter Presenter
        {
            get
            {
                return this._presenter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._presenter = value;
                this._presenter.View = this;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = this.labId.Text;


            this.CustomerName = this.txCustomerName.Text.ToString().Trim();
            this.CustomerGender = Convert.ToInt32(this.rblGender.SelectedValue) == 1 ? true : false; ;
            this.CustomerAddressId = Convert.ToInt32(this.dropListAddresses.SelectedValue);

            try
            {
                if (id != "")
                {
                    this.CustomerId = Convert.ToInt32(id);
                    _presenter.UpdateCustomer();
                }
                else
                {
                    _presenter.InsertCustomer();
                }
            }
            catch (System.Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            Response.Redirect("ShowAllCustomers.aspx");
        }
    }
}

