DROP PROCEDURE IF EXISTS conductor_Actualizar $$
CREATE PROCEDURE conductor_Actualizar
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



