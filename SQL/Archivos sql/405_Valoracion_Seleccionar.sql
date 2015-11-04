DROP PROCEDURE IF EXISTS valoracion_seleccionar $$
CREATE PROCEDURE valoracion_seleccionar(
	inIdUsuario INT,
	inIdEstacionamiento INT
) 
BEGIN
  SELECT 
    valoracion.id_valoracion as valoracion_id_valoracion,
	valoracion.valor_conductor as valoracion_valor_conductor,
	valoracion.valor_estacionamiento as valoracion_valor_estacionamiento
  FROM 
	conductor RIGHT JOIN valoracion ON conductor.id_conductor = valoracion.id_conductor
  WHERE
	conductor.id_usuario = inIdUsuario AND
	valoracion.id_estacionamiento = inIdEstacionamiento
    ORDER BY valoracion.fecha_hora DESC LIMIT 1;
END
$$