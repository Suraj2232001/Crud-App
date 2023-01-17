using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Assignment5
{
    public partial class billingSystem : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=IKL-70\\SQL2016;Initial Catalog=Batch10;User ID=sa;Password=sa@1234;MultipleActiveResultSets=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader rdr;
        SqlDataSource ds;
        DataTable dt;
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
                        cmd = new SqlCommand("Select CustID from CustomerMaster ", con);//it executes sql statements on database
                        rdr = cmd.ExecuteReader();//it executes the sql statement and bing data from back to front
                        while (rdr.Read())
                        {
                            drdCustID.Items.Add(rdr[0].ToString());
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

        public void Fetch()
        {
            try
            {
                drdCustID.Items.Clear();
                cmd = new SqlCommand("Select CustID from CustomerMaster", con);
                rdr = cmd.ExecuteReader();
                //int rdrIndex = rdr.GetOrdinal("EmpID");
                while (rdr.Read())
                {
                    drdCustID.Items.Add(rdr[0].ToString());
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
                cmd = new SqlCommand("Select * from CustomerMaster where CustID = 1", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    object name = cmd.ExecuteScalar();
                    txtCustID.Text = rdr["CustID"].ToString();
                    txtCustName.Text = rdr["CustName"].ToString();
                    txtCustAddress.Text = rdr["CustAddress"].ToString();
                    txtCustMobile.Text = rdr["MobileNumber"].ToString();
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
                txtCustID.Enabled = true;
                txtCustName.Enabled = true;
                txtCustAddress.Enabled = true;
                txtCustMobile.Enabled = true;
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
                txtCustID.Enabled = false;
                txtCustName.Enabled = false;
                txtCustAddress.Enabled = false;
                txtCustMobile.Enabled = false;
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        public void Clear()
        {
            txtCustID.Text = "";
            txtCustName.Text = "";
            txtCustAddress.Text = "";
            txtCustMobile.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Enable();
                Clear();
            }
            catch(Exception ex)
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

                cmd.CommandText = string.Format("insert into CustomerMaster(CustID, CustName, CustAddress, MobileNumber) values({0},'{1}','{2}', {3})", txtCustID.Text, txtCustName.Text, txtCustAddress.Text, txtCustMobile.Text);

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
                cmd.CommandText = String.Format("Update CustomerMaster set CustName = '{0}', CustAddress = '{1}', MobileNumber = {2} where CustID = {3}", txtCustName.Text, txtCustAddress.Text, txtCustMobile.Text, drdCustID.SelectedItem);
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

        protected void drdCustID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int id = Convert.ToInt32(drdCustID.Text);
                cmd = new SqlCommand("Select * from CustomerMaster where CustID=@OptionCustId", con);//drop down chnge query for 2ddl
                cmd.Parameters.AddWithValue("@OptionCustID", id);//assigning id in sql parameter
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {    
                    txtCustID.Text = rdr["CustID"].ToString();
                    txtCustName.Text = rdr["CustName"].ToString();
                    txtCustAddress.Text = rdr["CustAddress"].ToString();
                    txtCustMobile.Text = rdr["MobileNumber"].ToString();
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = String.Format("Delete from CustomerMaster where CustID = {0}", txtCustID.Text);
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

        
    }
}











































































/*
//SQL Code for reference..............
create table Employee(
EmpID int identity(1,1) primary key,
EmpName varchar(50),
EmpSal int,
DeptID int references Department(DeptID))

insert into Employee values('Suraj',50000,10)
insert into Employee values('Irfan',40000,20)

select * from Employee;
select * from Department;

drop table Employee;

create table Department(
DeptID int primary key,
DeptName varchar(50) not null)

insert into Department values(10,'HR'),(20,'IT'),(30,'FTE'),(40,'IP'),(50,'Maplytics');

select * from Department;
___________________________________________________________________________________________
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CrudSingle
{
    public partial class Single : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader rdr;
        SqlDataSource ds;
        DataTable dt;

        //page load code
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=IKL-70\\SQL2016;Initial Catalog=Batch10;User ID=sa;Password=sa@1234;MultipleActiveResultSets=True");
            try
            {
                con.Open();
                if(!Page.IsPostBack)//it is used bcoz we need want the data to be repeated on every pageload
                {
                    try
                    {
                        cmd = new SqlCommand("select DeptName from Department", con);//it executes sql statements on database
                        rdr = cmd.ExecuteReader();//it executes the sql statement and bing data from back to front
                        while(rdr.Read())
                        {
                            drdDeptName.Items.Add(rdr[0].ToString());
                        }
                        Fetch();
                        Display();
                        Disable();
                        
                    }
                    catch(Exception ex)
                    {
                        Response.Write("Message: " + ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //edit section.........to enable fields
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

        //Add data code........to enable fields
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

        //Insert data......Save button
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //cmd = new SqlCommand("Select DeptID from Department where DeptName ="+drdDeptNam, con);
                
                cmd = new SqlCommand();
                cmd.CommandText = String.Format("Select DeptID from Department where DeptName = '{0}'", drdDeptName.SelectedItem);
                cmd.Connection = con;
                int deptid = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = string.Format("insert into Employee(EmpName, EmpSal, DeptID) values('{0}',{1}, {2})", txtName.Text, txtSalary.Text, deptid);

                //cmd.CommandText = "@@Identity";
                cmd.Connection = con;
                int row = cmd.ExecuteNonQuery();
                if(row>0)
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

        //Delete the data
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = String.Format("Delete from Employee where EmpID = {0}", txtID.Text);
                cmd.Connection = con;
                int row = cmd.ExecuteNonQuery();
                if(row>0)
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

        //update section
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = String.Format("Select DeptID from Department where DeptName ='{0}' ",drdDeptName.SelectedItem);
                int deptid = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = String.Format("Update Employee set EmpName = '{0}', EmpSal = {1}, DeptID = {2} where EmpId = {3}",txtName.Text, txtSalary.Text,drdDeptName.SelectedItem, drdID.SelectedItem);
                cmd.Connection = con;
                int row = cmd.ExecuteNonQuery();
                if(row>0)
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

        protected void drdID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int id = Convert.ToInt32(drdID.Text);
                cmd = new SqlCommand("Select * from Employee where EmpID = @OptionID",con);
                cmd.Parameters.AddWithValue("@OptionID", id);//assigning id in sql parameter
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    int deptId = Convert.ToInt32(rdr["DeptID"].ToString());
                    cmd = new SqlCommand("Select DeptName from Department where DeptID=@OptiondeptId", con);//drop down chnge query for 2ddl
                    cmd.Parameters.AddWithValue("@OptiondeptID",deptId);
                    drdDeptName.Text = cmd.ExecuteScalar().ToString();//parameter line
                    txtID.Text = id.ToString();//rdr["EmpID"].ToString();
                    txtName.Text = rdr["EmpName"].ToString();
                    txtSalary.Text = rdr["EmpSal"].ToString();
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

        public void Display()
        {
            try
            {
                cmd = new SqlCommand("Select * from Employee where EmpID = 1", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmd = new SqlCommand("Select DeptName from Department where DeptID ="+rdr["DeptID"], con);
                    object name = cmd.ExecuteScalar();
                    txtID.Text = rdr["EmpID"].ToString();
                    txtName.Text = rdr["EmpName"].ToString();
                    txtSalary.Text = rdr["EmpSal"].ToString();
                    drdDeptName.Text = name.ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        public void Fetch()//to update the drop down list
        {
            try
            {
                drdID.Items.Clear();
                cmd = new SqlCommand("Select EmpID from Employee", con);
                rdr = cmd.ExecuteReader();
                //int rdrIndex = rdr.GetOrdinal("EmpID");
                while (rdr.Read())
                {
                    drdID.Items.Add(rdr[0].ToString());
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
                txtName.Enabled = true;
                txtSalary.Enabled = true;
                drdDeptName.Enabled = true;
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
                txtID.Enabled = false;
                txtName.Enabled = false;
                txtSalary.Enabled = false;
                drdDeptName.Enabled = false;
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        public void Clear()//to clear the feilds when when need to add naya data
        {
            txtID.Text = "";
            txtName.Text = "";
            txtSalary.Text = "";
        }

        protected void drdDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

*/
