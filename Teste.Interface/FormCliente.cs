using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Teste.Negocio;

namespace Teste.Interface
{
    public partial class FormCliente : Form
    {
        Cliente clienteNovo = new Cliente(0,null,DateTime.Now,null,null,"Ativo");
        public FormCliente()
        {
           InitializeComponent();
            label11.Text = "0";
           AtualizarGrid();
        }
        
        private void BtnSalvar_Click(object sender, EventArgs e)
        {            
                var endereco = new Endereco(TxtLogradouro.Text, TxtNumero.Text, TxtBairro.Text, TxtCidade.Text, TxtCep.Text, TxtUF.Text);
                var telefone = new Telefone(TxtDD.Text, TxtTelefone.Text);
                var clienteNovo = new Cliente(Convert.ToInt32(label11.Text), TxtNome.Text, DtaColetor.Value.Date, endereco, telefone, "Ativo");

            if (clienteNovo.Invalid)
            {
                string mensagem = "";
               
                foreach (var notification in clienteNovo.Notifications)
                    mensagem += notification.Message + "\r\n";

                MessageBox.Show(mensagem, "POR FAVOR CORRIJA ESTES ERROS");
                return;
            }

            Atualizar(clienteNovo);  
        }

        private void AtualizarGrid()
        {
            
            
            var repositorio = new ClienteRepositorio();
            var clientes = repositorio.ObterClientes();
            LbContador.Text = (repositorio.ObterClientes().Count().ToString());
            label11.Visible = false;
            label11.Text = "0";
            dataGridView1.DataSource = clientes.Select(p => new { p.IdCLiente, p.NomeCliente, p.DataNascimento, p.Endereco.Logradouro, p.Endereco.Numero, p.Endereco.Bairro, p.Endereco.Cidade, p.Endereco.UF, p.Endereco.CEP, p.Telefone.DD, p.Telefone.NumeroFone }).ToList();

            dataGridView1.Refresh(); 
        }     
        private void Atualizar(Cliente cliente )
        {
            var utilitario = new ClienteRepositorio();
            
            if (cliente.IdCLiente.Equals(0))
            {              
                if (!utilitario.SalvarCliente(cliente))
                {
                    MessageBox.Show("Não Salvou");                   
                }
                MessageBox.Show("Salvou");
                Limpar();
                AtualizarGrid();               
            }
            else
            {
               if (!utilitario.EditarCliente(cliente))
                {
                    MessageBox.Show("Erro ao alterar registro");                   
                }
                else
                {
                    MessageBox.Show("Alterado com sucesso");
                    Limpar();
                    AtualizarGrid();       
                }
            }
        }       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        void Limpar()
        {
            TxtNome.Text = TxtBairro.Text = TxtCep.Text = TxtCidade.Text = TxtDD.Text = TxtLogradouro.Text = TxtNumero.Text = TxtTelefone.Text = TxtUF.Text = "";
            DtaColetor.Value = DateTime.Now;
                       
            label11.Text = "0";
        }
        private void FormCliente_Load(object sender, EventArgs e)
        {
            Limpar();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow.Index != -1)
            {
                

                var repositorio = new ClienteRepositorio();

                clienteNovo = repositorio.ObterClientes().Where(x=> x.IdCLiente.Equals(dataGridView1.CurrentRow.Cells["IdCLiente"].Value)).FirstOrDefault();


                TxtNome.Text = clienteNovo.NomeCliente;
                DtaColetor.Value = clienteNovo.DataNascimento.Value;
                TxtLogradouro.Text = clienteNovo.Endereco.Logradouro;
                TxtNumero.Text = clienteNovo.Endereco.Numero;
                TxtBairro.Text = clienteNovo.Endereco.Bairro;
                TxtCidade.Text = clienteNovo.Endereco.Cidade;
                TxtUF.Text = clienteNovo.Endereco.UF;
                TxtCep.Text = clienteNovo.Endereco.CEP;
                TxtDD.Text = clienteNovo.Telefone.DD;
                TxtTelefone.Text = clienteNovo.Telefone.NumeroFone;
                label11.Visible = false;
                label11.Text = clienteNovo.IdCLiente.ToString();
                

                BtnSalvar.Text = "Atualizar";

                btnDeletar.Enabled = true;

            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            
            var repositorio = new ClienteRepositorio();
            if(MessageBox.Show("Você quer realmente excluir esse registro?"," FormCliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var clienteSelionado = repositorio.ObterCliente(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                
                clienteSelionado.Inativar();
                Atualizar(clienteSelionado);
            }
        }
        
    }
}
