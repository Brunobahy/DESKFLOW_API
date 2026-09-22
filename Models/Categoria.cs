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
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(150)]
        [Column("nomeCategoria", TypeName = "varchar(150)")]
        public string Nome { get; set; }

        public void Atualizar(Categoria categoriaAtualizada)
        {
            Nome = categoriaAtualizada.Nome;
        }
    }
}