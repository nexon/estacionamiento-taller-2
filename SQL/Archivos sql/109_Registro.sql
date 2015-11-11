DROP TABLE IF EXISTS registro $$
CREATE TABLE registro
(
 id_registro INT NOT NULL AUTO_INCREMENT,
 fecha_reserva DATETIME,
 fecha_ingreso DATETIME,
 fecha_salida DATETIME,
 monto_total INT,
 id_estacionamiento INT NOT NULL,
 id_vehiculo INT NOT NULL,
 codigo varchar(15) NOT NULL,
 PRIMARY KEY (id_registro),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento),
 FOREIGN KEY (id_vehiculo) REFERENCES vehiculo (id_vehiculo),
 FOREIGN KEY (codigo, id_estacionamiento) REFERENCES espacio (codigo, id_estacionamiento)
)
$$