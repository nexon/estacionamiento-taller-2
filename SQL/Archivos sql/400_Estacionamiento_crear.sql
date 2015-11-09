DROP PROCEDURE IF EXISTS estacionamiento_crear $$
CREATE PROCEDURE estacionamiento_crear(
	inNombre VARCHAR(45),
	inDireccion VARCHAR(45),
	inEmail VARCHAR(45),
	inTelefono INT,
    inCapacidad INT(11),
    inTiempoMinimo INT(11),
    inTarifaMinuto INT(11),
    inApertura DATETIME,
    inCierre DATETIME,
    inCoordenadaLatitud DOUBLE,
    inCoordenadaLongitud DOUBLE
)
BEGIN
	INSERT INTO estacionamiento (
		nombre,
		direccion,
		email,
		telefono,
		capacidad,
        tiempo_minimo,
        tarifa_minuto,
        apertura,
        cierre,
        coordenadaLatitud,
        coordenadaLongitud
)
	VALUES(
		inNombre,
		inDireccion,
		inEmail,
		inTelefono,
		inCapacidad,
		inTiempoMinimo,
		inTarifaMinuto,
		inApertura,
		inCierre,
		inCoordenadaLatitud,
		inCoordenadaLongitud
);
END $$