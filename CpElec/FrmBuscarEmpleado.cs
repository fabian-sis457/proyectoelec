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
    public partial class FrmBuscarEmpleado : Form
    {
        public FrmBuscarEmpleado()
        {
            InitializeComponent();
        }

        public Empleado EmpleadoSeleccionado { get; set; }
      //  public Empleado NombreSeleccionado { get; set; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var lista = EmpleadoCln.listar(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            if (lista.Count > 0)
            {
                dgvLista.Columns["cedulaIdentidad"].Selected = true;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count == 1) // si selecciona un fila
            {
                Int32 id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value); //asignamos el numero de id
               // Int32 paterno = Convert.ToInt32(dgvLista.CurrentRow.Cells[3].Value); //asignamos el numero de id
                EmpleadoSeleccionado = EmpleadoCln.get(id);//llenamos el empleado seleccionado
               // NombreSeleccionado = EmpleadoCln.get(paterno);//llenamos el empleado seleccionado
                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no ha seleccionado ningún Empleado");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
