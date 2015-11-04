DROP PROCEDURE IF EXISTS Estacionamiento_Disponibles $$
CREATE PROCEDURE Estacionamiento_Disponibles (
	inID_Estacionamiento bigint
)

BEGIN
	SELECT codigo AS Espacio_Codigo
	FROM
		(SELECT id_espacio, codigo 
		FROM Espacio 
		WHERE id_estacionamiento = inID_Estacionamiento) as Espacios 
	LEFT JOIN Registro
	ON Registro.id_espacio = Espacios.id_espacio AND ((registro.fecha_reserva is NULL
		AND registro.fecha_ingreso is NULL) OR (registro.fecha_reserva is not NULL
		AND registro.fecha_ingreso is not NULL
        AND registro.fecha_salida is not NULL));
END
$$