DROP PROCEDURE IF EXISTS Estacionamientos_Personal $$
CREATE PROCEDURE Estacionamientos_Personal (
	inID_Personal INT
)
BEGIN
	SELECT
		*
	FROM
		personal_estacionamiento
	WHERE
		id_personal = inID_Personal;
END
$$