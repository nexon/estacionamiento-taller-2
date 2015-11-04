DROP PROCEDURE IF EXISTS Espacio_Eliminar $$
CREATE PROCEDURE Espacio_Eliminar
(
	inCodigo VARCHAR(15)
)
BEGIN
DELETE FROM espacio
WHERE
	codigo=inCodigo;
END$$
