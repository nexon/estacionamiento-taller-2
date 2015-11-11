DROP PROCEDURE IF EXISTS Estacionamiento_DespacharVehiculo $$

CREATE PROCEDURE Estacionamiento_DespacharVehiculo (
    inFecha_salida datetime,
    inMonto int,
    inId_estacionamiento int,
    inCodigo varchar(15)
)

BEGIN 
    UPDATE Registro
    SET
        fecha_salida = inFecha_salida
    WHERE
        id_estacionamiento  = inId_estacionamiento  AND
        codigo              = inCodigo              AND
        fecha_salida IS NULL;
END
$$





