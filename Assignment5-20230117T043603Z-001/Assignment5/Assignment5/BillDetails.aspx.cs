using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class BillDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=IKL-70\\SQL2016;Initial Catalog=Batch10;User ID=sa;Password=sa@1234;MultipleActiveResultSets=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader rdr;
        SqlDataSource ds;
        DataTable dt;
        int ProdPrice, reqQty, finalBill, restQuantity, avilableQty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = String.Format("select ProdName from productMaster");
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        drdProdName.Items.Add(rdr[0].ToString());
                    }
                    rdr.Close();
                    cmd.CommandText = String.Format("select CustName from customerMaster");
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        drdCustomerName.Items.Add(rdr[0].ToString());
                    }
                    rdr.Close();
                    if (con.State == ConnectionState.Open)
                    {
                        FetchProduct();
                        DisplayProduct();
                        FetchCustomer();
                        DisplayCustomer();
                    }

                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void FetchCustomer()
        {
            drdCustomerName.Items.Clear();
            try
            {

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format("select CustName from customerMaster");
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    drdCustomerName.Items.Add(rdr[0].ToString());
                }
                rdr.Close();
            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }


        }

        public void DisplayCustomer()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format(" select * from customerMaster where CustName='{0}'", drdCustomerName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResCustID.Text = rdr["CustID"].ToString();
                    lblResCustName.Text = rdr["CustName"].ToString();
                    lblResAddress.Text = rdr["CustAddress"].ToString();
                    lblResMobile.Text = rdr["MobileNumber"].ToString();
                }
                rdr.Close();
                DisableTextBox();

            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }

        }

        public void FetchProduct()
        {
            drdProdName.Items.Clear();
            try
            {

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format("select ProdName from productMaster");
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    drdProdName.Items.Add(rdr[0].ToString());
                }
                rdr.Close();
            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }

        }

        public void DisplayProduct()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format("select * from productMaster where ProdName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResProdID.Text = rdr["ProdID"].ToString();
                    lblResProdName.Text = rdr["ProdName"].ToString();
                    lblProdPrice.Text = rdr["Price"].ToString();
                    lblResQty.Text = rdr["Qty"].ToString();
                }
                rdr.Close();
                DisableTextBox();

            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }

        }

        public void DisableTextBox()
        {
            txtBillNo.Enabled = false;
            txtReqQty.Enabled = false;
        }

        protected void ProductNameDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format("select * from productMaster where ProdName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResProdID.Text = rdr["ProdID"].ToString();
                    lblResProdName.Text = rdr["ProdName"].ToString();
                    lblProdPrice.Text = rdr["Price"].ToString();
                    lblResQty.Text = rdr["Qty"].ToString();
                }
                rdr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtReqQty.Text = "";
            txtBillNo.Text = "";
        }

        protected void drdProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format("select * from productMaster where ProdName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResProdID.Text = rdr["ProdID"].ToString();
                    lblResProdName.Text = rdr["ProdName"].ToString();
                    lblProdPrice.Text = rdr["Price"].ToString();
                    lblResQty.Text = rdr["Qty"].ToString();
                }
                rdr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        protected void drdCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format(" select * from customerMaster where CustName='{0}'", drdCustomerName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResCustID.Text = rdr["CustID"].ToString();
                    lblResCustName.Text = rdr["CustName"].ToString();
                    lblResMobile.Text = rdr["MobileNumber"].ToString();
                    lblResAddress.Text = rdr["CustAddress"].ToString();
                }
                rdr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            txtReqQty.Enabled = true;
            txtBillNo.Enabled = true;
            txtBillNo.Text = "";
            txtReqQty.Text = "";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                reqQty = Convert.ToInt32(txtReqQty.Text);
                finalBill = reqQty * ProdPrice;
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format("select * from productMaster where ProdName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResProdID.Text = rdr["ProdID"].ToString();
                    lblResProdName.Text = rdr["ProdName"].ToString();

                    lblProdPrice.Text = rdr["Price"].ToString();
                    ProdPrice = Convert.ToInt32(lblProdPrice.Text);
                    lblResQty.Text = rdr["Qty"].ToString();
                    avilableQty = Convert.ToInt32(lblResQty.Text);
                }
                rdr.Close();
                cmd.CommandText = String.Format(" select * from customerMaster where CustName='{0}'", drdCustomerName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResCustID.Text = rdr["CustID"].ToString();
                    lblResCustName.Text = rdr["CustName"].ToString();
                    lblResMobile.Text = rdr["MobileNumber"].ToString();
                    lblResAddress.Text = rdr["CustAddress"].ToString();
                }
                rdr.Close();
                if (avilableQty >= reqQty)
                {
                    restQuantity = avilableQty - reqQty;
                    finalBill = reqQty * ProdPrice;

                    cmd.CommandText = String.Format("insert into BillDetails(BillNo,CustID,ProdID,Qty,TotalBill)values({0},{1},{2},{3},{4})", txtBillNo.Text, lblResCustID.Text, lblResProdID.Text, reqQty, finalBill);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Response.Write("Your Order has been placed Successfully");
                        cmd.CommandText = String.Format("update productMaster set Qty={0}", restQuantity);
                        int updatedRow = cmd.ExecuteNonQuery();
                        if (updatedRow > 0)
                        {
                            Response.Write("......");
                        }
                        lblTotalBill.Text = "Total Bill: "+finalBill.ToString();
                    }


                }
                else
                {
                    Response.Write("item is not avilable accourding to your requirement");
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FetchProduct();
            }
        }
    }
}































