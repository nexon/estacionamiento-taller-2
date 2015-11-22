DROP PROCEDURE IF EXISTS Vehiculo_Agregar $$
	CREATE PROCEDURE Vehiculo_Agregar(
	    inPatente varchar(15),
	    IN inIDCOnductor int
	)
	BEGIN
		INSERT INTO Vehiculo
			(
				patente,
				id_conductor
			)
		VALUES
			(
				inPatente,
				inIDCOnductor
			);
	END
$$