using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste.Negocio;
using Teste.Data;

namespace Teste.Interface
{
    public partial class Referencia : Form
    {
        public Referencia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var teste = new ClienteRepositorio();
            

            var cliente = new Cliente(0, txtNome.Text, DateTime.Now, null, null,null);



            if (!teste.SalvarCliente(cliente))
            { 
                MessageBox.Show("Não Salvou");
                return;
            }

            MessageBox.Show("Salvou");
         }

        private void button2_Click(object sender, EventArgs e)
        {
            var repositorio = new ClienteRepositorio();
            var clientes = repositorio.ObterClientes();

            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();
        }
    }
}
