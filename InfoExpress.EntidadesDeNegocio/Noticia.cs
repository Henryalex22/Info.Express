using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoExpress.EntidadesDeNegocio
{
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La Categoria' es obligatorio.")]
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El Titulo' es obligatorio.")]
        [StringLength(255, ErrorMessage = "El campo 'Titulo' debe tener un máximo de 255 caracteres.")]
        public string Titulo { get; set; }

        [StringLength(2000, ErrorMessage = "Contenido debe tener un máximo de 2000 caracteres.")]
        public string Contenido { get; set; }

        [Required(ErrorMessage = "Fecha Publicacion es obligatorio.")]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "La Imagen' es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo 'Imagen' debe tener un máximo de 200 caracteres.")]
        public string Imagen { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Categoria Categoria { get; set; }
    }
}
