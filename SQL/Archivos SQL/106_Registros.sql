DROP TABLE IF EXISTS registros $$
CREATE TABLE registros
(
 id_registro INT NOT NULL AUTO_INCREMENT,
 fecha_ingreso DATETIME NOT NULL,
 fecha_salida DATETIME,
 monto_total INT,
 id_estacionamiento INT NOT NULL,
 id_vehiculo INT NOT NULL,
 PRIMARY KEY (id_registro),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamientos (id_estacionamiento),
 FOREIGN KEY (id_vehiculo) REFERENCES vehiculos (id_vehiculo)
)
$$