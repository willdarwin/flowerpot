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
    public partial class CreateProduct : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnCreatNew control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnCreatNew_Click(object sender, EventArgs e)
        {
            Proxy productService = new Proxy();

            string productName = this.txtProductName.Text.ToString().Trim();
            decimal productPrice = Convert.ToDecimal(this.txtProductPrice.Text);
            int categoryId = Convert.ToInt32(this.ddlCategorylist.SelectedValue);

            ProductBE product = new ProductBE();

            product.ProductName = productName;
            product.ProductPrice = productPrice;
            product.CategoryId = categoryId;
            CategoryBE category = new CategoryBE();
            category.CategoryId = categoryId;
            product.Category = category;

            productService.InsertProduct(product);
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