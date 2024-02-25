using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ApiProduto.Domain;

namespace ApiProduto.Infrastructure.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
        {
            public void Configure(EntityTypeBuilder<Produto> builder)
            {
                builder.Property(P => P.Id).HasColumnType("int").IsRequired().IsUnicode();
                builder.HasKey(P => P.Id);
                builder.Property(P => P.Descriscao)
                                .IsRequired()
                                .HasMaxLength(300);

                builder.Property(p => p.PrecoVenda)
                                .IsRequired()
                                .HasColumnType("decimal(10,2)");

                builder.Property(P => P.Estoque)
                                 .IsRequired();
                builder.Property(P => P.Status)
                                .HasColumnType("int")
                                .IsRequired();
            }
        }
    }

