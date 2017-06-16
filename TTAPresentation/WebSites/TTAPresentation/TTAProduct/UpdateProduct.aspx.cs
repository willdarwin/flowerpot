using System;
using Microsoft.Practices.ObjectBuilder;
using TTA.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TTAPresentation.TTAProduct.Views
{
    public partial class UpdateProduct : BasePage, IUpdateProductView
    {
        private UpdateProductPresenter _presenter;

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
                    Assign();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        [CreateNew]
        public UpdateProductPresenter Presenter
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
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProductId = Convert.ToInt32(this.hfldProductId.Value);
                ProductName = this.txtProductName.Text.ToString().Trim();
                ProductPrice = Convert.ToDecimal(this.txtProductPrice.Text);
                CategoryId = Convert.ToInt32(this.ddlCategorylist.SelectedValue);

                this._presenter.UpdateProduct();

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

        /// <summary>
        /// Assigns this instance.
        /// </summary>
        private void Assign()
        {
            try
            {
                if (Request.QueryString["productid"] != null)
                {
                    ProductId = Convert.ToInt32(Request["productid"]);

                    ProductBE product = this._presenter.GetProductById();
                    if (product == null)
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), string.Empty, "alert('we don\\'t have this product！');location='ProductList.aspx';", true);
                    }
                    else
                    {
                        this.hfldProductId.Value = Request["productid"];
                        this.txtProductName.Text = product.ProductName;
                        this.txtProductPrice.Text = Convert.ToString(product.ProductPrice);

                        ddlCategorylist.SelectedValue = Convert.ToString(product.CategoryId);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), string.Empty, "alert('we don\\'t have this product！');location='ProductList.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }
    }
}

