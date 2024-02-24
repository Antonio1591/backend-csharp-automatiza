using ApiProduto.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Infrastructure.Data.Mapping
{
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.Property(M => M.Id).HasColumnType("int").IsRequired().IsUnicode();
            builder.HasKey(M => M.Id);
            builder.Property(M => M.Descriscao)
                                               .IsRequired()
                                               .HasMaxLength(100);
            builder.Property(P => P.Status)
                 .IsRequired();
        }
    }
}
