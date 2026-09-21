using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeskFlow.Models
{
    public class Categoria
    {
        [Key]
        [Column("codCategoria", TypeName = "varchar(50)")]
        public int Id { get; set; }
        [MaxLength(150)]
        [Column("nomeCategoria", TypeName = "varchar(150)")]
        public string Nome { get; set; }

    }
}