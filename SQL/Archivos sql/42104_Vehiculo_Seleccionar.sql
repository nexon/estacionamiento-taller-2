DROP PROCEDURE IF EXISTS Vehiculo_Seleccionar $$
CREATE PROCEDURE Vehiculo_Seleccionar(
		inPatente VARCHAR(15)
	)
	BEGIN
		SELECT
			patente
		FROM Vehiculo
		WHERE patente = inPatente;
	END
$$