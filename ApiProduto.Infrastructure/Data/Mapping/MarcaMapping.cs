using ApiProduto.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Infrastructure.Data.Mapping
{
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.Property(M => M.Id).HasColumnType("int").IsRequired().IsUnicode();
            builder.HasKey(M => M.Id);
            builder.Property(M => M.Descricao)
                                               .IsRequired()
                                               .HasMaxLength(100);
            builder.Property(P => P.Status)
                            .HasColumnType("int")
                            .IsRequired(); 
        }
    }
}
