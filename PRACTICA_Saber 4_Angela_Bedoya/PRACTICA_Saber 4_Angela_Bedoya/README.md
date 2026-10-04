# Sistema de Facturación – Desarrollo por capas (Saber 4 – Segunda entrega)

Aplicación de escritorio Windows Forms (.NET Framework 4.7.2) con acceso a SQL Server `DBFACTURAS`.

## Arquitectura (3 capas)
| Proyecto | Responsabilidad |
|---|---|
| `Capa_AccesoDatos` | Única clase que habla con SQL Server (`Cls_Acceso_Datos`). |
| `Capa_LogicaDeNegocios` | Reglas de negocio y CRUD: `Cls_Empleados`, `Cls_Seguridad`, `Cls_Clientes`, `Cls_Productos`, `Validar_usuario`. |
| `Pantallas_Sistema_facturacion` | Formularios (solo capturan y muestran datos). |

## Formularios
- **Primera entrega:** `frmLogin`, `frmListaEmpleados` + `frmEmpleados`, `frmSeguridad`, `frmMenuPrincipal`.
- **Segunda entrega:** `frmListaClientes` + `frmClientes`, `frmListaProductos` + `frmProductos`.

Cada CRUD = un formulario de **lista** (Nuevo, Buscar, Salir y botones EDITAR/BORRAR en el grid) y un formulario de **edición** (validación con `ErrorProvider`).

## Cómo ejecutar
1. Restaurar la base con `Script_DBFACTURAS_v2.sql` en SQL Server.
2. Ajustar `Data Source` en `Pantallas_Sistema_facturacion/App.config` (`cnFacturas`).
3. (Opcional) Ejecutar `Scripts_SQL/01_...sql` y `Scripts_SQL/02_...sql` para verificar procedimientos.
4. Abrir `Proyecto_Facturacion_Capas.sln` en Visual Studio y ejecutar.

## Subir a GitHub
```bash
cd "PRACTICA_Saber 4_Angela_Bedoya"
git init
git add .
git commit -m "Saber 4 - Segunda entrega: CRUD Clientes y Productos por capas"
git branch -M main
git remote add origin https://github.com/<su_usuario>/<su_repositorio>.git
git push -u origin main
```
