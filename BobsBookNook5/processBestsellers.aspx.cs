using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class processBestsellers : System.Web.UI.Page
{
    string ownerID;

    protected void Page_Load(object sender, EventArgs e)
    {
        //string uploadPath = Server.MapPath("~/App_Data/");
        //try
        //{
        //    ownerID = System.IO.File.ReadAllText(uploadPath + "ownerID.txt");
        //    ownerID = ownerID.Trim();
        //    //Response.Write(ownerID + "<br />"); //error checking
        //}
        //catch { }
        ownerID = getOwnerId.getID(Server.MapPath("~/App_Data/"));
        //Load gvCatalog
        string sqlCommand = "SELECT ISBN, TITLE, AUTHOR FROM " + ownerID + "BOOKS ORDER BY TITLE";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvCatalog, ref lblErrorMessage);
        //gvBestSellers
        sqlCommand = "SELECT ISBN FROM " + ownerID + "BESTSELLER ORDER BY ISBN";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }

    protected void gvCatalog_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Write(gvCatalog.SelectedValue.ToString());
        string sqlCommand = "INSERT INTO " + ownerID + "BESTSELLER VALUES('" + gvCatalog.SelectedValue.ToString() + "')";
        //Response.Write(sqlCommand + "<br/>;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage);
        sqlCommand = "SELECT ISBN FROM " + ownerID + "BESTSELLER ORDER BY ISBN";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage);
    }

    protected void gvBestSellers_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sqlCommand = "DELETE FROM " + ownerID + "BESTSELLER WHERE ISBN = ('" + gvBestSellers.SelectedValue.ToString() + "')";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage);
        sqlCommand = "SELECT ISBN FROM " + ownerID + "BESTSELLER ORDER BY ISBN";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvBestSellers, ref lblErrorMessage);
    }
}