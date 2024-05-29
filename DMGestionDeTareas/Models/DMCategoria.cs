using System.ComponentModel.DataAnnotations;

namespace DMGestionDeTareas.Models
{
    public class DMCategoria
    {
        public int DMCategoriaId { get; set; }

        [Required]
        public string DMNombre { get; set; }
        public string DMDescripcion { get; set; }
        //public ICollection<DMTarea> DMTareas { get; set; }
    }
}
