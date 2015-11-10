DROP PROCEDURE IF EXISTS Estacionamiento_Disponibles $$
CREATE PROCEDURE Estacionamiento_Disponibles (
	inID_Estacionamiento bigint
)

BEGIN
	SELECT Espacio.id_espacio, Espacio.codigo
	FROM
			(SELECT id_espacio 
			FROM Registro 
			WHERE fecha_salida IS NULL) AS NoDisponibles
	RIGHT Join Espacio
	ON NoDisponibles.id_espacio = Espacio.id_espacio 
	WHERE NoDisponibles.id_espacio IS NULL 
		AND  Espacio.id_estacionamiento = inID_Estacionamiento;

END
$$