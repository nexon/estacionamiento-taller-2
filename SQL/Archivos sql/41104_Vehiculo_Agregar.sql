DROP PROCEDURE IF EXISTS Vehiculo_Agregar $$
	CREATE PROCEDURE Vehiculo_Agregar(
	    inPatente varchar(15),
	    inRut int
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
				(SELECT id_conductor FROM Conductor WHERE inRut = id_usuario)
			);
	END
$$