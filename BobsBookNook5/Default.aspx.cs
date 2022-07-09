using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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

        string sqlCommand = "SELECT Title, ISBN, Author, Category, Image, Description FROM " + ownerID + "BOOKS";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvCatalog, ref lblErrorMessage);

        //load author menu
        sqlCommand = "SELECT DISTINCT AUTHOR FROM " + ownerID + "BOOKS";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvAuthors, ref lblErrorMessage);

        //load cateogory menu
        sqlCommand = "SELECT DISTINCT CATEGORY FROM " + ownerID + "BOOKS";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvCategories, ref lblErrorMessage);
    }

    protected string FormatImageURL(string url)
    {
        if (url != null && url.Length > 0)
            return ("~/" + url);
        else return null;
    }


    protected void gvAuthors_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Write(gvAuthors.SelectedValue);
        string sqlCommand = "SELECT * FROM " + ownerID + "BOOKS WHERE AUTHOR = '" + gvAuthors.SelectedValue + "'";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvCatalog, ref lblErrorMessage);
    }

    protected void gvCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sqlCommand = "SELECT * FROM " + ownerID + "BOOKS WHERE CATEGORY = '" + gvCategories.SelectedValue + "'";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvCatalog, ref lblErrorMessage);
    }

    protected void btnClearSearchOptions_Click(object sender, EventArgs e)
    {
        string sqlCommand = "SELECT Title, ISBN, Author, Category, Image, Description FROM " + ownerID + "BOOKS";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvCatalog, ref lblErrorMessage);
    }

    protected void btnViewBestSellers_Click(object sender, EventArgs e)
    {
        string sqlCommand = "SELECT " + ownerID + "BOOKS.Title, " + ownerID + "BOOKS.ISBN, " + ownerID + "BOOKS.Author, " + ownerID + "BOOKS.Category, " + ownerID + "BOOKS.Image, " + ownerID + "BOOKS.Description FROM " + ownerID + "BOOKS INNER JOIN " + ownerID + "BESTSELLER ON " + ownerID + "BOOKS.ISBN = " + ownerID + "BESTSELLER.ISBN";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvCatalog, ref lblErrorMessage);
    }
}