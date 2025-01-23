using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Mi_Primera_Vez.Datos
{
    internal class dto_usuarios
    {
        public int idUsuario { get; set; }  // Identificador único del usuario
        public string Cedula { get; set; }  // Cédula del usuario
        public string Nombres { get; set; } // Nombres del usuario
        public string Direccion { get; set; } // Dirección del usuario
        public string Telefono { get; set; }  // Teléfono del usuario
        public int idPais { get; set; }     // Identificador del país asociado al usuario
    }
}
