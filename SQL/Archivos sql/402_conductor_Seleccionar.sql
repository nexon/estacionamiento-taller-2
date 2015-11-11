DROP PROCEDURE IF EXISTS Conductor_Seleccionar $$
CREATE PROCEDURE Conductor_Seleccionar
(
	inId_conductor INT
) 
BEGIN
SELECT
	id_conductor,id_usuario
FROM conductor
WHERE id_conductor=inId_conductor;
END$$

