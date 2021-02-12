using CadElec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnElec
{
    public class EmpleadoCln
    {
        public static int insertar(Empleado empleado)
        {
            using (var db = new VentaEntities())
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return empleado.id;
            }
        }
        public static int actualizar(Empleado empleado)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Empleado.Find(empleado.id);
                actual.cedulaIdentidad = empleado.cedulaIdentidad;
                actual.nombres = empleado.nombres;
                actual.paterno = empleado.paterno;
                actual.materno = empleado.materno;
                actual.direccion = empleado.direccion;
                actual.celular = empleado.celular;
                actual.cargo = empleado.cargo;
                return db.SaveChanges();
            }
        }
        public static int eliminar(int idEmpleado, string usuario)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Empleado.Find(idEmpleado);
                actual.registroActivo = false;
                actual.usuarioRegistro = usuario;
                return db.SaveChanges();
            }
        }
        public static Empleado get(int idEmpleado)
        {
            using (var db = new VentaEntities())
            {
                return db.Empleado.Find(idEmpleado);
            }
        }
        public static List<paEmpListar_Result> listar(string parametro)
        {
            using (var db = new VentaEntities())
            {
                return db.paEmpListar(parametro).ToList();
            }
        }

    }
}
