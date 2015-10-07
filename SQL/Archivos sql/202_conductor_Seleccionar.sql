DROP PROCEDURE IF EXISTS conductor_Seleccionar $$
CREATE PROCEDURE conductor_Seleccionar
(
	IN inId_conductor INT
) 
BEGIN
SELECT
	id_conductor,id_usuario,reputacion
FROM conductor
WHERE id_conductor=inId_conductor;
END$$

