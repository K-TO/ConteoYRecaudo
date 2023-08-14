# Conteo y Recaudo API

Conteo y Recaudo API, es una aplicación que toma datos almacenados en DB y los representa de manera grafica a traves de una App de Angular.

# Archivos

Los archivos con especificaciones del proyecto se encuentran en .\Utilidades y Entregables.

## Requisitos y tecnologias usadas

* .Net 6.0
* MSSQL Server
* Angular ^16.2.0

# Instalación y ejecución

* Se debera ajustar la linea de conexión a DB, esto se realiza desde: '.\Presentation\ConteoRecaudo.API\appsettings.json', la propiedad a modificar es `DefaultConnection`.

* Para la instalación en DB, se requiere la compilación de la solución y posteriormente ejecutar el comando: ` update-database ` desde el proyecto '.\ConteoRecaudo.Data'.

* Para la instalación de datos de pruebas, los scripts se encuentran en el directorio: .\Utilidades y Entregables\SQL (no importa el orden de ejecución).

* Para la ejecución de la aplicación Angular, se debera ejecutar el comando `npm install`.

* Tener en cuenta que el puerto de la API, debera ser igual al que se encuentra en el archivo '.\src\environments\environment.ts' de la aplicación angular.

* Para iniciar sesión se pueden usar los siguientes datos: 
    
    Usuario: admin
    Contraseña: admin

* Para registrar un nuevo usuario se podra registrar desde la API '/Api/Usuario/Register' o en su defecto registrandose desde la aplicación de Angular.
