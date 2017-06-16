using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTA.Model;
using TTA.BLL;
using TTA.ServiceProxy;

namespace TTA.Presentation
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                int productid = Convert.ToInt32(e.CommandArgument);
                Proxy productService = new Proxy();
                ProductBE product = productService.GetProductById(productid);
                if (product == null)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), string.Empty, "alert('we don\\'t have this product！');location='ProductList.aspx';", true);
                }
                else
                {
                    Response.Redirect("UpdateProduct.aspx?productid=" + productid);
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
                int productid = Convert.ToInt32(e.CommandArgument);
                Proxy productService = new Proxy();
                ProductBE product = productService.GetProductById(productid);
                if (product == null)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), string.Empty, "alert('we don\\'t have this product！');location='ProductList.aspx';", true);
                }
                else
                {
                    productService.DeleteProduct(Convert.ToInt32(e.CommandArgument));
                    rptProductList.DataBind();
                }
            }
        }
        /// <summary>
        /// jump to create new page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateProduct.aspx");
        }

    }
}