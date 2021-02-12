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
using static CpElec.FrmAutenticacion;

namespace CpElec
{
    public partial class FrmVenta : Form
    {
        double totalventa = 0;
        int idCliente;
        string idProducto;
        int idVenta;
        private DataTable VentaDetails;
        string saldo;

        public FrmVenta()
        {
            InitializeComponent();
        }
        /*private void ListarVenta()
        {
            var lista = VentaDetalleCln.listar();
            dgvLista.DataSource = lista;
        }*/
        private void ListarProducto()
        {
            var lista = ProductoCln.listarPA();
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
        }
        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarCliente Buscar = new FrmBuscarCliente();
            Buscar.ShowDialog();
            if (Buscar.ClienteSeleccionado != null)
            {
                txtCliente.Text = Buscar.ClienteSeleccionado.razonSocial.ToString();
                idCliente = Convert.ToInt32(Buscar.ClienteSeleccionado.id.ToString());
            }
            
        }
        
        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 237);
            lblTotal.Text = (0).ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmProductoBuscar Buscar = new FrmProductoBuscar();
            Buscar.ShowDialog();
            if (Buscar.ProductoSeleccionado != null)
            {
                txtProductoBuscar.Text = Buscar.ProductoSeleccionado.id.ToString();
            }
        }

        private decimal total()
        {
            decimal aux = 0;
            for (int i = 0; i < dgvDetalles.Rows.Count; i++)
                aux = aux + Convert.ToDecimal(dgvDetalles.Rows[i].Cells["Total"].Value);
            return aux;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                VentaDetalle ventaDetalle = new VentaDetalle();
                ventaDetalle.idVenta = idVenta;
                ventaDetalle.idProducto = Convert.ToInt32(idProducto);
                ventaDetalle.cantidad = Convert.ToInt64(txtCantidad.Text);
                ventaDetalle.precioUnitario = Convert.ToInt64(txtPrecio.Text);
                ventaDetalle.total = Convert.ToInt64(lblTotal.Text);
                ventaDetalle.usuarioRegistro = Util.usuario.usuario1;
                ventaDetalle.registroActivo = true;
                VentaDetalleCln.insertar(ventaDetalle);
                MessageBox.Show($"Venta guardado correctamente.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ListarVenta();
                //dgvLista.Columns["id"].Visible = false;
                //dgvLista.Columns["registroActivo"].Visible = false;
                limpiar();
                lblTotal.Text = Convert.ToString(totalventa);
            }
                
        }

        private bool validar()
        {
            bool esValido = true;
            erpCantidad.SetError(txtCantidad, string.Empty);
            erpPrecioUnitario.SetError(txtPrecio, string.Empty);

            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                erpCantidad.SetError(txtCantidad, "La cantidad es obligatoria"); esValido = false;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                erpPrecioUnitario.SetError(txtPrecio, "El precio unitario es obligatorio"); esValido = false;
            }

            return esValido;
        }
        private bool validarCliente()
        {
            bool esValido = true;
            erpCliente.SetError(txtCliente, string.Empty);

            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                erpCliente.SetError(txtCliente, "Debes seleccionar al cliente"); esValido = false;
            }

            return esValido;
        }

        private void limpiar()
        {
            txtProductoBuscar.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            lblTotal.Text = string.Empty;
            dgvDetalles.DataSource = string.Empty;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (validarCliente())
            {
                Venta venta = new Venta();
                venta.idUsuario = Util.usuario.id;
                venta.idCliente = idCliente;
                venta.transaccion = "Venta";
                venta.fecha = DateTime.Now;
                venta.registroActivo = true;
                venta.usuarioRegistro = Util.usuario.usuario1;
                VentaCln.insertar(venta);
                MessageBox.Show($"Cliente seleccionado correctamente.", "::: Ventas - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Size = new Size(900, 650);
                ListarProducto();
                CrearTabla();
                idVenta = venta.id;
            }

        }
        private void CrearTabla()
        {
            VentaDetails = new DataTable("Detalles");
            //VentaDetails.Columns.Add("id", Type.GetType("System.Int32"));
            VentaDetails.Columns.Add("Cantidad", Type.GetType("System.Int32"));
            VentaDetails.Columns.Add("precioUnitario", Type.GetType("System.Decimal"));
            VentaDetails.Columns.Add("Producto", Type.GetType("System.String"));
            VentaDetails.Columns.Add("Total", Type.GetType("System.Decimal"));

            //RELACIONAR EL DATALISTADO CON EL DATATABLE
            dgvDetalles.DataSource = VentaDetails;
            //dgvDetalles.Columns[0].Visible = false;
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            idProducto = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["id"].Value.ToString();
            saldo = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["saldo"].Value.ToString();
            txtPrecio.Text = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["precioVenta"].Value.ToString();
            txtProductoBuscar.Text = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["descripcion"].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCantidad.Text)>Convert.ToInt32(saldo))
            {
                MessageBox.Show("La cantidad ingresada es mayor que el stock", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                decimal tot = Convert.ToDecimal(txtPrecio.Text) * Convert.ToDecimal(txtCantidad.Text);

                DataRow row = VentaDetails.NewRow();
                //row["id"] = Convert.ToInt32(dgvDetalles.Rows[dgvDetalles.CurrentRow.Index].Cells["id"].Value.ToString());
                row["Cantidad"] = txtCantidad.Text;
                row["Producto"] = txtProductoBuscar.Text;
                row["precioUnitario"] = txtPrecio.Text;
                row["Total"] = tot;
                VentaDetails.Rows.Add(row);
                lblTotal.Text = total().ToString();

                Producto producto = new Producto();
                var xd = dgvLista.Rows[dgvLista.CurrentRow.Index];
                producto.saldo = (Convert.ToInt32(xd.Cells["saldo"].Value)) - (Convert.ToInt32(txtCantidad.Text));
                ProductoCln.actualizarSaldo(producto);
                ListarProducto();
            }
            
        }
    }
}
