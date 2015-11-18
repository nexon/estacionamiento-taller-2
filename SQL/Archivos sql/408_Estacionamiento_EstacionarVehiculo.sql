DROP PROCEDURE IF EXISTS Estacionamiento_EstacionarVehiculo $$

CREATE PROCEDURE Estacionamiento_EstacionarVehiculo (
    inFecha_ingreso datetime,
    inId_estacionamiento int,
    inId_vehiculo varchar(15),
    inCodigo varchar(15)
)

BEGIN 
    INSERT INTO Registro
    (
        fecha_ingreso,
        id_estacionamiento,
        id_vehiculo,
        codigo
    )
    VALUES
    (
        inFecha_ingreso,
        inId_estacionamiento,
        inId_vehiculo,
        inCodigo
    );
END
$$





