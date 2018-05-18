using VipValidator.Notifications;
using VipValidator.Validations;

namespace Teste.Negocio
{
    public  class Endereco : Notifiable
    {
        protected Endereco()
        {

        }
        public Endereco(string rua, string numero, string bairro, string cidade, string cep, string uf)
        {
            this.Logradouro = rua;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.CEP = cep;
            this.UF = uf;

            Validar();

        } 

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(Logradouro?.ToString(), 15, "Endereco.Logradouro", "Campo Logradouro deve conter no maximo 15 caracteres")
                .IsNotNullOrEmpty(Logradouro?.ToString(),"Endereco.Logradouro","Campo logradouro nao pode estar vazio")
                .HasMaxLen(Numero?.ToString(), 6, "Endereco.Numero", "Campo Numero deve conter no maximo 6 caracteres")
                .IsNotNullOrEmpty(Numero?.ToString(), "Endereco.Numero", "Campo Numero nao pode estar vazio")
                .HasMaxLen(Bairro?.ToString(), 10, "Endereco.Bairro", "Campo Bairro deve conter no maximo 10 caracteres")
                .IsNotNullOrEmpty(Bairro?.ToString(), "Endereco.Bairro", "Campo Bairro nao pode estar vazio")
                .HasMaxLen(Cidade?.ToString(), 10, "Endereco.Cidade", "Campo Cidade deve conter no maximo 10 caracteres")
                .IsNotNullOrEmpty(Cidade?.ToString(), "Endereco.Cidade", "Campo Cidade nao pode estar vazio")
                .HasMaxLen(CEP?.ToString(), 8, "Endereco.CEP", "Campo CEP deve conter no maximo 8 caracteres")
                .IsNotNullOrEmpty(CEP?.ToString(), "Endereco.CEP", "Campo CEP nao pode estar vazio")
                .HasMaxLen(UF?.ToString(), 2, "Endereco.UF", "Campo UF deve conter no maximo 2 caracteres")
                .IsNotNullOrEmpty(UF?.ToString(), "Endereco.UF", "Campo UF nao pode estar vazio")
                );
        }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
    }
}
