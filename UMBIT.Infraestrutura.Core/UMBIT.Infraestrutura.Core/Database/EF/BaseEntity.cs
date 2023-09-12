using System;

namespace UMBIT.Infraestrutura.Core.Database.EF
{
    public abstract class CoreBaseEntity
    {
        public Guid Id { get; set; } 
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get;set; }
    }
}
