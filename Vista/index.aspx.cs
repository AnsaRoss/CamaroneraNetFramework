using CamaroneraNetFramework.Controlador;
using CamaroneraNetFramework.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaroneraNetFramework.Vista
{
    public partial class index : System.Web.UI.Page
    {
        //ProductoControlador _pc;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static String Listado()
        {
            String _Resultado = "";
            var js = new JavaScriptSerializer();

            List<Camaron> lista = new List<Camaron>();
            try
            {
                lista = ProductoControlador.ListadoAD();


                js.MaxJsonLength = Int32.MaxValue;
                _Resultado = js.Serialize(lista);
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return _Resultado;
        }
        [WebMethod]
        public static String ListarProducto()
        {
            String _Resultado = "";
            var js = new JavaScriptSerializer();

            List<Camaron> lista = new List<Camaron>();
            try
            {
                lista = ProductoControlador.ListarProductoAD();


                js.MaxJsonLength = Int32.MaxValue;
                _Resultado = js.Serialize(lista);
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return _Resultado;
        }
        [WebMethod]
        public static String ObtenerInformacionCamaron(int id)
        {
            String _Resultado = "";
            var js = new JavaScriptSerializer();

            Camaron lista = new Camaron();
            try
            {
                lista = ProductoControlador.ObtenerInformacionCamaronAD(id);

                js.MaxJsonLength = Int32.MaxValue;
                _Resultado = js.Serialize(lista);
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return _Resultado;
        }
        [WebMethod]
        public static String Editar(int id, string nombre, string descripcion, int cantidad)
        {
            String _Resultado = "";
            var js = new JavaScriptSerializer();

            String lista = "";
            try
            {
                lista = ProductoControlador.EditarAD(id,nombre,descripcion,cantidad);


                js.MaxJsonLength = Int32.MaxValue;
                _Resultado = js.Serialize(lista);
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return _Resultado;
        }
        [WebMethod]
        public static String Guardar( string nombre, string descripcion, int cantidad)
        {
            String _Resultado = "";
            var js = new JavaScriptSerializer();

            String lista = "";
            try
            {
                lista = ProductoControlador.GuardarAD(nombre,descripcion,cantidad);


                js.MaxJsonLength = Int32.MaxValue;
                _Resultado = js.Serialize(lista);
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return _Resultado;
        }
        [WebMethod]
        public static String RegitrarSalida(int id, int cantidad)
        {
            String _Resultado = "";
            var js = new JavaScriptSerializer();

             string lista = "";
            try
            {
                if (ProductoControlador.GuardarHistorialAD(id, cantidad) == 1)
                {
                    lista = ProductoControlador.GuardarSalidaAD(id, cantidad);
                }

                js.MaxJsonLength = Int32.MaxValue;
                _Resultado = js.Serialize(lista);
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return _Resultado;
        }
    }
}