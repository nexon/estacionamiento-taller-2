DROP PROCEDURE IF EXISTS Estacionamiento_Eliminar_Personal  $$

CREATE PROCEDURE Estacionamiento_Eliminar_Personal (
	inID_Estacionamiento INT,
	inID_Personal INT
)
BEGIN

	DELETE FROM personal_estacionamiento
	WHERE
		id_personal 	     =	 inID_Personal AND
     	id_estacionamiento   =   inID_Estacionamiento;
END
$$
