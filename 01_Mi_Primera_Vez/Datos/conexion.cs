using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _01_Mi_Primera_Vez.Datos
{
    public class conexion
    {
        private readonly string varconexion =
            "Server=(local);database=Asistencias;uid=sa;pwd=123456";

        public SqlConnection obtenerConexion() {
            return new SqlConnection(varconexion);
        }

    }
}
