DROP PROCEDURE IF EXISTS estacionamiento_seleccionar $$
CREATE PROCEDURE estacionamiento_seleccionar(
	inIdEstacionamiento INT(11)
) 
BEGIN
  SELECT 
	
	e.nombre = estacionamiento_Nombre,
	e.direccion = estacionamiento_Direccion,
	e.capacidad = estacionamiento_Capacidad,
    e.tiempo_minimo = estacionamiento_TiempoMinimo,
    e.tarifa_minuto = estacionamiento_TarifaMinuto,
    e.cant_minutos = estacionamiento_CantMinutos,
	e.apertura = estacionamiento_Apertura,
    e.cierre = estacionamiento_Cierre,
    e.coordenadaLatitud = estacionamiento_CoordenadaLatitud,
    e.coordenadaLongitud = estacionamiento_CoordenadaLongitud
	
  FROM 
	estacionamiento as e
  WHERE
	e.id_estacionamiento = inIdEstacionamiento;
END $$