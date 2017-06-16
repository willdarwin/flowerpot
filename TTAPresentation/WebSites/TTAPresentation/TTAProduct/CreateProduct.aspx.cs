using System;
using Microsoft.Practices.ObjectBuilder;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTA.Model;

namespace TTAPresentation.TTAProduct.Views
{
    public partial class CreateProduct : BasePage, ICreateProductView
    {
        private CreateProductPresenter _presenter;

        #region

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    this.ddlCategorylist.DataSource = _presenter.SelectAllCategory();
                    this.ddlCategorylist.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        [CreateNew]
        public CreateProductPresenter Presenter
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
        /// Handles the Click event of the btnCreatNew control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnCreatNew_Click(object sender, EventArgs e)
        {
            try
            {
                ProductName = this.txtProductName.Text.ToString().Trim();
                ProductPrice = Convert.ToDecimal(this.txtProductPrice.Text);
                CategoryId = Convert.ToInt32(this.ddlCategorylist.SelectedValue);

                this._presenter.InsertProduct();
                Response.Redirect("ProductList.aspx");
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductList.aspx");
        }
    }
}

