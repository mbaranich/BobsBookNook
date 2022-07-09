using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkout : System.Web.UI.Page
{
    string ownerID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ownerID = getOwnerId.getID(Server.MapPath("~/App_Data/"));

        if (!IsPostBack)
        {
            lblMessage.Text = "Please enter the email address for delivery of your books.";
            txtEmail.Visible = true;
            txtEmail.Text = "";
        }
        if (IsPostBack)
        {
            //Email address for history
            string historyEMail = txtEmail.Text;
            lblMessage.Visible = false;
            lblMessage.Text = "";
            //Repopulate the txtbox with the message that says these are to be sent to you.
            

            string sqlCommand;
            string table2;
            string newTempUserID = "";
            Session["tempUserID"] = newTempUserID;

            table2 = Session["tempUserID"].ToString();

            sqlCommand = "SELECT * FROM " + table2;
            myDatabaseConnection.executeSQL(sqlCommand, ref gvISBN, ref lblMessage);

            Response.Write("Your card will be charged US$" + Math.Round(Convert.ToDecimal(gvISBN.Rows.Count * 5.99), 2) + "<br />");

            //send purchases to History
            sqlCommand = "INSERT INTO " + ownerID + "HISTORY (EMAIL, ISBN) SELECT '" + historyEMail + "', ISBN FROM " + table2;

            myDatabaseConnection.executeSQL(sqlCommand, ref gvISBN, ref lblMessage);
            //show contents of history just for validation. To be removed!!!
            sqlCommand = "SELECT * FROM " + ownerID + "HISTORY";
            myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblMessage);

            Label1.Text = "the following books will be sent to " + txtEmail.Text + " within 10 minutes.";

            try
            {
                string table1 = ownerID + "BOOKS";
                sqlCommand = "SELECT TITLE, AUTHOR, " + table1 + ".ISBN from " + table1 + " INNER JOIN " + table2 + " ON " + table1 + ".ISBN = " + table2 + ".ISBN ";
                myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblMessage);
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        string sqlCommand;
        string table2 = Session["tempUserID"].ToString();
        sqlCommand = "DROP TABLE " + table2;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvISBN, ref lblMessage);
        Session["tempUserID"] = null;
        Response.Redirect("Default.aspx");
    }
}