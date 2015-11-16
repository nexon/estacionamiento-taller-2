DROP PROCEDURE IF EXISTS Estacionamiento_Desvincular_Personal $$

CREATE PROCEDURE Estacionamiento_Desvincular_Personal (
	inIDEstacionamiento INT,
	inIDRut INT
)

BEGIN 
	DELETE personal_estacionamiento
	FROM personal_estacionamiento LEFT JOIN personal
	ON personal_estacionamiento.id_personal = personal.id_personal
    WHERE 
    personal_estacionamiento.id_estacionamiento  =   inIDEstacionamiento AND 
    personal_estacionamiento.id_personal  
    IN 
    (SELECT id_personal  
     FROM personal
     WHERE id_usuario = inIDRut ); 

END
$$





