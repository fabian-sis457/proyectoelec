using CadElec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnElec
{
    public class ClienteCln
    {
        public static int insertar(Cliente cliente)
        {
            using (var db = new VentaEntities())
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return cliente.id;
            }
        }
        public static int actualizar(Cliente cliente)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Cliente.Find(cliente.id);
                actual.nit = cliente.nit;
                actual.razonSocial = cliente.razonSocial;
                actual.nombre = cliente.nombre;
                actual.aPaterno = cliente.aPaterno;
                actual.aMaterno = cliente.aMaterno;
                return db.SaveChanges();
            }
        }
        public static int eliminar(int idCliente, string usuario)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Cliente.Find(idCliente);
                actual.registroActivo = false;
                actual.usuarioRegistro = usuario;
                return db.SaveChanges();
            }
        }
        public static Cliente get(int idCliente)
        {
            using (var db = new VentaEntities())
            {
                return db.Cliente.Find(idCliente);
            }
        }
        public static List<paCliListar_Result> listarPa(string parametro)
        {
            using (var db = new VentaEntities())
            {
                return db.paCliListar(parametro).ToList();
            }
        }
    }
}
