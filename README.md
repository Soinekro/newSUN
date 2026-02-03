SunExpert 2.0 API

Documentación del proyecto SunExpert 2.0, una suite de microservicios desarrollada con .NET 9 y Clean Architecture.

[Ver Documentación en Postman](https://documenter.getpostman.com/view/47393821/2sBXVo8nuc#df965836-5261-4f3c-8001-ebc71c60b9fe)

---

## 🏛 Arquitectura

El proyecto sigue una estructura de **Microservicios Modulares** con **Clean Architecture** y una librería compartida (`CommonClass`).

### Estructura de Módulos (Ej: `HumanResource`, `Security`)
Cada módulo/microservicio contiene los siguientes proyectos:
- **`[Modulo].API`**: Controladores y configuración de arranque (Program.cs).
- **`[Modulo].Application`**: Casos de uso, servicios, interfaces, DTOs y Mappers.
- **`[Modulo].Domain`**: Entidades del negocio e interfaces de repositorio.
- **`[Modulo].Infrastructure`**: Implementación de base de datos (EF Core), repositorios y migraciones.

### `CommonClass`
Librería transversal que provee:
- **Generic Repository/Service/Controller**: Clases base para estandarizar el CRUD.
- **Querying**: Soporte para paginación, ordenamiento, filtrado y relaciones dinámicas (`ApiQuerySpec`).
- **Wrappers**: `BaseResponse<T>` y `PagedResult<T>` para respuestas uniformes.

---

## 🚀 Generador de Código (Scaffolding)

El proyecto incluye una plantilla personalizada (`sun-crud`) para generar automáticamente todo el código necesario para una nueva entidad (CRUD completo) siguiendo nuestra arquitectura base.

### 1. Instalación de la Plantilla
Para instalar la plantilla en tu entorno local (solo se hace una vez o al actualizar la plantilla):

1. Abre una terminal en la raíz de la solución (`sunExpert2.0`).
2. Ejecuta el siguiente comando:
```
dotnet new s-module Security
```
### 2. Uso: Crear una Nueva Entidad
Para generar un nuevo CRUD (Controller, Service, Repository, DTOs, Mapper, Entity, Interfaces) dentro de un módulo existente:

**Parámetros:**
* `-n` o `--name`: Nombre de la entidad (en singular, PascalCase). Ej: `Vacation`.
* `-m` o `--ModuleName` (Opcional, defecto: `HumanResource`): Nombre del módulo donde se crearán los archivos. Ej: `Security`.

### Ejemplos

**Crear una entidad `Attendance` en el módulo `HumanResource`:**
*(Esto creará `AttendanceController`, `AttendanceService`, `AttendanceRepository`, etc., en las carpetas correspondientes de los proyectos `HumanResource.*`)*.

**Crear una entidad `Role` en el módulo `Security`:**
```
dotnet new sun-crud -E Role --ModuleName Security
```
---

## 🛠 Desarrollo

### BaseController y Endpoints Estándar
Todos los controladores generados heredan de `BaseController` y automáticamente exponen:

* `GET /api/[Entity]?page=1&perPage=10&sort=-id&relations=x` (Listado paginado)
* `GET /api/[Entity]/{id}` (Obtener por ID)
* `POST /api/[Entity]` (Crear)
* `PUT /api/[Entity]/{id}` (Actualizar)
* `DELETE /api/[Entity]/{id}` (Soft Delete)

### Filtrado y Relaciones Dinámicas
Los endpoints `GET` soportan parámetros avanzados:
* **Paginación**: `?page=1&perPage=20`
* **Relaciones**: `?relations=contracts,employee` (Carga relaciones definidas en la "lista blanca" del repositorio).
* **Ordenamiento**: `?sort=name,-createdDate` (`-` para descendente).
* **Filtros**: `?filter[name]=juan` (Según soporte del repositorio).
