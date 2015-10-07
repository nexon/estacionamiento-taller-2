DROP TABLE IF EXISTS detalle_estacionamiento $$
CREATE TABLE detalle_estacionamiento 
(
 id_estacionamiento INT NOT NULL,
 id_palabra INT NOT NULL,
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento),
 FOREIGN KEY (id_palabra) REFERENCES palabra_clave (id_palabra)
)
$$