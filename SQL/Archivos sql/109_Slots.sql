DROP TABLE IF EXISTS slots $$
CREATE TABLE slots
(
 id_slot INT NOT NULL AUTO_INCREMENT,
 nombreSlot VARCHAR(15),
 expiracion DATETIME NOT NULL,
 id_vehiculo INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 id_estado INT NOT NULL,
 PRIMARY KEY (id_slot),
 FOREIGN KEY (id_vehiculo) REFERENCES vehiculos (id_vehiculo),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamientos (id_estacionamiento),
 FOREIGN KEY (id_estado) REFERENCES estados (id_estado)
)
$$