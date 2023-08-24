using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UMBIT.Infraestrutura.Core.Database.EF
{
    public abstract class CoreEntityConfigurate<T> : IEntityTypeConfiguration<T> where T : CoreBaseEntity
    {

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey((T be) => be.Id);
            ConfigureEntidade(builder);
            builder.Property((T be) => be.DataCriacao).IsRequired();
            builder.Property((T be) => be.DataAtualizacao).IsRequired();
        }

        
        public abstract void ConfigureEntidade(EntityTypeBuilder<T> builder);
    }
}
