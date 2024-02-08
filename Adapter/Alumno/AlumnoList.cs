namespace Adapter.Alumno
{
    public class AlumnoList:FieldsAudit
    {
        public int IdPersona { get; set; }
        public string? NumeroDocumento { get; set; }
        public int TipoDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public int Estado { get; set; }
    }
}
