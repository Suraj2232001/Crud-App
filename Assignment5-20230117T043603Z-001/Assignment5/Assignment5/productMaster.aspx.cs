using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class productMaster : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=IKL-70\\SQL2016;Initial Catalog=Batch10;User ID=sa;Password=sa@1234;MultipleActiveResultSets=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        //SqlDataSource ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //con.Open();
                if (!Page.IsPostBack)//it is used bcoz we need want the data to be repeated on every pageload
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("Select ProdID from ProductMaster ", con);//it executes sql statements on database
                        rdr = cmd.ExecuteReader();//it executes the sql statement and bing data from back to front
                        while (rdr.Read())
                        {
                            drdProdID.Items.Add(rdr[0].ToString());
                        }
                        Fetch();
                        Display();
                        Disable();

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Message: " + ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Enable();
                Clear();
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();

                cmd.CommandText = string.Format("insert into ProductMaster(ProdID, ProdName, Price, Qty) values({0},'{1}',{2}, {3})", txtProdID.Text, txtProdName.Text, txtProdPrice.Text, txtProdQty.Text);

                cmd.Connection = con;
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Response.Write("Record Inserted Successfully...........");
                }
                Fetch();
                Clear();
                Disable();
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Enable();
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = String.Format("Update ProductMaster set ProdName = '{0}', Price = {1}, Qty = {2} where ProdID = {3}", txtProdName.Text, txtProdPrice.Text, txtProdQty.Text, drdProdID.SelectedItem);
                cmd.Connection = con;
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Response.Write("Records Updated Successsfully...........");
                }
                else
                {
                    Response.Write("Error: Cannot Update...........");
                }
                Fetch();
                Clear();

            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = String.Format("Delete from ProductMaster where ProdID = {0}", txtProdID.Text);
                cmd.Connection = con;
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Response.Write("Records Deleted Successsfully...........");
                }
                else
                {
                    Response.Write("Error........Cannot be deleted...........");
                }
                Fetch();
                Clear();
                Display();
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void drdCustID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int id = Convert.ToInt32(drdProdID.Text);
                cmd = new SqlCommand("Select * from ProductMaster where ProdID=@OptionProdId", con);//drop down chnge query for 2ddl
                cmd.Parameters.AddWithValue("@OptionProdID", id);//assigning id in sql parameter
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtProdID.Text = rdr["ProdID"].ToString();
                    txtProdName.Text = rdr["ProdName"].ToString();
                    txtProdPrice.Text = rdr["Price"].ToString();
                    txtProdQty.Text = rdr["Qty"].ToString();
                }

            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Fetch()
        {
            try
            {
                drdProdID.Items.Clear();
                cmd = new SqlCommand("Select ProdID from ProductMaster", con);
                rdr = cmd.ExecuteReader();
                //int rdrIndex = rdr.GetOrdinal("EmpID");
                while (rdr.Read())
                {
                    drdProdID.Items.Add(rdr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        public void Display()
        {
            try
            {
                cmd = new SqlCommand("Select * from ProductMaster where ProdID = 1", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    object name = cmd.ExecuteScalar();
                    txtProdID.Text = rdr["ProdID"].ToString();
                    txtProdName.Text = rdr["ProdName"].ToString();
                    txtProdPrice.Text = rdr["Price"].ToString();
                    txtProdQty.Text = rdr["Qty"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        public void Enable()
        {
            try
            {
                txtProdID.Enabled = true;
                txtProdName.Enabled = true;
                txtProdPrice.Enabled = true;
                txtProdQty.Enabled = true;
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        public void Disable()
        {
            try
            {
                txtProdID.Enabled = false;
                txtProdName.Enabled = false;
                txtProdPrice.Enabled = false;
                txtProdQty.Enabled = false;
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        public void Clear()
        {
            txtProdID.Text = "";
            txtProdName.Text = "";
            txtProdPrice.Text = "";
            txtProdQty.Text = "";
        }
    }
}