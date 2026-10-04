using System;
using System.Collections.Generic;
using System.Data;
using Capa_AccesoDatos;

namespace Capa_LogicaDeNegocios
{
    /// <summary>
    /// CAPA DE LOGICA DE NEGOCIOS - Productos.
    /// FUNCIONALIDAD: Todas las operaciones del CRUD de productos (tabla TBLPRODUCTO):
    /// consultar todos, consultar uno, filtrar, consultar categorias, guardar y eliminar.
    /// </summary>
    public class Cls_Productos
    {
        // DEFINIMOS LOS ATRIBUTOS DE LA CLASE (uno por cada campo de la tabla)
        public int C_IdProducto { get; set; }
        public string C_StrNombre { get; set; }
        public string C_StrCodigo { get; set; }
        public double C_NumPrecioCompra { get; set; }
        public double C_NumPrecioVenta { get; set; }
        public int C_IdCategoria { get; set; }
        public string C_StrDetalle { get; set; }
        public string C_StrFoto { get; set; }
        public int C_NumStock { get; set; }
        public string C_StrUsuarioModifica { get; set; }

        Cls_Acceso_Datos AccesoDatos = new Cls_Acceso_Datos();

        // Columnas que se consultan (siempre en este mismo orden)
        private const string CAMPOS = @"SELECT p.IdProducto, p.StrNombre, p.StrCodigo, p.NumPrecioCompra,
                                               p.NumPrecioVenta, p.IdCategoria, p.StrDetalle, p.strFoto,
                                               p.NumStock, c.StrDescripcion AS Categoria
                                        FROM TBLPRODUCTO p
                                        LEFT JOIN TBLCATEGORIA_PROD c ON p.IdCategoria = c.IdCategoria ";

        // ===== Consultamos todos los productos =====
        public DataTable Consulta_Producto()
        {
            return AccesoDatos.EjecutarConsulta(CAMPOS + "ORDER BY p.StrNombre");
        }

        // ===== Sobrecarga: consultamos UN producto por su Id =====
        public DataTable Consulta_Producto(int IdProducto)
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@IdProducto", IdProducto));
            return AccesoDatos.EjecutarConsulta(CAMPOS + "WHERE p.IdProducto = @IdProducto", lst);
        }

        // ===== Filtramos por nombre o codigo =====
        public DataTable Filtrar_Producto(string filtro)
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@Filtro", "%" + filtro + "%"));
            return AccesoDatos.EjecutarConsulta(CAMPOS +
                "WHERE p.StrNombre LIKE @Filtro OR p.StrCodigo LIKE @Filtro ORDER BY p.StrNombre", lst);
        }

        // ===== Consultamos las categorias para llenar el combo =====
        public DataTable ConsultarCategoria()
        {
            return AccesoDatos.EjecutarConsulta(
                "SELECT IdCategoria, StrDescripcion FROM TBLCATEGORIA_PROD ORDER BY StrDescripcion");
        }

        // ===== REGLA DE NEGOCIO: no puede haber dos productos con el mismo codigo =====
        public bool ExisteCodigo()
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@Codigo", C_StrCodigo));
            lst.Add(new Cls_parametros("@IdProducto", C_IdProducto));
            DataTable dt = AccesoDatos.EjecutarConsulta(
                "SELECT COUNT(*) FROM TBLPRODUCTO WHERE StrCodigo = @Codigo AND IdProducto <> @IdProducto", lst);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // ===== REGLA DE NEGOCIO: un producto que ya se facturo no se puede borrar =====
        public int ContarFacturados()
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@IdProducto", C_IdProducto));
            DataTable dt = AccesoDatos.EjecutarConsulta(
                "SELECT COUNT(*) FROM TBLDETALLE_FACTURA WHERE IdProducto = @IdProducto", lst);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        // ===== Eliminamos un producto (procedimiento Eliminar_Producto) =====
        public string EliminaProducto()
        {
            string mensaje = "";
            try
            {
                int usos = ContarFacturados();
                if (usos > 0)
                    return "No se puede borrar el producto porque aparece en " + usos + " detalle(s) de factura";

                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdProducto", C_IdProducto));
                mensaje = AccesoDatos.Ejecutar_procedimiento("Eliminar_Producto", lst);
            }
            catch (Exception ex)
            {
                mensaje = "FALLO EL BORRADO DEL PRODUCTO. " + ex.Message;
            }
            return mensaje;
        }

        // ===== Insertamos (si IdProducto = 0) o actualizamos un producto =====
        public string ActualizarProducto()
        {
            string mensaje = "";
            try
            {
                // REGLAS DE NEGOCIO
                if (string.IsNullOrWhiteSpace(C_StrNombre))
                    return "Debe ingresar el nombre del producto";
                if (string.IsNullOrWhiteSpace(C_StrCodigo))
                    return "Debe ingresar el codigo del producto";
                if (C_IdCategoria <= 0)
                    return "Debe seleccionar una categoria";
                if (C_NumPrecioCompra < 0 || C_NumPrecioVenta < 0)
                    return "Los precios no pueden ser negativos";
                if (C_NumPrecioVenta < C_NumPrecioCompra)
                    return "El precio de venta no puede ser menor que el precio de compra";
                if (C_NumStock < 0)
                    return "El stock no puede ser negativo";
                if (ExisteCodigo())
                    return "Ya existe otro producto con ese codigo";

                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdProducto", C_IdProducto));
                lst.Add(new Cls_parametros("@StrNombre", C_StrNombre));
                lst.Add(new Cls_parametros("@StrCodigo", C_StrCodigo));
                lst.Add(new Cls_parametros("@NumPrecioCompra", C_NumPrecioCompra));
                lst.Add(new Cls_parametros("@NumPrecioVenta", C_NumPrecioVenta));
                lst.Add(new Cls_parametros("@IdCategoria", C_IdCategoria));
                lst.Add(new Cls_parametros("@StrDetalle", C_StrDetalle));
                lst.Add(new Cls_parametros("@strFoto", string.IsNullOrWhiteSpace(C_StrFoto) ? "ninguna" : C_StrFoto));
                lst.Add(new Cls_parametros("@NumStock", C_NumStock));
                lst.Add(new Cls_parametros("@DtmFechaModifica", DateTime.Now));
                lst.Add(new Cls_parametros("@StrUsuarioModifica", C_StrUsuarioModifica));

                mensaje = AccesoDatos.Ejecutar_procedimiento("actualizar_Producto", lst);
            }
            catch (Exception ex)
            {
                mensaje = "FALLO LA ACTUALIZACION DEL PRODUCTO. " + ex.Message;
            }
            return mensaje;
        }
    }
}
