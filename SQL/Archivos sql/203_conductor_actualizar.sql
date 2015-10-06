DROP PROCEDURE IF EXISTS conductor_actualizar $$
CREATE PROCEDURE conductor_actualizar
(
	IN inId_conductor INT,
	IN inId_usuario INT,
	IN inReputacion FLOAT
)
BEGIN
UPDATE conductor
SET 
	id_usuario = inId_usuario,
	reputacion = inReputacion
WHERE
	id_conductor = inId_conductor;
END$$



