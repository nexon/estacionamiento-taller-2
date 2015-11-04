


DROP PROCEDURE IF EXISTS Personal_Seleccionar $$
CREATE PROCEDURE Personal_Seleccionar
(
	inId_personal INT
) 
BEGIN
SELECT
	id_personal,id_usuario
FROM personal
WHERE id_personal=inId_personal;
END$$