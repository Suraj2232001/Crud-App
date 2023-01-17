using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string LoginID = "admin", Password = "admin@1234#$!";
                if ((txtLoginID.Text == LoginID) && (txtPassword.Text == Password))
                {
                    Response.Redirect("customerMaster.aspx");
                }
                else
                {
                    Response.Write("Invalid Credentials....Please try once again.........Thankyou");
                }
            }
            catch(Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        protected void LinkProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string LoginID = "admin", Password = "admin@1234#$!";
                if ((txtLoginID.Text == LoginID) && (txtPassword.Text == Password))
                {
                    Response.Redirect("productMaster.aspx");
                }
                else
                {
                    Response.Write("Invalid Credentials....Please try once again.........Thankyou");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }

        protected void LinkBilling_Click(object sender, EventArgs e)
        {
            try
            {
                string LoginID = "admin", Password = "admin@1234#$!";
                if ((txtLoginID.Text == LoginID) && (txtPassword.Text == Password))
                {
                    Response.Redirect("BillDetails.aspx");
                }
                else
                {
                    Response.Write("Invalid Credentials....Please try once again.........Thankyou");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Message: " + ex.Message);
            }
        }
    }
}