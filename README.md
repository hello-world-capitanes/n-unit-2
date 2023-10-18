# Aplicación Endpoints de scroring – autoaprobación de solicitudes

Se debe poder dar de alta una solicitud de renting llamada API.

Para realizar una solicitud se deben indicar los datos básicos del cliente y los datos de la solicitud.
Para preaprobarse automáticamente una solicitud deben cumplirse todas las condiciones de aprobación y no cumplirse ninguna de denegación.

Si se cumple una sola condición de denegación se auto denegaría.

En cualquier otro caso quedaría en pendiente de revisar por analista.

## Reglas de aprobación

|Nº|APROBACIONES AUTOMATICAS cumplir TODAS|
|:----|:----|
|1| INVERSION <= INGRESOS NETO
|2| INVERSION < =80 K€
|3| Nacionalidad = Española
|4| Si el cliente es asalariado y el CIF/NIF de la empresa donde trabaja el cliente SÍ se encuentra en INFORMA

## Reglas de denegación

|Nº|DENEGACIONES AUTOMATICAS (cumplir UNA)|
|:----|:----|
|1| Edad cliente  < 18 años|
|2| Edad cliente + Plazo a contratar >= 80|

Datos necesarios.
Persona contratante:
- Fecha de nacimiento
- Ingresos netos anuales como asalariado
- Ingresos netos anuales como autónomo
- Ingresos brutos anuales como autónomo
- Fecha inicio empleo como asalariado
- Nacionalidad
- CIF empleador

Solicitud renting:

- Fecha solicitud
- Numero vehículos
- Inversión (coste total coches)
- Cuota
- Plazo (meses)
- Fecha inicio vigor renting

