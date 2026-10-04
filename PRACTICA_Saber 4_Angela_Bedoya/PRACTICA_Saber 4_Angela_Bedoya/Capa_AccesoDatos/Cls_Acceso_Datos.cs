using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Capa_AccesoDatos
{
    /// <summary>
    /// FUNCIONALIDAD: Guarda el nombre, el valor y la direccion de un parametro
    /// que se le envia a SQL Server. Es como la "etiqueta" que se le pega a cada
    /// dato antes de mandarlo a la base de datos.
    /// </summary>
    public class Cls_parametros
    {
        // DEFINIMOS LOS ATRIBUTOS DEL PARAMETRO
        public string Nombre { get; set; }                          // Nombre del parametro, ej: @IdEmpleado
        public object Valor { get; set; }                           // Valor del parametro
        public SqlDbType TipoDato { get; set; }                     // Tipo de dato (solo parametros de salida)
        public Int32 Tamaño { get; set; }                           // Longitud (solo parametros de salida)
        public ParameterDirection Direccionparametro { get; set; }  // Input (entra) u Output (sale)

        // CONSTRUCTOR PARAMETROS DE ENTRADA
        public Cls_parametros(string Objnombre, Object ObjValor)
        {
            Nombre = Objnombre;
            Valor = ObjValor;
            Direccionparametro = ParameterDirection.Input;
        }

        // CONSTRUCTOR PARAMETROS DE SALIDA
        public Cls_parametros(string Objnombre, SqlDbType ObjTipoDato, Int32 ObjTamaño)
        {
            Nombre = Objnombre;
            TipoDato = ObjTipoDato;
            Tamaño = ObjTamaño;
            Direccionparametro = ParameterDirection.Output;
        }
    }

    /// <summary>
    /// CAPA DE ACCESO A DATOS.
    /// FUNCIONALIDAD: Es la UNICA clase del sistema que habla con la base de datos DBFACTURAS.
    /// Abre y cierra la conexion, ejecuta consultas (SELECT) y procedimientos almacenados.
    /// </summary>
    public class Cls_Acceso_Datos
    {
        SqlConnection conexion;  // conexion con SQL Server
        SqlDataAdapter da;       // puente entre la BD y el DataTable
        DataTable dt;            // tabla de datos en memoria

        // La cadena de conexion se lee del App.config del proyecto de presentacion
        // (nombre "cnFacturas"). Si no la encuentra usa la de respaldo.
        private string ObtenerCadenaConexion()
        {
            ConnectionStringSettings cfg = ConfigurationManager.ConnectionStrings["cnFacturas"];
            if (cfg != null && !string.IsNullOrWhiteSpace(cfg.ConnectionString))
                return cfg.ConnectionString;
            return @"Data Source=.\SQLEXPRESS;Initial Catalog=DBFACTURAS;Integrated Security=True";
        }

        // Metodo para abrir la base de datos
        public string AbrirBd()
        {
            string resultado = "";
            try
            {
                conexion = new SqlConnection(ObtenerCadenaConexion());
                conexion.Open();
            }
            catch (Exception ex)
            {
                resultado = "ERROR: No se establecio la conexion con la base de datos. " + ex.Message;
            }
            return resultado;
        }

        // Metodo para cerrar la base de datos
        public string CerrarBd()
        {
            string resultado = "";
            try
            {
                if (conexion != null) conexion.Close();
            }
            catch (Exception ex)
            {
                resultado = "ERROR: fallo al cerrar la conexion. " + ex.Message;
            }
            return resultado;
        }

        // Pasa la lista de parametros (lst) al comando
        private void AgregarParametros(SqlCommand comando, List<Cls_parametros> lst)
        {
            if (lst == null) return;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Direccionparametro == ParameterDirection.Input)
                {
                    // si el valor viene vacio (null) se manda como NULL de SQL
                    comando.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor ?? DBNull.Value);
                }
                if (lst[i].Direccionparametro == ParameterDirection.Output)
                {
                    comando.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamaño).Direction = ParameterDirection.Output;
                }
            }
        }

        // EJECUTA UN PROCEDIMIENTO ALMACENADO QUE NO RETORNA DATOS (INSERT, UPDATE, DELETE).
        // Retorna un mensaje indicando si se actualizo o no.
        public string Ejecutar_procedimiento(string procedimiento, List<Cls_parametros> lst)
        {
            string salida = "";
            try
            {
                int retornado;
                string error = AbrirBd();
                if (error != "") return error;

                SqlCommand Comando = new SqlCommand(procedimiento, conexion);
                Comando.CommandType = CommandType.StoredProcedure;
                AgregarParametros(Comando, lst);

                retornado = Comando.ExecuteNonQuery(); // numero de filas afectadas
                CerrarBd();

                if (retornado != 0)   // si el procedimiento usa SET NOCOUNT ON retorna -1
                    salida = "Los datos fueron actualizados";
                else
                    salida = "Los datos no fueron actualizados";
            }
            catch (Exception ex)
            {
                CerrarBd();
                salida = "ERROR: fallo la operacion. " + ex.Message;
            }
            return salida;
        }

        // EJECUTA UNA SENTENCIA SQL DE INSERT, UPDATE O DELETE ESCRITA COMO TEXTO.
        public string EjecutarComando(string sentencia)
        {
            return EjecutarComando(sentencia, null);
        }

        public string EjecutarComando(string sentencia, List<Cls_parametros> lst)
        {
            string salida = "";
            try
            {
                string error = AbrirBd();
                if (error != "") return error;
                SqlCommand cmd = new SqlCommand(sentencia, conexion);
                AgregarParametros(cmd, lst);
                int retornado = cmd.ExecuteNonQuery();
                CerrarBd();
                salida = retornado > 0 ? "Los datos fueron actualizados" : "Los datos no fueron actualizados";
            }
            catch (Exception ex)
            {
                CerrarBd();
                salida = "ERROR: fallo la operacion. " + ex.Message;
            }
            return salida;
        }

        // EJECUTA UNA CONSULTA (SELECT) Y RETORNA LOS REGISTROS EN UN DATATABLE.
        // Ideal para llenar el DataGridView y los ComboBox.
        public DataTable EjecutarConsulta(string sentencia)
        {
            return EjecutarConsulta(sentencia, null);
        }

        // Sobrecarga con parametros: los datos que escribe el usuario viajan
        // como parametros y no pegados al texto del SQL (evita la "inyeccion SQL").
        public DataTable EjecutarConsulta(string sentencia, List<Cls_parametros> lst)
        {
            string error = AbrirBd();
            if (error != "") throw new Exception(error);
            try
            {
                SqlCommand cmd = new SqlCommand(sentencia, conexion);
                AgregarParametros(cmd, lst);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                CerrarBd();
            }
        }
    }
}
