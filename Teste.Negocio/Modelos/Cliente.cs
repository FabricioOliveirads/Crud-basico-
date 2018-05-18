using System;
using System.Collections.Generic;
using VipValidator.Notifications;
using VipValidator.Validations;

namespace Teste.Negocio
{
    public class Cliente : Notifiable
    {
           
        protected Cliente()
        {
        }
        public Cliente(int id, string nome, DateTime nascimento, Endereco endereco, Telefone telefone, string ativo)
        {
            if (endereco == null)
                endereco = new Endereco("", "", "", "", "", "");
            if (telefone == null)
                telefone = new Telefone("", "");
            this.IdCLiente = id;
            this.NomeCliente = nome == null ? "": nome;
            this.DataNascimento = nascimento ;
            this.Endereco = endereco; 
            this.Telefone = telefone;
            this.Ativo = ativo;

            Validar();
         }
        private void Validar()
        {           
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(NomeCliente?.ToString(), "Cliente.NomeCliente", "O campo Nome nao pode estar em branco")
                .HasMaxLen(NomeCliente?.ToString(), 10, "Cliente.NomeCliente", "O campo Nome deve ter no máximo 10 caracteres.")                
                );              
            AddNotifications(Endereco.Notifications);
            AddNotifications(Telefone.Notifications);
        }
        public int IdCLiente { get; private set; }
        public string NomeCliente { get; set; }
        public DateTime? DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public string Ativo { get; set; }      
        public void Inativar()
        {
            Ativo = "Inativo";
        }

        
    }
}
