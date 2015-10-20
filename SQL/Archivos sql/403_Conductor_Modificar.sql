DROP PROCEDURE IF EXISTS Conductor_Modificar $$
CREATE PROCEDURE Conductor_Modificar
(
	inId_conductor INT,
	inId_usuario INT
)
BEGIN
UPDATE conductor
SET 
	id_usuario = inId_usuario
WHERE
	id_conductor = inId_conductor;
END$$



