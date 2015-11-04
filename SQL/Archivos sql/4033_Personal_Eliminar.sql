DROP PROCEDURE IF EXISTS Personal_Eliminar $$
CREATE PROCEDURE Personal_Eliminar
(
	inId_personal INT
)
BEGIN
DELETE FROM personal
WHERE
	Id_personal=inId_personal;
END$$
