DROP PROCEDURE IF EXISTS conductor_borrar $$
CREATE PROCEDURE conductor_borrar
(
	IN inId_conductor INT
)
BEGIN
DELETE FROM conductor
WHERE
	id_conductor=inId_conductor;
END$$


