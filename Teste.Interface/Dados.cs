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


namespace Teste.Interface
{
    public partial class Dados : Form
    {
        public Dados()
        {
            InitializeComponent();
        }

        private void Dados_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns.Add("colIDCLiente", "IDCliente");
            dataGridView1.Columns.Add("colNome", "Nome");
            dataGridView1.Columns.Add("colDD", "DD");
            dataGridView1.Columns.Add("colTelefone", "Telefone");
            dataGridView1.Columns.Add("colLogradouro", "Logradouro");
            dataGridView1.Columns.Add("colBairro", "Bairro");
            dataGridView1.Columns.Add("colCidade", "Cidade");
            dataGridView1.Columns.Add("colNumero", "Numero");
            dataGridView1.Columns.Add("colUF", "UF");
            dataGridView1.Columns.Add("colCEP", "CEP");

            var contexto = new TesteContext();
            var lista = from Clientes in contexto.Clientes select Clientes;
           

            


        }
    }
}
