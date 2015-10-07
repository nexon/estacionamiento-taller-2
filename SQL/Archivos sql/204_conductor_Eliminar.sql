DROP PROCEDURE IF EXISTS conductor_Eliminar $$
CREATE PROCEDURE conductor_Eliminar
(
	IN inId_conductor INT
)
BEGIN
DELETE FROM conductor
WHERE
	id_conductor=inId_conductor;
END$$


