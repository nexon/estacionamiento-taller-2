DROP TABLE IF EXISTS espacio $$
CREATE TABLE espacio
(
 id_espacio INT NOT NULL AUTO_INCREMENT,
 nombreSlot VARCHAR(15),
 expiracion DATETIME NOT NULL,
 id_vehiculo INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 PRIMARY KEY (id_espacio),
 FOREIGN KEY (id_vehiculo) REFERENCES vehiculo (id_vehiculo),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento)
)
$$