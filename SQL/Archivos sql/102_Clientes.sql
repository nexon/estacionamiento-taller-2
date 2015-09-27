DROP TABLE IF EXISTS clientes $$
CREATE TABLE clientes
(
 id_cliente INT NOT NULL AUTO_INCREMENT,
 id_usuario INT NOT NULL,
 reputacion FLOAT,
 PRIMARY KEY (id_cliente),
 FOREIGN KEY (id_usuario) REFERENCES usuarios (id_usuario)
)
$$