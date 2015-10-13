DROP PROCEDURE IF EXISTS valoracion_seleccionar_promedio $$
CREATE PROCEDURE valoracion_seleccionar_promedio(
	inIdUsuario INT,
	inIdEstacionamiento INT
) 
BEGIN
  SELECT 
	AVG(valoracion.valor_conductor) as valoracion_valor_conductor,
	AVG(valoracion.valor_estacionamiento) as valoracion_valor_estacionamiento
  FROM 
	conductor RIGHT JOIN valoracion ON conductor.id_conductor = valoracion.id_conductor
  WHERE
	(conductor.id_usuario = inIdUsuario AND valoracion.valor_conductor > 0) OR
	(valoracion.id_estacionamiento = inIdEstacionamiento AND valoracion.valor_estacionamiento > 0);
END
$$