DROP PROCEDURE IF EXISTS estacionamiento_Reservados $$
CREATE PROCEDURE estacionamiento_Reservados(
	IN IdEstacionamiento INT(11)
) 
BEGIN

  SELECT registro.fecha_reserva AS registro_fecha_reserva,
  		registro.fecha_salida AS registro_fecha_salida,
  		registro.fecha_ingreso AS registro_fecha_ingreso,
  		vehiculo.patente AS vehiculo_patente,
  		espacio.codigo AS espacio_codigo,
  		usuario.nombre AS usuario_nombre

  FROM registro inner join vehiculo on vehiculo.id_vehiculo = registro.id_vehiculo
  				inner join espacio on registro.id_espacio = espacio.id_espacio
  				inner join conductor on conductor.id_conductor = vehiculo.id_conductor
  				inner join usuario on conductor.id_usuario = usuario.rut

  WHERE registro.id_estacionamiento=IdEstacionamiento AND
        registro.fecha_reserva is not NULL AND 
        registro.fecha_ingreso is NULL AND
        registro.fecha_salida  is NULL AND;

END $$