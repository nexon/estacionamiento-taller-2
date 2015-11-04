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

  FROM registro ,vehiculo , espacio, conductor, usuario

  WHERE Registro.id_estacionamiento=IdEstacionamiento AND
        Registro.fecha_reserva is not NULL AND 
        Registro.fecha_ingreso is NULL AND
        Registro.fecha_salida  is NULL AND
        vehiculo.id_vehiculo = registro.id_vehiculo AND
        registro.id_espacio = espacio.id_espacio AND
        conductor.id_conductor = vehiculo.id_conductor AND
        conductor.id_usuario = usuario.rut;

END $$