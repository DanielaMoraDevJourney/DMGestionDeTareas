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
        public DMPrioridad DMPrioridadTarea { get; set; }

        [Required]
        public int DMCategoriaId { get; set; }
        public DMCategoria DMCategoria { get; set; }
    }

    public enum DMPrioridad
    {
        Baja,
        Media,
        Alta,
        MuyAlta,
        Urgente
    }
}

