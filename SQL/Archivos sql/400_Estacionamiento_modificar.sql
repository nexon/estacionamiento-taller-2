DROP PROCEDURE IF EXISTS estacionamiento_modificar $$
CREATE PROCEDURE estacionamiento_modificar(
	inIdEstacionamiento INT(11),
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
	UPDATE estacionamiento
	SET 
		nombre = inNombre,
        direccion = inDireccion,
		email = inEmail,
		telefono = inTelefono,
        capacidad = inCapacidad,
        tiempo_minimo = inTiempoMinimo,
        tarifa_minuto = inTarifaMinuto,
        apertura = inApertura,
        cierre = inCierre,
        coordenadaLatitud = inCoordenadaLatitud,
        coordenadaLongitud = inCoordenadaLongitud
        
	WHERE id_estacionamiento = inIdEstacionamiento;
END $$