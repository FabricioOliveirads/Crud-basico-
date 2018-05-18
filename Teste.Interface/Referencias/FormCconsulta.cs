using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste.Data;
using Teste.Negocio;

namespace Teste.Interface
{
    public partial class FormCconsulta : Form
    {
        public FormCconsulta()
        {
            InitializeComponent();

            AtualizarGrid();
        }

        

        

        private void AtualizarGrid()
        {
            var repositorio = new ClienteRepositorio();
            var clientes = repositorio.ObterClientes();




            dataGridView1.DataSource = clientes.Select(p => new { p.IdCLiente, p.NomeCliente, p.DataNascimento, p.Endereco.Logradouro, p.Endereco.Numero, p.Endereco.Bairro, p.Endereco.Cidade, p.Endereco.UF, p.Endereco.CEP, p.Telefone.DD, p.Telefone.NumeroFone }).ToList();
            dataGridView1.Refresh();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {

            var repositorio = new ClienteRepositorio();
            var clientes = repositorio.ObterClientes().Where(x=> x.NomeCliente.Contains(TxtNome.Text)).ToList();

           

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();
         }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var repositorio = new ClienteRepositorio();
            var valor = (dataGridView1.CurrentRow.Cells[0].Value);
            
            var cliente = repositorio.ObterCliente(Convert.ToInt32(valor));
            

            var form = new FormCliente();
            this.Close();
            form.Show();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
       
    }
}     


           
            
