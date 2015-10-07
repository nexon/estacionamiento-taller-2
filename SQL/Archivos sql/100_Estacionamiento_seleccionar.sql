DROP PROCEDURE IF EXISTS estacionamiento_seleccionar $$
CREATE PROCEDURE estacionamiento_seleccionar(
	inIdEstacionamiento INT
) 
BEGIN
  SELECT 
	e.nombre = estacionamiento_Nombre,
	e.direccion = estacionamiento_Direccion,
	e.capacidad = estacionamiento_Capacidad,
	e.reputacion = estacionamiento_Reputacion,
	e.cargo_fijo = estacionamiento_CargoFijo,
	e.cargo_minuto = estacionamiento_CargoMinuto,
	e.cant_minutos = estacionamiento_CantMinutos
  FROM 
	estacionamiento as e
  WHERE
	e.id_estacionamiento = inIdEstacionamiento;
END $$