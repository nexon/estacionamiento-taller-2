DROP TABLE IF EXISTS reputacion $$
CREATE TABLE reputaciones
(
 id_reputacion INT NOT NULL AUTO_INCREMENT,
 valor_cliente FLOAT NOT NULL,
 valor_estacionamiento FLOAT NOT NULL,
 fecha_hora DATETIME NOT NULL,
 id_cliente INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 PRIMARY KEY (id_reputacion),
 FOREIGN KEY (id_cliente) REFERENCES cliente (id_cliente),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento)
)
$$