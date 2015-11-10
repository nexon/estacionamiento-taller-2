DROP PROCEDURE IF EXISTS Estacionamiento_DespacharVehiculo $$

CREATE PROCEDURE Estacionamiento_DespacharVehiculo (
    inFecha_salida datetime,
    inMonto int,
    inId_estacionamiento int,
    inId_espacio int
)

BEGIN 
    UPDATE Registro
    SET
        fecha_salida = inFecha_salida
    WHERE
        id_estacionamiento  = inId_estacionamiento  AND
        inId_espacio        = inId_espacio          AND
        fecha_salida IS NULL;
END
$$





