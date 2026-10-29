# Trabajo Práctico Integrador

## Integrantes:

- 54280 - Squarzon, Nicolás José
- 54448 - Grieco, Giuliana
- 55160 - Corbella, Leonardo Gabriel

## Sistema de Gestión Veterinaria

Este proyecto es un Sistema de Gestión Integral para una Clínica Veterinaria, desarrollado como Trabajo Práctico Integrador (TPI) para la cátedra Tecnologías de Desarrollo de Software IDE (UTN FRRo).
El sistema cuenta con una arquitectura en capas, una API REST, y dos interfaces de usuario: Escritorio (WinForms) y Web (Blazor Server).

### Descripción General del Sistema

El **Sistema de Gestión Veterinaria (SGV)** registra y administra las actividades clínicas y operativas de la clínica en torno a las entidades principales de **Dueños, Mascotas, Veterinarios, Turnos y Medicamentos**.

## Requisitos previos

- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/es/) (con la carga de trabajo "Desarrollo de escritorio de .NET" y "Desarrollo de ASP.NET y web").
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
- [Microsoft SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (Express o Developer) corriendo localmente.

## Instrucciones de Ejecución

1. Clonar el repositorio

````
   ```bash
   git clone https://github.com/ggiuliana/TPI-Veterinaria.git
````

2. Abrir la solución:

Abrir el archivo `.sln ` principal con Visual Studio 2022.

3. Ejecutar el proyecto:

Para poder usar la aplicación, es necesario ejecutar la API y el Frontend elegido al mismo tiempo.

- Hacé clic derecho en la Solución (en el Explorador de soluciones) -> Configurar proyectos de inicio...

- Seleccioná Proyectos de inicio múltiples.

- Poné la acción Iniciar para el proyecto WebAPI.

- Poné la acción Iniciar para WinFormsApp1 (Escritorio) y/o BlazorServer (Web) según qué interfaz quieras probar.

- Presioná Aplicar y luego ejecutá con F5.

## Usuarios de prueba

Los usuarios disponibles para probar las diferentes funcionalidades en el sistema son los siguientes:

### Administrador

- Username: admin
- Password: admin123

### Veterinario

- Username: vet
- Password: vet123

### Dueño

- Username: duenio
- Password: duenio123

---

_Desarrollado por el Grupo T11 (Comisión 3EK02)._
