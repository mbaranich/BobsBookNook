using System;
//using System.Collections.Generic;
//using System.Linq;
using System.IO;

public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        {
            //use a bool flag to indicate errors
            bool okFlag = true;
            //make sure ownerID is entered twice in the form
            if ((txtOwnerID.Text == "") || (txtOwnerID0.Text == ""))
            {
                okFlag = false;
                txtOwnerID.Text = "";
                txtOwnerID0.Text = "";
                txtOwnerID.Focus();
            }
            //make sure owner IDs match
            if (txtOwnerID.Text != txtOwnerID0.Text)
            {
                okFlag = false;
                txtOwnerID.Text = "";
                txtOwnerID0.Text = "";
                txtOwnerID.Focus();
            }
            //if ownerID does not end with underscore, add it
            if(!txtOwnerID.Text.EndsWith("_"))
            {
                txtOwnerID.Text += "_";
            }
            //check okFlag for 'permission' to go back to admin
            if (okFlag)
            {
                using (StreamWriter _writeFile = new StreamWriter(Server.MapPath("~/App_Data/ownerID.txt"), false))
                    _writeFile.WriteLine(txtOwnerID.Text); //Write the file
                     Response.Redirect("Admin.aspx");
            }
        }
    }
}