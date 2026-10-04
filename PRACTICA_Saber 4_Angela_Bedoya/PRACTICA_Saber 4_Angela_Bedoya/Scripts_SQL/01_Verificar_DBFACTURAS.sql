/* =====================================================================
   PRACTICA SABER 4 - MULTICAPAS  |  Script de verificacion
   Ejecutelo en SQL Server Management Studio (boton "Ejecutar" o F5).
   No borra ni cambia datos: solo revisa y, si falta, crea Eliminar_Seguridad.
   ===================================================================== */
USE DBFACTURAS;
GO

/* 1. Procedimientos que usa el programa. Deben salir 4 filas. */
SELECT name AS procedimiento_encontrado
FROM sys.procedures
WHERE name IN ('actualizar_Empleado', 'Eliminar_Empleado',
               'actualizar_Seguridad', 'Eliminar_Seguridad');
GO

/* 2. Si no existe Eliminar_Seguridad, lo creamos (borra el usuario de un empleado). */
IF OBJECT_ID('dbo.Eliminar_Seguridad', 'P') IS NULL
BEGIN
    EXEC('CREATE PROCEDURE dbo.Eliminar_Seguridad
              @IdEmpleado INT
          AS
          BEGIN
              DELETE FROM TBLSEGURIDAD WHERE IdEmpleado = @IdEmpleado;
          END');
    PRINT 'Se creo el procedimiento Eliminar_Seguridad';
END
ELSE
    PRINT 'Eliminar_Seguridad ya existia, no se toco';
GO

/* 3. Usuarios con los que puede entrar al sistema (para el video). */
SELECT e.IdEmpleado, e.strNombre AS Empleado, s.StrUsuario AS Usuario, s.StrClave AS Clave
FROM TBLSEGURIDAD s
INNER JOIN TBLEMPLEADO e ON s.IdEmpleado = e.IdEmpleado;
GO

/* 4. Roles disponibles (llenan el combo de frmEmpleados). */
SELECT IdRolEmpleado, StrDescripcion FROM TBLROLES;
GO
