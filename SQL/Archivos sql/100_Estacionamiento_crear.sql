DROP PROCEDURE IF EXISTS estacionamiento_crear $$
CREATE PROCEDURE estacionamiento_crear(
	inNombre VARCHAR(45),
	inDireccion VARCHAR(45),
    inCapacidad INT,
    inReputacion FLOAT,
    inCargoFijo INT,
    inCargoMinuto INT,
    inCantMinutos INT
)
BEGIN
	INSERT INTO estacionamiento (
		nombre,
		direccion,
		capacidad,
		reputacion,
		cargo_fijo,
		cargo_minuto,
		cant_minutos
)
	VALUES(
		inNombre,
		inDireccion,
		inCapacidad,
		inReputacion,
		inCargoFijo,
		inCargoMinuto,
		inCantMinutos
);
END $$