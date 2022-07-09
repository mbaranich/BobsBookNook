using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class removeBooksFromInventory : System.Web.UI.Page
{
    string ownerID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ownerID = getOwnerId.getID(Server.MapPath("~/App_Data/"));

        string sqlCommand = "SELECT IMAGE, TITLE, ISBN FROM " + ownerID + "BOOKS";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDeleteBooks, ref lblErrorMessage);
    }

    protected void btnReturntoAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }

    protected void gvDeleteBooks_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Write(gvDeleteBooks.SelectedValue.ToString());
        string sqlCommand = "DELETE FROM " + ownerID + "BOOKS WHERE ISBN = " + gvDeleteBooks.SelectedValue.ToString();
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDeleteBooks, ref lblErrorMessage);
        
        //we need to remove from best seller if the book is there
        try
        {
            sqlCommand = "DELETE FROM " + ownerID + "BESTSELLER WHERE ISBN = " + gvDeleteBooks.SelectedValue.ToString();
            myDatabaseConnection.executeSQL(sqlCommand, ref gvDeleteBooks, ref lblErrorMessage);
        }
        catch { }

        //redisplay books
        sqlCommand = "SELECT IMAGE, TITLE, ISBN FROM " + ownerID + "BOOKS";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDeleteBooks, ref lblErrorMessage);
    }

    protected string FormatImageUrl(string url)
    {
        if (url != null && url.Length > 0)
            return ("~/" + url);
        else return null;
    }
}