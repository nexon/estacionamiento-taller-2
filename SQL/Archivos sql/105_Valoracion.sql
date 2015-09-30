DROP TABLE IF EXISTS valoracion $$
CREATE TABLE valoracion
(
 id_valoracion INT NOT NULL AUTO_INCREMENT,
 valor_conductor FLOAT NOT NULL,
 valor_estacionamiento FLOAT NOT NULL,
 fecha_hora DATETIME NOT NULL,
 id_conductor INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 PRIMARY KEY (id_valoracion),
 FOREIGN KEY (id_conductor) REFERENCES cliente (id_conductor),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento)
)
$$