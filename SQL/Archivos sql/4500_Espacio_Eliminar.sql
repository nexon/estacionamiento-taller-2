DROP PROCEDURE IF EXISTS Espacio_Eliminar $$
CREATE PROCEDURE Espacio_Eliminar
(
	inCodigo INT
)
BEGIN
DELETE FROM espacio
WHERE
	codigo=inCodigo;
END$$
