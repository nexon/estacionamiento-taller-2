DROP PROCEDURE IF EXISTS Estacionamiento_Ocupados $$
CREATE PROCEDURE Estacionamiento_Ocupados (
	inID_Estacionamiento bigint
)
BEGIN

	SELECT
		codigo			AS Espacio_Codigo,
		patente			AS Vehiculo_Patente,
		fecha_reserva	AS Fecha_Reserva,
		fecha_ingreso 	AS Fecha_Ingreso
	FROM
		Espacio, Vehiculo, (SELECT fecha_reserva, fecha_ingreso, id_espacio, id_vehiculo 
								 FROM Registro
							  	 WHERE id_estacionamiento = inID_Estacionamiento AND fecha_ingreso is NOT NULL AND fecha_salida is NULL) AS ocupados
	WHERE Espacio.id_espacio = 	ocupados.id_espacio AND Vehiculo.id_vehiculo = ocupados.id_vehiculo;
END
$$