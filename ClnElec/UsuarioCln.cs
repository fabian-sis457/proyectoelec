using CadElec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnElec
{
    public class UsuarioCln
    {
        public static int insertar(Usuario usuario)
        {
            using (var db = new VentaEntities())
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return usuario.id;
            }
        }
        public static int actualizar(Usuario usuario)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Usuario.Find(usuario.id);
                actual.usuario1 = usuario.usuario1;
                actual.idEmpleado = usuario.idEmpleado;
                return db.SaveChanges();
            }
        }
        public static int eliminar(int idUsuario, string usuario)
        {
            using (var db = new VentaEntities())
            {
                var actual = db.Usuario.Find(idUsuario);
                actual.registroActivo = false;
                actual.usuarioRegistro = usuario;
                return db.SaveChanges();
            }
        }
        public static Usuario get(int idUsuario)
        {
            using (var db = new VentaEntities())
            {
                return db.Usuario.Find(idUsuario);
            }
        }
        public static List<Usuario> listar()
        {
            using (var db = new VentaEntities())
            {
                return db.Usuario.Where(x => x.registroActivo == true).ToList();
            }
        }
        public static List<paUsuListar_Result> listarPa(string parametro)
        {
            using (var db = new VentaEntities())
            {
                return db.paUsuListar(parametro).ToList();
            }
        }
        public static Usuario validar(string usuario, string clave)
        {
            using (var db = new VentaEntities())
            {
                return db.Usuario.Where(x => x.usuario1 == usuario && x.clave == clave).FirstOrDefault();
            }
        }
    }
}
