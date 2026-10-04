using System;
using System.Collections.Generic;
using System.Data;
using Capa_AccesoDatos;

namespace Capa_LogicaDeNegocios
{
    /// <summary>
    /// CAPA DE LOGICA DE NEGOCIOS - Validacion de usuario.
    /// FUNCIONALIDAD: Verifica si el usuario y la clave existen en TBLSEGURIDAD.
    /// Si los encuentra deja en C_IdEmpleado el Id del empleado; si no, queda en 0.
    /// </summary>
    public class Validar_usuario
    {
        // DEFINIMOS LOS ATRIBUTOS DE LA CLASE
        public string C_StrUsuario { get; set; }
        public string C_StrClave { get; set; }
        public Int32 C_IdEmpleado { get; set; }
        public string C_StrNombreEmpleado { get; set; }
        public string C_StrRol { get; set; }

        // Metodo que valida el usuario: consulta en la BD el usuario y la clave
        public void ValidarUsuario()
        {
            C_IdEmpleado = 0;

            string sentencia = @"SELECT s.IdEmpleado, e.strNombre, r.StrDescripcion
                                 FROM TBLSEGURIDAD s
                                 INNER JOIN TBLEMPLEADO e ON s.IdEmpleado = e.IdEmpleado
                                 LEFT JOIN TBLROLES r ON e.IdRolEmpleado = r.IdRolEmpleado
                                 WHERE s.StrUsuario = @Usuario AND s.StrClave = @Clave";

            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@Usuario", C_StrUsuario));
            lst.Add(new Cls_parametros("@Clave", C_StrClave));

            Cls_Acceso_Datos Acceso = new Cls_Acceso_Datos(); // objeto de la capa de acceso a datos
            DataTable dt = Acceso.EjecutarConsulta(sentencia, lst);

            foreach (DataRow row in dt.Rows)
            {
                C_IdEmpleado = int.Parse(row[0].ToString());   // Id del empleado encontrado
                C_StrNombreEmpleado = row[1].ToString().Trim();
                C_StrRol = row[2].ToString().Trim();
            }
        }
    }
}
