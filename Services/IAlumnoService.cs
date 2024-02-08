using Adapter.Alumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAlumnoService
    {
        Task<List<AlumnoList>> GetListaAlumnosAsync(AlumnoRequest request);
        Task<AlumnoList> SaveAlumnoAsync(AlumnoList request);
    }
}
