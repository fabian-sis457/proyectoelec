using CadElec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnElec
{
    public class ProductoCln
    {
        public static int insertar(Producto producto)
        {
            using (var db = new VentaEntities())
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return producto.id;
            }
        }
        public static int actualizar(Producto producto)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Producto.Find(producto.id);
                actual.codigo = producto.codigo;
                actual.descripcion = producto.descripcion;
                actual.unidadMedia = producto.unidadMedia;
                actual.saldo = producto.saldo;
                actual.precioVenta = producto.precioVenta;
                return db.SaveChanges();
            }
        }
        public static int actualizarSaldo(Producto producto)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Producto.Find(producto.saldo);
                return db.SaveChanges();
            }
        }
        public static int eliminar(int idProducto, string usuario)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Producto.Find(idProducto);
                actual.registroActivo = false;
                actual.usuarioRegistro = usuario;
                return db.SaveChanges();
            }
        }
        public static Producto get(int idProducto)
        {
            using (var db = new VentaEntities())
            {
                return db.Producto.Find(idProducto);
            }
        }
        public static List<paPrctListar_Result> listar(string parametro)
        {
            using (var db = new VentaEntities())
            {
                return db.paPrctListar(parametro).ToList();
            }
        }

        public static List<PRODUCTOLIST_Result> listarPA()
        {
            using (var db = new VentaEntities())
            {
                return db.PRODUCTOLIST().ToList();
            }
        }
    }
}
