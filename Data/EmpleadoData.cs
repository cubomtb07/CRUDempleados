using CRUDempleados.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDempleados.Data
{
    public class EmpleadoData
    {
        public List<EmpleadoModel> Listar()
        {

            var oLista = new List<EmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listarempleados", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {
                            EmpleadoID = Convert.ToInt32(dr["EmpleadoID"]),
                            Nombre = dr["Nombre"].ToString(),
                            Celular = dr["Celular"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Cargo = dr["Cargo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public EmpleadoModel Obtener(int EmpleadoID)
        {

            var oEmpleado = new EmpleadoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("obtenerempleado", conexion);
                cmd.Parameters.AddWithValue("@EmpleadoID", EmpleadoID);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEmpleado.EmpleadoID = Convert.ToInt32(dr["EmpleadoID"]);
                        oEmpleado.Nombre = dr["Nombre"].ToString();
                        oEmpleado.Celular = dr["Celular"].ToString();
                        oEmpleado.Correo = dr["Correo"].ToString();
                        oEmpleado.Cargo = dr["Cargo"].ToString();
                        oEmpleado.FechaAlta = Convert.ToDateTime(dr["FechaAlta"]);
                    }
                }

            }
            return oEmpleado;
        }

        public bool Crear(EmpleadoModel oEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("crearempleado", conexion);
                    cmd.Parameters.AddWithValue("@Nombre", oEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("@Celular", oEmpleado.Celular);
                    cmd.Parameters.AddWithValue("@Correo", oEmpleado.Correo);
                    cmd.Parameters.AddWithValue("@Cargo", oEmpleado.Cargo);
                    cmd.Parameters.AddWithValue("@FechaAlta", oEmpleado.FechaAlta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Actualizar(EmpleadoModel oEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("actualizarempleado", conexion);
                    cmd.Parameters.AddWithValue("@EmpleadoID", oEmpleado.EmpleadoID);
                    cmd.Parameters.AddWithValue("@Nombre", oEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("@Celular", oEmpleado.Celular);
                    cmd.Parameters.AddWithValue("@Correo", oEmpleado.Correo);
                    cmd.Parameters.AddWithValue("@Cargo", oEmpleado.Cargo);
                    cmd.Parameters.AddWithValue("@FechaAlta", oEmpleado.FechaAlta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int EmpleadoID)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminarempleado", conexion);
                    cmd.Parameters.AddWithValue("EmpleadoID", EmpleadoID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
