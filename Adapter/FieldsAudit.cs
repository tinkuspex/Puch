using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FieldsAudit
    {
        public int? UsuarioCreacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime? FechaUsuarioCreacion { get; set; }
        public DateTime? FechaUsuarioModificacion { get; set; }
    }
}
