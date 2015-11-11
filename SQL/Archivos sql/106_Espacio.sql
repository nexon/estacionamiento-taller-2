DROP TABLE IF EXISTS espacio $$
CREATE TABLE espacio
(
 codigo VARCHAR(15),
 id_estacionamiento INT NOT NULL,
 PRIMARY KEY (codigo, id_estacionamiento),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento)
)
$$