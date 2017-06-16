using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : Microsoft.Practices.CompositeWeb.Web.UI.Page
{
	public BasePage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void ShowErrorMessage(Exception ex)
    {
        StringBuilder js = new StringBuilder();
        js.Append("showErrorMessage('").Append(ex.Message).Append("')");
        this.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMess", js.ToString(), true);
    }
}