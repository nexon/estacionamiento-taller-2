DROP TABLE IF EXISTS detalles_estacionamiento $$
CREATE TABLE detalles_estacionamiento 
(
 id_estacionamiento INT NOT NULL,
 id_palabra INT NOT NULL,
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamientos (id_estacionamiento),
 FOREIGN KEY (id_palabra) REFERENCES palabras_clave (id_palabra)
)
$$