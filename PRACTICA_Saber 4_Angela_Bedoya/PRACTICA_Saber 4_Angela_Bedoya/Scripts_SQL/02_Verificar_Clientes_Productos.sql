/* =====================================================================
   PRACTICA SABER 4 - MULTICAPAS  |  Verificacion SEGUNDA ENTREGA
   (CRUD Clientes y CRUD Productos). Solo consulta, no modifica datos.
   ===================================================================== */
USE DBFACTURAS;
GO

/* 1. Procedimientos que usan Clientes y Productos. Deben salir 4 filas. */
SELECT name AS procedimiento_encontrado
FROM sys.procedures
WHERE name IN ('actualizar_Cliente', 'Eliminar_Cliente',
               'actualizar_Producto', 'Eliminar_Producto');
GO

/* 2. Categorias que llenan el combo de frmProductos (debe haber al menos una). */
SELECT IdCategoria, StrDescripcion FROM TBLCATEGORIA_PROD;
GO

/* 3. Datos actuales. */
SELECT COUNT(*) AS Clientes FROM TBLCLIENTES;
SELECT COUNT(*) AS Productos FROM TBLPRODUCTO;
GO
