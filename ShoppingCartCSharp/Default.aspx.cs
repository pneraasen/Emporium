using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
        {
            SqlConnection FrenchConnection = new SqlConnection();
            try
            {
                if (Trace.IsEnabled)
                {
                    Trace.Warn("shit!");
                }


                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString.ToString();
                FrenchConnection.ConnectionString = ConnectionString;

                string queryString = "SELECT Name, ProductCategoryID FROM Production.ProductCategory;";
                SqlCommand Command = new SqlCommand(queryString, FrenchConnection);

                FrenchConnection.Open();

                SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);
                DataSet Dataset = new DataSet();
                DataAdapter.Fill(Dataset);
                Category.DataSource = Dataset;
                Category.DataValueField = "ProductCategoryID";
                Category.DataTextField = "Name";
                Category.DataBind();
                
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Text += "<br />" + ex.StackTrace.ToString();
                errorLabel.Visible = true;
            }
            finally
            {
                if (FrenchConnection.State.ToString() != "Closed")
                {
                    FrenchConnection.Close();
                }
            }
        }
    }

    protected void Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Category.SelectedValue != "Other Question" && Category.SelectedValue != "Please choose an option")
        {
            Subcategory.Visible = true;

            SqlConnection FrenchConnection = new SqlConnection();
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString.ToString();
                FrenchConnection.ConnectionString = ConnectionString;

                string subQueryString = "SELECT Name, ProductSubcategoryID FROM Production.ProductSubcategory WHERE ProductCategoryID = @CATID";
                SqlCommand Command = new SqlCommand(subQueryString, FrenchConnection);

                Command.Parameters.Add("CATID", SqlDbType.Int);
                Command.Parameters["CATID"].Value = Category.SelectedValue;

                SqlDataAdapter SubAdapter = new SqlDataAdapter(Command);

                DataSet Dataset = new DataSet();
                SubAdapter.Fill(Dataset);

                Subcategory.DataSource = Dataset;
                Subcategory.DataValueField = "ProductSubCategoryID";
                Subcategory.DataTextField = "Name";
                Subcategory.DataBind();
                Subcategory.Items.Insert(0, new ListItem("Please choose an option"));

            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Text += "<br />" + ex.StackTrace.ToString();
                errorLabel.Visible = true;
            }
            finally
            {
                if (FrenchConnection.State.ToString() != "Closed")
                {
                    FrenchConnection.Close();
                }
            }
        }
        else
        {
            
            EmailSection.Visible = true;
           
        }
    }

    //PRODUCT DROPDOWN

    protected void Subcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        CartProduct.Visible = true;

        SqlConnection FrenchConnection = new SqlConnection();
        if (Subcategory.SelectedValue != "Please choose an option")
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString.ToString();
                FrenchConnection.ConnectionString = ConnectionString;

                string proQueryString = "SELECT Name, ProductSubcategoryID, ProductID FROM Production.Product WHERE ProductSubcategoryID = @SUBCATID;";
                SqlCommand Command = new SqlCommand(proQueryString, FrenchConnection);

                Command.Parameters.Add("SUBCATID", SqlDbType.Int);
                Command.Parameters["SUBCATID"].Value = Subcategory.SelectedValue;

                SqlDataAdapter SubAdapter = new SqlDataAdapter(Command);

                DataSet Dataset = new DataSet();
                SubAdapter.Fill(Dataset);

                CartProduct.DataSource = Dataset;
                CartProduct.DataValueField = "ProductID";
                CartProduct.DataTextField = "Name";
                CartProduct.DataBind();
                CartProduct.Items.Insert(0, new ListItem("Please choose an option"));
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Text += "<br />" + ex.StackTrace.ToString();
                errorLabel.Visible = true;
            }
            finally
            {
                if (FrenchConnection.State.ToString() != "Closed")
                {
                    FrenchConnection.Close();
                }
            }
        }
    }

    protected void CartProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        EmailSection.Visible = true;
    }

    protected void btnAddProduct_Click(object sender, EventArgs e) {
		// Add product 1 to the shopping cart
		ShoppingCart.Instance.AddItem(1);

		// Redirect the user to view their shopping cart
		Response.Redirect("ViewCart.aspx");
	}

	//protected void btnAddShirt_Click(object sender, EventArgs e) {
	//	ShoppingCart.Instance.AddItem(2);
	//	Response.Redirect("ViewCart.aspx");
	//}

	//protected void btnAddPants_Click(object sender, EventArgs e) {
	//	ShoppingCart.Instance.AddItem(3);
	//	Response.Redirect("ViewCart.aspx");
	//}








}
