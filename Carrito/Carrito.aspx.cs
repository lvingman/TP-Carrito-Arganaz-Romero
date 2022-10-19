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
         //  SumaColumna();
            


        }
        private List<ItemCarrito> ListaSessionCar()
        {
            List<ItemCarrito> ItemEnCarro = Session["listaEnCarro"] != null ?
                (List<ItemCarrito>)Session["listaEnCarro"] : new List<ItemCarrito>();
            return ItemEnCarro;
        }

        //public void SumaColumna()
        //{
        //    decimal Total = 0;

        //    foreach (DataGridItem row in dgvCarrito.Rows)
        //    {
        //        Total += Convert.ToDecimal(row.Cells["Precio"].Value);

        //    }
        //    lblTotal.Text = Total.ToString();
        //}

    }
   
}