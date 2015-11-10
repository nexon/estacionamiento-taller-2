DROP PROCEDURE IF EXISTS Estacionamiento_EstacionarVehiculo $$

CREATE PROCEDURE Estacionamiento_EstacionarVehiculo (
    inFecha_ingreso datetime,
    inId_estacionamiento int,
    inId_vehiculo int,
    inId_espacio int
)

BEGIN 
    INSERT INTO Registro
    (
        fecha_ingreso,
        id_estacionamiento,
        id_vehiculo,
        id_espacio
    )
    VALUES
    (
        inFecha_ingreso,
        inId_estacionamiento,
        inId_vehiculo,
        inId_espacio
    );
END
$$





