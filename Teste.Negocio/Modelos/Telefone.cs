using VipValidator.Notifications;
using VipValidator.Validations;

namespace Teste.Negocio
{
    public  class Telefone : Notifiable
    {
        protected Telefone()
        {
        }
        public Telefone(string dd, string fone)
        {
            this.DD = dd;
            this.NumeroFone = fone;
            Validar();
        }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(DD?.ToString(),2,"Cliente.Telefone","o Campo DD nao pode ter mais que 2 caracteres")
                .IsNotNullOrEmpty(DD?.ToString(),"Cliente.Telefone","O campo DD nao pode estar vazio")
                .HasMaxLen(NumeroFone?.ToString(),10,"Cliente.Telefone","O campo NumeroFone nao pode ter mais que 10 caracteres")
                .IsNotNullOrEmpty(NumeroFone?.ToString(),"CLiente.Telefone","O campo NumeroFone nao pode estar vazio"));
        }
        public string DD { get; set; }
        public string NumeroFone { get; set; }
    }
}
