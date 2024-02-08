using Adapter.Alumno;
using Business;
namespace Services
{
    public class AlumnoService: IAlumnoService
    {
        #region Variables

        private readonly IAlumnoBusiness _alumnoBusiness;

        #endregion
        #region Builder

        public AlumnoService(IAlumnoBusiness AlumnoBusiness)
        {
            _alumnoBusiness = AlumnoBusiness;
        }

        #endregion

        #region Methods
        public async Task<List<AlumnoList>> GetListaAlumnosAsync(AlumnoRequest request)
        {
            return await _alumnoBusiness.GetListaAlumnosAsync(request);
        }
        public async Task<AlumnoList> SaveAlumnoAsync(AlumnoList request)
        {
            return await _alumnoBusiness.SaveAlumnoAsync(request);
        }
        #endregion
    }
}
