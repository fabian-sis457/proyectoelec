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
    public partial class FrmBuscarCliente : Form
    {
        bool esNuevo;
        public FrmBuscarCliente()
        {
            InitializeComponent();
        }

        public Cliente ClienteSeleccionado { get; set; }
        public Cliente RazonSeleccionado { get; set; }

        private void listar()
        {
            var lista = ClienteCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if (lista.Count > 0)
            {
                dgvLista.Columns["nit"].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            this.Size = new Size(846, 665);
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            txtNit.Focus();
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
                Cliente cliente = new Cliente();
                cliente.nombre = txtNombre.Text.Trim();
                cliente.aPaterno = txtPaterno.Text.Trim();
                cliente.aMaterno = txtMaterno.Text.Trim();
                cliente.nit = txtNit.Text.Trim();
                cliente.razonSocial = txtRazonSocial.Text.Trim();
                cliente.usuarioRegistro = Util.usuario.usuario1;

                if (esNuevo)
                {
                    cliente.registroActivo = true;
                    ClienteCln.insertar(cliente);
                }
                else
                {
                    var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
                    cliente.id = Convert.ToInt32(row.Cells["id"].Value);
                    ClienteCln.actualizar(cliente);
                }
                MessageBox.Show($"Cliente guardado correctamente.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                btnCancelar.PerformClick();
            }
        }
        private bool validar()
        {
            bool esValido = true;
            erpNit.SetError(txtNit, string.Empty);
            erpRazonSocial.SetError(txtRazonSocial, string.Empty);
            erpNombre.SetError(txtNombre, string.Empty);
            erpPaterno.SetError(txtPaterno, string.Empty);
            erpMaterno.SetError(txtMaterno, string.Empty);

            if (string.IsNullOrEmpty(txtNit.Text))
            {
                erpNit.SetError(txtNit, "El NIT es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                erpRazonSocial.SetError(txtRazonSocial, "La Razón Social es obligatorio"); esValido = false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "El Nombre es obligatorio"); esValido = false;
            }
            if (string.IsNullOrEmpty(txtPaterno.Text))
            {
                erpPaterno.SetError(txtPaterno, "El apellido paterno es obligatorio"); esValido = false;
            }
            if (string.IsNullOrEmpty(txtMaterno.Text))
            {
                erpMaterno.SetError(txtMaterno, "El apellido materno es obligatorio"); esValido = false;
            }
            return esValido;
        }

        private void limpiar()
        {
            txtNit.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtMaterno.Text = string.Empty;
        }

        private void cargarDatos()
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            var lista = ProveedorCln.listarPa(txtParametro.Text);
            if (lista.Count > 0)
            {
                dgvLista.Columns["nit"].Selected = true;
            }
            txtNit.Text = row.Cells["nit"].Value.ToString();
            txtRazonSocial.Text = row.Cells["razonSocial"].Value.ToString();
            txtNombre.Text = row.Cells["nombre"].Value.ToString();
            txtPaterno.Text = row.Cells["aPaterno"].Value.ToString();
            txtMaterno.Text = row.Cells["aMaterno"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            this.Size = new Size(846, 665);
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            cargarDatos();
            txtNit.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            var nit = row.Cells["nit"].Value.ToString();
            var msg = MessageBox.Show($"¿Está seguro que desea eliminar el cliente con nit {nit}?", "::: Ventas - Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                ClienteCln.eliminar(Convert.ToInt32(row.Cells["id"].Value), Util.usuario.usuario1);
                MessageBox.Show($"Cliente dado de baja.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }
        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            this.Size = new Size(846, 403);
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count == 1) // si selecciona un fila
            {
                Int32 id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value); //asignamos el numero de id
                Int32 razonSocial = Convert.ToInt32(dgvLista.CurrentRow.Cells[1].Value);
                ClienteSeleccionado = ClienteCln.get(id);//llenamos el empleado seleccionado
                RazonSeleccionado = ClienteCln.get(razonSocial);//llenamos el empleado seleccionado
                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no ha seleccionado ningún Empleado");
            }
        }
    }
}
