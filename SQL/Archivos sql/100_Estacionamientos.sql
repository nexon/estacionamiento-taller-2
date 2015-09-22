DROP TABLE IF EXISTS estacionamientos $$
CREATE TABLE estacionamientos
(
 id_estacionamiento INT NOT NULL AUTO_INCREMENT,
 nombre VARCHAR(45) NOT NULL,
 direccion VARCHAR(45) NOT NULL,
 capacidad INT NOT NULL,
 reputacion FLOAT,
 cargo_fijo INT NOT NULL,
 cargo_minuto INT NOT NULL,
 cant_minutos INT NOT NULL,
 PRIMARY KEY (id_estacionamiento)
) 
$$