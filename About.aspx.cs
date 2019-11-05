using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    private string connectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            FillAuthorList();
        }
    }

    private void FillAuthorList()
    {
        lstAuthor.Items.Clear();
        // Define the select statement
        string selectSQL = "SELECT au_lname,au_fname,au_id FROM Authors";

        // define the ADO.NET objects
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(selectSQL,conn);

        SqlDataReader reader;

        // try to open database and read information
        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();

            //loop
            while (reader.Read())
            {
                ListItem newItem = new ListItem();
                newItem.Text = reader["au_lname"] + "," + reader["au_fname"];
                newItem.Value = reader["au_id"].ToString();
                lstAuthor.Items.Add(newItem);
            }

            reader.Close();
        }
        catch(Exception err)
        {
            lblResult.Text = "Error reading list of names.";
            lblResult.Text += err.Message;
        }
        finally
        {
            conn.Close();
        }
    }
}