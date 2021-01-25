using System.Collections.Generic;

namespace WebDiabloMvc.Models
{
    public class PersonajeViewModel
    {
        public IEnumerable<Personaje> Personajes { get; set; }
        public MyFiltersPersonaje Filtro { get; set; }
        public IEnumerable<string> DropClases { get; set; }

    }
}