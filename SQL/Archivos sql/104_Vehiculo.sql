DROP TABLE IF EXISTS vehiculo $$
CREATE TABLE vehiculo
(
 id_vehiculo INT NOT NULL AUTO_INCREMENT,
 patente VARCHAR(15) NOT NULL,
 id_conductor INT NOT NULL,
 PRIMARY KEY (id_vehiculo, patente),
 FOREIGN KEY (id_conductor) REFERENCES conductor (id_conductor)
)
$$