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
    public partial class FrmProducto : Form
    {
        bool esNuevo;
        public FrmProducto()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var lista = ProductoCln.listar(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if (lista.Count > 0)
            {
                dgvLista.Columns["descripcion"].Selected = true;
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
            txtCodigo.Focus();
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
                Producto producto = new Producto();
                producto.codigo = txtCodigo.Text;
                producto.descripcion = txtDescripcion.Text.Trim();
                producto.unidadMedia = txtUnidad.Text.Trim();
                producto.saldo = Convert.ToInt64(txtSaldo.Text);
                producto.precioVenta = Convert.ToInt64(txtPrecio.Text);
                producto.usuarioRegistro = Util.usuario.usuario1; 

                if (esNuevo)
                {
                    producto.registroActivo = true;
                    ProductoCln.insertar(producto);
                }
                else
                {
                    var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
                    producto.id = Convert.ToInt32(row.Cells["id"].Value);
                    ProductoCln.actualizar(producto);
                }
                MessageBox.Show($"Producto guardado correctamente.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                btnCancelar.PerformClick();
            }
        }

        private bool validar()
        {
            bool esValido = true;
            erpCodigo.SetError(txtCodigo, string.Empty);
            erpDescripcion.SetError(txtDescripcion, string.Empty);
            erpPrecio.SetError(txtPrecio, string.Empty);
            erpSaldo.SetError(txtSaldo, string.Empty);
            erpUnidad.SetError(txtUnidad, string.Empty);

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                erpCodigo.SetError(txtCodigo, "El Código es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                erpDescripcion.SetError(txtDescripcion, "La descripción es obligatoria"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                erpPrecio.SetError(txtPrecio, "El precio es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtSaldo.Text))
            {
                erpSaldo.SetError(txtSaldo, "El saldo es obligatorio"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtUnidad.Text))
            {
                erpUnidad.SetError(txtUnidad, "La unidad es obligatoria"); esValido = false;
            }
            return esValido;
        }

        private void limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtSaldo.Text = string.Empty;
            txtUnidad.Text = string.Empty;
        }

        private void cargarDatos()
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            txtCodigo.Text = row.Cells["codigo"].Value.ToString();
            txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();
            txtPrecio.Text = row.Cells["precioVenta"].Value.ToString();
            txtSaldo.Text = row.Cells["saldo"].Value.ToString();
            txtUnidad.Text = row.Cells["unidadMedia"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            this.Size = new Size(846, 665);
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            cargarDatos();
            txtCodigo.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            var codigo = row.Cells["codigo"].Value.ToString();
            var msg = MessageBox.Show($"¿Está seguro que desea eliminar el producto con código {codigo}?", "::: Ventas - Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                ProductoCln.eliminar(Convert.ToInt32(row.Cells["id"].Value), Util.usuario.usuario1);
                MessageBox.Show($"Producto dado de baja.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            this.Size = new Size(846, 403);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
