DROP TABLE IF EXISTS estacionamiento $$
CREATE TABLE estacionamiento
(
 id_estacionamiento INT NOT NULL AUTO_INCREMENT,
 nombre VARCHAR(45) NOT NULL,
 direccion VARCHAR(45) NOT NULL,
 capacidad INT NOT NULL,
 reputacion FLOAT,
 tiempo_minimo INT NOT NULL,
 tarifa_minuto INT NOT NULL,
 cant_minutos INT NOT NULL,
 apertura DATETIME,
 cierre DATETIME,
 coordenadaLatitud DOUBLE,
 coordenadaLongitud DOUBLE,
 PRIMARY KEY (id_estacionamiento)
) 
$$