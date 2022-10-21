using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace Carrito
{
    public partial class Contact : Page
    {
        public List<int> cantidadArticulos { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            List<ItemCarrito> ListSesion = ListaSessionCar();
            dgvCarrito.DataSource = ListSesion;
            dgvCarrito.DataBind();
            if (dgvCarrito.Rows.Count > 0)
            {
                dgvCarrito.HeaderRow.Style["background-color"] = "#f0f2f4";
                
            }
            contar();
        


        }
        private List<ItemCarrito> ListaSessionCar()
        {
            List<ItemCarrito> ItemEnCarro = Session["listaEnCarro"] != null ?
                (List<ItemCarrito>)Session["listaEnCarro"] : new List<ItemCarrito>();
            return ItemEnCarro;
        }

        public void contar()
        {
            decimal a = 0;
            foreach  (ItemCarrito item in ListaSessionCar()) {
                a += item.Precio*item.Cantidad;            
            }
            lblTotal.Text = a.ToString();
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idd = dgvCarrito.SelectedRow.Cells[0].Text;
            foreach (ItemCarrito item in ListaSessionCar())
            {
                int itemid = Convert.ToInt32(item.Id);
                int id = Convert.ToInt32(idd);
                if (id == itemid)
                {
                    item.Cantidad--;
                    if (item.Cantidad == 0)
                    {
                        item.Precio = 0;
                        item.Id = 0;
                        item.Nombre = "0";
                        Response.Redirect("carrito.aspx");
                    }                 
                }
               
            }

        }
    }
   
}