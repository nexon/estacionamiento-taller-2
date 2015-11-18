DROP PROCEDURE IF EXISTS Estacionamiento_Todos $$
CREATE PROCEDURE Estacionamiento_Todos (
	inID_Estacionamiento bigint
)
BEGIN

	SELECT
		Todos.codigo	AS Espacio_Codigo,
		patente			AS Vehiculo_Patente,
		fecha_reserva	AS fecha_Reserva,
		fecha_ingreso 	AS Fecha_Ingreso,
		fecha_salida 	AS Fecha_Salida
	FROM
		( SELECT Espacios.codigo, id_vehiculo ,fecha_reserva, fecha_ingreso, fecha_salida FROM
							(SELECT codigo FROM Espacio WHERE id_estacionamiento = inID_Estacionamiento) as Espacios 
								LEFT JOIN Registro
								ON Registro.codigo = Espacios.codigo AND fecha_salida IS NULL  ) AS Todos
		LEFT JOIN Vehiculo
		ON Vehiculo.patente = Todos.id_vehiculo;
END
$$