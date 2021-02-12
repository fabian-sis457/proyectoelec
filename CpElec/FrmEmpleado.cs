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
    public partial class FrmEmpleado : Form
    {
        bool esNuevo;
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = EmpleadoCln.listar(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if (lista.Count > 0)
            {
                dgvLista.Columns["cedulaIdentidad"].Selected = true;
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
            txtDireccion.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(846, 403);
            gbxDatos.Enabled = false;
            gbxLista.Enabled = true;
            limpiar();
            txtParametro.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Empleado empleado = new Empleado();
                empleado.cedulaIdentidad = txtCi.Text.Trim();
                empleado.nombres = txtNombre.Text.Trim();
                empleado.paterno = txtPaterno.Text.Trim();
                empleado.materno = txtMaterno.Text.Trim();
                empleado.direccion = txtDireccion.Text.Trim();
                empleado.celular = Convert.ToInt64(txtCelular.Text);
                empleado.cargo = txtCargo.Text.Trim();
                empleado.usuarioRegistro = "franz";//Util.usuario.usuario1;

                if (esNuevo)
                {
                    empleado.registroActivo = true;
                    EmpleadoCln.insertar(empleado);
                }
                else
                {
                    var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
                    empleado.id = Convert.ToInt32(row.Cells["id"].Value);
                    EmpleadoCln.actualizar(empleado);
                }
                MessageBox.Show($"Empleado guardado correctamente.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                btnCancelar.PerformClick();
            }
        }

        private bool validar()
        {
            bool esValido = true;
            erpNombre.SetError(txtNombre, string.Empty);
            erpPaterno.SetError(txtPaterno, string.Empty);
            erpMaterno.SetError(txtMaterno, string.Empty);
            erpCi.SetError(txtCi, string.Empty);
            erpDireccion.SetError(txtDireccion, string.Empty);
            erpCelular.SetError(txtCelular, string.Empty);
            erpCargo.SetError(txtCargo, string.Empty);

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "El nombre es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtPaterno.Text))
            {
                erpPaterno.SetError(txtPaterno, "El apellido paterno es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtMaterno.Text))
            {
                erpMaterno.SetError(txtMaterno, "El apellido materno es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtCi.Text))
            {
                erpCi.SetError(txtCi, "El carnet de identidad es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                erpDireccion.SetError(txtDireccion, "La dirección es obligatorio"); esValido = false;
            }
            if (string.IsNullOrEmpty(txtCelular.Text))
            {
                erpCelular.SetError(txtCelular, "El celular es obligatorio"); esValido = false;
            }
            if (string.IsNullOrEmpty(txtCargo.Text))
            {
                erpCargo.SetError(txtCargo, "El cargo es obligatorio"); esValido = false;
            }
            return esValido;
        }

        private void limpiar()
        {
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtMaterno.Text = string.Empty;
            txtCi.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtCargo.Text = string.Empty;
        }

        private void cargarDatos()
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            txtNombre.Text = row.Cells["nombres"].Value.ToString();
            txtPaterno.Text = row.Cells["paterno"].Value.ToString();
            txtMaterno.Text = row.Cells["materno"].Value.ToString();
            txtCi.Text = row.Cells["cedulaIdentidad"].Value.ToString();
            txtDireccion.Text = row.Cells["direccion"].Value.ToString();
            txtCelular.Text = row.Cells["celular"].Value.ToString();
            txtCargo.Text = row.Cells["cargo"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            this.Size = new Size(846, 660);
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            var lista = EmpleadoCln.listar(txtParametro.Text);
            if (lista.Count > 0)
            {
                dgvLista.Columns["nombres"].Selected = true;
            }
            cargarDatos();
            txtDireccion.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            var ci = row.Cells["cedulaIdentidad"].Value.ToString();
            var msg = MessageBox.Show($"¿Está seguro que desea eliminar el empleado con carnet de identidad {ci}?", "::: Ventas - Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                EmpleadoCln.eliminar(Convert.ToInt32(row.Cells["id"].Value), Util.usuario.usuario1);
                MessageBox.Show($"Empleado dado de baja.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            this.Size = new Size(846, 403);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar>=32&&e.KeyChar<=47)|| (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
