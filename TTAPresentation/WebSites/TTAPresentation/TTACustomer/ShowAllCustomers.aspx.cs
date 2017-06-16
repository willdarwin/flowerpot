using System;
using Microsoft.Practices.ObjectBuilder;
using TTA.Model;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TTAPresentation.TTACustomer.Views
{
    public partial class ShowAllCustomers : BasePage, IShowAllCustomersView
    {
        private ShowAllCustomersPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.reapterCustomers.DataSource = _presenter.GetAllCustomers();
                this.reapterCustomers.DataBind();
            }
            catch (System.Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        [CreateNew]
        public ShowAllCustomersPresenter Presenter
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

        /// <summary>
        /// Handles the ItemDataBound event of the reapterCustomers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void reapterCustomers_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null) return;
            var button2 = (Button)e.Item.FindControl("Button2");
            var button3 = (Button)e.Item.FindControl("Button3");
            button2.ID = "button2_" + e.Item.ItemIndex;
            button3.ID = "button3_" + e.Item.ItemIndex;
        }


        protected void reapterCustomers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.ToString() == "Delete")
            {
                try
                {
                    _presenter.DeleteCustomer(id);
                    this.reapterCustomers.DataSource = _presenter.GetAllCustomers();
                    this.reapterCustomers.DataBind();
                }
                catch (System.Exception ex)
                {
                    this.ShowErrorMessage(ex);
                }

            }
            else if (e.CommandName.ToString() == "Update")
            {
                Response.Redirect("CreateNewCustomer.aspx?id=" + id);
            }
        }
        protected void btnCreateNewCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewCustomer.aspx");
        }
    }
}

