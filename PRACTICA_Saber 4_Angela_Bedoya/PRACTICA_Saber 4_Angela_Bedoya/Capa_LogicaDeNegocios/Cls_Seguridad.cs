using System;
using System.Collections.Generic;
using System.Data;
using Capa_AccesoDatos;

namespace Capa_LogicaDeNegocios
{
    /// <summary>
    /// CAPA DE LOGICA DE NEGOCIOS - Seguridad.
    /// FUNCIONALIDAD: Administra el usuario y la clave con que cada empleado
    /// entra al sistema (tabla TBLSEGURIDAD).
    /// </summary>
    public class Cls_Seguridad
    {
        // DEFINIMOS LOS ATRIBUTOS DE LA CLASE
        public int C_IdEmpleado { get; set; }
        public string C_StrUsuario { get; set; }
        public string C_StrClave { get; set; }
        public string C_StrUsuarioModifico { get; set; }

        Cls_Acceso_Datos AccesoDatos = new Cls_Acceso_Datos();

        // Consultamos los empleados para mostrarlos en el combo
        public DataTable ConsultarEmpleados()
        {
            return AccesoDatos.EjecutarConsulta("SELECT IdEmpleado, strNombre FROM TBLEMPLEADO ORDER BY strNombre");
        }

        // Lista de empleados con su usuario asignado (para la tabla de abajo)
        public DataTable ConsultarUsuariosAsignados()
        {
            return AccesoDatos.EjecutarConsulta(
                @"SELECT e.strNombre AS EMPLEADO, ISNULL(s.StrUsuario, '(sin usuario)') AS USUARIO
                  FROM TBLEMPLEADO e
                  LEFT JOIN TBLSEGURIDAD s ON e.IdEmpleado = s.IdEmpleado
                  ORDER BY e.strNombre");
        }

        // Consultamos el usuario y la clave que tiene asignados un empleado
        public DataTable Consulta_SeguridadEmpleado(int IdEmpleado)
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@IdEmpleado", IdEmpleado));
            return AccesoDatos.EjecutarConsulta(
                "SELECT StrUsuario, StrClave FROM TBLSEGURIDAD WHERE IdEmpleado = @IdEmpleado", lst);
        }

        // REGLA DE NEGOCIO: un nombre de usuario no puede repetirse entre empleados
        public bool ExisteUsuario()
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@Usuario", C_StrUsuario));
            lst.Add(new Cls_parametros("@IdEmpleado", C_IdEmpleado));
            DataTable dt = AccesoDatos.EjecutarConsulta(
                "SELECT COUNT(*) FROM TBLSEGURIDAD WHERE StrUsuario = @Usuario AND IdEmpleado <> @IdEmpleado", lst);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Eliminamos la informacion de seguridad de un empleado
        public string EliminarSeguridadEmpleado()
        {
            string mensaje = "";
            try
            {
                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdEmpleado", C_IdEmpleado));
                mensaje = AccesoDatos.Ejecutar_procedimiento("Eliminar_Seguridad", lst);
            }
            catch (Exception ex)
            {
                mensaje = "FALLO EL BORRADO EN SEGURIDAD. " + ex.Message;
            }
            return mensaje;
        }

        // Ingresamos o actualizamos el usuario y la clave de un empleado
        public string ActualizarSeguridadEmpleado()
        {
            string mensaje = "";
            try
            {
                if (ExisteUsuario())
                    return "Ese nombre de usuario ya lo tiene otro empleado";

                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdEmpleado", C_IdEmpleado));
                lst.Add(new Cls_parametros("@StrUsuario", C_StrUsuario));
                lst.Add(new Cls_parametros("@StrClave", C_StrClave));
                lst.Add(new Cls_parametros("@DtmFechaModifica", DateTime.Now));
                lst.Add(new Cls_parametros("@StrUsuarioModifico", C_StrUsuarioModifico));

                mensaje = AccesoDatos.Ejecutar_procedimiento("actualizar_Seguridad", lst);
            }
            catch (Exception ex)
            {
                mensaje = "FALLO LA ACTUALIZACION DE SEGURIDAD. " + ex.Message;
            }
            return mensaje;
        }
    }
}
