


DROP PROCEDURE IF EXISTS Personal_Modificar $$
CREATE PROCEDURE Personal_Modificar
(
	inid_personal INT,
	inId_usuario INT
)
BEGIN
UPDATE personal
SET 
	id_usuario = inId_usuario
WHERE
	id_conductor = inid_personal;
END$$


