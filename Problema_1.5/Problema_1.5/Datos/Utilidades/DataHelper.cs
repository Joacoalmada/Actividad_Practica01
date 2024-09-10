using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


namespace Problema_1._5.Datos.Utilidades
{
    public class DataHelper
    {
        public static DataHelper _instancia;
        public SqlConnection _Conexion;

        private DataHelper() 
        { 
            _Conexion = new SqlConnection(Properties.Resources.CnnString);
        }
        public static DataHelper GetInstance()
        {
            if (_instancia == null)
                _instancia = new DataHelper();

            return _instancia;
        }

      

        public DataTable EjecutarPA(string sp)
        {
            DataTable tabla = new DataTable();
            try
            {
                _Conexion.Open();
                var comando = new SqlCommand(sp, _Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                tabla.Load(comando.ExecuteReader());
                _Conexion.Close();
            }
            catch (SqlException)
            { 
                tabla = null;
            }
            return tabla;
        }

        public int EjecutarSPDML(string sp, List<ParametrosSQL>? parametros)
        {
            int filas;
            try
            {
                _Conexion.Open();
                var cmd = new SqlCommand(sp, _Conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        cmd.Parameters.AddWithValue(param.Nombre, param.Value);
                    }

                }
                filas = cmd.ExecuteNonQuery();
                _Conexion.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al ejecutar el SP: " + ex.Message);
                filas = 0;
            }
            finally
            {
                if (_Conexion.State == System.Data.ConnectionState.Open)
                {
                    _Conexion.Close();
                }
            }
            return filas;
        }
        public SqlConnection GetConnection()
        {
            return _Conexion;
        }
    }

   
   
}
