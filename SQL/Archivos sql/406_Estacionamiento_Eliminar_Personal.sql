DROP PROCEDURE IF EXISTS Estacionamiento_Eliminar_Personal  $$

CREATE PROCEDURE Estacionamiento_Eliminar_Personal (
	inID_Estacionamiento INT,
	inID_RUT INT
)

BEGIN 
	DELETE personal_estacionamiento
	From personal_estacionamiento INNER JOIN personal
	on personal_estacionamiento.id_personal = personal.id_personal
    WHERE 
    personal_estacionamiento.id_estacionamiento  =   inID_Estacionamiento AND 
    personal_estacionamiento.id_personal  
    IN 
    (select id_personal  
     from personal
     where id_usuario = inID_RUT ); 

END
$$





