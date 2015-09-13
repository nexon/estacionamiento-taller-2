DROP TABLE IF EXISTS vehiculos $$
CREATE TABLE vehiculos
(
 id_vehiculo INT NOT NULL AUTO_INCREMENT,
 patente VARCHAR(15) NOT NULL,
 id_cliente INT NOT NULL,
 PRIMARY KEY (id_vehiculo, patente),
 FOREIGN KEY (id_cliente) REFERENCES clientes (id_cliente)
)
$$