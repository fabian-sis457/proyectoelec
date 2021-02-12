using CadElec;
using ClnElec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpElec
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal(FrmAutenticacion frmAutenticacion)
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FrmUsuario().ShowDialog();
            /*Usuario usuario = new Usuario();
            usuario.usuario1 = "franz";
            usuario.clave = Util.Encrypt("1234");
            usuario.idEmpleado = 15;
            usuario.registroActivo = true;
            UsuarioCln.insertar(usuario);*/
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            new FrmCliente().ShowDialog();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            new FrmProveedor().ShowDialog();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            new FrmProducto().ShowDialog();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            new FrmEmpleado().ShowDialog();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            new FrmVenta().ShowDialog();
        }
    }
}
