DROP PROCEDURE IF EXISTS conductor_obtener $$
CREATE PROCEDURE conductor_obtener
(
	IN inId_conductor INT
) 
BEGIN
SELECT
	id_conductor,id_usuario,reputacion
FROM conductor
WHERE id_conductor=inId_conductor;
END$$

