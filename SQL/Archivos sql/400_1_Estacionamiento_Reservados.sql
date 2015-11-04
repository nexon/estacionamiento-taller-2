DROP PROCEDURE IF EXISTS estacionamiento_Reservados $$
CREATE PROCEDURE estacionamiento_Reservados(
	IN IdEstacionamiento INT(11)
) 
BEGIN

  SELECT registro.fecha_reserva ,registro.fecha_salida , registro.fecha_ingreso , vehiculo.patente , espacio.codigo

  FROM registro ,vehiculo , espacio

  WHERE Registro.id_estacionamiento=IdEstacionamiento AND
        Registro.fecha_reserva is not NULL AND 
        Registro.fecha_ingreso is NULL AND
        Registro.fecha_salida  is NULL AND
        vehiculo.id_vehiculo = registro.id_vehiculo AND
        registro.id_espacio = espacio.id_espacio;

END $$