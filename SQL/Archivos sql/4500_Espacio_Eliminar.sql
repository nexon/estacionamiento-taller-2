DROP PROCEDURE IF EXISTS Espacio_Eliminar $$
CREATE PROCEDURE Espacio_Eliminar
(
	inCodigo VARCHAR(15),
	inID INT
)
BEGIN
DELETE FROM espacio
WHERE
	codigo=inCodigo and id_estacionamiento=inID ;
END$$
