DROP PROCEDURE IF EXISTS Personal_Buscar $$
CREATE PROCEDURE Personal_Buscar(
	inId_usuario INT
) 
BEGIN
  SELECT 
  	 id_personal AS Personal_Id
  FROM 
	personal
  WHERE
	id_usuario= inId_usuario;
END
$$