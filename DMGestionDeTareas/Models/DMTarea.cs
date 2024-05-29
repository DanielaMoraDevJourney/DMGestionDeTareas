using System.ComponentModel.DataAnnotations;

namespace DMGestionDeTareas.Models
{
    public class DMTarea
    {
        public int DMTareaId { get; set; }

        [Required]
        public string DMTitulo { get; set; }
        public string DMDescripcion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DMFechaVencimiento { get; set; }

        [Required]
        public int DMPrioridadId { get; set; }
        public DMPrioridad DMPrioridad { get; set; }
        public ICollection<DMPrioridad> DMPrioridades { get; set; }

        [Required]
        public int DMCategoriaId { get; set; }
        public DMCategoria DMCategoria { get; set; }
        public ICollection<DMCategoria> DMCategorias { get; set; }


    }

}

