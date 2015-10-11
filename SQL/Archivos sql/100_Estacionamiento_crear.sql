DELIMITER $$
DROP PROCEDURE IF EXISTS estacionamiento_crear $$
CREATE PROCEDURE estacionamiento_crear(
	inNombre VARCHAR(45),
	inDireccion VARCHAR(45),
    inCapacidad INT(11),
    inTiempoMinimo INT(11),
    inTarifaMinuto INT(11),
    inCantMinutos INT(11),
    inApertura DATETIME,
    inCierre DATETIME,
    inCoordenadaLatitud DOUBLE,
    inCoordenadaLongitud DOUBLE
)
BEGIN
	INSERT INTO estacionamiento (
		nombre,
		direccion,
		capacidad,
        tiempo_minimo,
        tarifa_minuto,
        cant_minutos,
        apertura,
        cierre,
        coordenadaLatitud,
        coordenadaLongitud
)
	VALUES(
		inNombre,
		inDireccion,
		inCapacidad,
		inTiempoMinimo,
		inTarifaMinuto,
		inCantMinutos,
		inApertura,
		inCierre,
		inCoordenadaLatitud,
		inCoordenadaLongitud
);
END $$
DELIMITER ;