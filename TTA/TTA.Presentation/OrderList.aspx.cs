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
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }


        }

        /// <summary>
        /// Handles the Click event of the Search control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.labName.Text = this.CustomerName.Text.Trim();
            this.labStartDate.Text = this.txtDateStartCondition.Text.Trim();
            this.labEndDate.Text = this.txtDateEndCondition.Text.Trim();

            Proxy proxy = new Proxy();
            List<OrderBE> list = proxy.GetOrdersbyCondition(this.CustomerName.Text.Trim(), this.txtDateStartCondition.Text, this.txtDateEndCondition.Text);
            //List<OrderBE> list = service.GetbyCondition(this.CustomerName.Text.Trim(), this.txtDateStartCondition.Text, this.txtDateEndCondition.Text);
            rptOrderList.DataSource = list;

            rptOrderList.DataBind();
        }

        /// <summary>
        /// Handles the ItemCommand event of the rptOrderList control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void rptOrderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                //service.DeleteOrder(id);

                //List<OrderBE> list = service.GetbyCondition(this.labName.Text, this.labStartDate.Text, this.labEndDate.Text);
                Proxy proxy = new Proxy();
                proxy.DeleteOrder(id);
                List<OrderBE> list = proxy.GetOrdersbyCondition(this.CustomerName.Text.Trim(), this.txtDateStartCondition.Text, this.txtDateEndCondition.Text);
                rptOrderList.DataSource = list;
                rptOrderList.DataBind();
            }

            if (e.CommandName == "Detail")
            {
                Response.Redirect("UpdateOrderDetails.aspx?id=" + e.CommandArgument.ToString());

            }
        }

        /// <summary>
        /// Handles the Click event of the CloseInBatch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void CloseInBatch_Click(object sender, EventArgs e)
        {
            Proxy proxy = new Proxy();
            
            foreach (RepeaterItem repeaterItem in rptOrderList.Items)
            {
                CheckBox myCheckBox = (CheckBox)repeaterItem.FindControl("Close");
                Label orderIdLabel = (Label)repeaterItem.FindControl("labId");
                if (myCheckBox.Checked)
                {
                    int id = Convert.ToInt32(orderIdLabel.Text);
                    proxy.CloseOrder(id);
                }
            }
            List<OrderBE> list = proxy.GetOrdersbyCondition(this.CustomerName.Text.Trim(), this.txtDateStartCondition.Text, this.txtDateEndCondition.Text);
            rptOrderList.DataSource = list;

            rptOrderList.DataBind();
        }

    }
}