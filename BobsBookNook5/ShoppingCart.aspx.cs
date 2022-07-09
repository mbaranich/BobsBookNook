using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShoppingCart : System.Web.UI.Page
{
    string ownerID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ownerID = getOwnerId.getID(Server.MapPath("~/App_Data/"));
        //try
        //{
        //    //Save session variable
        //    Session[Session.Count.ToString()] = Request.QueryString["id"];
        //    //display session variable
        //    for (int i = 0; i < Session.Count; i++)
        //    {
        //        Response.Write("<br />" + Session[i.ToString()].ToString());
        //    }
        //}
        //catch { Response.Redirect("~/Default.aspx"); }
        string newTempUserID = "";
        string tempUserSource = "A" + "B" + "C" + "D" + "E" + "F" + "G" + "H" + "I" + "J" + "K" + "L" + "M" + "N" + "O" + "P" + "Q" + "R" + "S" + "T" + "U" + "V" + "W" + "X" + "Y" + "Z" + "0" + "1" + "2" + "3" + "4" + "5" + "6" + "7" + "8" + "9";
        //remove after testing
        //Response.Write(tempUserSource + "<hr>");

        try
        {
            //Why do we use a try catch? Session will toss an error if tempUserID does not exist.
            //thus an else can not be used in this example.
            if (Session["tempUserID"].ToString() == "")
            {
                ;
            }
        }
        catch
        {
            //create a unique temporary ID 20 characters long. Must start with a letter
            Random r = new Random();
            int index = r.Next(0, 26); //Makes sure first character is a letter
            newTempUserID += tempUserSource.Substring(index, 1);
            for (int i = 2; i < 21; i++)
            {
                index = r.Next(0, 36);
                //Must be += or we only capture the last letter.
                newTempUserID += tempUserSource.Substring(index, 1);
                //Response.Write(newTempUserID + "<HR>");
                
            }
            ////place it in a session variable
            Session["tempUserID"] = newTempUserID;
            string sqlCommand = "CREATE TABLE " + newTempUserID + " (ISBN CHAR(14))";
            myDatabaseConnection.executeSQL(sqlCommand, ref gvShoppingCart, ref lblErrorMessage);

        }

        if (!IsPostBack)
        {
            //show session variable so we know it works.
            //Response.Write(Session["tempUserID"].ToString() + "<br/>");
            //Show ISBN of new Selection
            //Response.Write(Request.QueryString["id"] + "<br/>");
            //Add ISBN to database table and view
            addToShoppingList(Session["tempUserID"].ToString(), Request.QueryString["id"]);
        }

        viewGvDisplay();
    }

    protected string FormatImageUrl(string url)
    {
        if (url != null && url.Length > 0)
            return ("~/" + url);
        else return null;
    }

    private void viewGvDisplay()
    {
        string sqlCommand;
        //throw new NotImplementedException();
        try
        {
            string table1 = ownerID + "BOOKS";
            string table2 = Session["tempUserID"].ToString();
            sqlCommand = "SELECT IMAGE, AUTHOR, TITLE, " + table1 + ".ISBN from " + table1 + " INNER JOIN " + table2 + " ON " + table1 + ".ISBN = " + table2 + ".ISBN ";
            myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);

            //Response.Write(ownerID.ToString());
        }
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }





    private void addToShoppingList(string userID, string ISBN)
    {
        //throw new NotImplementedException();
        string sqlCommand = "INSERT INTO " + userID + " VALUES(" + ISBN + ")";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvShoppingCart, ref lblErrorMessage);
        //sqlCommand = "SELECT * FROM " + userID;
        //myDatabaseConnection.executeSQL(sqlCommand, ref gvShoppingCart, ref lblErrorMessage);

    }

    protected void btnBacktoBrowsing_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        try
        {
            string sqlCommand;
            string table2 = Session["tempuserID"].ToString();
            sqlCommand = "DROP TABLE " + table2;
            myDatabaseConnection.executeSQL(sqlCommand, ref gvShoppingCart, ref lblErrorMessage);
            Session["tempUserID"] = null;
        }
        catch { }

        Response.Redirect("checkout.aspx");
    }

    protected void gvDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        string sqlCommand;
        string table1 = ownerID + "BOOKS";
        string table2 = Session["tempUserID"].ToString();

        sqlCommand = "DELETE FROM " + ownerID + "BOOKS WHERE ISBN = " + gvDisplay.SelectedValue;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);

        //sqlCommand = "DELETE FROM " + table2 + " WHERE ISBN = " + gvDisplay.SelectedValue;
        //myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);
        //System.Diagnostics.Debug.WriteLine(sqlCommand);

        sqlCommand = "SELECT IMAGE, AUTHOR, TITLE, " + table1 + ".ISBN from " + table1 + " INNER JOIN " + table2 + " ON " + table1 + ".ISBN = " + table2 + ".ISBN ";
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);
        //System.Diagnostics.Debug.WriteLine(sqlCommand);

        //Response.Write(gvDisplay.SelectedValue.ToString());

    }


    protected void gvShoppingCart_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvDisplay_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}