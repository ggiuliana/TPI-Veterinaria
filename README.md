# Trabajo Práctico Integrador

## Integrantes:
* 54280 - Squarzon, Nicolás José
* 54448 - Grieco, Giuliana
* 55160 - Corbella, Leonardo Gabriel

## Descripción General del Sistema
### Sistema de Gestión Veterinaria
El **Sistema de Gestión Veterinaria (SGV)** registra y administra las actividades clínicas y operativas de la clínica en torno a las entidades principales de **Dueños, Mascotas, Veterinarios, Turnos y Medicamentos**.

Tanto los **Dueños** como los **Veterinarios** tienen datos en común, tales como **DNI, Nombre, Apellido, Dirección, Teléfono y Email**, entre otros.

Las **Mascotas** pertenecen a un único **Dueño** y tienen características propias como **Especie, Raza y Fecha de Nacimiento**. Su historial clínico se conforma mediante la aplicación de **Vacunas** (ingresadas por el Dueño al momento de registro de la Mascota) y la realización de **Estudios y Consultas**.

El acceso a las distintas funcionalidades está restringido mediante **Roles** (por ejemplo, **Administrador, Recepcionista y Veterinario**).

Cada **Usuario** tiene acceso a diferentes funcionalidades del sistema mediante el **Módulo de Acceso** que le corresponda (dependiendo si es **Administrador/Recepcionista, Dueño o Veterinario**), el cual le da permisos para realizar diferentes acciones en el programa.

Para la atención, la clínica gestiona **Turnos**, donde se asocia una **Mascota** con un turno, cargado por un **Veterinario** y asociado con él en una fecha y hora específicas. El **Dueño** de la Mascota selecciona un turno de los turnos disponibles previamente cargados por el Veterinario y se le asigna a su Mascota.

Al momento de que el **Veterinario** crea sus turnos, los mismos tienen el estado **"Disponible"**. Cuando un turno es asignado a una Mascota su estado se convierte en **"Otorgado"**. Llegado el día y la hora del turno su estado pasa a ser **"Resuelto"** y se crea la **Consulta** si la Mascota asistió. Previo a la fecha del turno el Dueño puede cancelarlo, volviendo al estado **"Disponible"**.

Al concretarse la atención clínica, el **Veterinario** debe registrar la **Consulta** en el sistema. En este acto, el Veterinario detalla el **diagnóstico, el tratamiento, el peso registrado y los medicamentos utilizados o recetados**.

En caso de utilizar **Medicamentos**, se actualiza su stock. Para que en una consulta se utilicen cierta cantidad de medicamentos, debe haber stock suficiente.

El día de la consulta el **Veterinario** puede decidir si es necesario realizar un **Estudio**, asignándolo a la misma. Los estudios son realizados por un Veterinario.

Teniendo en cuenta este modelo las funcionalidades a implementar son las siguientes:


## Alcance Funcional y Requerimientos

### Requerimientos Funcionales Implementados
Teniendo en cuenta este modelo las funcionalidades a implementar son las siguientes:

1. Alta, Baja, Modificaciones y Consulta de Usuarios
2. Alta, Baja, Modificaciones y Consulta de Veterinarios
3. Alta, Baja, Modificaciones y Consulta de Dueños
4. Alta, Baja, Modificaciones y Consulta de Turnos
5. Alta, Baja, Modificaciones y Consulta de Mascotas
6. Alta, Baja, Modificaciones y Consulta de Estudios
7. Alta, Baja, Modificaciones y Consulta de Vacunas
8. Asignación de turno
9. Registro de Consultas, Estudios y Medicamentos utilizados
10. Reporte de Historial clínico (Estudios, vacunas y consultas)
11. Reporte de Turnos
12. Reporte de stock de Medicamentos


## Modelo del Dominio

![ModeloVeterinaria](./docs/ModeloVeterinaria.png)
