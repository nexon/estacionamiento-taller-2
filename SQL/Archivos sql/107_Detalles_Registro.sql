DROP TABLE IF EXISTS detalles_registro $$
CREATE TABLE detalles_registro
(
 id_empleado INT NOT NULL,
 id_registro INT NOT NULL,
 detalle VARCHAR(10) NOT NULL,
 FOREIGN KEY (id_empleado) REFERENCES empleados (id_empleado),
 FOREIGN KEY (id_registro) REFERENCES registros (id_registro)
)
$$
/* Detalle {Entrada/Salida) */