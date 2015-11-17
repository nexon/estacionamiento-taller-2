DROP PROCEDURE IF EXISTS Estacionamiento_ConfirmarReserva $$

CREATE PROCEDURE Estacionamiento_ConfirmarReserva (
    inFecha_ingreso datetime,
    inidEstacionamiento int,
    inCodigoEspacio varchar(15)
)

BEGIN 
    UPDATE Registro
    SET
        fecha_ingreso = inFecha_ingreso
    WHERE
        id_estacionamiento  = inidEstacionamiento  AND
        codigo              = inCodigoEspacio      AND
        fecha_salida IS NULL AND
        fecha_ingreso IS NULL;
END
$$





