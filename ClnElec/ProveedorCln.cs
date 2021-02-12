using CadElec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnElec
{
    public class ProveedorCln
    {
        public static int insertar(Proveedor proveedor)
        {
            using (var db = new VentaEntities())
            {
                db.Proveedor.Add(proveedor);
                db.SaveChanges();
                return proveedor.id;
            }
        }
        public static int actualizar(Proveedor proveedor)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Proveedor.Find(proveedor.id);
                actual.nit = proveedor.nit;
                actual.razonSocial = proveedor.razonSocial;
                actual.direccion = proveedor.direccion;
                actual.telefono = proveedor.telefono;
                actual.representante = proveedor.representante;
                return db.SaveChanges();
            }
        }
        public static int eliminar(int idProveedor, string usuario)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Proveedor.Find(idProveedor);
                actual.registroActivo = false;
                actual.usuarioRegistro = usuario;
                return db.SaveChanges();
            }
        }
        public static Proveedor get(int idProveedor)
        {
            using (var db = new VentaEntities())
            {
                return db.Proveedor.Find(idProveedor);
            }
        }
        public static List<Proveedor> listar()
        {
            using (var db = new VentaEntities())
            {
                return db.Proveedor.Where(x => x.registroActivo == true).ToList();
            }
        }

        public static List<paProListar_Result> listarPa(string parametro)
        {
            using (var db = new VentaEntities())
            {
                return db.paProListar(parametro).ToList();
            }
        }
    }
}
