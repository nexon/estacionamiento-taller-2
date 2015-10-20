DROP PROCEDURE IF EXISTS Conductor_Eliminar $$
CREATE PROCEDURE Conductor_Eliminar
(
	inId_conductor INT
)
BEGIN
DELETE FROM conductor
WHERE
	id_usuario=inId_conductor;
END$$


