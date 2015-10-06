DROP PROCEDURE IF EXISTS valoracion_leer $$
CREATE PROCEDURE valoracion_leer(
	inIdConductor INT,
	inIdEstacionamiento INT
) 
BEGIN
  SELECT 
	AVG(v.valor_conductor) as valoracion_valor_conductor,
	AVG(v.valor_estacionamiento) as valoracion_valor_estacionamiento
  FROM 
	valoracion as v
  WHERE
	v.id_conductor = inIdConductor OR
	v.id_estacionamiento = inIdEstacionamiento;
END
$$