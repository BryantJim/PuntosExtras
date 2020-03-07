using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PuntosExtras.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonasId { get; set; }
        public String Nombres { get; set; }

        public Personas()
        {
            PersonasId = 0;
            Nombres = string.Empty;
        }
    }
}
