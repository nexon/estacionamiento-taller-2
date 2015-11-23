DROP PROCEDURE IF EXISTS estacionamiento_seleccionar $$
CREATE PROCEDURE estacionamiento_seleccionar(
	inIdEstacionamiento INT(11)
) 
BEGIN
  SELECT
	nombre as estacionamiento_Nombre,
	direccion as estacionamiento_Direccion,
	email as estacionamiento_Email,
	telefono as estacionamiento_Telefono,
    tiempo_minimo as estacionamiento_TiempoMinimo,
    tarifa_minuto as estacionamiento_TarifaMinuto,
	apertura as estacionamiento_Apertura,
    cierre as estacionamiento_Cierre,
    coordenadaLatitud as estacionamiento_CoordenadaLatitud,
    coordenadaLongitud as estacionamiento_CoordenadaLongitud
  FROM 
	estacionamiento
  WHERE
	id_estacionamiento = inIdEstacionamiento;
END $$