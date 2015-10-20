DROP PROCEDURE IF EXISTS Personal_Eliminar $$
CREATE PROCEDURE Personal_Eliminar
(
	inId_personal INT
)
BEGIN
DELETE FROM personal
WHERE
	id_usuario=inId_personal;
END$$
