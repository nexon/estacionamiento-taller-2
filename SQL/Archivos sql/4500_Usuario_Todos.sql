DROP PROCEDURE IF EXISTS Usuario_Todos $$
CREATE PROCEDURE Usuario_Todos(
	
) 
  SELECT 
    rut			  AS Usuario_Rut,
	nombre		  AS Usuario_Nombre,
	email 	      AS Usuario_Email,
	telefono	  AS Usuario_Telefono
  FROM 
	usuario

$$