using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTA.Model;
using TTA.BLL;
using TTA.ServiceProxy;

namespace TTA.Presentation
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Assign();
            }

        }

        /// <summary>
        /// Assigns this instance.
        /// </summary>
        private void Assign()
        {
            if (Request.QueryString["productid"] != null)
            {
                int productid = Convert.ToInt32(Request["productid"]);

                Proxy productService = new Proxy();
                ProductBE product = productService.GetProductById(productid);
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

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Proxy productService = new Proxy();

            int productId = Convert.ToInt32(this.hfldProductId.Value);
            string productName = this.txtProductName.Text.ToString().Trim();
            decimal productPrice = Convert.ToDecimal(this.txtProductPrice.Text);
            int categoryId = Convert.ToInt32(this.ddlCategorylist.SelectedValue);


            ProductBE product = new ProductBE();
            product.ProductId = productId;
            product.ProductName = productName;
            product.ProductPrice = productPrice;
            product.CategoryId = categoryId;

            CategoryBE category = new CategoryBE();
            category.CategoryId = categoryId;
            product.Category = category;

            productService.UpdateProduct(product);

            Response.Redirect("ProductList.aspx");

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