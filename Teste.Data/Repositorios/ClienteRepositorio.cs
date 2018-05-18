using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Teste.Data;

namespace Teste.Negocio
{
    public class ClienteRepositorio
    {
        public bool SalvarCliente(Cliente cliente)
        {
            try
            {
                using (var contexto = new TesteContext())
                {
                    contexto.Clientes.Add(cliente);
                   
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public IEnumerable<Cliente> ObterClientes()
        {
            using (var contexto = new TesteContext())
            {
                return contexto.Clientes.Where(x=> x.Ativo.Equals("Ativo")).ToList(); 
            }
        }
        public Cliente ObterCliente(int id)
        {
            using (var contexto = new TesteContext())
            {              
                return contexto.Clientes.First(x => x.IdCLiente == id);
            }    
                }
        public bool EditarCliente(Cliente cliente)
        {
            try
            {
                using (var contexto = new TesteContext())
                {
                    contexto.Entry(cliente).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
