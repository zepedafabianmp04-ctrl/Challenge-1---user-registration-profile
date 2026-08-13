# Challenge-1 - User Registration Profile
## Equipo: David's Friends

A continuación se detalla la asignación de roles y responsabilidades para el desarrollo del módulo de registro y perfil de usuario:

* **David**
  * Configuración de API
* **Fabian**
  * Diseño
  * Documentación
* **Cesar**
  * Diagramas de entidad-relación
  * Conexión de base de datos
* **Jonathan**
  * Base de datos

**Repositorio:**  
Se inicializó el control de versiones y se subió exitosamente la estructura base de los archivos del proyecto (ASP.NET Core) a GitHub.

---

## 📝 Descripción del Proyecto

**Challenge-1 - User Registration Profile** es una solución web full-stack desarrollada en **ASP.NET Core** y **SQLite**. El sistema permite la gestión completa del ciclo de vida de los usuarios mediante una interfaz dinámica e interactiva en el frontend que se comunica con una API RESTful.

### Características Principales
* **Registro de Usuarios:** Validación de campos obligatorios, prevención de correos duplicados y cifrado de contraseñas.
* **Autenticación (Inicio de Sesión):** Verificación de credenciales registradas.
* **Consulta de Usuarios:** Visualización en tiempo real de los usuarios activos guardados en la base de datos.
* **Persistencia Integrada:** Uso de SQLite con creación automática de la base de datos al iniciar el servidor.
* **Documentación Interactiva:** Integración con Swagger UI para pruebas de la API.

---

## 🛠️ Tecnologías Utilizadas

* **Backend:** C# / .NET Core 9.0 (Web API)
* **ORM:** Entity Framework Core
* **Base de Datos:** SQLite (`users.db`)
* **Seguridad:** `Microsoft.AspNetCore.Identity.PasswordHasher`
* **Frontend:** HTML5, CSS3 (Diseño responsivo / Dark Mode) y JavaScript nativo (Fetch API)
* **Herramientas & Documentación:** Swagger / OpenAPI, Git, VS Code

---

## 📡 Endpoints de la API (`/api/Users`)

| Método | Ruta | Descripción | Cuerpo de la Petición (JSON) |
| :--- | :--- | :--- | :--- |
| **GET** | `/api/Users` | Obtiene todos los usuarios activos. | *Ninguno* |
| **GET** | `/api/Users/{id}` | Consulta un usuario por su ID. | *Ninguno* |
| **POST** | `/api/Users` | Registra un nuevo usuario con contraseña hasheada. | `{ "username": "string", "email": "string", "passwordHash": "string" }` |
| **DELETE** | `/api/Users/{id}` | Realiza un borrado lógico del usuario (`IsActive = false`). | *Ninguno* |

---

## 🗄️ Modelo de Datos (`User.cs`)

| Propiedad | Tipo | Restricciones | Descripción |
| :--- | :--- | :--- | :--- |
| `Id` | `int` | Key, Auto-incremental | Identificador único del usuario |
| `Username` | `string` | Required, MaxLength(50) | Nombre de usuario |
| `Email` | `string` | Required, EmailAddress, MaxLength(100) | Correo electrónico único |
| `PasswordHash` | `string` | Required, MaxLength(255) | Hash seguro de la contraseña |
| `RegistrationDate` | `DateTime` | Default `DateTime.Now` | Fecha y hora de registro |
| `IsActive` | `bool` | Default `true` | Estado activo/inactivo |

---

## 🚀 Instalación y Ejecución Local

### Requisitos Previos
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) o superior.
* Git.

### Pasos

1. **Clonar el repositorio:**
   ```bash
   git clone [https://github.com/zepedafabianmp04-ctrl/Challenge-1---user-registration-profile.git](https://github.com/zepedafabianmp04-ctrl/Challenge-1---user-registration-profile.git)
   cd Challenge-1---user-registration-profile
