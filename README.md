# TPaga_Prueba_Dev
Código fuente usado para desarrollar la prueba de TPaga

El proyecto fue realizado usando el framework WebApi de .NET. Consiste en un servicio web llamado API en el segundo nivel del modelo Richardson que contiene dos endpoints:
- /API/Cuentas
- /API/Cuentas/Bitcoins

Cada endpoint usa los verbos GET y PUT, por lo tanto están formateados para usar los respectivos estándares, por ejemplo:
- GET cuentas: /API/Cuentas
- Put cuentas: /API/Cuentas/{id}, donde id es el id de la cuenta y en el body se especifica el saldo como propiedad de un objeto para modificar el saldo.
