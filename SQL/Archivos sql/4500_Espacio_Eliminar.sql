DROP PROCEDURE IF EXISTS Espacio_Eliminar $$
CREATE PROCEDURE Espacio_Eliminar
(
	inId_espacio INT
)
BEGIN
DELETE FROM espacio
WHERE
	id_espacio=inId_espacio;
END$$
