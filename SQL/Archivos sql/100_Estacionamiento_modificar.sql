DROP PROCEDURE IF EXISTS estacionamiento_modificar $$
CREATE PROCEDURE estacionamiento_modificar(
	inIdEstacionamiento INT,
    inNombre VARCHAR(45),
	inDireccion VARCHAR(45),
    inCapacidad INT,
    inReputacion FLOAT,
    inCargoFijo INT,
    inCargoMinuto INT,
    inCantMinutos INT	
)
BEGIN
	UPDATE estacionamiento
	SET 
		nombre = inNombre,
        direccion = inDireccion,
        capacidad = inCapacidad,
        reputacion = inReputacion,
        cargo_fijo = inCargoFijo,
        cargo_minuto = inCargoMinuto,
        cant_minutos = inCantMinutos
	WHERE id_estacionamiento = inIdEstacionamiento;
END $$