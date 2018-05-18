using System.Data.Entity.ModelConfiguration;
using Teste.Negocio;

namespace Teste.Data.Mappings
{
    class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        //Configurar o mapeamento das classes controla o que cria 
        public ClienteMap()
        {
            ToTable("Cliente");
            HasKey(x => x.IdCLiente);
            Property(x => x.NomeCliente)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.Telefone.DD)
                .HasColumnName("DD")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(x => x.Telefone.NumeroFone)
                .HasColumnName("Fone")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.Endereco.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.Endereco.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.Endereco.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.Endereco.Numero)
                .HasColumnName("Numero")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(x => x.Endereco.UF)
                .HasColumnName("UF")
                .HasColumnType("varchar")
                .HasMaxLength(2);

            Property(x => x.Endereco.CEP)
                .HasColumnName("CEP")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.DataNascimento)
                .HasColumnName("Nascimento")
                .HasColumnType("DATE");

            Property(x => x.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("varchar")
                .HasMaxLength(10);            
        }
    }
}
