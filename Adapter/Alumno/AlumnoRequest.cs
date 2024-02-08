using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Alumno
{
    public class AlumnoRequest 
    {
        public int IdPersona { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre { get; set; }
    }
}
