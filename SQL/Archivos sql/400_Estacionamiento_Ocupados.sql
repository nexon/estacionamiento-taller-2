DROP PROCEDURE IF EXISTS Estacionamiento_Ocupados $$
CREATE PROCEDURE Estacionamiento_Ocupados (
	inID_Estacionamiento bigint
)
BEGIN

	SELECT
		Espacio.codigo	AS Espacio_Codigo,
		patente			AS Vehiculo_Patente,
		fecha_reserva	AS Fecha_Reserva,
		fecha_ingreso 	AS Fecha_Ingreso
	FROM
		Espacio, Vehiculo, (SELECT fecha_reserva, fecha_ingreso, codigo, id_vehiculo 
								 FROM Registro
							  	 WHERE id_estacionamiento = inID_Estacionamiento AND fecha_ingreso is NOT NULL AND fecha_salida is NULL) AS ocupados
	WHERE Espacio.codigo = 	ocupados.codigo AND Vehiculo.patente = ocupados.id_vehiculo;
END
$$