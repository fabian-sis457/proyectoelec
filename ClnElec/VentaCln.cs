using CadElec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnElec
{
    public class VentaCln
    {
        public static int insertar(Venta venta)
        {
            using (var db = new VentaEntities())
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return venta.id;
            }
        }
        public static int actualizar(Venta venta)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Venta.Find(venta.id);
                actual.idUsuario = venta.idUsuario;
                actual.idCliente = venta.idCliente;
                actual.transaccion = venta.transaccion;
                actual.fecha = venta.fecha;
                return db.SaveChanges();
            }
        }
        public static int eliminar(int idVenta, string usuario)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Venta.Find(idVenta);
                actual.registroActivo = false;
                actual.usuarioRegistro = usuario;
                return db.SaveChanges();
            }
        }
        public static Venta get(int idVenta)
        {
            using (var db = new VentaEntities())
            {
                return db.Venta.Find(idVenta);
            }
        }
        public static List<Usuariolistar_Result> listar(string parametro)
        {
            using (var db = new VentaEntities())
            {
                return db.Usuariolistar(parametro).ToList();
            }
        }
    }
}
