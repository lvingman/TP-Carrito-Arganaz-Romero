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
            int idAgregar = int.Parse(((Button)sender).CommandArgument);

            List<ItemCarrito> ListSesion = ListaSessionCar();
            ItemCarrito aAgregar = new ItemCarrito();
            if ((aAgregar = ListSesion.Find(x => x.Id == idAgregar)) != null){
                aAgregar.Cantidad++;
            }
            else
            {
                ItemCarrito nuevoItem = new ItemCarrito();
                Articulo nuevoArticulo = BuscarProduc(idAgregar);
                nuevoItem.Id = nuevoArticulo.Id;
                nuevoItem.Nombre = nuevoArticulo.Nombre;
                nuevoItem.URLImagen = nuevoArticulo.URLImagen;
                nuevoItem.Precio = nuevoArticulo.Precio;
                nuevoItem.Cantidad++;
                ListSesion.Add(nuevoItem);
            }
   
            Session.Add("listaEnCarro", ListSesion);
        }

        protected void btnAgregarCarritoRedirect_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            int idAgregar = int.Parse(((Button)sender).CommandArgument);

            List<ItemCarrito> ListSesion = ListaSessionCar();
            ItemCarrito aAgregar;
            if ((aAgregar = ListSesion.Find(x => x.Id == idAgregar)) != null)
            {
                aAgregar.Cantidad++;
            }
            else
            {
                ItemCarrito nuevoItem = new ItemCarrito();
                Articulo nuevoArticulo = BuscarProduc(idAgregar);
                nuevoItem.Id = nuevoArticulo.Id;
                nuevoItem.Nombre = nuevoArticulo.Nombre;
                nuevoItem.URLImagen = nuevoArticulo.URLImagen;
                nuevoItem.Precio = nuevoArticulo.Precio;
                nuevoItem.Cantidad++;
                ListSesion.Add(nuevoItem);
            }

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

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
                List<Articulo> listaFiltrada;
                string filtro = txtFiltro.Text;

                if (filtro != "")
                {
                    listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {

                    listaFiltrada = listaArticulos;

                }

                Repeter.DataSource = listaFiltrada;
                Repeter.DataBind();         
        }
    }
    }


