DROP PROCEDURE IF EXISTS Estacionamiento_ Desvincular_Personal  $$

CREATE PROCEDURE Estacionamiento_Desvincular_Personal (
	inID_Estacionamiento INT,
	inID_RUT INT
)

BEGIN 
	DELETE personal_estacionamiento
	FROM personal_estacionamiento LEFT JOIN personal
	ON personal_estacionamiento.id_personal = personal.id_personal
    WHERE 
    personal_estacionamiento.id_estacionamiento  =   inID_Estacionamiento AND 
    personal_estacionamiento.id_personal  
    IN 
    (SELECT id_personal  
     FROM personal
     WHERE id_usuario = inID_RUT ); 

END
$$





