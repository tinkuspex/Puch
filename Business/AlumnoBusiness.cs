using AccessUtilities;
using Adapter.Alumno;
using Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions;
using Microsoft.Extensions.Options;
using System.Data;

namespace Business
{
    public class AlumnoBusiness: IAlumnoBusiness
    {
        #region Variables
        private readonly ConexionDB.SqlServer _sqlServer;
        private readonly Configuration.Polly _polly;
        private readonly Configuration.ConnectionString _conn;

        #endregion

        #region Builder

        public AlumnoBusiness( IOptions<Configuration.Polly> polly, IOptions<Configuration.ConnectionString> conn)
        {
            _polly = polly.Value;
            _conn = conn.Value;
            _sqlServer = new ConexionDB.SqlServer(_conn.Con);
        }

        #endregion
        #region Methods 
        public async Task<List<AlumnoList>> GetListaAlumnosAsync(AlumnoRequest request)
        {
            //string strSql = "spGSIL_Anular_OC";
            //List<SqlParameter> arParams = new List<SqlParameter>();
            //arParams.Add(new SqlParameter("@IdPersona", request.IdPersona));
            //arParams.Add(new SqlParameter("@NumeroDocumento", request.NumeroDocumento));
            //arParams.Add(new SqlParameter("@Nombre", request.Nombre));

            //DataSet ds = SqlHelper.ExecuteDataset(_conn.Con, CommandType.StoredProcedure, strSql, arParams.ToArray());

            //List<AlumnoList> response = new List<AlumnoList>();
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    AlumnoList obj = new AlumnoList();
            //    obj.IdPersona = Convert.ToInt32(row["IdPersona"].ToString());
            //    obj.NumeroDocumento =row["Op"].ToString();
            //    obj.TipoDocumento = Convert.ToInt32(row["TipoDocumento"].ToString());
            //    obj.Nombres = row["Nombres"].ToString();
            //    obj.ApellidoPaterno = row["ApellidoPaterno"].ToString();
            //    obj.ApellidoMaterno = row["ApellidoMaterno"].ToString();
            //    obj.Telefono = row["Telefono"].ToString();
            //    obj.Correo = row["Correo"].ToString();
            //    obj.Direccion = row["Direccion"].ToString();
            //    obj.Estado = Convert.ToInt32(row["Estado"].ToString());
            //}

            List<Parameter> parameters = new List<Parameter>() {
                new Parameter() { key = "@IdPersona", value = request.IdPersona},
                new Parameter() { key = "@NumeroDocumento", value = request.NumeroDocumento},
                new Parameter() { key = "@Nombre", value = request.Nombre},

            };
            var response = await _sqlServer.TransaccionAsync<AlumnoList>("[dbo].[sp_Listar_Alumnos]", parameters).
            ExecuteAsync(_polly.Intent, _polly.Delay);
            return response.ToList();
        }
        public async Task<AlumnoList> SaveAlumnoAsync(AlumnoList request)
        {
            List<Parameter> parameters = new List<Parameter>() {
                new Parameter() { key = "IdPersona", value = request.IdPersona},
                new Parameter() { key = "NumeroDocumento", value = request.NumeroDocumento},
                new Parameter() { key = "TipoDocumento", value = request.TipoDocumento},
                new Parameter() { key = "Nombres", value = request.Nombres},
                new Parameter() { key = "ApellidoPaterno", value = request.ApellidoPaterno},
                new Parameter() { key = "ApellidoMaterno", value = request.ApellidoMaterno},
                new Parameter() { key = "Telefono", value = request.Telefono},
                new Parameter() { key = "Correo", value = request.Correo},
                new Parameter() { key = "Direccion", value = request.Direccion},
                new Parameter() { key = "Estado", value = request.Estado},
                new Parameter() { key = "Usuario", value = request.UsuarioCreacion},
            };

            var response = await _sqlServer.TransaccionAsync<AlumnoList>("[dbo].[sp_Ingresar_Alumno]", parameters).
               ExecuteAsync(_polly.Intent, _polly.Delay);

            return response.FirstOrDefault();
        }
        #endregion
    }
}
