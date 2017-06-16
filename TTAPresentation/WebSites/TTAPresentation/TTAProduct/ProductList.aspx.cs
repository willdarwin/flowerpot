using System;
using Microsoft.Practices.ObjectBuilder;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTA.Model;
using System.Collections.Generic;

namespace TTAPresentation.TTAProduct.Views
{
    public partial class ProductList : BasePage, IProductListView
    {
        private ProductListPresenter _presenter;

        #region

        public int ProductId { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    this.rptProductList.DataSource = _presenter.SelectAllProduct();
                    this.rptProductList.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        [CreateNew]
        public ProductListPresenter Presenter
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
        /// Judgment operation
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void rptProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName.ToString())
            {
                case "btnUpdate":
                    Update(e);
                    break;
                case "btnDelete":
                    Delete(e);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// jump to update page by productid
        /// </summary>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void Update(RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                try
                {
                    ProductId = Convert.ToInt32(e.CommandArgument);
                    ProductBE product = this._presenter.GetProductById();
                    if (product == null)
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), string.Empty, "alert('we don\\'t have this product！');location='ProductList.aspx';", true);
                    }
                    else
                    {
                        Response.Redirect("UpdateProduct.aspx?productid=" + ProductId);
                    }
                }
                catch (Exception ex)
                {
                    this.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// delete product by productid
        /// </summary>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void Delete(RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                try
                {
                    ProductId = Convert.ToInt32(e.CommandArgument);
                    ProductBE product = this._presenter.GetProductById();
                    int countNum = this._presenter.CountOrderDetailsByProductId();
                    if (product == null)
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), string.Empty, "showErrorMessage('we don\\'t have this product！');location='ProductList.aspx';", true);
                    }
                    else if (countNum > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), string.Empty, "showErrorMessage('The product is being used！')", true);
                    }
                    else
                    {
                        this._presenter.DeleteProduct();
                        Page.ClientScript.RegisterStartupScript(typeof(string), string.Empty, "window.location.href=window.location.href;", true);
                    }
                }
                catch (Exception ex)
                {
                    this.ShowErrorMessage(ex);
                }
            }
        }


    }
}

