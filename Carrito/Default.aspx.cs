using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Carrito
{
    public partial class _Default : Page
    {

        public List<Articulo> listaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();

            if (!IsPostBack) {
            Repeter.DataSource = listaArticulos;
            Repeter.DataBind();
            }

        }
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
           string valor = ((Button)sender).CommandArgument;
            ItemCarrito nuevo = new ItemCarrito();
            int idArt = int.Parse(((Button)sender).CommandArgument);
            Articulo nuevoArticulo = BuscarProduc(idArt);

            nuevo.Id = nuevoArticulo.Id;
            nuevo.Nombre = nuevoArticulo.Nombre;
            nuevo.Cantidad++;

            List<ItemCarrito> ListSesion = ListaSessionCar();
            ListSesion.Add(nuevo);
            Session.Add("listaEnCarro", ListSesion);
        }

        protected void btnAgregarCarritoRedirect_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            string valor = ((Button)sender).CommandArgument;
            ItemCarrito nuevo = new ItemCarrito();
            int idArt = int.Parse(((Button)sender).CommandArgument);
            Articulo nuevoArticulo = BuscarProduc(idArt);

            nuevo.Id = nuevoArticulo.Id;
            nuevo.Nombre = nuevoArticulo.Nombre;
            nuevo.Cantidad++;

            List<ItemCarrito> ListSesion = ListaSessionCar();
            ListSesion.Add(nuevo);
            Session.Add("listaEnCarro", ListSesion);

            Response.Redirect("Carrito.aspx");
        }

        public Articulo BuscarProduc(int id)
        {
           Articulo art = new Articulo();
            art = listaArticulos.Find(x => x.Id == id);
            return art;
        }

        private List<ItemCarrito> ListaSessionCar()
        {
            List<ItemCarrito> ItemEnCarro = Session["listaEnCarro"] != null ?
                (List<ItemCarrito>)Session["listaEnCarro"] : new List<ItemCarrito>();
            return ItemEnCarro;
        }


    }
}