DROP TABLE IF EXISTS vehiculo $$
CREATE TABLE vehiculo
(
 patente VARCHAR(15) NOT NULL,
 id_conductor INT NOT NULL,
 PRIMARY KEY (patente),
 FOREIGN KEY (id_conductor) REFERENCES conductor (id_conductor)
)
$$