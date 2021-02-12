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
    public partial class FrmUsuario : Form
    {
        bool esNuevo;
        int idEmpleado;
        public FrmUsuario()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var lista = UsuarioCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["clave"].Visible = false;
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if (lista.Count > 0)
            {
                dgvLista.Columns["usuario"].Selected = true;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            this.Size = new Size(846, 660);
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            txtUsuario.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Usuario usuario = new Usuario();
                usuario.usuario1 = txtUsuario.Text.Trim();
                usuario.clave = Util.Encrypt(txtClave.Text.Trim());
                usuario.idEmpleado = idEmpleado;
                usuario.usuarioRegistro = Util.usuario.usuario1; 

                if (esNuevo)
                {
                    usuario.registroActivo = true;
                    UsuarioCln.insertar(usuario);
                }
                else
                {
                    var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
                    usuario.id = Convert.ToInt32(row.Cells["id"].Value);
                    UsuarioCln.actualizar(usuario);
                }
                MessageBox.Show($"Usuario guardado correctamente.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                btnCancelar.PerformClick();
            }
        }
        private bool validar()
        {
            bool esValido = true;
            erpUsuario.SetError(txtUsuario, string.Empty);
            erpClave.SetError(txtClave, string.Empty);
            erpEmpleado.SetError(txtEmpleado, string.Empty);


            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                erpUsuario.SetError(txtUsuario, "El usuario es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtClave.Text))
            {
                erpClave.SetError(txtClave, "La contraseña es obligatorio"); esValido = false;
            }
            if (string.IsNullOrEmpty(txtEmpleado.Text))
            {
                erpEmpleado.SetError(txtEmpleado, "La contraseña es obligatorio"); esValido = false;
            }

            return esValido;
        }

        private void limpiar()
        {
            txtUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtEmpleado.Text = string.Empty;
        }

        private void cargarDatos()
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            txtUsuario.Text = row.Cells["usuario"].Value.ToString();
            txtClave.Text = row.Cells["clave"].Value.ToString();
            txtEmpleado.Text = row.Cells["idEmpleado"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            this.Size = new Size(846, 660);
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            var lista = UsuarioCln.listarPa(txtParametro.Text);
            if (lista.Count > 0)
            {
                dgvLista.Columns["nombres"].Selected = true;
            }
            cargarDatos();
            txtUsuario.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(846, 403);
            gbxDatos.Enabled = false;
            gbxLista.Enabled = true;
            limpiar();
            txtParametro.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            var usuario = row.Cells["usuario"].Value.ToString();
            var msg = MessageBox.Show($"¿Está seguro que desea eliminar el usuario  {usuario}?", "::: Ventas - Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                UsuarioCln.eliminar(Convert.ToInt32(row.Cells["id"].Value), Util.usuario.usuario1);
                MessageBox.Show($"Usuario dado de baja.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            this.Size = new Size(846, 403);
            txtEmpleado.Enabled = false;
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            FrmBuscarEmpleado Buscar = new FrmBuscarEmpleado();
            Buscar.ShowDialog();
            if (Buscar.EmpleadoSeleccionado != null)
            {
                idEmpleado = Convert.ToInt32(Buscar.EmpleadoSeleccionado.id.ToString());
                txtEmpleado.Text = Buscar.EmpleadoSeleccionado.nombres.ToString();
            }
        }
    }
}
