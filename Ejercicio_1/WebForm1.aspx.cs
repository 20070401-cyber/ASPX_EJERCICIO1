using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // Guardar datos en cookies
            Response.Cookies["ddlCategory"].Value = ddlCategory.SelectedValue;
            Response.Cookies["ddlSupplier"].Value = ddlSupplier.SelectedValue;
            Response.Cookies["strProduct"].Value = txtProduct.Text;
            Response.Cookies["strDescription"].Value = txtDescription.Text;
            Response.Cookies["strImage"].Value = txtImage.Text;
            Response.Cookies["decPrice"].Value = txtPrice.Text;
            Response.Cookies["bytNumberInStock"].Value = txtNumberInStock.Text;
            Response.Cookies["bytNumberOnOrder"].Value = txtNumberOnOrder.Text;
            Response.Cookies["bytReorderLevel"].Value = txtReorderLevel.Text;

            // Redirigir a otra página
            Response.Redirect("WebForm1.aspx");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                if (Request.Cookies["ddlCategory"] != null)
                {
                    ddlCategory.SelectedValue = Request.Cookies["ddlCategory"].Value;
                    ddlSupplier.SelectedValue = Request.Cookies["ddlSupplier"].Value;
                    lblProduct.Text = Request.Cookies["strProduct"].Value;
                    txtDescription.Text = Request.Cookies["strDescription"].Value;
                    lblImage.Text = Request.Cookies["strImage"].Value;

                    Decimal decPrice = Convert.ToDecimal(Request.Cookies["decPrice"].Value);
                    lblPrice.Text = decPrice.ToString("c");

                    lblNumberInStock.Text = Request.Cookies["bytNumberInStock"].Value;
                    lblNumberOnOrder.Text = Request.Cookies["bytNumberOnOrder"].Value;
                    lblReorderLevel.Text = Request.Cookies["bytReorderLevel"].Value;

                    Byte bytNumberInStock = Convert.ToByte(Request.Cookies["bytNumberInStock"].Value);
                    Byte bytNumberOnOrder = Convert.ToByte(Request.Cookies["bytNumberOnOrder"].Value);

                    Decimal decValueInStock = decPrice * bytNumberInStock;
                    Decimal decValueOnOrder = decPrice * bytNumberOnOrder;

                    lblValueInStock.Text = decValueInStock.ToString("c");
                    lblValueOnOrder.Text = decValueOnOrder.ToString("c");
                }
               
        }
    }
}
