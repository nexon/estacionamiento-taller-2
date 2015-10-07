DROP TABLE IF EXISTS espacio $$
CREATE TABLE espacio
(
 id_espacio INT NOT NULL AUTO_INCREMENT,
 codigo VARCHAR(15),
 id_estacionamiento INT NOT NULL,
 PRIMARY KEY (id_espacio),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento)
)
$$