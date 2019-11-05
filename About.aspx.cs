using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

    //change autoPostBack to make changes visible as soon as you change the author
    protected void lstAuthor_SelectedIndexChanged(object sender, EventArgs e)
    {
        // create a select statement that searched for a record
        string selectSQL;
        selectSQL = "SELECT * FROM Authors ";
        selectSQL += "WHERE au_id='" + lstAuthor.SelectedValue + "'";

        // define the ado.net objects.
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;

        //try to open database and read information
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();

            // build a string with the record information()
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<b>");
            stringBuilder.Append(reader["au_lname"]);
            stringBuilder.Append(",");
            stringBuilder.Append(reader["au_fname"]);
            stringBuilder.Append("</b><br/>");
            stringBuilder.Append("Phone: ");
            stringBuilder.Append(reader["phone"]);
            stringBuilder.Append("<br/>");
            stringBuilder.Append("Address: ");
            stringBuilder.Append(reader["address"]);
            stringBuilder.Append("<br/>");
            stringBuilder.Append("City:");
            stringBuilder.Append(reader["city"]);
            stringBuilder.Append("<br/>");
            stringBuilder.Append("State:");
            stringBuilder.Append(reader["state"]);
            stringBuilder.Append("<br/>");

            lblResult.Text = stringBuilder.ToString();
            reader.Close();
        }
        catch (Exception ex)
        {
            lblResult.Text = "Error gttingauthor";
            lblResult.Text += ex.Message;
        }
        finally
        {
            con.Close();
        }
    }
}