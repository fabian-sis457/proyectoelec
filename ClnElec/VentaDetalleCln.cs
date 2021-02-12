using CadElec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnElec
{
    public class VentaDetalleCln
    {
        public static int insertar(VentaDetalle ventaDetalle)
        {
            using (var db = new VentaEntities())
            {
                db.VentaDetalle.Add(ventaDetalle);
                db.SaveChanges();
                return ventaDetalle.id;
            }
        }
        public static int actualizar(VentaDetalle ventaDetalle)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.VentaDetalle.Find(ventaDetalle.id);
                actual.idVenta = ventaDetalle.idVenta;
                actual.idProducto = ventaDetalle.idProducto;
                actual.cantidad = ventaDetalle.cantidad;
                actual.total = ventaDetalle.total;
                return db.SaveChanges();
            }
        }
        public static int eliminar(int idVentaDetalle, string usuario)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.VentaDetalle.Find(idVentaDetalle);
                actual.registroActivo = false;
                actual.usuarioRegistro = usuario;
                return db.SaveChanges();
            }
        }
        public static VentaDetalle get(int idVentaDetalle)
        {
            using (var db = new VentaEntities())
            {
                return db.VentaDetalle.Find(idVentaDetalle);
            }
        }
        public static List<paVENTASDETALLE_Result> listar()
        {
            using (var db = new VentaEntities())
            {
                return db.paVENTASDETALLE().ToList();
            }
        }
    }
}
