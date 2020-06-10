using System;
namespace Data.Driven.Design.Application.Entities
{
    public class Entity
    {
        //[Key]
        public int Id { get; set; }

        //[Column("dta_cadastro")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataCadastro { get; set; }

        //[Column("hor_cadastro")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan HoraCadastro { get; set; }

        //[Column("cod_usuario")]
        public int CodigoUsuario { get; set; }
    }
}
