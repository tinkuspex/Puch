using Adapter.Alumno;


namespace Business
{
    public interface IAlumnoBusiness
    {
        Task<List<AlumnoList>> GetListaAlumnosAsync(AlumnoRequest request);
        Task<AlumnoList> SaveAlumnoAsync(AlumnoList request);
    }
}
