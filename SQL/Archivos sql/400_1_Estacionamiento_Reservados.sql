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

  FROM registro left join vehiculo on vehiculo.id_vehiculo = registro.id_vehiculo
  				left  join espacio on registro.codigo = espacio.codigo AND registro.id_estacionamiento = espacio.id_estacionamiento
  				left join conductor on conductor.id_conductor = vehiculo.id_conductor
  				left join usuario on conductor.id_usuario = usuario.rut

  WHERE registro.id_estacionamiento=IdEstacionamiento AND
        registro.fecha_reserva is not NULL AND 
        registro.fecha_ingreso is NULL AND
        registro.fecha_salida  is NULL;

END $$