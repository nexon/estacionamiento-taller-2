-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bdtaller
-- ------------------------------------------------------
-- Server version	5.6.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientes` (
  `id_cliente` int(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` int(11) NOT NULL,
  `reputacion` float DEFAULT NULL,
  PRIMARY KEY (`id_cliente`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `clientes_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalles_estacionamiento`
--

DROP TABLE IF EXISTS `detalles_estacionamiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalles_estacionamiento` (
  `id_estacionamiento` int(11) NOT NULL,
  `id_palabra` int(11) NOT NULL,
  KEY `id_estacionamiento` (`id_estacionamiento`),
  KEY `id_palabra` (`id_palabra`),
  CONSTRAINT `detalles_estacionamiento_ibfk_1` FOREIGN KEY (`id_estacionamiento`) REFERENCES `estacionamientos` (`id_estacionamiento`),
  CONSTRAINT `detalles_estacionamiento_ibfk_2` FOREIGN KEY (`id_palabra`) REFERENCES `palabras_clave` (`id_palabra`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalles_estacionamiento`
--

LOCK TABLES `detalles_estacionamiento` WRITE;
/*!40000 ALTER TABLE `detalles_estacionamiento` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalles_estacionamiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalles_registro`
--

DROP TABLE IF EXISTS `detalles_registro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalles_registro` (
  `id_empleado` int(11) NOT NULL,
  `id_registro` int(11) NOT NULL,
  `detalle` varchar(10) NOT NULL,
  KEY `id_empleado` (`id_empleado`),
  KEY `id_registro` (`id_registro`),
  CONSTRAINT `detalles_registro_ibfk_1` FOREIGN KEY (`id_empleado`) REFERENCES `empleados` (`id_empleado`),
  CONSTRAINT `detalles_registro_ibfk_2` FOREIGN KEY (`id_registro`) REFERENCES `registros` (`id_registro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalles_registro`
--

LOCK TABLES `detalles_registro` WRITE;
/*!40000 ALTER TABLE `detalles_registro` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalles_registro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empleados` (
  `id_empleado` int(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` int(11) NOT NULL,
  `id_estacionamiento` int(11) NOT NULL,
  `propietario` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_empleado`),
  KEY `id_usuario` (`id_usuario`),
  KEY `id_estacionamiento` (`id_estacionamiento`),
  CONSTRAINT `empleados_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `empleados_ibfk_2` FOREIGN KEY (`id_estacionamiento`) REFERENCES `estacionamientos` (`id_estacionamiento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleados`
--

LOCK TABLES `empleados` WRITE;
/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estacionamientos`
--

DROP TABLE IF EXISTS `estacionamientos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estacionamientos` (
  `id_estacionamiento` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `direccion` varchar(45) NOT NULL,
  `capacidad` int(11) NOT NULL,
  `reputacion` float DEFAULT NULL,
  `cargo_fijo` int(11) NOT NULL,
  `cargo_minuto` int(11) NOT NULL,
  `cant_minutos` int(11) NOT NULL,
  PRIMARY KEY (`id_estacionamiento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estacionamientos`
--

LOCK TABLES `estacionamientos` WRITE;
/*!40000 ALTER TABLE `estacionamientos` DISABLE KEYS */;
/*!40000 ALTER TABLE `estacionamientos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estados`
--

DROP TABLE IF EXISTS `estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estados` (
  `id_estado` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`id_estado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados`
--

LOCK TABLES `estados` WRITE;
/*!40000 ALTER TABLE `estados` DISABLE KEYS */;
/*!40000 ALTER TABLE `estados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `palabras_clave`
--

DROP TABLE IF EXISTS `palabras_clave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `palabras_clave` (
  `id_palabra` int(11) NOT NULL AUTO_INCREMENT,
  `clave` varchar(45) NOT NULL,
  PRIMARY KEY (`id_palabra`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `palabras_clave`
--

LOCK TABLES `palabras_clave` WRITE;
/*!40000 ALTER TABLE `palabras_clave` DISABLE KEYS */;
/*!40000 ALTER TABLE `palabras_clave` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `promociones`
--

DROP TABLE IF EXISTS `promociones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `promociones` (
  `id_promo` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `descripcion` varchar(120) NOT NULL,
  `fecha_inicio` date NOT NULL,
  `fecha_termino` date NOT NULL,
  `id_estacionamiento` int(11) NOT NULL,
  PRIMARY KEY (`id_promo`),
  KEY `id_estacionamiento` (`id_estacionamiento`),
  CONSTRAINT `promociones_ibfk_1` FOREIGN KEY (`id_estacionamiento`) REFERENCES `estacionamientos` (`id_estacionamiento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `promociones`
--

LOCK TABLES `promociones` WRITE;
/*!40000 ALTER TABLE `promociones` DISABLE KEYS */;
/*!40000 ALTER TABLE `promociones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puntos_acceso`
--

DROP TABLE IF EXISTS `puntos_acceso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `puntos_acceso` (
  `id_punto_acceso` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `direccion` varchar(45) NOT NULL,
  `latitud` decimal(10,8) NOT NULL,
  `longitud` decimal(11,8) NOT NULL,
  `id_tipo` int(11) NOT NULL,
  `id_estacionamiento` int(11) NOT NULL,
  PRIMARY KEY (`id_punto_acceso`),
  KEY `id_estacionamiento` (`id_estacionamiento`),
  KEY `id_tipo` (`id_tipo`),
  CONSTRAINT `puntos_acceso_ibfk_1` FOREIGN KEY (`id_estacionamiento`) REFERENCES `estacionamientos` (`id_estacionamiento`),
  CONSTRAINT `puntos_acceso_ibfk_2` FOREIGN KEY (`id_tipo`) REFERENCES `tipos_punto_acceso` (`id_tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puntos_acceso`
--

LOCK TABLES `puntos_acceso` WRITE;
/*!40000 ALTER TABLE `puntos_acceso` DISABLE KEYS */;
/*!40000 ALTER TABLE `puntos_acceso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registros`
--

DROP TABLE IF EXISTS `registros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `registros` (
  `id_registro` int(11) NOT NULL AUTO_INCREMENT,
  `fecha_ingreso` datetime NOT NULL,
  `fecha_salida` datetime DEFAULT NULL,
  `monto_total` int(11) DEFAULT NULL,
  `id_estacionamiento` int(11) NOT NULL,
  `id_vehiculo` int(11) NOT NULL,
  PRIMARY KEY (`id_registro`),
  KEY `id_estacionamiento` (`id_estacionamiento`),
  KEY `id_vehiculo` (`id_vehiculo`),
  CONSTRAINT `registros_ibfk_1` FOREIGN KEY (`id_estacionamiento`) REFERENCES `estacionamientos` (`id_estacionamiento`),
  CONSTRAINT `registros_ibfk_2` FOREIGN KEY (`id_vehiculo`) REFERENCES `vehiculos` (`id_vehiculo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registros`
--

LOCK TABLES `registros` WRITE;
/*!40000 ALTER TABLE `registros` DISABLE KEYS */;
/*!40000 ALTER TABLE `registros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reputaciones`
--

DROP TABLE IF EXISTS `reputaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reputaciones` (
  `id_reputacion` int(11) NOT NULL AUTO_INCREMENT,
  `valor_cliente` float NOT NULL,
  `valor_estacionamiento` float NOT NULL,
  `fecha_hora` datetime NOT NULL,
  `id_cliente` int(11) NOT NULL,
  `id_estacionamiento` int(11) NOT NULL,
  PRIMARY KEY (`id_reputacion`),
  KEY `id_cliente` (`id_cliente`),
  KEY `id_estacionamiento` (`id_estacionamiento`),
  CONSTRAINT `reputaciones_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`),
  CONSTRAINT `reputaciones_ibfk_2` FOREIGN KEY (`id_estacionamiento`) REFERENCES `estacionamientos` (`id_estacionamiento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reputaciones`
--

LOCK TABLES `reputaciones` WRITE;
/*!40000 ALTER TABLE `reputaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `reputaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `slots`
--

DROP TABLE IF EXISTS `slots`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `slots` (
  `id_slot` int(11) NOT NULL AUTO_INCREMENT,
  `nombreSlot` varchar(15) DEFAULT NULL,
  `expiracion` datetime NOT NULL,
  `id_vehiculo` int(11) NOT NULL,
  `id_estacionamiento` int(11) NOT NULL,
  `id_estado` int(11) NOT NULL,
  PRIMARY KEY (`id_slot`),
  KEY `id_vehiculo` (`id_vehiculo`),
  KEY `id_estacionamiento` (`id_estacionamiento`),
  KEY `id_estado` (`id_estado`),
  CONSTRAINT `slots_ibfk_1` FOREIGN KEY (`id_vehiculo`) REFERENCES `vehiculos` (`id_vehiculo`),
  CONSTRAINT `slots_ibfk_2` FOREIGN KEY (`id_estacionamiento`) REFERENCES `estacionamientos` (`id_estacionamiento`),
  CONSTRAINT `slots_ibfk_3` FOREIGN KEY (`id_estado`) REFERENCES `estados` (`id_estado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `slots`
--

LOCK TABLES `slots` WRITE;
/*!40000 ALTER TABLE `slots` DISABLE KEYS */;
/*!40000 ALTER TABLE `slots` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_punto_acceso`
--

DROP TABLE IF EXISTS `tipos_punto_acceso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_punto_acceso` (
  `id_tipo` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`id_tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_punto_acceso`
--

LOCK TABLES `tipos_punto_acceso` WRITE;
/*!40000 ALTER TABLE `tipos_punto_acceso` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipos_punto_acceso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `rut` varchar(15) DEFAULT NULL,
  `contrasenia` varchar(45) NOT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehiculos`
--

DROP TABLE IF EXISTS `vehiculos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vehiculos` (
  `id_vehiculo` int(11) NOT NULL AUTO_INCREMENT,
  `patente` varchar(15) NOT NULL,
  `id_cliente` int(11) NOT NULL,
  PRIMARY KEY (`id_vehiculo`,`patente`),
  KEY `id_cliente` (`id_cliente`),
  CONSTRAINT `vehiculos_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehiculos`
--

LOCK TABLES `vehiculos` WRITE;
/*!40000 ALTER TABLE `vehiculos` DISABLE KEYS */;
/*!40000 ALTER TABLE `vehiculos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-09-07 18:21:36
