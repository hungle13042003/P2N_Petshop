-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: 157.119.251.140    Database: p2n_pet
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `age`
--

DROP TABLE IF EXISTS `age`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `age` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `orderview` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `age`
--

LOCK TABLES `age` WRITE;
/*!40000 ALTER TABLE `age` DISABLE KEYS */;
INSERT INTO `age` VALUES (1,'1-3 tháng',1,10,1,'2021-12-16 20:51:40',1,'2021-12-16 20:51:40'),(2,'4 - 6 tháng',2,10,1,'2021-12-16 20:53:25',1,'2021-12-16 20:53:25'),(3,'7 - 9 tháng',3,10,1,'2021-12-16 20:53:38',1,'2021-12-16 20:53:38'),(4,'10 - 12 tháng',4,10,1,'2021-12-16 20:53:54',1,'2021-12-16 20:53:54'),(5,'1 năm',5,10,1,'2021-12-16 20:54:05',1,'2021-12-16 20:54:05'),(6,'2 năm',6,10,1,'2021-12-16 20:54:14',1,'2021-12-16 20:54:14'),(7,'3 năm',7,10,1,'2021-12-16 20:54:23',1,'2021-12-16 20:54:23'),(8,'4 năm',8,10,1,'2021-12-16 20:54:30',1,'2021-12-16 20:54:30'),(9,'5 năm',9,10,1,'2021-12-16 20:54:37',1,'2021-12-16 20:54:37'),(10,'6 năm',10,10,1,'2021-12-16 20:54:46',1,'2021-12-16 20:54:46'),(11,'7 năm',11,10,1,'2021-12-16 20:54:54',1,'2021-12-16 20:54:54'),(12,'8 năm',12,10,1,'2021-12-16 20:55:01',1,'2021-12-16 20:55:01'),(13,'9 năm',13,10,1,'2021-12-16 20:55:07',1,'2021-12-16 20:55:07'),(14,'10 năm',14,10,1,'2021-12-16 20:55:15',1,'2021-12-16 20:55:15');
/*!40000 ALTER TABLE `age` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `brand`
--

DROP TABLE IF EXISTS `brand`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brand` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `phone` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `address` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brand`
--

LOCK TABLES `brand` WRITE;
/*!40000 ALTER TABLE `brand` DISABLE KEYS */;
INSERT INTO `brand` VALUES (1,'0123456789','thuduc@p2npet.com','02, Đặng Văn Bi, TP. Thủ Đức, HCM',10,1,'2022-04-24 18:03:59',1,'2022-06-24 14:43:24'),(2,'0987654321','binhthanh@p2npet.com','142-145, đường D2, Quận Bình Thạnh, HCM',190,1,'2022-04-24 18:07:30',1,'2022-04-24 19:19:19'),(3,'0987654321','binhthanh@p2npet.com','142-145, đường D2, Quận Bình Thạnh, HCM',10,1,'2022-04-24 18:15:49',1,'2022-04-24 18:15:49'),(4,'5555590900','quan2@p2npet.com','HCM',190,1,'2022-04-24 19:16:50',1,'2022-06-15 11:13:18'),(5,'0999888777','chinhanh4@pet.vn','Làng Đại học Thủ Đức',10,1,'2022-06-13 11:08:33',1,'2022-06-15 11:04:50'),(6,'0333355555','chinhanh5@gmail.com','Lê Văn Việt, Quận 9',10,1,'2022-06-14 15:06:11',1,'2022-06-15 11:02:45');
/*!40000 ALTER TABLE `brand` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `brandproduct`
--

DROP TABLE IF EXISTS `brandproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brandproduct` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `brandid` bigint unsigned DEFAULT NULL,
  `productdetailid` bigint unsigned DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brandproduct`
--

LOCK TABLES `brandproduct` WRITE;
/*!40000 ALTER TABLE `brandproduct` DISABLE KEYS */;
INSERT INTO `brandproduct` VALUES (1,2,1,2,10,1,'2022-04-24 18:07:30',1,'2022-04-24 18:07:30'),(2,3,1,2,10,1,'2022-04-24 18:15:49',1,'2022-04-24 18:15:49'),(3,4,1,2,10,1,'2022-04-24 19:16:50',1,'2022-04-24 19:16:50'),(4,1,1,4,10,1,'2022-04-24 19:18:21',1,'2022-06-24 14:43:24'),(5,1,2,3,10,1,'2022-04-24 19:18:21',1,'2022-06-24 14:43:24'),(6,6,20,5,10,1,'2022-06-14 15:06:11',1,'2022-06-15 11:02:45'),(7,6,27,10,10,1,'2022-06-14 15:06:11',1,'2022-06-15 11:02:45'),(8,6,35,10,10,1,'2022-06-15 11:02:45',1,'2022-06-15 11:02:45'),(9,5,9,10,10,1,'2022-06-15 11:04:50',1,'2022-06-15 11:04:50'),(10,1,39,5,10,1,'2022-06-24 14:43:24',1,'2022-06-24 14:43:24'),(11,1,40,5,10,1,'2022-06-24 14:43:24',1,'2022-06-24 14:43:24'),(12,5,43,10,10,1,'2022-06-28 11:34:12',1,'2022-06-28 11:34:12'),(13,6,43,20,10,1,'2022-06-28 11:34:12',1,'2022-06-28 11:34:12');
/*!40000 ALTER TABLE `brandproduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `breed`
--

DROP TABLE IF EXISTS `breed`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `breed` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `breedid` bigint unsigned DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `breedid` (`breedid`),
  CONSTRAINT `breed_ibfk_1` FOREIGN KEY (`breedid`) REFERENCES `breed` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `breed`
--

LOCK TABLES `breed` WRITE;
/*!40000 ALTER TABLE `breed` DISABLE KEYS */;
INSERT INTO `breed` VALUES (1,'Chó',1,10,1,'2021-12-16 20:35:37',1,'2021-12-16 20:35:37'),(2,'Mèo',2,10,1,'2021-12-16 20:35:37',1,'2021-12-16 20:35:37'),(3,'Chó Husky Sibir',1,10,1,'2021-12-16 21:09:28',1,'2021-12-16 21:14:46'),(4,'Chó Bulldog Pháp',1,10,1,'2021-12-16 21:10:18',1,'2021-12-16 21:14:38'),(5,'Chó Pitbull',1,10,1,'2021-12-16 21:12:02',1,'2021-12-16 21:15:15'),(6,'Chó Shiba Inu',1,10,1,'2021-12-16 21:12:56',1,'2021-12-16 21:15:30'),(7,'Chó Poodle Tiny',1,10,1,'2021-12-16 21:13:53',1,'2021-12-16 21:15:23'),(8,'Chó Phú Quốc',1,10,1,'2021-12-16 21:15:07',1,'2021-12-16 21:15:07'),(9,'Mèo Anh lông ngắn',2,10,1,'2021-12-16 21:16:09',1,'2021-12-16 21:17:26'),(10,'Mèo Anh lông dài',2,10,1,'2021-12-16 21:16:39',1,'2021-12-16 21:17:13'),(11,'Mèo Ba Tư',2,10,1,'2021-12-16 21:16:46',1,'2021-12-16 21:17:20'),(12,'Mèo Bengal',2,10,1,'2021-12-16 21:17:07',1,'2021-12-16 21:17:07'),(13,'Mèo Munchkin',2,10,1,'2021-12-16 21:18:27',1,'2021-12-16 21:18:27'),(14,'Mèo tam thể',2,10,1,'2021-12-16 21:19:24',1,'2021-12-16 21:19:33'),(15,'Thỏ',15,10,1,'2021-12-17 22:35:26',1,'2021-12-17 22:35:26'),(16,'Chuột',16,10,1,'2021-12-17 22:35:41',1,'2021-12-17 22:35:41'),(17,'Nhím',17,10,1,'2021-12-17 22:35:56',1,'2021-12-17 22:35:56'),(18,'Chuột Hamster',16,10,1,'2021-12-17 22:37:41',1,'2021-12-17 22:37:41'),(19,'Nhím kiểng',17,10,1,'2021-12-17 22:41:49',1,'2021-12-17 22:41:49'),(20,'Thỏ Angora',15,10,1,'2021-12-17 22:45:22',1,'2021-12-17 22:45:22');
/*!40000 ALTER TABLE `breed` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cart`
--

DROP TABLE IF EXISTS `cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `userid` bigint unsigned DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart`
--

LOCK TABLES `cart` WRITE;
/*!40000 ALTER TABLE `cart` DISABLE KEYS */;
INSERT INTO `cart` VALUES (1,6,10,6,'2021-12-19 14:11:47',6,'2021-12-19 14:11:47'),(2,7,10,7,'2021-12-26 16:48:12',7,'2021-12-26 16:48:12'),(3,1,10,1,'2022-01-02 20:21:25',1,'2022-01-02 20:21:25'),(4,20,10,20,'2022-01-02 20:23:05',20,'2022-01-02 20:23:05'),(5,19,10,19,'2022-01-02 20:31:51',19,'2022-01-02 20:31:51'),(6,17,10,17,'2022-01-02 20:56:02',17,'2022-01-02 20:56:02'),(7,18,10,18,'2022-01-02 21:40:51',18,'2022-01-02 21:40:51'),(8,16,10,16,'2022-01-02 22:16:24',16,'2022-01-02 22:16:24'),(9,8,10,8,'2022-01-02 22:30:05',8,'2022-01-02 22:30:05'),(10,24,10,24,'2022-01-02 23:33:58',24,'2022-01-02 23:33:58'),(11,13,10,13,'2022-01-06 21:31:17',13,'2022-01-06 21:31:17'),(12,11,10,11,'2022-01-06 21:39:03',11,'2022-01-06 21:39:03'),(13,4,10,4,'2022-05-05 19:07:56',4,'2022-05-05 19:07:56'),(14,25,10,25,'2022-05-15 00:16:35',25,'2022-05-15 00:16:35'),(15,34,10,34,'2022-06-04 08:15:00',34,'2022-06-04 08:15:00');
/*!40000 ALTER TABLE `cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cartitem`
--

DROP TABLE IF EXISTS `cartitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cartitem` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `cartid` bigint unsigned DEFAULT NULL,
  `productdetailid` bigint unsigned DEFAULT NULL,
  `orderid` bigint unsigned DEFAULT NULL,
  `brandid` bigint unsigned DEFAULT NULL,
  `pricediscount` float DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=143 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartitem`
--

LOCK TABLES `cartitem` WRITE;
/*!40000 ALTER TABLE `cartitem` DISABLE KEYS */;
INSERT INTO `cartitem` VALUES (1,1,1,1,NULL,5040000,1,10,6,'2021-12-19 14:14:29',6,'2021-12-26 10:22:56'),(2,1,2,1,NULL,13800000,1,10,6,'2021-12-19 14:15:56',6,'2021-12-26 09:24:31'),(3,2,2,2,NULL,13800000,1,10,7,'2021-12-26 16:50:30',7,'2021-12-26 16:50:30'),(4,2,3,2,NULL,5520000,1,10,7,'2021-12-26 16:51:14',7,'2021-12-26 16:51:14'),(5,3,20,27,NULL,2275000,1,10,1,'2022-01-02 20:21:25',1,'2022-05-15 05:37:13'),(6,4,13,3,NULL,18700000,1,10,20,'2022-01-02 20:23:05',20,'2022-01-02 20:23:48'),(7,4,5,4,NULL,5225000,1,10,20,'2022-01-02 20:25:53',20,'2022-01-02 20:27:06'),(8,5,4,5,NULL,8500000,1,10,19,'2022-01-02 20:31:51',19,'2022-01-02 20:32:35'),(9,5,21,6,NULL,1116000,1,10,19,'2022-01-02 20:40:43',19,'2022-01-02 20:41:42'),(10,6,29,7,NULL,11400000,1,10,17,'2022-01-02 20:56:02',17,'2022-01-02 20:56:43'),(11,6,14,8,NULL,14725000,1,10,17,'2022-01-02 20:57:27',17,'2022-01-02 20:58:05'),(12,7,10,9,NULL,9660000,1,10,18,'2022-01-02 21:40:51',18,'2022-01-02 21:42:10'),(13,7,9,10,NULL,11500000,1,10,18,'2022-01-02 21:43:30',18,'2022-01-02 21:44:11'),(14,7,22,11,NULL,13340000,1,10,18,'2022-01-02 21:44:32',18,'2022-01-02 21:58:58'),(15,7,2,11,NULL,13800000,1,10,18,'2022-01-02 21:44:37',18,'2022-01-02 21:58:58'),(16,7,35,NULL,NULL,2816000,1,190,18,'2022-01-02 21:44:45',18,'2022-01-02 21:58:05'),(17,7,20,NULL,NULL,2275000,1,190,18,'2022-01-02 21:44:56',18,'2022-01-02 21:50:30'),(18,3,11,26,NULL,6600000,2,10,1,'2022-01-02 21:45:23',1,'2022-02-02 15:08:32'),(19,7,11,NULL,NULL,6600000,1,190,18,'2022-01-02 21:45:57',18,'2022-01-02 21:58:02'),(20,7,34,NULL,NULL,2185000,1,190,18,'2022-01-02 21:50:52',18,'2022-01-02 21:58:01'),(21,7,19,NULL,NULL,1020000,1,190,18,'2022-01-02 21:50:57',18,'2022-01-02 21:58:00'),(22,8,27,12,NULL,8100000,1,10,16,'2022-01-02 22:16:24',16,'2022-01-02 22:17:52'),(23,8,11,13,NULL,6600000,1,10,16,'2022-01-02 22:18:40',16,'2022-01-02 22:19:19'),(24,8,19,14,NULL,1020000,1,10,16,'2022-01-02 22:22:37',16,'2022-01-02 22:23:30'),(25,8,15,14,NULL,6720000,1,10,16,'2022-01-02 22:22:44',16,'2022-01-02 22:23:30'),(26,8,27,15,NULL,8100000,1,10,16,'2022-01-02 22:26:17',16,'2022-01-02 22:27:03'),(27,9,10,16,NULL,9660000,1,10,8,'2022-01-02 22:30:05',8,'2022-01-02 22:31:10'),(28,10,3,17,NULL,5520000,1,10,24,'2022-01-02 23:33:58',24,'2022-01-02 23:38:19'),(29,3,4,26,NULL,8500000,1,10,1,'2022-01-04 15:24:36',1,'2022-02-02 15:08:32'),(30,5,30,18,NULL,7520000,1,10,19,'2022-01-06 21:20:16',19,'2022-01-06 21:21:14'),(31,5,22,19,NULL,13340000,1,10,19,'2022-01-06 21:22:02',19,'2022-01-06 21:27:44'),(32,5,9,20,NULL,11500000,1,10,19,'2022-01-06 21:28:21',19,'2022-01-06 21:29:02'),(33,11,33,21,NULL,3600000,1,10,13,'2022-01-06 21:31:17',13,'2022-01-06 21:32:19'),(34,11,24,NULL,NULL,5915000,1,190,13,'2022-01-06 21:33:29',13,'2022-01-06 21:33:42'),(35,11,27,22,NULL,8100000,1,10,13,'2022-01-06 21:33:54',13,'2022-01-06 21:34:42'),(36,11,7,23,NULL,12600000,1,10,13,'2022-01-06 21:37:11',13,'2022-01-06 21:37:59'),(37,12,19,24,NULL,1020000,1,10,11,'2022-01-06 21:39:03',11,'2022-01-06 21:39:51'),(38,12,18,25,NULL,4320000,1,10,11,'2022-01-06 21:40:29',11,'2022-01-06 21:41:12'),(39,12,30,NULL,NULL,7520000,1,10,11,'2022-01-06 21:45:13',11,'2022-01-06 21:45:13'),(40,13,5,NULL,NULL,5225000,0,190,4,'2022-05-05 19:07:56',1,'2022-06-10 17:42:33'),(41,13,10,NULL,NULL,9660000,3,10,4,'2022-05-05 19:09:44',4,'2022-05-05 19:12:56'),(42,3,7,27,NULL,12600000,2,10,1,'2022-05-13 01:03:06',1,'2022-05-15 05:37:13'),(43,3,7,27,NULL,12600000,2,10,1,'2022-05-13 01:03:24',1,'2022-05-15 05:37:13'),(44,3,11,27,NULL,6600000,3,10,1,'2022-05-13 01:06:31',1,'2022-05-15 05:37:13'),(45,3,15,27,NULL,6720000,3,10,1,'2022-05-13 01:10:10',1,'2022-05-15 05:37:13'),(46,3,13,27,NULL,18700000,1,10,1,'2022-05-13 09:15:25',1,'2022-05-15 05:37:13'),(47,14,15,NULL,NULL,6720000,2,10,25,'2022-05-15 00:16:35',25,'2022-05-15 00:16:35'),(52,3,19,28,1,1020000,1,10,1,'2022-05-15 05:47:21',1,'2022-05-15 05:47:48'),(53,3,4,29,1,8500000,1,10,1,'2022-05-15 05:53:04',1,'2022-05-15 05:53:41'),(54,3,19,30,1,1020000,1,10,1,'2022-05-15 05:56:03',1,'2022-05-15 05:57:41'),(55,3,35,31,1,2816000,1,10,1,'2022-05-15 06:03:55',1,'2022-05-15 06:04:33'),(56,3,25,32,1,17600000,1,10,1,'2022-05-15 06:05:13',1,'2022-05-15 06:05:25'),(57,3,25,33,1,17600000,2,10,1,'2022-05-15 06:09:29',1,'2022-05-15 06:09:37'),(58,3,25,34,1,17600000,2,10,1,'2022-05-15 06:11:17',1,'2022-05-15 06:11:26'),(59,3,34,35,1,2185000,1,10,1,'2022-05-15 06:13:34',1,'2022-05-15 06:13:40'),(60,3,34,36,1,2185000,1,10,1,'2022-05-15 06:15:32',1,'2022-05-15 06:15:35'),(61,3,26,37,1,5720000,1,10,1,'2022-05-15 06:16:17',1,'2022-05-15 06:16:56'),(62,3,35,38,1,2816000,1,10,1,'2022-05-15 06:22:53',1,'2022-05-15 06:23:11'),(63,3,32,39,1,4700000,1,10,1,'2022-05-15 06:26:19',1,'2022-05-15 07:21:45'),(64,3,19,39,1,1020000,1,10,1,'2022-05-15 06:26:35',1,'2022-05-15 07:21:45'),(65,3,4,39,1,8500000,1,10,1,'2022-05-15 07:20:59',1,'2022-05-15 07:21:45'),(66,3,26,41,1,5720000,1,10,1,'2022-05-15 07:24:43',1,'2022-05-15 07:31:42'),(67,3,12,41,1,10800000,1,10,1,'2022-05-15 07:30:57',1,'2022-05-15 07:31:42'),(68,3,7,42,1,12600000,1,10,1,'2022-05-15 08:15:15',1,'2022-05-15 08:19:32'),(69,3,35,42,1,2816000,3,10,1,'2022-05-15 08:16:06',1,'2022-05-15 08:19:32'),(70,3,4,43,1,8500000,1,10,1,'2022-05-15 08:20:32',1,'2022-05-15 10:10:46'),(71,3,26,43,1,5720000,2,10,1,'2022-05-15 08:26:47',1,'2022-05-15 10:10:46'),(72,3,20,43,1,2275000,1,10,1,'2022-05-15 08:27:07',1,'2022-05-15 10:10:46'),(73,3,1,43,1,5040000,1,10,1,'2022-05-15 08:27:26',1,'2022-05-15 10:10:46'),(74,3,4,44,1,8500000,1,10,1,'2022-05-15 10:17:06',1,'2022-05-15 10:33:09'),(75,3,27,44,1,8100000,1,10,1,'2022-05-15 10:32:18',1,'2022-05-15 10:33:09'),(76,3,33,79,1,3600000,1,10,1,'2022-05-17 23:24:22',1,'2022-06-12 17:59:52'),(77,3,19,45,1,1020000,2,10,1,'2022-05-17 23:26:03',1,'2022-05-28 21:16:38'),(78,3,29,NULL,1,11400000,3,190,1,'2022-05-18 09:58:39',1,'2022-05-20 01:35:17'),(79,3,5,61,1,5225000,1,10,1,'2022-05-18 09:58:47',1,'2022-06-10 17:42:33'),(80,3,34,65,1,2185000,1,10,1,'2022-05-20 00:59:57',1,'2022-06-12 14:43:15'),(81,3,4,72,1,8500000,1,10,1,'2022-05-20 01:15:00',1,'2022-06-12 16:27:57'),(82,3,15,NULL,1,6720000,1,190,1,'2022-05-20 01:35:01',1,'2022-05-20 01:35:24'),(83,3,17,NULL,1,5390000,1,190,1,'2022-05-20 01:38:01',1,'2022-05-20 01:38:14'),(84,3,35,53,1,2816000,1,10,1,'2022-05-20 02:06:56',1,'2022-06-01 16:33:23'),(85,3,35,NULL,1,2816000,1,190,1,'2022-05-20 02:06:54',1,'2022-05-20 02:07:02'),(88,13,8,NULL,1,3600000,1,10,4,'2022-05-30 23:35:41',4,'2022-05-30 23:35:41'),(89,3,24,51,1,5915000,1,10,1,'2022-05-30 23:40:33',1,'2022-05-31 01:02:43'),(90,3,26,46,1,5720000,1,10,1,'2022-05-30 23:40:49',1,'2022-05-30 23:58:43'),(91,3,22,46,1,13340000,3,10,1,'2022-05-30 23:42:03',1,'2022-05-30 23:58:43'),(92,3,6,47,1,10625000,1,10,1,'2022-05-31 00:00:04',1,'2022-05-31 00:30:45'),(93,3,13,48,1,18700000,1,10,1,'2022-05-31 00:31:02',1,'2022-05-31 00:36:06'),(94,3,1,49,1,5040000,1,10,1,'2022-05-31 00:50:18',1,'2022-05-31 00:50:30'),(95,3,20,50,1,2275000,1,10,1,'2022-05-31 00:58:19',1,'2022-05-31 00:58:59'),(96,3,26,52,1,5720000,1,10,1,'2022-05-31 09:55:46',1,'2022-05-31 10:02:25'),(97,3,26,53,1,5720000,1,10,1,'2022-05-31 16:19:27',1,'2022-06-01 16:33:23'),(98,3,8,NULL,NULL,3600000,1,190,1,'2022-06-01 09:59:14',1,'2022-06-01 09:59:21'),(99,3,6,53,1,10625000,1,10,1,'2022-06-01 16:32:19',1,'2022-06-01 16:33:23'),(100,3,6,53,1,10625000,1,10,1,'2022-06-01 16:32:22',1,'2022-06-01 16:33:23'),(101,3,7,NULL,1,12600000,1,190,1,'2022-06-02 13:25:58',1,'2022-06-04 09:13:27'),(102,3,13,54,1,18700000,2,10,1,'2022-06-02 17:04:47',1,'2022-06-04 05:22:38'),(103,3,23,NULL,1,5520000,3,190,1,'2022-06-03 00:12:13',1,'2022-06-04 02:57:34'),(104,3,12,54,1,10800000,2,10,1,'2022-06-03 23:57:43',1,'2022-06-04 05:22:38'),(105,3,2,54,1,13800000,2,10,1,'2022-06-04 05:20:58',1,'2022-06-04 05:22:38'),(106,15,6,55,1,10625000,1,190,34,'2022-06-04 08:15:00',34,'2022-06-04 08:27:19'),(107,15,13,NULL,1,18700000,1,190,34,'2022-06-04 08:27:09',34,'2022-06-04 08:27:31'),(108,3,1,60,1,5040000,1,10,1,'2022-06-04 09:12:38',1,'2022-06-10 16:14:28'),(109,3,13,58,1,18700000,2,10,1,'2022-06-04 09:14:12',1,'2022-06-06 10:40:56'),(110,3,6,56,1,10625000,1,190,1,'2022-06-04 09:21:03',1,'2022-06-04 09:23:36'),(111,3,6,57,1,10625000,3,10,1,'2022-06-04 09:24:24',1,'2022-06-05 09:07:17'),(112,3,19,57,1,1020000,1,10,1,'2022-06-05 09:02:24',1,'2022-06-05 09:07:17'),(113,3,6,59,1,10625000,2,10,1,'2022-06-07 20:46:13',1,'2022-06-10 15:45:08'),(114,3,6,77,1,10625000,1,10,1,'2022-06-07 20:46:09',1,'2022-06-12 17:52:58'),(115,3,13,62,NULL,18700000,1,10,1,'2022-06-10 17:53:01',1,'2022-06-10 17:58:31'),(116,3,13,63,NULL,18700000,1,10,1,'2022-06-10 18:05:05',1,'2022-06-11 16:05:47'),(117,3,1,64,NULL,5040000,5,10,1,'2022-06-11 19:02:13',1,'2022-06-11 19:03:35'),(118,3,1,NULL,NULL,5040000,1,190,1,'2022-06-12 13:47:21',1,'2022-06-12 14:35:28'),(119,3,19,66,NULL,1020000,1,10,1,'2022-06-12 14:44:37',1,'2022-06-12 14:45:36'),(120,3,19,68,NULL,1020000,1,10,1,'2022-06-12 14:56:55',1,'2022-06-12 15:00:02'),(121,3,19,69,NULL,1020000,1,10,1,'2022-06-12 15:09:05',1,'2022-06-12 15:10:47'),(122,3,19,70,NULL,1020000,1,10,1,'2022-06-12 15:42:56',1,'2022-06-12 15:43:53'),(123,3,19,71,NULL,1020000,1,10,1,'2022-06-12 16:24:04',1,'2022-06-12 16:24:43'),(124,3,4,73,NULL,8500000,1,10,1,'2022-06-12 16:28:56',1,'2022-06-12 17:10:01'),(125,3,34,74,NULL,2185000,1,10,1,'2022-06-12 17:23:56',1,'2022-06-12 17:24:17'),(126,3,34,75,NULL,2185000,1,10,1,'2022-06-12 17:28:11',1,'2022-06-12 17:28:29'),(127,3,4,76,NULL,8500000,1,10,1,'2022-06-12 17:30:22',1,'2022-06-12 17:30:39'),(128,3,21,78,NULL,1116000,1,10,1,'2022-06-12 17:59:07',1,'2022-06-12 17:59:23'),(129,3,34,80,NULL,2185000,1,10,1,'2022-06-12 18:29:23',1,'2022-06-12 18:30:04'),(130,3,34,81,NULL,2185000,1,10,1,'2022-06-12 22:49:55',1,'2022-06-12 22:57:57'),(131,3,34,82,NULL,2185000,1,10,1,'2022-06-12 23:02:02',1,'2022-06-12 23:02:21'),(132,3,34,83,NULL,2185000,1,10,1,'2022-06-12 23:04:30',1,'2022-06-12 23:04:46'),(133,3,19,84,NULL,1020000,1,10,1,'2022-06-13 10:44:10',1,'2022-06-13 10:44:47'),(134,3,19,85,NULL,1020000,1,10,1,'2022-06-13 11:38:16',1,'2022-06-13 11:38:58'),(135,3,9,86,NULL,11500000,1,10,1,'2022-06-13 15:27:14',1,'2022-06-13 15:27:58'),(136,3,19,87,NULL,1020000,1,10,1,'2022-06-13 22:08:43',1,'2022-06-13 22:10:04'),(137,3,19,88,NULL,1020000,1,10,1,'2022-06-14 02:03:46',1,'2022-06-14 02:09:57'),(138,3,34,89,NULL,2185000,1,10,1,'2022-06-14 02:25:30',1,'2022-06-14 08:57:24'),(139,3,4,89,NULL,8500000,1,10,1,'2022-06-14 08:56:28',1,'2022-06-14 08:57:24'),(140,3,6,90,NULL,10625000,1,10,1,'2022-06-14 08:58:25',1,'2022-06-14 08:59:13'),(141,3,21,91,NULL,1116000,1,10,1,'2022-06-14 15:46:34',1,'2022-06-21 00:38:08'),(142,3,19,NULL,NULL,1020000,1,10,1,'2022-06-21 00:53:36',1,'2022-06-21 00:53:36');
/*!40000 ALTER TABLE `cartitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `categoryrootid` int DEFAULT NULL,
  `typeproductid` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (5,'Thức ăn cho Hamster',5,20,10,1,'2022-04-24 17:45:59',1,'2022-04-24 17:53:47'),(6,'Thức ăn cho Mèo',6,20,10,1,'2022-04-24 17:46:21',1,'2022-04-24 17:46:21'),(7,'Thức ăn cho Nhím Kiểng',7,20,10,1,'2022-04-24 17:47:34',1,'2022-04-24 17:47:34'),(8,'Thức ăn cho Chó',8,20,10,1,'2022-04-24 17:54:11',1,'2022-04-24 17:54:11'),(9,'Thức ăn cho Thỏ',9,20,10,1,'2022-04-24 17:54:38',1,'2022-04-24 17:54:38'),(10,'Phụ kiện nuôi Chó',10,30,10,1,'2022-05-22 21:39:25',1,'2022-05-22 21:39:25'),(11,'Thức ăn nuôi mèo',11,30,190,1,'2022-05-22 21:39:25',1,'2022-05-22 21:39:25'),(12,'Phụ kiện nuôi Mèo',12,30,10,1,'2022-05-22 21:40:41',1,'2022-05-22 21:40:41'),(13,'Phụ kiện nuôi Nhím Kiểng',13,30,10,1,'2022-05-22 21:40:56',1,'2022-05-22 21:40:56'),(14,'Phụ kiện nuôi Hamster',14,30,10,1,'2022-05-22 21:42:53',1,'2022-05-22 21:42:53'),(15,'Phụ kiện nuôi Thỏ',15,30,10,1,'2022-05-22 21:43:07',1,'2022-05-22 21:43:07'),(16,'Chuồng/ Lồng nuôi Chó',10,30,10,1,'2022-05-22 21:52:55',1,'2022-05-22 21:52:55'),(17,'Chuồng/ Lồng nuôi Mèo',12,30,10,1,'2022-05-22 21:53:01',1,'2022-05-22 21:53:01'),(18,'Chuồng/ Lồng nuôi Hamster',14,30,10,1,'2022-05-22 21:53:11',1,'2022-05-22 21:53:11'),(19,'Chuồng/ Lồng nuôi Nhím Kiểng',13,30,10,1,'2022-05-22 21:53:22',1,'2022-05-22 21:53:22'),(20,'Chuồng/ Lồng nuôi Thỏ',15,30,10,1,'2022-05-22 21:53:30',1,'2022-05-22 21:53:30'),(21,'Combo Bánh mài răng cho Hamster',5,20,10,1,'2022-05-22 21:56:43',1,'2022-05-22 21:56:43'),(22,'Hạt hướng dương',5,20,10,1,'2022-05-22 21:57:00',1,'2022-05-22 21:57:00'),(23,'Thức ăn Hamster hải sản Nhật tôm khô cá khô',5,20,10,1,'2022-05-22 21:57:51',1,'2022-05-22 21:57:51'),(24,'Bánh mài răng vị sữa',5,20,10,1,'2022-05-22 21:58:31',1,'2022-05-22 21:58:31'),(25,'Bánh mài răng vị dâu',5,20,10,1,'2022-05-22 21:58:58',1,'2022-05-22 21:58:58'),(26,'Táo đỏ sấy khô',5,20,10,1,'2022-05-22 21:59:23',1,'2022-05-22 21:59:23'),(27,'Hạt kê nguyên chùm',5,20,10,1,'2022-05-22 21:59:40',1,'2022-05-22 21:59:40'),(28,'Pate vị cá ngừ',6,20,190,1,'2022-05-22 22:01:01',1,'2022-06-02 09:22:29'),(29,'Pate vị cá thu',6,20,10,1,'2022-05-22 22:02:28',1,'2022-05-22 22:02:28'),(30,'Pate vị cá trích cho mèo trưởng thành',6,20,10,1,'2022-05-22 22:02:46',1,'2022-05-22 22:02:46'),(31,'Bột ăn dặm cho mèo con',6,20,10,1,'2022-05-22 22:03:24',1,'2022-05-22 22:03:24'),(32,'Sâu Canxi',7,20,10,1,'2022-05-24 04:21:38',1,'2022-05-24 04:21:38'),(33,'Sâu gạo sấy khô ',7,20,10,1,'2022-05-24 04:24:04',1,'2022-05-24 04:24:04'),(34,'Cám Nhím dạng bịch',7,20,10,1,'2022-05-24 04:24:43',1,'2022-05-24 04:24:43'),(35,'Bộ kiềm tỉa móng',10,30,10,1,'2022-05-28 19:46:25',1,'2022-05-28 19:46:25');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chatcontent`
--

DROP TABLE IF EXISTS `chatcontent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chatcontent` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `chatroomid` bigint unsigned DEFAULT NULL,
  `userid` bigint unsigned DEFAULT NULL,
  `content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `isnew` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chatcontent`
--

LOCK TABLES `chatcontent` WRITE;
/*!40000 ALTER TABLE `chatcontent` DISABLE KEYS */;
INSERT INTO `chatcontent` VALUES (1,1,5,'Hông đã lắm nha!',1,10,4,'2022-03-27 15:55:47',4,'2022-03-27 16:02:14'),(2,1,24,'Đây là khách hàng!',1,10,24,'2022-03-27 18:58:21',24,'2022-03-27 18:58:21'),(4,1,24,'Đói bụng quá đi',1,10,24,'2022-03-27 19:09:09',24,'2022-03-27 19:09:09'),(5,1,5,'Kệ nha bro',1,10,4,'2022-03-27 19:10:41',4,'2022-03-27 19:10:41'),(6,2,20,'Mới nha bro',1,10,20,'2022-03-27 19:12:22',20,'2022-03-27 19:12:22'),(7,3,19,'Đói quá đi',1,10,19,'2022-03-27 19:25:32',19,'2022-03-27 19:25:32'),(8,4,18,'Bàn ủi hơi nước',1,10,18,'2022-03-27 19:34:36',18,'2022-03-27 19:34:36'),(9,1,5,'Đã cập nhật rồi nha',1,10,4,'2022-04-07 17:22:45',4,'2022-04-05 17:23:56'),(10,5,4,'Chat thôi nào!',1,190,4,'2022-05-08 12:42:03',4,'2022-05-08 15:37:30'),(11,5,4,'Chat thôi nào lần 2!',1,10,4,'2022-05-08 12:43:17',4,'2022-05-08 12:43:17'),(12,5,2,'Đây là người quản lý',1,10,1,'2022-05-08 14:02:11',1,'2022-05-08 14:02:11'),(13,5,1,'Đây nè ba',1,10,1,'2022-05-08 14:20:57',1,'2022-05-08 14:20:57');
/*!40000 ALTER TABLE `chatcontent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chatroom`
--

DROP TABLE IF EXISTS `chatroom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chatroom` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `numchatnewcustomer` int DEFAULT NULL,
  `numchatnewmanager` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chatroom`
--

LOCK TABLES `chatroom` WRITE;
/*!40000 ALTER TABLE `chatroom` DISABLE KEYS */;
INSERT INTO `chatroom` VALUES (1,0,0,10,24,'2022-03-27 18:58:21',24,'2022-03-27 18:58:21'),(2,0,0,10,20,'2022-03-27 19:12:22',20,'2022-03-27 19:12:22'),(3,0,0,10,19,'2022-03-27 19:25:32',19,'2022-03-27 19:25:32'),(4,0,0,10,18,'2022-03-27 19:34:36',18,'2022-03-27 19:34:36'),(5,0,0,10,4,'2022-05-08 12:42:03',4,'2022-05-08 12:42:03');
/*!40000 ALTER TABLE `chatroom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chatroomuser`
--

DROP TABLE IF EXISTS `chatroomuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chatroomuser` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `chatroomid` bigint unsigned DEFAULT NULL,
  `userid` bigint unsigned DEFAULT NULL,
  `deletedate` datetime DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chatroomuser`
--

LOCK TABLES `chatroomuser` WRITE;
/*!40000 ALTER TABLE `chatroomuser` DISABLE KEYS */;
INSERT INTO `chatroomuser` VALUES (1,1,24,NULL,10,24,'2022-03-27 18:58:21',24,'2022-03-27 18:58:21'),(2,1,5,'2022-04-05 17:26:01',10,4,'2022-03-27 19:10:41',4,'2022-04-05 17:26:01'),(3,2,20,NULL,10,20,'2022-03-27 19:12:22',20,'2022-03-27 19:12:22'),(4,3,19,NULL,10,19,'2022-03-27 19:25:32',19,'2022-03-27 19:25:32'),(5,4,18,NULL,10,18,'2022-03-27 19:34:36',18,'2022-03-27 19:34:36'),(6,5,4,'2022-05-08 13:31:41',10,4,'2022-05-08 12:42:03',4,'2022-05-08 13:31:41'),(7,5,2,'2022-05-08 14:02:11',10,1,'2022-05-08 14:02:11',1,'2022-05-08 14:02:11'),(8,5,1,'2022-05-08 13:31:41',10,1,'2022-05-08 14:20:57',1,'2022-05-08 14:20:57');
/*!40000 ALTER TABLE `chatroomuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `color`
--

DROP TABLE IF EXISTS `color`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `color` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `color`
--

LOCK TABLES `color` WRITE;
/*!40000 ALTER TABLE `color` DISABLE KEYS */;
INSERT INTO `color` VALUES (1,'Đen trắng',10,1,'2021-12-17 16:34:56',1,'2021-12-17 16:34:56'),(2,'Nâu trắng',10,1,'2021-12-17 16:53:29',1,'2021-12-17 16:53:29'),(3,'Nâu đỏ',10,1,'2021-12-17 16:57:00',1,'2021-12-17 16:57:00'),(4,'Trắng',10,1,'2021-12-17 17:02:51',1,'2021-12-17 17:02:51'),(5,'Xám xanh',10,1,'2021-12-17 17:07:24',1,'2021-12-17 17:07:24'),(6,'Xám trắng',10,1,'2021-12-17 21:19:02',1,'2021-12-17 21:20:07'),(7,'Vàng trắng',10,1,'2021-12-17 21:27:16',1,'2021-12-17 21:27:16'),(8,'Đen',10,1,'2021-12-17 21:33:53',1,'2021-12-17 21:33:53'),(9,'Nâu vàng',10,1,'2021-12-17 22:03:10',1,'2021-12-17 22:03:28'),(10,'Đen vàng trắng',10,1,'2021-12-17 22:20:43',1,'2021-12-17 22:20:43');
/*!40000 ALTER TABLE `color` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contact` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `subject` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `status` int DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact`
--

LOCK TABLES `contact` WRITE;
/*!40000 ALTER TABLE `contact` DISABLE KEYS */;
INSERT INTO `contact` VALUES (1,'Ngô Văn Toản','toanvanngo@gmail.com','0997631093','Thú cưng giống Corgi Dog','Cửa hàng có định bán thú cưng này không ạ! Giá  là bao nhiêu trên thị trượng ạ!',10,'2021-12-27 17:13:43'),(2,'Trần Văn Hoàng','hoangtran@gmail.com','0732365876','Giá chó Husky','Có con nào trong tầm giá 3-5 triệu không shop?',10,'2021-12-27 17:13:43'),(3,'Tây Vĩnh Hòa','hoatay@gmail.com','0367823197','Hỏi thông tin nhím','Nhím shop có các loại khác không?',10,'2021-12-27 17:13:43'),(4,'Lê Quang Vũ','vulequang@gmail.com','0379876498','Thông tin poodle teacup','Shop có bán thêm về poole teacup không?',10,'2021-12-27 17:13:43'),(5,'Huỳnh Phụng Kiều','kieuhuynh@gmail.com','0368769231','Bán sóc','Shop có bán thêm sóc không?',10,'2021-12-27 17:13:43'),(6,'Lê Thị Hương','huongle@gmail.com','0365876598','Hỏi chó poodle teacup','Poodle có màu trắng teacup không?',10,'2021-12-27 17:13:43'),(7,'Nguyễn Thanh Tú','tunguyen@gmail.com','0736983721','Hỏi về giống pitbull','Shop có dòng nhỏ nhất không?',10,'2021-12-27 17:13:43'),(8,'Ngô Văn Ân','ngovanan@gmail.com','0367291876','Thông tin shop','Shop đã có những chứng nhận gì chưa?',10,'2021-12-27 17:13:43'),(9,'Nguyễn Văn Linh','linhvannguyen@gmail.com','0902124323','Hỏi về poodle','Shop có poodle loại to không?',10,'2021-12-27 18:12:43'),(10,'Lê Thị Hương','huonglt18401@st.uel.edu.vn','0965218906','Hỏi về Pitpull','Giống này có con màu trắng không shop?',10,'2022-01-02 23:23:58'),(11,'Huỳnh Trọng Nghĩa','huynhtrongnghia1090@gmail.com','0386998130','Hỏi thăm sức khỏe','Chó Pulldog tiny của m khỏe không?',10,'2022-02-02 15:19:07'),(12,'abc','18110326@student.hcmute.edu.vn','0386998130','abc','xyz',10,'2022-05-15 07:16:47'),(13,'abc','18110326@student.hcmute.edu.vn','0386998130','abc','xyz',10,'2022-05-15 07:18:42'),(14,'Huỳnh Trọng Nghĩa','18110326@student.hcmute.eduu.vn','03886998130','Thú cưng','Cách chăm thú cưng hiệu quả',10,'2022-05-15 07:39:34'),(15,'Huỳnh Trọng Nghĩa','huynhtrongnghia1090@gmail.com','0386998130','abc','xyz',10,'2022-05-15 07:41:33'),(16,'Nam','18110321@student.hcmute.edu.vn','0366036372','Thú cưng','Dễ thương quá',10,'2022-05-15 07:56:47'),(17,'Nam','18110321@student.hcmute.edu.vn','0366036372','Hỏi cách chăm sóc','Nội dung',10,'2022-05-18 04:55:23'),(18,'nghĩa huỳnh','18110326@student.hcmute.edu.vn','0386998130','mới nha','mới nữa á',10,'2022-05-30 23:57:26'),(19,'Cầy tơ 7 món','quangvupp.api@gmail.com','666555666','Nhập thịt chó','thịt ?',10,'2022-05-31 16:21:38'),(20,'Cầy tơ 7 món','quangvupp.api@gmail.com','666555666','Nhập thịt chó','thịt ?',10,'2022-05-31 16:21:41'),(21,'Nam Nguyễn','18110321@student.hcmute.edu.vn','0987654321','Liên Hệ','Nội dung liên Hệ',10,'2022-06-02 16:32:06'),(22,'Nam Nguyễn','18110326@student.hcmute.edu.vn','0386998130','Hết hồn','nhập nội dung mới',10,'2022-06-03 17:37:42'),(23,'Huỳnh Trọng Nghĩa','18110326@student.hcmute.edu.vn','0386998130','Thông tin mới về thú cưng','Cửa hàng bán thú cưng sóc nữa nha',10,'2022-06-04 05:35:40'),(24,'Nam','18110321@student.hcmute.edu.vn','0366036372','Nhím con','Nuôi nhím như thế nào ?',10,'2022-06-04 08:22:32'),(25,'Nam','18110326@student.hcmute.edu.vn','0386998130','Hỏi về sóc','Cửa hàng có bán thêm sóc không',10,'2022-06-05 09:10:47'),(26,'Nam Nguyễn','18110326@student.hcmute.edu.vn','0386998130','Nội dung mới','Đát nước trọn niềm vui',10,'2022-06-10 17:29:35'),(27,'Nguyễn Thanh Tú','huynhtrongnghia1090@gmail.com','0386998130','Mua thu cưng','Mua thật nhiều nha!!!',90,'2022-06-13 21:52:49');
/*!40000 ALTER TABLE `contact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `userid` bigint unsigned DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `birthday` datetime DEFAULT NULL,
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `phone` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=92 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,6,'Nguyễn Hoàng Minh','2021-12-19 00:00:00','123 Củ Chi, TP.HCM','0978656753','18110326@student.hcmute.edu.vn',10,6,'2021-12-19 14:17:47',6,'2021-12-19 14:17:47'),(2,7,'Lê Thị Hương','2000-12-05 00:00:00','134/6B Hoàng Giang, Nông Cống, Thanh Hóa','0365876598','huongle@gmail.com',10,7,'2021-12-26 16:46:10',7,'2021-12-26 16:46:10'),(3,20,'Đặng Trí Nguyên','0001-01-01 00:00:00','Hòa Bắc, Long Xuyên, An Giang','0382198740','18110326@student.hcmute.edu.vn',10,20,'2022-01-02 20:23:48',1,'2022-01-02 21:35:18'),(4,20,'Đặng Trí Nguyên','0001-01-01 00:00:00','Hòa Bắc, Long Xuyên, An Giang','0382198740','18110326@student.hcmute.edu.vn',10,20,'2022-01-02 20:27:06',1,'2022-01-02 20:36:38'),(5,19,'Nguyễn Ngọc Hải',NULL,'Kom Tum, DakLak','0365271987','18110326@student.hcmute.edu.vn',10,19,'2022-01-02 20:32:35',19,'2022-01-02 20:32:35'),(6,19,'Nguyễn Ngọc Hải',NULL,'Kom Tum, DakLak','0365271987','18110326@student.hcmute.edu.vn',10,19,'2022-01-02 20:41:42',19,'2022-01-02 20:41:42'),(7,17,'Phạm Xuận Nhuận',NULL,'Hòa Tây, Bến Tre','0398284673','18110326@student.hcmute.edu.vn',10,17,'2022-01-02 20:56:43',17,'2022-01-02 20:56:43'),(8,17,'Phạm Xuận Nhuận',NULL,'Hòa Tây, Bến Tre','0398284673','18110326@student.hcmute.edu.vn',10,17,'2022-01-02 20:58:05',17,'2022-01-02 20:58:05'),(9,18,'Hồ Văn Hiếu',NULL,'Di Linh, Đà Lạt','0387623918','18110326@student.hcmute.edu.vn',10,18,'2022-01-02 21:42:10',18,'2022-01-02 21:42:10'),(10,18,'Hồ Văn Hiếu',NULL,'Di Linh, Đà Lạt','0387623918','18110326@student.hcmute.edu.vn',10,18,'2022-01-02 21:44:11',18,'2022-01-02 21:44:11'),(11,18,'Hồ Văn Hiếu',NULL,'Di Linh, Đà Lạt','0387623918','18110326@student.hcmute.edu.vn',10,18,'2022-01-02 21:58:58',18,'2022-01-02 21:58:58'),(12,16,'Tây Vĩnh Hòa',NULL,'Di Linh, Lâm Đồng','0367823197','18110278@student.hcmute.edu.vn',10,16,'2022-01-02 22:17:52',16,'2022-01-02 22:17:52'),(13,16,'Tây Vĩnh Hòa',NULL,'Di Linh, Lâm Đồng','0367823197','18110278@student.hcmute.edu.vn',10,16,'2022-01-02 22:19:19',16,'2022-01-02 22:19:19'),(14,16,'Tây Vĩnh Hòa',NULL,'Di Linh, Lâm Đồng','0367823197','18110326@student.hcmute.edu.vn',10,16,'2022-01-02 22:23:30',16,'2022-01-02 22:23:30'),(15,16,'Tây Vĩnh Hòa',NULL,'Di Linh, Lâm Đồng','0367823197','18110326@student.hcmute.edu.vn',10,16,'2022-01-02 22:27:03',16,'2022-01-02 22:27:03'),(16,8,'Bùi Khánh Hải',NULL,'Tân Ngãi, Vĩnh Long','0397384690','18110326@student.hcmute.edu.vn',10,8,'2022-01-02 22:31:10',8,'2022-01-02 22:31:10'),(17,24,'Lê Thị Hương',NULL,'Nông Cống, Thanh Hóa','0965218906','huonglt18401@st.uel.edu.vn',10,24,'2022-01-02 23:38:19',24,'2022-01-02 23:38:19'),(18,19,'Nguyễn Ngọc Hải',NULL,'KomTum, DakLak','0365271987','hainguyen@gmail.com',10,19,'2022-01-06 21:21:14',19,'2022-01-06 21:21:14'),(19,19,'Nguyễn Ngọc Hải',NULL,'KomTum, DakLak','0365271987','18110326@student.hcmute.edu.vn',10,19,'2022-01-06 21:27:44',19,'2022-01-06 21:27:44'),(20,19,'Nguyễn Ngọc Hải',NULL,'Kom Tum, Dak Lak','0365271987','18110326@student.hcmute.edu.vn',10,19,'2022-01-06 21:29:02',19,'2022-01-06 21:29:02'),(21,13,'Võ Quốc Cường',NULL,'Hòa An, Kiên Giang','0386273458','18110326@student.hcmute.edu.vn',10,13,'2022-01-06 21:32:19',13,'2022-01-06 21:32:19'),(22,13,'Võ Quốc Cường',NULL,'Hòa An, Kiên Giang','0386273458','18110326@student.hcmute.edu.vn',10,13,'2022-01-06 21:34:42',13,'2022-01-06 21:34:42'),(23,13,'Võ Quốc Cường',NULL,'Hòa An, Kiên Giang','0386273458','18110326@student.hcmute.edu.vn',10,13,'2022-01-06 21:37:59',13,'2022-01-06 21:37:59'),(24,11,'Nguyễn Văn Pháp',NULL,'Bình Tân, TP.HCM','0369872301','18110326@student.hcmute.edu.vn',10,11,'2022-01-06 21:39:51',11,'2022-01-06 21:39:51'),(25,11,'Nguyễn Văn Pháp',NULL,'Bình Tân, TP.HCM','0369872301','18110326@student.hcmute.edu.vn',10,11,'2022-01-06 21:41:12',11,'2022-01-06 21:41:12'),(26,1,'Huỳnh Trọng Nghĩa',NULL,'134/8B, khóm Tân Vĩnh Thuận, phường Tân Ngãi, Tp.VL','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-02-02 15:08:32',1,'2022-02-02 15:08:32'),(27,1,'nghia',NULL,'123, abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 05:37:13',1,'2022-05-15 05:37:13'),(28,1,'Nghĩa Huỳnh',NULL,'abc','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-05-15 05:47:48',1,'2022-05-15 05:47:48'),(29,1,'abx',NULL,'abx','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 05:53:41',1,'2022-05-15 05:53:41'),(30,1,'Huynh',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 05:57:41',1,'2022-05-15 05:57:41'),(31,1,'abc',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 06:04:33',1,'2022-05-15 06:04:33'),(32,1,'Huynh',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 06:05:25',1,'2022-05-15 06:05:25'),(33,1,'Huynh',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 06:09:37',1,'2022-05-15 06:09:37'),(34,1,'Huynh',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 06:11:26',1,'2022-05-15 06:11:26'),(35,1,'Huynh',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 06:13:40',1,'2022-05-15 06:13:40'),(36,1,'Huynh',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 06:15:35',1,'2022-05-15 06:15:35'),(37,1,'abc,',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 06:16:56',1,'2022-05-15 06:16:56'),(38,1,'abc',NULL,'gh','10556666','huynhtrongnghia1090@gmail.com',10,1,'2022-05-15 06:23:11',1,'2022-05-15 06:23:11'),(39,1,'Huỳnh Trọng Nghĩa',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 07:21:45',1,'2022-05-15 07:21:45'),(40,1,'Huỳnh Trọng Nghĩa',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 07:31:41',1,'2022-05-15 07:31:41'),(41,1,'Huỳnh Trọng Nghĩa',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-15 07:31:42',1,'2022-05-15 07:31:42'),(42,1,'Nam',NULL,'Tien Giang','0366036372','18110321@hcmute.edu.vn',10,1,'2022-05-15 08:19:32',1,'2022-05-15 08:19:32'),(43,1,'Nam',NULL,'Tien Giang','0987654321','18110321@student.hcmute.edu.vn',10,1,'2022-05-15 10:10:46',1,'2022-05-15 10:10:46'),(44,1,'Nam',NULL,'Tien giang','0987654321','18110321@student.hcmute.edu.vn',10,1,'2022-05-15 10:33:09',1,'2022-05-15 10:33:09'),(45,1,'Nam',NULL,'abc','0987654321','18110321@student.hcmute.edu.vn',10,1,'2022-05-28 21:16:38',1,'2022-05-28 21:16:38'),(46,1,'nghĩa huỳnh',NULL,'anc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-30 23:58:43',1,'2022-05-30 23:58:43'),(47,1,'Hương',NULL,'abac','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-05-31 00:30:45',1,'2022-05-31 00:30:45'),(48,1,'Hương',NULL,'abac','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-05-31 00:36:06',1,'2022-05-31 00:36:06'),(49,1,'Hương',NULL,'abac','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-05-31 00:50:30',1,'2022-05-31 00:50:30'),(50,1,'Hương',NULL,'abac','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-05-31 00:58:59',1,'2022-05-31 00:58:59'),(51,1,'Hương',NULL,'abac','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-05-31 01:02:43',1,'2022-05-31 01:02:43'),(52,1,'Hương',NULL,'abc','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-05-31 10:02:25',1,'2022-05-31 10:02:25'),(53,1,'Thiên',NULL,'346 bến vân đồn','0123456789','thienmon99@gmail.com',10,1,'2022-06-01 16:33:23',1,'2022-06-01 16:33:23'),(54,1,'Nguyễn Hoài Nam',NULL,'Võ Văn Ngân','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-06-04 05:22:38',1,'2022-06-04 05:22:38'),(55,34,'Nam Hoài',NULL,'Tiền Giang','0366036372','18110321@student.hcmute.edu.vn',10,34,'2022-06-04 08:26:54',34,'2022-06-04 08:26:54'),(56,1,'Nghĩa',NULL,'Tiền Giang','0366036372','18110321@student.hcmute.edu.vn',10,1,'2022-06-04 09:22:29',1,'2022-06-04 09:22:29'),(57,1,'Nam',NULL,'Vĩnh Long','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-06-05 09:07:17',1,'2022-06-05 09:07:17'),(58,1,'Nghĩa',NULL,'346 Bến Vân Đồn','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-06-06 10:40:56',1,'2022-06-06 10:40:56'),(59,1,'Nguyễn Ngọc Gia Tuệ',NULL,'346 Bến Vân Đồn','0386998130','nngt.0101@gmail.com',10,1,'2022-06-10 15:45:08',1,'2022-06-10 15:45:08'),(60,1,'Huỳnh Trọng Nghĩa',NULL,'346 Bến Văn Đồn','0386998130','18110326@student.hcmute.edu.vn',10,1,'2022-06-10 16:14:28',1,'2022-06-10 16:14:28'),(61,1,'Nam',NULL,'346 Bến Văn Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-10 17:42:33',1,'2022-06-10 17:42:33'),(62,1,'Nghĩa',NULL,'Vĩnh Long','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-10 17:58:31',1,'2022-06-10 17:58:31'),(63,1,'Nam',NULL,'346 Bến Vân Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-11 16:05:47',1,'2022-06-11 16:05:47'),(64,1,'Huỳnh Ngọc Phúc',NULL,'123','0386998130','huynhngocphuc.9d@gmail.com',10,1,'2022-06-11 19:03:35',1,'2022-06-11 19:03:35'),(65,1,'Huỳnh Trọng Nghĩa',NULL,'346 Bến Vân Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 14:43:15',1,'2022-06-12 14:43:15'),(66,1,'Huỳnh Trọng Nghĩa',NULL,'346 Bến Vân Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 14:45:36',1,'2022-06-12 14:45:36'),(67,1,'Huỳnh Quang Thái',NULL,'346 Bến Vân Đồn','0386998130','giadinhthai12345@gmail.com',10,1,'2022-06-12 14:57:41',1,'2022-06-12 14:57:41'),(68,1,'Huỳnh Quang Thái',NULL,'346 Bến Vân Đồn','0386998130','giadinhthai12345@gmail.com',10,1,'2022-06-12 15:00:02',1,'2022-06-12 15:00:02'),(69,1,'Huỳnh Trọng Nghĩa',NULL,'346 Bến Vân Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 15:10:47',1,'2022-06-12 15:10:47'),(70,1,'Nguyễn Hoài Nam',NULL,'346 Bến Vân Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 15:43:53',1,'2022-06-12 15:43:53'),(71,1,'a',NULL,'a','32','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 16:24:43',1,'2022-06-12 16:24:43'),(72,1,'a',NULL,'a','4','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 16:27:57',1,'2022-06-12 16:27:57'),(73,1,'a',NULL,'b','09','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 17:10:01',1,'2022-06-12 17:10:01'),(74,1,'a',NULL,'a','0','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 17:24:17',1,'2022-06-12 17:24:17'),(75,1,'a',NULL,'abc','0809','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 17:28:29',1,'2022-06-12 17:28:29'),(76,1,'b',NULL,'abc','a','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 17:30:39',1,'2022-06-12 17:30:39'),(77,1,'a',NULL,'abc','0809','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 17:52:58',1,'2022-06-12 17:52:58'),(78,1,'a',NULL,'a','09','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 17:59:23',1,'2022-06-12 17:59:23'),(79,1,'a',NULL,'abc','90','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 17:59:52',1,'2022-06-12 17:59:52'),(80,1,'Hồ',NULL,'affff','909890098','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 18:30:04',1,'2022-06-12 18:30:04'),(81,1,'Huỳnh Trọng Nghĩa',NULL,'abc','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 22:57:57',1,'2022-06-12 22:57:57'),(82,1,'a',NULL,'f','666','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 23:02:21',1,'2022-06-12 23:02:21'),(83,1,'d',NULL,'d','9','huynhtrongnghia1090@gmail.com',10,1,'2022-06-12 23:04:46',1,'2022-06-12 23:04:46'),(84,1,'Huỳnh Trọng Nghĩa',NULL,'kghgiu','0990','huynhtrongnghia1090@gmail.com',10,1,'2022-06-13 10:44:47',1,'2022-06-13 10:44:47'),(85,1,'Huỳnh Trọng Nghĩa',NULL,'346 Bến Vân Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-13 11:38:58',1,'2022-06-13 11:38:58'),(86,1,'Huỳnh Trọng Nghĩa',NULL,'346 Bến Vân Đồn, Phường 1, Quận 4, Tp.HCM','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-13 15:27:58',1,'2022-06-13 15:27:58'),(87,1,'Huỳnh Trọng Nghĩa',NULL,'346 Bến Văn Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-13 22:10:04',1,'2022-06-13 22:10:04'),(88,1,'Huỳnh Trọng Nghĩa',NULL,'346 Bến Vân Đồn','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-14 02:09:57',1,'2022-06-14 02:09:57'),(89,1,'Nghĩa Huỳnh',NULL,'Tiền Giang','0943443555','18110321@student.hcmute.edu.vn',10,1,'2022-06-14 08:57:24',1,'2022-06-14 08:57:24'),(90,1,'Nam',NULL,'Tiền Giang','0987654554','18110321@student.hcmute.edu.vn',10,1,'2022-06-14 08:59:13',1,'2022-06-14 08:59:13'),(91,1,'Nguyễn Giáo Sư',NULL,'abc','0386998130','huynhtrongnghia1090@gmail.com',10,1,'2022-06-21 00:38:08',1,'2022-06-21 00:38:08');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `news`
--

DROP TABLE IF EXISTS `news`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `news` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `content` text COLLATE utf8mb4_unicode_ci,
  `htmlcontent` text COLLATE utf8mb4_unicode_ci,
  `image` text COLLATE utf8mb4_unicode_ci,
  `typenewsid` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `news`
--

LOCK TABLES `news` WRITE;
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
INSERT INTO `news` VALUES (1,'đây là bài post','đây nè','đây lần 2','Image_News_1742a2d4-c570-4013-a7ce-e72709460307.png',1,190,4,'2022-05-24 13:58:01',4,'2022-05-24 15:33:09'),(2,'Mừng 01/06 Mua Bọ Mỹ Tặng Ngay 500K','Mừng ngày quốc tế Phụ Nữ, PetXinh hân hoan mở sự kiện tặng ngay voucher 500K khi mua Bọ Mỹ. Hãy chọn ngay một chú bọ Mỹ xinh xắn đáng yêu tặng cho người phụ nữ mà bạn yêu mến nhé.   Tặng voucher mua hàng trị giá 500.000 vnd cho hóa đơn mua Bọ Mỹ   Chương trình diễn ra từ 03/03/2021 tới 10/03/2021 hoặc có thể kết thúc khi số lượng khuyến mãi đã hết.   Chương trình không áp dụng đồng thời với các khuyến mãi khác Chương trình có thể kết thúc sớm trước thời hạn và không cần thông báo trước khi số lượng khuyến mãi đã hết. Voucher được sử dụng để mua phụ kiện. Không được dùng để mua thú cưng và không được trừ thẳng vào giá trị thú cưng đã mua. Không được thối lại tiền thừa nếu không sử dụng hết giá trị voucher. Voucher không có giá trị quy đổi thành tiền mặt hoặc tương đương tiền mặt (ví dụ như tiền chuyển khoản hoặc tiền trong ví điện tử)',NULL,'Image_News_f905c369-1a78-4a85-8e0d-c415cbf16316.jpg',1,190,4,'2022-06-02 16:19:49',4,'2022-06-02 16:19:49'),(3,'Mua Bọ Mỹ Tặng Ngay 500K','P2NPet hân hoan mở sự kiện tặng ngay voucher 500K khi mua Bọ Mỹ.; Hãy chọn ngay một chú bọ Mỹ xinh xắn đáng yêu tặng cho người thân, bạn bè mà bạn yêu mến nhé.; ;Nội dung chương trình:;;Tặng voucher mua hàng trị giá 500.000 vnd cho hóa đơn mua Bọ Mỹ;;Thời gian:;;Chương trình diễn ra từ 03/06/2022 tới 10/06/2022 hoặc có thể kết thúc khi số lượng khuyến mãi đã hết.',NULL,'Image_News_74f4771f-0c9a-4adb-96ef-b1fcd597ce71.jpg',2,10,1,'2022-06-03 23:06:27',1,'2022-06-04 01:32:23'),(4,'Vui Hè Cùng Nhím Yêu Nhận Ngay 100.000đ','Thời gian: Từ ngày 01/06 – 30/07/2022;;Khi mua một cặp nhím bất kỳ tại P2NPet. Các bạn sẽ được tặng ngay VOUCHER TRỊ GIÁ 100.000đ để sử dụng mua hàng trong tháng 8.;;Lưu ý:;- 1 Voucher áp dụng cho 1 hóa đơn và không có giá trị đổi thành tiền mặt nếu không dùng hết số tiền ghi trên voucher.;- Voucher có giá trị hiệu lực khi có con dấu của PetXinh.',NULL,'Image_News_b551c0b2-16ac-439f-9f37-0a6d16521b9a.png',2,10,1,'2022-06-03 23:11:37',1,'2022-06-04 01:33:42'),(5,'Kiến Thức Cơ Bản Khi Nuôi Hamster','Thường thì chúng ta được hỏi: “Làm thế nào để chăm sóc cho hamster ?” Đó là một câu hỏi rất khó trả lời vì có rất nhiều cách để nói và hướng dẫn. Dưới đây là một số điều cơ bản để giúp bạn bắt đầu nuôi hamster một cách tốt nhất.;;1. Thức ăn cho Hamster dạng hỗn hợp luôn có sẵn ở các cửa hàng vật nuôi. Chúng thường là sự kết hợp của các loại ngũ cốc (đậu nành, lúa mì, bắp (ngô), hướng dương, kê, ba khía, kham …);Những loại cần tránh:;\\t- Khoai tây tươi.;\\t- Đậu (Kidney bean).;;2. Các ngôi nhà, đồ chơi và chuồng trại cần phải được sạch sẽ và thoải mái để có hamster khỏe mạnh. Càng lớn càng tốt.;;3. Giao tiếp và chơi với hamster là một điều cần thiết phải làm. Hamster của bạn sẽ cần phải được chúng ta chơi với mỗi ngày, để giữ cho chúng cảm thấy hạnh phúc và ko bị bỏ quên.;;4. Chủng loại và màu sắc thường là những lý do điều kiện để chọn một hamster.;;5. Việc nuôi sinh sản hamster cần phải được cân nhắc bởi người nuôi. Đó là 1 công việc khó khăn, hamster chỉ nên được nuôi sinh sản bởi những người biết những gì họ đang làm, và không chỉ làm nó cho vui, thỏa mãn sở thích của bản thân.;;6. Hamster bị bệnh rất khó khắn trong việc chữa trị. Bệnh phổ biến nhất là ướt đuôi, căn bệnh tiêu chảy truyền nhiễm, thường xuất phát từ việc bị stress ở hamster còn nhỏ. ',NULL,'Image_News_2b9967d5-340b-4d51-b017-3204e8931550.jpg',1,10,1,'2022-06-03 23:18:39',1,'2022-06-04 01:34:25'),(6,'Cách Phân Biệt Nhím Kiểng Đực Cái','Cách phân biệt nhím kiểng đực cái. Các bạn mới nuôi nhím chắc hẳn rất quan tâm giới tính bé nhím kiểng mình nuôi là đực hay cái đúng không nè? Để sau này mình còn kiếm bạn đời cho các bé nhím sinh sản nữa chứ.;;Về ngoại hình: Để phân biệt nhím đực cái. Đối với các bé nhím kiểng có độ tuổi khoảng từ 1 -2 tháng thì rất khó để phân biệt các bé là trai hay gái khi sử dụng phương pháp này.Tuy nhiên đối với các bé nhím trưởng thành thì chúng ta hoàn toàn có thể dựa vào ngoại hình để biết các bé nhím kiểng là đực hay cái. Nhím đực thường có ngoại hình nhỏ con hơn hơn các bé nhím cái.;Về độ thân thiện: Ngay từ những lúc mới được sinh ra, nhím kiểng đực đã tỏ ra rất chi là khó chịu, muốn tiếp cận được các bé này thì cần phải có tính kiên nhẫn và cần thời gian rất lâu. Khác với các bé nhím được, các nàng nhím kiểng cái lại tỏ ra rất thân thiện với người nuôi, có thể bồng bế thoải mái. Nhưng phương diện này chỉ chính xác khoảng 95%.;Về lượng thức ăn: Từ hai tháng tuổi trở đi, các bé nhím kiểng đực ăn rất ít, uống nước cũng rất ít. Con cái thì có vẻ tham ăn hơn, các bé ăn cũng tiêu thụ nước rất nhiều.;Về lượng phân, nước tiểu: Do chí ăn một số lượng ít thức ăn nên con đực sẽ đi vệ sinh không nhiều và con cái thì ngược lại. Cách nhận biết này và bên trên có mức độ chính xác cũng tương đối, chỉ khoảng 80%.',NULL,'Image_News_78529ddf-2aa1-484e-b231-54a2a3a98d0c.jpg',1,10,1,'2022-06-03 23:22:49',1,'2022-06-04 01:35:06'),(7,'Các Bệnh Thường Gặp Ở Thỏ Kiểng, Phòng Và Trị Bệnh Như Thế Nào?','Các bệnh thường gặp và cách điều trị:;;Thỏ Kiểng Mini là động vật rất dễ nuôi, dễ chăm sóc. Tuy nhiên, việc chăm sóc không đúng cách có thể gây nên một số bệnh thường gặp. Do đó, việc phòng và trị bệnh cho bé là điều nên làm. Dưới đây là một số loại bệnh, cách phòng và điều trị nếu trong quá trình nuôi bạn gặp phải:;Bệnh bại huyết còn gọi là bệnh xuất huyết: Là bệnh truyền nhiễm lây lan rất nhanh, bệnh chủ yếu xảy ra ở thỏ lớn từ 1,5 tháng tuổi trở lên. Khi thỏ bị bệnh, thỏ lờ đờ, bỏ ăn trong thời gian ngắn rồi chết. Trước khi chết thỏ giãy giụa, quay vòng, có xuất huyết ở miệng và mũi. Cách điều trị duy nhất là tiêm phòng vaccine VHD bại huyết. Và không có thuốc điều trị.;;Bệnh cầu trùng:;Khi nuôi trong điều kiện kiện vệ sinh kém các bé thỏ thường hay phát sinh loại bênh này. Dấu hiệu nhận biết các bé mang bệnh là thỏ kém ăn, xù lông, phân lỏng. Cách phòng bệnh: bạn nên thường xuyên vệ sinh sát trùng chuồng trại. Khi bé mắc bệnh, bạn nên sử dụng Anticoc, HanE trộn với thức ăn tinh với liều 0,1-0,2g/kg thể trọng.;;Bệnh ghẻ: Bệnh này thường có hiểu hiện là Thỏ kiểng hay bị ngứa, rụng lông và có vảy, khô, cứng (chủ yếu ở tai, chân và mũi). Nếu bệnh nặng có thể nuổi mủ do nhiễm trùng da. Để không xuất hiện bệnh bạn nên thường xuyên tẩy uế, vệ sinh chuồng trại. Khi bé bị bệnh bạn nên cách ly và chăm sóc chu đáo.',NULL,'Image_News_63fa6fa8-6f21-4b89-a96e-1a972c97e00e.jpg',1,10,1,'2022-06-03 23:49:07',1,'2022-06-04 01:35:48');
/*!40000 ALTER TABLE `news` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `cartid` bigint unsigned DEFAULT NULL,
  `customerid` bigint unsigned DEFAULT NULL,
  `statusorderid` int DEFAULT NULL,
  `typepaymentid` int DEFAULT NULL,
  `statuspaymentid` int DEFAULT NULL,
  `totalmoney` bigint unsigned DEFAULT NULL,
  `note` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=92 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,1,1,3,NULL,NULL,18840000,'',10,6,'2021-08-01 00:00:00',6,'2021-08-01 00:00:00'),(2,2,2,3,NULL,NULL,19320000,'',10,7,'2021-08-19 00:00:00',1,'2021-08-19 00:00:00'),(3,4,3,3,NULL,NULL,18700000,'',10,20,'2021-08-23 00:00:00',1,'2021-08-23 00:00:00'),(4,4,4,3,NULL,NULL,5225000,'',10,20,'2021-09-02 00:00:00',1,'2021-09-02 00:00:00'),(5,5,5,3,NULL,NULL,8500000,'',10,19,'2021-09-11 00:00:00',1,'2021-09-11 00:00:00'),(6,5,6,3,NULL,NULL,1116000,'',10,19,'2021-09-19 00:00:00',1,'2021-09-19 00:00:00'),(7,6,7,3,NULL,NULL,11400000,'',10,17,'2021-10-04 00:00:00',1,'2021-10-04 00:00:00'),(8,6,8,3,NULL,NULL,14725000,'',10,17,'2021-10-14 00:00:00',1,'2021-10-14 00:00:00'),(9,7,9,3,NULL,NULL,9660000,'',10,18,'2021-11-05 00:00:00',1,'2021-11-05 00:00:00'),(10,7,10,3,NULL,NULL,11500000,'',10,18,'2021-11-15 00:00:00',1,'2021-11-15 00:00:00'),(11,7,11,3,NULL,20,27140000,'',10,18,'2021-11-25 00:00:00',1,'2021-11-25 00:00:00'),(12,8,12,3,NULL,NULL,8100000,'',10,16,'2021-12-02 00:00:00',1,'2021-12-02 00:00:00'),(13,8,13,3,NULL,NULL,6600000,'',10,16,'2021-12-20 00:00:00',1,'2021-12-20 00:00:00'),(14,8,14,3,NULL,NULL,7740000,'',10,16,'2022-01-02 22:23:30',1,'2022-01-02 22:23:51'),(15,8,15,2,NULL,NULL,8100000,'',10,16,'2022-01-02 22:27:03',1,'2022-01-06 21:44:30'),(16,9,16,2,NULL,NULL,9660000,'',10,8,'2022-01-02 22:31:10',1,'2022-01-04 15:47:08'),(17,10,17,2,NULL,NULL,5520000,'Sale 50%',10,24,'2022-01-02 23:38:19',1,'2022-01-02 23:42:37'),(18,5,18,2,NULL,NULL,7520000,'',10,19,'2022-01-06 21:21:14',1,'2022-01-06 21:44:29'),(19,5,19,1,NULL,NULL,13340000,'',10,19,'2022-01-06 21:27:44',19,'2022-01-06 21:27:44'),(20,5,20,1,NULL,NULL,11500000,'',10,19,'2022-01-06 21:29:02',19,'2022-01-06 21:29:02'),(21,11,21,1,NULL,NULL,3600000,'',10,13,'2022-01-06 21:32:19',13,'2022-01-06 21:32:19'),(22,11,22,1,NULL,NULL,8100000,'Nhẹ nhàng nha',10,13,'2022-01-06 21:34:42',13,'2022-01-06 21:34:42'),(23,11,23,1,NULL,NULL,12600000,'',10,13,'2022-01-06 21:37:59',13,'2022-01-06 21:37:59'),(24,12,24,1,NULL,NULL,1020000,'',10,11,'2022-01-06 21:39:51',11,'2022-01-06 21:39:51'),(25,12,25,1,NULL,NULL,4320000,'',10,11,'2022-01-06 21:41:12',11,'2022-01-06 21:41:12'),(26,3,26,4,NULL,NULL,21700000,'Cẩn thận!',10,1,'2022-02-02 15:08:32',1,'2022-06-03 01:54:35'),(27,3,27,4,NULL,NULL,111335000,'abg',10,1,'2022-05-15 05:37:13',1,'2022-06-03 01:53:22'),(28,3,28,4,NULL,NULL,1020000,'xyz',10,1,'2022-05-15 05:47:48',1,'2022-06-03 01:54:56'),(29,3,29,4,NULL,NULL,8500000,'xyz',10,1,'2022-05-15 05:53:41',1,'2022-06-03 16:36:46'),(30,3,30,4,NULL,NULL,1020000,'xyz',10,1,'2022-05-15 05:57:41',1,'2022-06-03 13:18:07'),(31,3,31,1,NULL,NULL,2816000,'xyz',10,1,'2022-05-15 06:04:33',1,'2022-05-15 06:04:33'),(32,3,32,1,NULL,NULL,17600000,'xyz',10,1,'2022-05-15 06:05:25',1,'2022-05-15 06:05:25'),(33,3,33,1,NULL,NULL,35200000,'xyz',10,1,'2022-05-15 06:09:37',1,'2022-05-15 06:09:37'),(34,3,34,1,NULL,NULL,35200000,'xyz',10,1,'2022-05-15 06:11:26',1,'2022-05-15 06:11:26'),(35,3,35,4,NULL,NULL,2185000,'xyz',10,1,'2022-05-15 06:13:40',1,'2022-06-03 02:03:02'),(36,3,36,4,NULL,NULL,2185000,'xyz',10,1,'2022-05-15 06:15:35',1,'2022-06-03 02:03:21'),(37,3,37,4,NULL,NULL,5720000,'xyz',10,1,'2022-05-15 06:16:56',1,'2022-06-03 01:56:47'),(38,3,38,4,NULL,NULL,2816000,'hh',10,1,'2022-05-15 06:23:11',1,'2022-06-03 01:55:17'),(39,3,39,4,NULL,NULL,14220000,'xyz',10,1,'2022-05-15 07:21:45',1,'2022-06-03 02:01:51'),(40,3,40,4,NULL,NULL,16520000,'xyz',10,1,'2022-05-15 07:31:41',1,'2022-06-03 02:01:11'),(41,3,41,4,NULL,NULL,16520000,'xyz',10,1,'2022-05-15 07:31:42',1,'2022-06-03 01:59:45'),(42,3,42,1,NULL,NULL,21048000,'Khong',10,1,'2022-05-15 08:19:32',1,'2022-05-15 08:19:32'),(43,3,43,4,NULL,NULL,27255000,'can than',10,1,'2022-05-15 10:10:46',1,'2022-06-03 04:11:51'),(44,3,44,2,NULL,NULL,16600000,'khon',10,1,'2022-05-15 10:33:09',1,'2022-05-25 10:19:31'),(45,3,45,1,NULL,NULL,2040000,'',10,1,'2022-05-28 21:16:38',1,'2022-05-28 21:16:38'),(46,3,46,4,NULL,NULL,45740000,'cẩn thận',10,1,'2022-05-30 23:58:43',1,'2022-06-03 02:15:07'),(47,3,47,4,NULL,NULL,10625000,'âbc',10,1,'2022-05-31 00:30:45',1,'2022-06-03 01:59:33'),(48,3,48,4,NULL,NULL,18700000,'abc',10,1,'2022-05-31 00:36:06',1,'2022-06-03 01:47:31'),(49,3,49,3,NULL,20,5040000,'âbc',10,1,'2022-05-31 00:50:30',1,'2022-06-23 17:59:47'),(50,3,50,4,NULL,NULL,2275000,'âbc',10,1,'2022-05-31 00:58:59',1,'2022-06-03 01:49:48'),(51,3,51,3,NULL,20,5915000,'âbc',10,1,'2022-05-31 01:02:43',1,'2022-06-03 01:46:47'),(52,3,52,3,NULL,20,5720000,'Cẩn thận',10,1,'2022-05-31 10:02:25',1,'2022-06-23 17:59:23'),(53,3,53,4,NULL,NULL,29786000,'giao trong giờ hành chính',10,1,'2022-06-01 16:33:23',1,'2022-06-04 09:25:39'),(54,3,54,4,NULL,NULL,86600000,'Cẩn thận',10,1,'2022-06-04 05:22:38',1,'2022-06-04 05:23:26'),(55,15,55,1,NULL,NULL,10625000,'Nhận tại cửa hàng được không ạ?',10,34,'2022-06-04 08:26:54',34,'2022-06-04 08:26:54'),(56,3,56,4,NULL,NULL,10625000,'không',10,1,'2022-06-04 09:22:29',1,'2022-06-04 09:25:27'),(57,3,57,4,NULL,NULL,32895000,'Cẩn thận ',10,1,'2022-06-05 09:07:17',1,'2022-06-05 09:08:33'),(58,3,58,1,NULL,NULL,37400000,'Cẩn thận ',10,1,'2022-06-06 10:40:56',1,'2022-06-06 10:40:56'),(59,3,59,1,NULL,NULL,21250000,'Cẩn thận',10,1,'2022-06-10 15:45:08',1,'2022-06-10 15:45:08'),(60,3,60,1,NULL,NULL,5040000,'Cẩn thận',10,1,'2022-06-10 16:14:28',1,'2022-06-10 16:14:28'),(61,3,61,1,NULL,20,5225000,'Cẩn thận',10,1,'2022-06-10 17:42:33',1,'2022-06-10 17:42:33'),(62,3,62,1,NULL,20,18700000,'',10,1,'2022-06-10 17:58:31',1,'2022-06-10 17:58:31'),(63,3,63,1,NULL,20,18700000,'Cẩn thận',10,1,'2022-06-11 16:05:47',1,'2022-06-11 16:05:47'),(64,3,64,1,NULL,20,25200000,'',10,1,'2022-06-11 19:03:35',1,'2022-06-11 19:03:35'),(65,3,65,1,20,10,2185000,'Cẩn thận',10,1,'2022-06-12 14:43:15',1,'2022-06-12 14:43:15'),(66,3,66,1,20,10,1020000,'Cẩn thận',10,1,'2022-06-12 14:45:36',1,'2022-06-12 14:45:36'),(68,3,68,1,20,20,1020000,'Cẩn thận',10,1,'2022-06-12 15:00:02',1,'2022-06-12 15:00:02'),(69,3,69,1,20,20,1020000,'Cẩn thận',10,1,'2022-06-12 15:10:47',1,'2022-06-12 15:10:47'),(70,3,70,1,20,10,1020000,'',10,1,'2022-06-12 15:43:53',1,'2022-06-12 15:43:53'),(71,3,71,1,20,10,1020000,'a',10,1,'2022-06-12 16:24:43',1,'2022-06-12 16:24:43'),(72,3,72,1,10,10,8500000,'',10,1,'2022-06-12 16:27:57',1,'2022-06-12 16:27:57'),(73,3,73,1,20,10,8500000,'',10,1,'2022-06-12 17:10:01',1,'2022-06-12 17:10:01'),(74,3,74,1,20,10,2185000,'a',10,1,'2022-06-12 17:24:17',1,'2022-06-12 17:24:17'),(75,3,75,1,20,10,2185000,'',10,1,'2022-06-12 17:28:29',1,'2022-06-12 17:28:29'),(76,3,76,1,20,10,8500000,'d',10,1,'2022-06-12 17:30:39',1,'2022-06-12 17:30:39'),(77,3,77,1,10,10,10625000,'',10,1,'2022-06-12 17:52:58',1,'2022-06-12 17:52:58'),(78,3,78,1,10,10,1116000,'d',10,1,'2022-06-12 17:59:23',1,'2022-06-12 17:59:23'),(79,3,79,1,20,10,3600000,'d',10,1,'2022-06-12 17:59:52',1,'2022-06-12 17:59:52'),(80,3,80,4,20,10,2185000,'',10,1,'2022-06-12 18:30:04',1,'2022-06-13 10:18:18'),(81,3,81,1,20,10,2185000,'',10,1,'2022-06-12 22:57:57',1,'2022-06-12 22:57:57'),(82,3,82,1,20,10,2185000,'',10,1,'2022-06-12 23:02:21',1,'2022-06-12 23:02:21'),(83,3,83,1,20,20,2185000,'',10,1,'2022-06-12 23:04:46',1,'2022-06-12 23:04:46'),(84,3,84,1,20,20,1020000,'',10,1,'2022-06-13 10:44:47',1,'2022-06-13 10:44:47'),(85,3,85,1,20,20,1020000,'',10,1,'2022-06-13 11:38:58',1,'2022-06-13 11:38:58'),(86,3,86,1,20,20,11500000,'',10,1,'2022-06-13 15:27:58',1,'2022-06-13 15:27:58'),(87,3,87,1,20,20,1020000,'',10,1,'2022-06-13 22:10:04',1,'2022-06-13 22:10:04'),(88,3,88,1,30,20,1020000,'Cẩn thận',10,1,'2022-06-14 02:09:57',1,'2022-06-14 02:09:57'),(89,3,89,1,30,20,10685000,'',10,1,'2022-06-14 08:57:24',1,'2022-06-14 08:57:24'),(90,3,90,1,30,10,10625000,'',10,1,'2022-06-14 08:59:13',1,'2022-06-14 08:59:13'),(91,3,91,1,20,10,1116000,'',10,1,'2022-06-21 00:38:08',1,'2022-06-21 00:38:08');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `productname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `breedid` bigint unsigned DEFAULT NULL,
  `supplierid` bigint unsigned DEFAULT NULL,
  `categoryid` int DEFAULT NULL,
  `content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,NULL,3,3,NULL,'Nhân giống tại Trang trại Dogily Kennel Đà Lạt (thành viên Hiệp hội những người nuôi chó giống Việt Nam – VKA)',10,1,'2021-12-17 16:36:06',1,'2021-12-17 16:36:29'),(2,NULL,7,8,NULL,'Nhân giống tại Trang trại Merge Pet (thành viên Hiệp hội những người nuôi chó giống Việt Nam – VKA)',10,1,'2021-12-17 16:59:07',1,'2021-12-17 16:59:07'),(3,NULL,9,5,NULL,'Nhập khẩu châu Âu (liên bang Nga)',10,1,'2021-12-17 17:05:53',1,'2021-12-17 17:05:53'),(4,NULL,10,4,NULL,'Nhân giống tại Dogily Cattery Đà Lạt',10,1,'2021-12-17 17:15:51',1,'2021-12-17 17:15:51'),(5,NULL,6,8,NULL,'Nhân giống tại Trang trại Dogily Kennel Đà Lạt (thành viên Hiệp hội những người nuôi chó giống Việt Nam – VKA). Chó bố mẹ nhập khẩu châu Âu',10,1,'2021-12-17 21:26:26',1,'2021-12-17 21:26:26'),(6,NULL,8,7,NULL,'Nhân giống tại Phú Quốc',10,1,'2021-12-17 21:33:27',1,'2021-12-17 21:33:27'),(7,NULL,4,2,NULL,'Nhân giống tại Trang trại Lê Trung Pet tại Đà Lạt (thành viên Hiệp hội những người nuôi chó giống Việt Nam – VKA)',10,1,'2021-12-17 21:39:37',1,'2021-12-17 21:39:37'),(8,NULL,5,2,NULL,'Nhân giống tại Trang trại Lê Trung Pet Đà Lạt (thành viên Hiệp hội những người nuôi chó giống Việt Nam – VKA)',10,1,'2021-12-17 21:44:46',1,'2021-12-17 21:44:57'),(9,NULL,11,7,NULL,'Nhập khẩu Nga',10,1,'2021-12-17 21:53:25',1,'2021-12-17 21:53:25'),(10,NULL,12,8,NULL,'Nhân giống tại Merge Pet',10,1,'2021-12-17 22:02:18',1,'2021-12-17 22:02:18'),(11,NULL,13,4,NULL,'Nhân giống tại Pet Xinh TP.HCM',10,1,'2021-12-17 22:07:53',1,'2021-12-17 22:08:48'),(12,NULL,14,7,NULL,'Nhân giống tại Thế giới thú cưng',10,1,'2021-12-17 22:13:54',1,'2021-12-17 22:13:54'),(13,NULL,18,7,NULL,'Nhân giống tại Thế giới thú cưng',10,1,'2021-12-17 22:38:08',1,'2021-12-17 22:38:08'),(14,NULL,19,7,NULL,'Nhân giống tại Thế giới thú cưng',10,1,'2021-12-17 22:42:13',1,'2021-12-17 22:42:13'),(15,NULL,20,7,NULL,'Nhập khẩu từ Thổ Nhĩ Kỳ tại vùng Ankara',10,1,'2021-12-17 22:45:49',1,'2021-12-17 22:45:49'),(16,NULL,4,1,NULL,'new',90,1,'2022-02-02 14:02:10',1,'2022-02-02 14:03:15'),(17,'Hải sản Nhật có tôm khô',NULL,9,22,'mới mới',10,1,'2022-06-02 14:02:10',1,'2022-06-02 14:02:10'),(18,'',NULL,9,32,'Thức ăn bổ dưỡng cho hamter',10,1,'2022-06-21 05:03:53',1,'2022-06-21 05:03:53'),(19,NULL,NULL,9,25,'Dinh dưỡng  cao thích hợp  cho thú cưng',10,1,'2022-06-21 05:49:29',1,'2022-06-21 05:55:14');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productcomment`
--

DROP TABLE IF EXISTS `productcomment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productcomment` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `userid` bigint unsigned DEFAULT NULL,
  `productdetailid` bigint unsigned DEFAULT NULL,
  `content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `commentrootid` bigint unsigned DEFAULT NULL,
  `rating` float DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=205 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productcomment`
--

LOCK TABLES `productcomment` WRITE;
/*!40000 ALTER TABLE `productcomment` DISABLE KEYS */;
INSERT INTO `productcomment` VALUES (1,17,1,'Chó con bé, xinh và đáng yêu',NULL,NULL,190,17,'2022-01-13 15:27:01',1,'2022-06-02 01:24:19'),(2,17,5,'Mèo con bé nhỏ,  rất \nđáng yêu',NULL,NULL,10,17,'2022-01-13 15:28:01',17,'2022-01-13 15:28:01'),(3,17,4,'Mặt ổng hoang mang ghê!',NULL,NULL,10,17,'2022-01-13 15:30:24',17,'2022-01-13 15:30:24'),(4,17,19,'Chuột này có màu sắc rất đẹp nha',NULL,NULL,10,17,'2022-01-13 15:31:11',17,'2022-01-13 15:31:11'),(5,17,8,'Mèo con đáng yêu, xinh xắn',NULL,NULL,10,17,'2022-01-13 15:32:34',17,'2022-01-13 15:32:34'),(6,17,34,'Shop ơi!!! Mình muốn nuôi một cặp hamster hiền và trọn bộ phụ kiện lồng cho hamster thì mình nên lấy loại nào ạ (Tham khảo)',NULL,NULL,10,17,'2022-01-13 15:34:06',17,'2022-01-13 15:34:06'),(7,19,11,'Cute vậy, đáng yêu, 10 điểm lun nha',NULL,NULL,10,19,'2022-01-13 15:36:19',19,'2022-01-13 15:36:19'),(8,19,4,'Cún này bé bé, màu đẹp thế',NULL,NULL,190,19,'2022-01-13 15:36:49',1,'2022-06-02 13:24:47'),(9,19,16,'Mèo này màu sắc đẹp thật, giảm giá shop ơi!!!',NULL,NULL,10,19,'2022-01-13 15:37:35',19,'2022-01-13 15:37:35'),(10,19,15,'Ôi! Con bé trắng tinh, bé nhỏ cưng thật',NULL,NULL,10,19,'2022-01-13 15:38:07',19,'2022-01-13 15:38:07'),(11,19,21,'Xứng đáng để chọn làm thú cưng nha, rất dễ nuôi',NULL,NULL,10,19,'2022-01-13 15:39:04',19,'2022-01-13 15:39:04'),(12,19,27,'Bé này rất dễ gần và đáng yêu nha',NULL,NULL,10,19,'2022-01-13 15:39:51',19,'2022-01-13 15:39:51'),(13,19,13,'Cơ bắp thật sự lun!!!\nKhá là to con',NULL,NULL,10,19,'2022-01-13 15:40:42',19,'2022-01-13 15:40:42'),(14,19,12,'Nhìn đáng yêu, láo thật sự mọi người ạ!',NULL,NULL,10,19,'2022-01-13 15:41:30',19,'2022-01-13 15:41:30'),(15,19,25,'Woow... cơ bắp, mạnh mẽ và thông minh nha!!!',NULL,NULL,10,19,'2022-01-13 15:42:00',19,'2022-01-13 15:42:00'),(16,10,4,'Bé bé xinh xinh đáng yêu thật',NULL,NULL,190,10,'2022-01-13 15:42:59',1,'2022-06-02 13:24:47'),(17,10,6,'Ôi! Bé này màu đẹp lại còn đáng yêu nữa',NULL,NULL,10,10,'2022-01-13 15:43:27',10,'2022-01-13 15:43:27'),(18,10,35,'Bé chuột này đáng mua và cực đáng yêu luôn!',NULL,NULL,10,10,'2022-01-13 15:43:53',10,'2022-01-13 15:43:53'),(19,10,36,'Chú nhím với màu sắc đặc biệt quá đi',NULL,NULL,10,10,'2022-01-13 15:44:17',10,'2022-01-13 15:44:17'),(20,10,25,'Ôi, mạnh mẽ quá!!!',NULL,NULL,10,10,'2022-01-13 15:44:52',10,'2022-01-13 15:44:52'),(21,10,23,'Bé này, nhìn mặt cưng ghê!',NULL,NULL,10,10,'2022-01-13 15:45:16',10,'2022-01-13 15:45:16'),(22,10,18,'Màu sắc thật đặc biệt, đang mua nha mọi người!',NULL,NULL,10,10,'2022-01-13 15:45:56',10,'2022-01-13 15:45:56'),(23,1,4,'Bé này màu sắc đặc biệt và cực đáng yêu ghê!',NULL,NULL,190,1,'2022-01-13 15:47:14',1,'2022-06-02 01:25:41'),(24,1,26,'Ôi! Bé con đáng yêu quá đi shop ơi!',NULL,NULL,10,1,'2022-01-13 15:47:44',1,'2022-01-13 15:47:44'),(25,1,9,'Chú này rất rất thông minh lun nha, đáng để mua nè',NULL,NULL,10,1,'2022-01-13 15:48:16',1,'2022-01-13 15:48:16'),(26,1,2,'Chú này rất vui tính và hiền lành nha',NULL,NULL,190,1,'2022-01-13 15:48:55',1,'2022-06-02 03:28:56'),(27,11,10,'Chú chó thông minh và khỏe mạnh. Thật sự đáng mua!',NULL,NULL,10,11,'2022-01-13 15:50:42',11,'2022-01-13 15:50:42'),(28,11,33,'Chú thỏ đáng yêu và màu mắt ruby nè',NULL,NULL,10,11,'2022-01-13 15:51:05',11,'2022-01-13 15:51:05'),(29,11,20,'Bé nhím rất chi là cute lun cả nhà ơi',NULL,NULL,10,11,'2022-01-13 15:51:33',11,'2022-01-13 15:51:33'),(30,11,22,'Bé này nghe bảo là Ngáo thì phải nhã... hahaha....',NULL,NULL,10,11,'2022-01-13 15:51:58',11,'2022-01-13 15:51:58'),(31,11,24,'Ôi! Đáng yêu thật sự',NULL,NULL,10,11,'2022-01-13 15:52:20',11,'2022-01-13 15:52:20'),(32,11,29,'Chú mèo thật đáng yêu',NULL,NULL,10,11,'2022-01-13 15:52:53',11,'2022-01-13 15:52:53'),(33,11,5,'Con bé nhỏ nhắn và cực đáng yêu nha',NULL,NULL,190,11,'2022-01-13 15:53:20',1,'2022-06-02 01:40:53'),(34,11,28,'Chú mèo này thông minh lắm lun',NULL,NULL,10,11,'2022-01-13 15:53:49',11,'2022-01-13 15:53:49'),(35,11,7,'Thật là sang chảnh và đẹp',NULL,NULL,10,11,'2022-01-13 15:54:31',11,'2022-01-13 15:54:31'),(36,11,30,'Ôi! Bé con đáng yêu thật sự',NULL,NULL,10,11,'2022-01-13 15:54:52',11,'2022-01-13 15:54:52'),(37,11,14,'Chú mèo này sang chảnh quá đi!!!',NULL,NULL,10,11,'2022-01-13 15:55:27',11,'2022-01-13 15:55:27'),(38,11,4,'Chú cún này cưng thế, bé bé cưng ghê!',NULL,NULL,190,11,'2022-01-13 15:56:17',1,'2022-06-02 13:24:47'),(39,11,3,'Ôi! Bé xinh, đáng yêu quá đi',NULL,NULL,10,11,'2022-01-13 15:56:53',11,'2022-01-13 15:56:53'),(40,24,32,'Bé mèo con, xinh, thông minh và rất đáng mua nha',NULL,NULL,10,24,'2022-01-13 15:58:34',24,'2022-01-13 15:58:34'),(41,18,4,'Chú này đáng yêu và thông minh nữa',NULL,NULL,190,18,'2022-01-13 15:59:37',1,'2022-06-02 13:24:46'),(42,18,17,'Bé mèo đáng yêu và thông minh ghê luôn',NULL,NULL,10,18,'2022-01-13 16:00:26',18,'2022-01-13 16:00:26'),(43,18,31,'Ôi, bé mèo xinh xắn và đáng yêu quá đi',NULL,NULL,10,18,'2022-01-13 16:00:56',18,'2022-01-13 16:00:56'),(44,18,1,'Chú chó ngáo ngơ này đáng yêu quá đi',NULL,NULL,190,18,'2022-01-13 16:01:37',1,'2022-06-02 01:24:19'),(45,18,24,'Wow, nó đáng yêu quá đi',NULL,NULL,10,18,'2022-01-13 16:01:57',18,'2022-01-13 16:01:57'),(46,18,35,'Bé chuột này dễ nuôi và rất đáng yêu nha',NULL,NULL,10,18,'2022-01-13 16:02:39',18,'2022-01-13 16:02:39'),(47,15,4,'Cún này nhỏ bé, trắng trắng, đáng yêu và cực đáng mua luôn nha!!!',NULL,NULL,190,15,'2022-01-13 16:03:51',1,'2022-06-02 13:24:46'),(48,15,1,'Con này ngáo thật sự lun!!!',NULL,NULL,190,15,'2022-01-13 16:04:37',1,'2022-06-02 01:24:19'),(49,15,33,'Ôi! Đôi mắt ruby nè',NULL,NULL,10,15,'2022-01-13 16:04:53',15,'2022-01-13 16:04:53'),(50,15,16,'Con bé nó đóm đẹp quá đi',NULL,NULL,10,15,'2022-01-13 16:05:37',15,'2022-01-13 16:05:37'),(53,4,8,'Đây là comment nè',NULL,NULL,10,4,'2022-02-02 14:43:36',4,'2022-02-02 14:43:36'),(56,1,23,'abc',NULL,NULL,190,1,'2022-02-02 14:48:17',1,'2022-02-02 14:48:19'),(57,1,4,'a',NULL,NULL,190,1,'2022-02-02 14:57:34',1,'2022-02-02 15:15:55'),(58,1,4,'Update nhaaaa',NULL,NULL,190,1,'2022-02-02 15:15:53',1,'2022-06-02 01:23:52'),(60,4,4,'Comment đã được cập nhật!',NULL,4,190,4,'2022-03-14 21:41:05',1,'2022-06-02 01:23:41'),(61,4,4,'Đây là bài comment cũ',60,0,10,4,'2022-03-14 21:49:11',4,'2022-03-14 21:52:12'),(68,1,1,'abc',NULL,0,190,1,'2022-03-20 14:58:47',1,'2022-03-20 15:35:30'),(69,1,1,'mình em ơi ơi',NULL,0,190,1,'2022-03-20 14:58:57',1,'2022-06-02 01:24:18'),(82,25,15,'Khá tuyệt',NULL,0,10,25,'2022-05-15 00:50:05',25,'2022-05-15 00:50:05'),(83,1,20,'Nhìn dễ thương quá',NULL,0,190,1,'2022-05-28 19:43:48',1,'2022-05-28 19:44:09'),(84,1,20,'Dễ thương quá đi',NULL,0,10,1,'2022-05-28 19:44:34',1,'2022-05-28 19:44:34'),(85,1,20,'đẹp lắm đó mọi người',NULL,0,190,1,'2022-05-28 20:05:57',1,'2022-05-28 20:06:24'),(86,1,20,'Đẹp lắm',NULL,0,10,1,'2022-05-28 20:09:21',1,'2022-05-28 20:09:21'),(87,1,4,'Bình luận mới cập nhật lại lại oke nha',NULL,0,190,1,'2022-05-30 14:36:42',1,'2022-06-02 01:23:41'),(88,1,4,'bình luận mới nhất',NULL,0,190,1,'2022-05-30 14:41:29',1,'2022-06-02 01:23:41'),(89,1,35,'REPLY NE',46,0,10,1,'2022-05-31 16:03:46',1,'2022-05-31 16:03:46'),(90,1,35,'nghixa ne',NULL,0,190,1,'2022-05-31 16:20:50',1,'2022-05-31 16:27:12'),(91,1,35,'hay',NULL,0,190,1,'2022-05-31 16:38:54',1,'2022-05-31 16:43:38'),(92,1,35,'hay',NULL,0,10,1,'2022-05-31 16:45:47',1,'2022-05-31 16:45:47'),(93,1,35,'phan hoi hay',NULL,0,190,1,'2022-05-31 16:56:35',1,'2022-05-31 17:12:02'),(94,1,35,'123',NULL,0,190,1,'2022-05-31 16:57:21',1,'2022-05-31 17:12:01'),(95,1,35,'2222',NULL,0,190,1,'2022-05-31 16:57:55',1,'2022-05-31 17:12:01'),(96,1,35,'123',NULL,0,190,1,'2022-05-31 17:10:43',1,'2022-05-31 17:12:00'),(97,1,35,'222',NULL,0,10,1,'2022-05-31 17:12:05',1,'2022-05-31 17:12:05'),(98,1,35,'222',NULL,0,10,1,'2022-05-31 17:13:02',1,'2022-05-31 17:13:02'),(99,1,35,'phan hoi nesss',NULL,0,10,1,'2022-05-31 17:34:07',1,'2022-06-01 14:03:55'),(100,1,24,'hayy',NULL,0,10,1,'2022-06-01 08:29:09',1,'2022-06-01 08:29:16'),(101,1,24,'phan hoi ne',NULL,0,190,1,'2022-06-01 08:29:50',1,'2022-06-01 08:31:11'),(102,1,24,'222',NULL,0,190,1,'2022-06-01 08:38:55',1,'2022-06-02 01:26:12'),(103,1,26,'gagaga',NULL,0,10,1,'2022-06-01 10:01:17',1,'2022-06-01 10:01:17'),(104,1,26,'222',NULL,0,10,1,'2022-06-01 10:01:47',1,'2022-06-01 10:01:47'),(105,1,26,'trả kiwuf 22',104,0,10,1,'2022-06-01 10:05:01',1,'2022-06-01 10:05:01'),(106,1,26,'tra loi cua tra loi',104,0,190,1,'2022-06-01 10:05:11',1,'2022-06-01 13:39:36'),(107,1,26,'222',104,0,190,1,'2022-06-01 10:05:18',1,'2022-06-01 13:39:35'),(108,1,26,'trar lowi ne',104,0,190,1,'2022-06-01 10:21:26',1,'2022-06-01 13:39:34'),(109,1,26,'222',104,0,190,1,'2022-06-01 10:22:59',1,'2022-06-01 13:39:32'),(110,1,26,'3',104,0,190,1,'2022-06-01 10:23:03',1,'2022-06-01 13:39:37'),(111,1,26,'gagaga',103,0,10,1,'2022-06-01 10:23:13',1,'2022-06-01 10:23:13'),(112,1,26,'222',103,0,10,1,'2022-06-01 10:23:19',1,'2022-06-01 10:23:19'),(113,1,35,'222',99,0,190,1,'2022-06-01 14:05:24',1,'2022-06-01 14:19:43'),(114,1,35,'3333',NULL,0,10,1,'2022-06-01 14:06:45',1,'2022-06-01 14:06:45'),(115,1,35,'phan hoi 333',114,0,190,1,'2022-06-01 14:07:08',1,'2022-06-01 14:08:43'),(116,1,35,'222',114,0,190,1,'2022-06-01 14:08:19',1,'2022-06-01 14:08:42'),(117,1,35,'phan hoi cmnr',114,0,190,1,'2022-06-01 14:08:32',1,'2022-06-01 14:08:34'),(118,1,4,'comment mới',NULL,5,190,1,'2022-06-02 00:27:54',1,'2022-06-02 01:23:23'),(119,1,3,'dễ thương',NULL,5,10,1,'2022-06-02 00:35:25',1,'2022-06-02 00:35:25'),(120,1,3,'Xinh đẹp',NULL,5,10,1,'2022-06-02 00:37:14',1,'2022-06-02 00:37:14'),(121,1,3,'màu nâu đẹp',NULL,5,10,1,'2022-06-02 00:38:43',1,'2022-06-02 00:38:43'),(122,1,9,'dễ thương',NULL,5,10,1,'2022-06-02 00:44:57',1,'2022-06-02 00:44:57'),(123,1,9,'xinh đẹp',NULL,5,10,1,'2022-06-02 00:45:55',1,'2022-06-02 00:45:55'),(124,1,9,'sao đẹp nhỉ',NULL,5,10,1,'2022-06-02 00:51:49',1,'2022-06-13 15:26:50'),(125,1,4,'bình luận mới',NULL,5,190,1,'2022-06-02 00:55:54',1,'2022-06-02 01:23:40'),(126,1,4,'bình luận',NULL,5,190,1,'2022-06-02 00:57:42',1,'2022-06-02 01:23:38'),(127,1,4,'bình luận',NULL,5,190,1,'2022-06-02 00:57:46',1,'2022-06-02 01:23:17'),(128,1,24,'đây là',NULL,5,190,1,'2022-06-02 01:28:25',1,'2022-06-02 01:28:32'),(129,1,5,'con mèo dễ thương',NULL,5,190,1,'2022-06-02 01:39:45',1,'2022-06-02 01:40:52'),(130,1,5,'dễ thương',NULL,5,190,1,'2022-06-02 01:40:14',1,'2022-06-02 01:40:20'),(131,1,4,'hi',NULL,5,190,1,'2022-06-02 01:41:26',1,'2022-06-02 01:41:44'),(132,1,4,'bình luận',NULL,5,190,1,'2022-06-02 01:45:48',1,'2022-06-02 01:46:09'),(133,1,23,'tạo rồi',NULL,5,190,1,'2022-06-02 01:47:49',1,'2022-06-02 01:48:04'),(134,1,23,'b',NULL,5,190,1,'2022-06-02 01:55:50',1,'2022-06-03 18:32:50'),(135,1,4,'đây là',NULL,5,190,1,'2022-06-02 02:07:19',1,'2022-06-02 02:41:28'),(136,1,22,'bình luận mới',NULL,5,10,1,'2022-06-02 02:07:51',1,'2022-06-02 02:07:51'),(137,1,4,'tạo nha',NULL,5,190,1,'2022-06-02 02:08:18',1,'2022-06-02 02:08:55'),(138,1,4,'nhập',NULL,5,190,1,'2022-06-02 02:14:25',1,'2022-06-02 02:14:41'),(139,1,4,'nhập',NULL,5,190,1,'2022-06-02 02:15:01',1,'2022-06-02 02:15:16'),(140,1,4,'abc',NULL,5,190,1,'2022-06-02 02:17:46',1,'2022-06-02 02:26:37'),(141,1,7,'comment mới',NULL,5,190,1,'2022-06-02 02:32:05',1,'2022-06-02 02:32:13'),(142,1,24,'đẹp nha',NULL,5,10,1,'2022-06-02 03:29:57',1,'2022-06-02 03:29:57'),(143,1,4,'đẹp quá',NULL,5,190,1,'2022-06-02 13:24:19',1,'2022-06-02 13:24:44'),(144,1,4,'đẹp quá',NULL,5,190,1,'2022-06-02 13:25:14',1,'2022-06-02 13:25:18'),(145,1,6,'xinh đẹp',NULL,5,190,1,'2022-06-02 13:35:40',1,'2022-06-03 13:29:03'),(146,1,4,'comment nha',NULL,5,10,1,'2022-06-02 14:06:52',1,'2022-06-02 14:06:52'),(147,1,4,'comment nữa nha',NULL,5,190,1,'2022-06-02 14:07:13',1,'2022-06-02 14:07:26'),(148,1,4,'tạo comment mới',NULL,5,190,1,'2022-06-02 14:09:39',1,'2022-06-02 14:09:42'),(149,1,4,'jsjj ohcnoc',NULL,5,190,1,'2022-06-02 14:15:05',1,'2022-06-02 14:15:17'),(150,1,4,'đây là comment',NULL,5,190,1,'2022-06-02 14:27:04',1,'2022-06-02 14:33:41'),(151,1,19,'comment thôi',NULL,5,190,1,'2022-06-02 14:29:53',1,'2022-06-05 09:00:52'),(152,1,19,'khing thế nhở',NULL,5,190,1,'2022-06-02 14:30:11',1,'2022-06-02 14:30:36'),(153,1,19,'khing thế nh kkk',NULL,5,190,1,'2022-06-02 14:30:30',1,'2022-06-02 14:30:35'),(154,1,19,'hihi',NULL,5,190,1,'2022-06-02 14:30:46',1,'2022-06-02 14:30:49'),(155,1,4,'kkkk',NULL,5,190,1,'2022-06-02 14:31:10',1,'2022-06-02 14:33:39'),(156,1,4,'hhh',NULL,5,190,1,'2022-06-02 14:31:21',1,'2022-06-02 14:31:22'),(157,1,4,'hh',NULL,5,190,1,'2022-06-02 14:33:48',1,'2022-06-02 14:41:54'),(158,1,4,'kkk',NULL,5,190,1,'2022-06-02 14:33:54',1,'2022-06-02 14:33:57'),(159,1,4,'kkk',NULL,5,190,1,'2022-06-02 14:36:45',1,'2022-06-02 14:41:53'),(160,1,4,'abc',NULL,5,190,1,'2022-06-02 14:36:51',1,'2022-06-02 14:39:28'),(161,1,4,'cmm',NULL,5,190,1,'2022-06-02 14:39:45',1,'2022-06-02 14:41:50'),(162,1,4,'hihi',NULL,5,190,1,'2022-06-02 14:39:59',1,'2022-06-02 14:41:48'),(163,1,19,'hihi',NULL,5,190,1,'2022-06-02 14:42:20',1,'2022-06-02 14:58:40'),(164,1,19,'kaka',NULL,5,190,1,'2022-06-02 14:42:35',1,'2022-06-02 14:58:39'),(165,1,19,'abc',NULL,5,190,1,'2022-06-02 14:48:49',1,'2022-06-02 14:49:06'),(166,1,19,'abc',NULL,5,190,1,'2022-06-02 14:49:02',1,'2022-06-02 14:49:04'),(167,1,19,'khá là nóng',NULL,5,190,1,'2022-06-02 14:58:50',1,'2022-06-02 15:03:24'),(168,1,19,'nóng tính',NULL,5,190,1,'2022-06-02 14:58:57',1,'2022-06-02 15:03:21'),(169,1,19,'abc',NULL,5,190,1,'2022-06-02 15:02:39',1,'2022-06-02 15:03:22'),(170,1,19,'post',NULL,5,190,1,'2022-06-02 15:03:09',1,'2022-06-02 15:03:25'),(171,1,19,'nếu',NULL,5,190,1,'2022-06-02 15:03:35',1,'2022-06-02 15:35:34'),(172,1,6,'comment nha',NULL,5,190,1,'2022-06-02 15:19:40',1,'2022-06-03 13:29:01'),(173,1,6,'nhập',NULL,5,190,1,'2022-06-02 15:22:53',1,'2022-06-02 15:23:12'),(174,1,6,'đẹp',NULL,5,190,1,'2022-06-02 15:23:06',1,'2022-06-02 15:23:09'),(175,1,33,'đẹp nha',NULL,5,10,1,'2022-06-02 15:29:58',1,'2022-06-02 15:29:58'),(176,1,33,'xinh đẹp',NULL,5,10,1,'2022-06-02 15:30:11',1,'2022-06-02 15:30:11'),(177,1,4,'vô vô',NULL,5,190,1,'2022-06-02 15:31:06',1,'2022-06-02 15:31:39'),(178,1,4,'didiid',NULL,5,190,1,'2022-06-02 15:31:16',1,'2022-06-02 15:31:38'),(179,1,4,'ngon',NULL,5,190,1,'2022-06-02 15:31:20',1,'2022-06-02 15:31:37'),(180,1,19,'đẹp',NULL,5,190,1,'2022-06-02 15:35:18',1,'2022-06-02 15:35:30'),(181,1,19,'xuất sắc lun',NULL,5,190,1,'2022-06-02 15:35:28',1,'2022-06-02 15:35:35'),(182,1,13,'đẹp trai',NULL,5,190,1,'2022-06-02 17:05:51',1,'2022-06-02 17:05:53'),(183,1,22,'Dễ thương ❤️',NULL,5,190,1,'2022-06-02 19:24:12',1,'2022-06-04 05:20:31'),(184,1,1,'xinh đẹp',NULL,5,10,1,'2022-06-03 00:05:19',1,'2022-06-03 00:05:19'),(185,1,1,'dễ thương',NULL,5,10,1,'2022-06-03 00:05:29',1,'2022-06-03 00:05:29'),(186,1,6,'xinh xắn',NULL,5,190,1,'2022-06-03 13:26:37',1,'2022-06-04 08:44:41'),(187,1,6,'xinh xinh xinh nha mọi người',NULL,5,190,1,'2022-06-03 13:27:15',1,'2022-06-03 13:29:13'),(188,1,6,'xinh nha',NULL,5,190,1,'2022-06-03 13:31:07',1,'2022-06-03 13:31:10'),(189,1,23,'dễ thương quá',NULL,5,10,1,'2022-06-03 19:05:12',1,'2022-06-03 19:05:12'),(190,1,6,'ngon lành',NULL,5,190,1,'2022-06-03 19:34:44',1,'2022-06-03 19:34:47'),(191,1,2,'thú cưng đẹp',NULL,5,10,1,'2022-06-04 05:20:46',1,'2022-06-04 05:20:46'),(192,1,30,'dễ thương quá',NULL,5,190,1,'2022-06-04 05:36:36',1,'2022-06-04 05:36:48'),(193,1,30,'giá rất phải chăng',NULL,5,10,1,'2022-06-04 05:36:46',1,'2022-06-04 05:36:46'),(194,34,6,'chăm sóc dễ không ạ?',NULL,5,190,34,'2022-06-04 08:12:44',34,'2022-06-04 08:13:02'),(195,34,6,'Được ạ',NULL,5,190,34,'2022-06-04 08:12:57',34,'2022-06-04 08:12:59'),(196,1,6,'dễ thương',NULL,5,10,1,'2022-06-04 08:44:52',1,'2022-06-04 08:44:52'),(197,1,24,'xịn',NULL,5,10,1,'2022-06-04 09:13:15',1,'2022-06-04 09:13:15'),(198,1,6,'dữ',NULL,5,190,1,'2022-06-04 09:20:44',1,'2022-06-04 09:20:50'),(199,1,19,'dễ thương',NULL,5,190,1,'2022-06-05 09:00:04',1,'2022-06-05 09:00:47'),(200,1,13,'đây nè',NULL,5,190,1,'2022-06-06 10:38:48',1,'2022-06-06 10:38:53'),(201,1,13,'Đúng rồi á á',NULL,0,10,1,'2022-06-09 08:47:51',1,'2022-06-09 08:48:15'),(202,1,9,'hihi',124,0,190,1,'2022-06-13 15:25:34',1,'2022-06-13 15:26:03'),(203,1,9,'fff',124,0,190,1,'2022-06-13 15:25:59',1,'2022-06-13 15:26:20'),(204,1,9,'hihi',124,0,190,1,'2022-06-13 15:26:38',1,'2022-06-13 15:26:41');
/*!40000 ALTER TABLE `productcomment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productdetail`
--

DROP TABLE IF EXISTS `productdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productdetail` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `productid` bigint unsigned DEFAULT NULL,
  `colorid` bigint unsigned DEFAULT NULL,
  `sizeid` bigint unsigned DEFAULT NULL,
  `ageid` bigint unsigned DEFAULT NULL,
  `sexid` int DEFAULT NULL,
  `statusdetailid` int DEFAULT NULL,
  `price` float DEFAULT NULL,
  `discount` float DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productdetail`
--

LOCK TABLES `productdetail` WRITE;
/*!40000 ALTER TABLE `productdetail` DISABLE KEYS */;
INSERT INTO `productdetail` VALUES (1,1,1,2,1,1,1,5600000,10,3,10,1,'2021-12-17 16:42:33',1,'2022-06-11 19:03:35'),(2,1,2,4,7,2,1,15000000,8,4,10,1,'2021-12-17 16:55:17',1,'2022-06-04 05:22:38'),(3,2,3,1,2,1,1,6000000,8,5,10,1,'2021-12-17 17:00:13',24,'2022-01-02 23:38:19'),(4,2,4,1,1,2,1,10000000,15,2,10,1,'2021-12-17 17:03:45',1,'2022-06-14 08:57:24'),(5,3,5,2,1,2,1,5500000,5,5,10,1,'2021-12-17 17:09:45',1,'2022-06-10 17:42:33'),(6,3,7,4,6,1,1,12500000,15,4,10,1,'2021-12-17 17:13:18',1,'2022-06-14 08:59:13'),(7,4,4,4,6,1,1,14000000,10,5,10,1,'2021-12-17 17:16:42',1,'2022-05-15 08:19:32'),(8,4,6,2,1,2,1,4000000,10,5,10,1,'2021-12-17 21:19:54',1,'2021-12-17 21:19:54'),(9,5,7,4,7,1,1,12500000,8,5,10,1,'2021-12-17 21:28:37',1,'2022-06-13 15:27:58'),(10,6,8,4,7,1,1,10500000,8,5,10,1,'2021-12-17 21:34:44',8,'2022-01-02 22:31:10'),(11,7,4,2,2,1,1,7500000,12,5,10,1,'2021-12-17 21:40:41',1,'2022-05-15 05:37:13'),(12,8,6,2,1,1,1,12000000,10,10,10,1,'2021-12-17 21:46:15',1,'2022-06-04 05:22:38'),(13,8,7,4,8,1,1,22000000,15,4,10,1,'2021-12-17 21:49:16',1,'2022-06-11 16:05:47'),(14,9,4,3,5,2,1,15500000,5,4,10,1,'2021-12-17 21:54:21',17,'2022-01-02 20:58:05'),(15,9,4,1,1,1,1,7000000,4,8,10,1,'2021-12-17 21:57:32',1,'2022-05-15 05:37:13'),(16,10,9,3,4,1,1,13000000,9,2,10,1,'2021-12-17 22:04:02',1,'2021-12-17 22:04:43'),(17,11,6,2,1,2,1,5500000,2,4,10,1,'2021-12-17 22:09:53',1,'2021-12-17 22:09:53'),(18,12,10,3,3,1,1,4500000,4,7,10,1,'2021-12-17 22:22:34',11,'2022-01-06 21:41:12'),(19,13,6,1,1,1,1,1200000,15,46,10,1,'2021-12-17 22:40:19',1,'2022-06-14 02:09:57'),(20,14,1,3,3,2,1,2500000,9,6,10,1,'2021-12-17 22:43:09',1,'2022-05-15 10:10:46'),(21,15,9,3,4,2,1,1200000,7,9,10,1,'2021-12-17 22:49:06',1,'2022-06-21 00:38:08'),(22,1,1,3,6,2,1,14500000,8,8,10,1,'2021-12-26 15:03:24',19,'2022-01-06 21:27:44'),(23,1,2,2,1,1,1,6000000,8,7,10,1,'2021-12-26 15:07:14',1,'2021-12-26 15:07:58'),(24,7,2,2,1,1,1,6500000,9,5,10,1,'2021-12-26 15:13:00',1,'2022-05-31 01:02:43'),(25,8,6,4,6,1,1,20000000,12,10,10,1,'2021-12-26 15:18:13',1,'2022-05-15 06:11:26'),(26,5,7,2,1,2,3,6500000,12,8,10,1,'2021-12-26 15:22:01',1,'2022-06-01 16:33:23'),(27,2,3,3,5,2,1,9000000,10,4,10,1,'2021-12-26 15:44:12',1,'2022-05-15 10:33:09'),(28,3,5,3,5,2,1,9500000,7,4,10,1,'2021-12-26 15:47:02',1,'2021-12-26 15:47:43'),(29,3,4,3,5,1,1,12000000,5,6,10,1,'2021-12-26 15:51:17',17,'2022-01-02 20:56:43'),(30,4,4,2,1,1,1,8000000,6,6,10,1,'2021-12-26 15:54:33',19,'2022-01-06 21:21:14'),(31,10,9,2,1,1,1,7000000,5,7,10,1,'2021-12-26 15:57:37',1,'2021-12-26 15:57:37'),(32,11,5,2,1,1,1,5000000,6,4,10,1,'2021-12-26 16:01:35',1,'2022-05-15 07:21:45'),(33,15,4,4,6,1,1,4000000,10,8,10,1,'2021-12-26 16:05:13',1,'2022-06-12 17:59:52'),(34,13,10,2,3,2,1,2300000,5,49,10,1,'2021-12-26 16:07:24',1,'2022-06-14 08:57:24'),(35,13,6,1,2,1,1,3200000,12,50,10,1,'2021-12-26 16:09:41',1,'2022-06-01 16:33:23'),(36,14,4,2,2,1,1,4000000,7,8,10,1,'2021-12-26 16:12:44',1,'2021-12-26 16:12:44'),(37,7,1,2,1,1,1,1200000,10,2,90,1,'2022-02-02 14:15:14',1,'2022-02-02 14:16:19'),(38,17,NULL,6,NULL,NULL,1,65000,0,50,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32'),(39,18,NULL,6,NULL,NULL,1,55000,0,100,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32'),(40,18,NULL,7,NULL,NULL,1,105000,0,100,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32'),(41,18,NULL,8,NULL,NULL,1,150000,0,100,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32'),(42,17,NULL,7,NULL,NULL,1,79000,0,50,10,1,'2022-06-28 10:44:01',1,'2022-06-28 10:44:01'),(43,17,NULL,7,NULL,NULL,1,79000,0,50,10,1,'2022-06-28 11:34:12',1,'2022-06-28 11:34:12');
/*!40000 ALTER TABLE `productdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productimage`
--

DROP TABLE IF EXISTS `productimage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productimage` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `image` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productimage`
--

LOCK TABLES `productimage` WRITE;
/*!40000 ALTER TABLE `productimage` DISABLE KEYS */;
INSERT INTO `productimage` VALUES (1,'Image_PetDetail_399283bc-598c-4156-99ec-4f37db4a32bd.jpg',10,1,'2021-12-17 16:42:33',1,'2021-12-17 16:42:33'),(2,'Image_PetDetail_e8a16e04-e1f8-47bf-9785-4f6e07e2ad41.jpg',10,1,'2021-12-17 16:42:33',1,'2021-12-17 16:42:33'),(3,'Image_PetDetail_02de27aa-cc05-475d-84ba-1f71b11669a7.png',10,1,'2021-12-17 16:42:33',1,'2021-12-17 16:42:33'),(4,'Image_PetDetail_1cf02087-5f1f-49bd-9e53-5fb63694841e.png',10,1,'2021-12-17 16:55:17',1,'2021-12-17 16:55:17'),(5,'Image_PetDetail_b5918051-e5b3-4f89-a4fd-032248c4180a.jpg',10,1,'2021-12-17 16:55:17',1,'2021-12-17 16:55:17'),(6,'Image_PetDetail_d07af5cd-61d3-4415-9586-2951cda1c0d4.png',10,1,'2021-12-17 16:55:17',1,'2021-12-17 16:55:17'),(7,'Image_PetDetail_1a4ced5e-5451-467e-9095-85b5aedc4f6b.jpg',10,1,'2021-12-17 17:00:13',1,'2021-12-17 17:00:13'),(8,'Image_PetDetail_6da6360c-541d-4bf5-8edd-7de883c4b02f.jpg',10,1,'2021-12-17 17:00:13',1,'2021-12-17 17:00:13'),(9,'Image_PetDetail_e1da75c9-bdda-44a8-9847-48a26c6b29da.jpg',10,1,'2021-12-17 17:00:13',1,'2021-12-17 17:00:13'),(10,'Image_PetDetail_bf85fe4c-226b-4f16-9869-cd3028a57b45.jpg',10,1,'2021-12-17 17:03:45',1,'2021-12-17 17:03:45'),(11,'Image_PetDetail_f4ccf872-643a-4034-b753-75c664b09ad4.jpg',10,1,'2021-12-17 17:03:45',1,'2021-12-17 17:03:45'),(12,'Image_PetDetail_a253a84e-8e5e-44e8-b1ad-1db5cf84a822.jpg',10,1,'2021-12-17 17:03:45',1,'2021-12-17 17:03:45'),(13,'Image_PetDetail_9b07654a-86c2-4636-939d-213ab6fb03fd.jpg',10,1,'2021-12-17 17:09:45',1,'2021-12-17 17:09:45'),(14,'Image_PetDetail_27458d7a-f7be-4b64-9cbe-97ed6f21eab7.jpg',10,1,'2021-12-17 17:09:45',1,'2021-12-17 17:09:45'),(15,'Image_PetDetail_f1bc517b-7a73-46e7-a410-c2ef24b9b275.jpg',10,1,'2021-12-17 17:09:45',1,'2021-12-17 17:09:45'),(16,'Image_PetDetail_44fb46aa-c67c-41b0-9201-9c480e11ce9a.jpg',10,1,'2021-12-17 17:13:18',1,'2021-12-17 17:13:18'),(17,'Image_PetDetail_d5f6a4c3-44fa-4521-ae0f-e28ef9797dff.jpg',10,1,'2021-12-17 17:13:18',1,'2021-12-17 17:13:18'),(18,'Image_PetDetail_c1563a83-fd3a-4ca9-ab2f-8f69ec93db7b.jpg',10,1,'2021-12-17 17:13:18',1,'2021-12-17 17:13:18'),(19,'Image_PetDetail_6fcac3af-0347-4703-8a5f-58742bf8ef4e.jpg',10,1,'2021-12-17 17:16:42',1,'2021-12-17 17:16:42'),(20,'Image_PetDetail_9be3f4fd-35f0-4adb-9d36-5fc74cc69109.jpg',10,1,'2021-12-17 17:16:42',1,'2021-12-17 17:16:42'),(21,'Image_PetDetail_7b0563e6-fad6-4fc7-b9ba-288aa54a6f10.jpg',10,1,'2021-12-17 17:16:42',1,'2021-12-17 17:16:42'),(22,'Image_PetDetail_b42e2cb9-a8a5-4f5a-88e3-c13bc604517f.jpg',10,1,'2021-12-17 21:19:54',1,'2021-12-17 21:19:54'),(23,'Image_PetDetail_a7db2d13-309c-44ff-bc92-99dd1159b598.jpg',10,1,'2021-12-17 21:19:54',1,'2021-12-17 21:19:54'),(24,'Image_PetDetail_2559845b-9eae-441a-b3bc-568456d3f737.jpg',10,1,'2021-12-17 21:19:54',1,'2021-12-17 21:19:54'),(25,'Image_PetDetail_776f1fd7-90d9-4437-b13f-ed40341ca77f.jpg',10,1,'2021-12-17 21:29:11',1,'2021-12-17 21:29:11'),(26,'Image_PetDetail_444f1256-c663-4bcb-8176-d3ae509f490c.jpg',10,1,'2021-12-17 21:29:11',1,'2021-12-17 21:29:11'),(27,'Image_PetDetail_242b0ae4-748d-4ed2-846e-b73a62e65f4e.jpg',10,1,'2021-12-17 21:29:11',1,'2021-12-17 21:29:11'),(28,'Image_PetDetail_436bb5e5-4c59-4e6a-b4fc-c3e8e321bc69.jpg',10,1,'2021-12-17 21:35:37',1,'2021-12-17 21:35:37'),(29,'Image_PetDetail_b7406502-3f33-4a93-baa5-c0aba9cf9d32.jpg',10,1,'2021-12-17 21:35:37',1,'2021-12-17 21:35:37'),(30,'Image_PetDetail_ecf18c13-df90-4196-adb1-87d1aeeca0af.jpg',10,1,'2021-12-17 21:35:37',1,'2021-12-17 21:35:37'),(31,'Image_PetDetail_30223709-85eb-4f07-bcbd-fdc825ca612b.jpg',10,1,'2021-12-17 21:40:41',1,'2021-12-17 21:40:41'),(32,'Image_PetDetail_72263594-ab2f-4784-a1e4-8c953bee01d8.jpg',10,1,'2021-12-17 21:40:41',1,'2021-12-17 21:40:41'),(33,'Image_PetDetail_354a444b-b843-4f47-aa92-b8c23b0673ee.jpg',10,1,'2021-12-17 21:40:41',1,'2021-12-17 21:40:41'),(34,'Image_PetDetail_12192576-2d62-4546-b177-981744254e1e.jpg',10,1,'2021-12-17 21:46:15',1,'2021-12-17 21:46:15'),(35,'Image_PetDetail_12f3daec-5fb5-4638-9a0c-3bc55b6e9477.jpg',10,1,'2021-12-17 21:46:15',1,'2021-12-17 21:46:15'),(36,'Image_PetDetail_5a8d3fb4-c57b-40a1-9d6a-df486932d701.jpg',10,1,'2021-12-17 21:46:15',1,'2021-12-17 21:46:15'),(37,'Image_PetDetail_a00339f8-d388-4fd5-9387-91148f9cd8d3.jpg',10,1,'2021-12-17 21:49:16',1,'2021-12-17 21:49:16'),(38,'Image_PetDetail_1c233864-dd9e-4fd4-b81f-9c02dcb6ee1e.jpg',10,1,'2021-12-17 21:49:16',1,'2021-12-17 21:49:16'),(39,'Image_PetDetail_57a1daf6-64ac-429d-9095-5f17e98e41be.jpg',10,1,'2021-12-17 21:49:16',1,'2021-12-17 21:49:16'),(40,'Image_PetDetail_53b6186c-e1db-4b0d-b212-a936c7001c70.jpg',10,1,'2021-12-17 21:54:21',1,'2021-12-17 21:54:21'),(41,'Image_PetDetail_0d3f2d14-2bb3-46d1-b9ee-4d2b5bedf9d2.jpg',10,1,'2021-12-17 21:54:21',1,'2021-12-17 21:54:21'),(42,'Image_PetDetail_f607f2fa-0e50-4109-a6d0-dc799d3df67e.jpg',10,1,'2021-12-17 21:54:21',1,'2021-12-17 21:54:21'),(43,'Image_PetDetail_08c40c7d-80b8-42a4-8d67-0d8bd311289f.jpg',10,1,'2021-12-17 21:57:32',1,'2021-12-17 21:57:32'),(44,'Image_PetDetail_446de3bb-93a7-4a52-8b4b-893fc21c6150.jpg',10,1,'2021-12-17 21:57:32',1,'2021-12-17 21:57:32'),(45,'Image_PetDetail_2036b9aa-f118-460f-8ef1-fc78aec09a5d.jpg',10,1,'2021-12-17 21:57:32',1,'2021-12-17 21:57:32'),(46,'Image_PetDetail_60af76b3-312e-4d77-bdbf-b0d7ff88d3e9.jpg',10,1,'2021-12-17 22:04:43',1,'2021-12-17 22:04:43'),(47,'Image_PetDetail_a21a9550-6031-4ea4-b367-3bf5761844f8.jpg',10,1,'2021-12-17 22:04:43',1,'2021-12-17 22:04:43'),(48,'Image_PetDetail_b8ff6e9e-ed0d-4763-8aa6-9b330e9abd2b.jpg',10,1,'2021-12-17 22:04:43',1,'2021-12-17 22:04:43'),(49,'Image_PetDetail_5ad96f19-a488-4b43-97d1-00d9777fbec2.jpg',10,1,'2021-12-17 22:09:53',1,'2021-12-17 22:09:53'),(50,'Image_PetDetail_05c8565d-16eb-4c99-976e-b32d9938d70a.jpg',10,1,'2021-12-17 22:09:53',1,'2021-12-17 22:09:53'),(51,'Image_PetDetail_9ba8a9b5-f1fb-4c1e-b21f-c80ecc788dcb.jpg',10,1,'2021-12-17 22:09:53',1,'2021-12-17 22:09:53'),(52,'Image_PetDetail_fd92fa83-6b6e-4d93-9f4a-2595fd098818.jpg',10,1,'2021-12-17 22:22:34',1,'2021-12-17 22:22:34'),(53,'Image_PetDetail_92b08d2f-f1c1-42aa-9b2f-4145291904fa.jpg',10,1,'2021-12-17 22:22:34',1,'2021-12-17 22:22:34'),(54,'Image_PetDetail_448b4cb8-6bc2-4522-987b-b70d8026dbba.jpg',10,1,'2021-12-17 22:22:34',1,'2021-12-17 22:22:34'),(55,'Image_PetDetail_286120c8-c491-4396-a26a-0ba4ff9aa88a.jpg',10,1,'2021-12-17 22:40:19',1,'2021-12-17 22:40:19'),(56,'Image_PetDetail_0b4a74a9-41ea-467d-8f1d-f0375cf85ba6.jpg',10,1,'2021-12-17 22:40:19',1,'2021-12-17 22:40:19'),(57,'Image_PetDetail_6c507e10-a390-4d64-83fb-25047db85e95.jpg',10,1,'2021-12-17 22:40:19',1,'2021-12-17 22:40:19'),(58,'Image_PetDetail_59129345-4b01-44c4-b16a-84a001138ea3.jpg',10,1,'2021-12-17 22:43:09',1,'2021-12-17 22:43:09'),(59,'Image_PetDetail_b6aa9cdc-adf4-4395-b883-f915427e2fb1.jpg',10,1,'2021-12-17 22:43:09',1,'2021-12-17 22:43:09'),(60,'Image_PetDetail_a726ee23-0043-4846-8351-be1aae179d49.jpg',10,1,'2021-12-17 22:43:09',1,'2021-12-17 22:43:09'),(61,'Image_PetDetail_01bf6b7b-8708-4b7f-853a-7519c243ee5f.jpg',10,1,'2021-12-17 22:49:06',1,'2021-12-17 22:49:06'),(62,'Image_PetDetail_c72a55dc-e7d7-4a74-b587-a13d990c140a.jpg',10,1,'2021-12-17 22:49:06',1,'2021-12-17 22:49:06'),(63,'Image_PetDetail_b43dfa6f-2b10-4d27-bf3c-5fa1020f801a.jpg',10,1,'2021-12-17 22:49:06',1,'2021-12-17 22:49:06'),(64,'Image_PetDetail_cf8ee01a-59de-49cb-b13c-8c64c77e2faf.jpg',10,1,'2021-12-26 15:03:24',1,'2021-12-26 15:03:24'),(65,'Image_PetDetail_75841fca-dacb-4c1e-a9bb-01a7c2a9efd4.jpg',10,1,'2021-12-26 15:03:24',1,'2021-12-26 15:03:24'),(66,'Image_PetDetail_2b093425-dd29-4645-9bf1-8ecc1a995d40.jpg',10,1,'2021-12-26 15:03:24',1,'2021-12-26 15:03:24'),(67,'Image_PetDetail_65686cf8-958b-4578-ad2f-0ecb798e6d62.jpg',10,1,'2021-12-26 15:07:58',1,'2021-12-26 15:07:58'),(68,'Image_PetDetail_51431b3d-c4eb-49b8-9824-5c65fdb06f39.jpg',10,1,'2021-12-26 15:07:58',1,'2021-12-26 15:07:58'),(69,'Image_PetDetail_ac6b795a-6aef-434a-ba86-bbb128d64709.jpg',10,1,'2021-12-26 15:07:58',1,'2021-12-26 15:07:58'),(70,'Image_PetDetail_3d7530f0-dc80-4210-9493-5a1a3910cbb2.jpg',10,1,'2021-12-26 15:13:00',1,'2021-12-26 15:13:00'),(71,'Image_PetDetail_b3bd5b94-742f-4399-88e5-c656cda59137.jpg',10,1,'2021-12-26 15:13:00',1,'2021-12-26 15:13:00'),(72,'Image_PetDetail_e65fdebb-b8e8-4798-8780-a574b875b71a.jpg',10,1,'2021-12-26 15:13:00',1,'2021-12-26 15:13:00'),(73,'Image_PetDetail_7aebe09f-04b4-4f5f-a91f-596084f0d2bc.jpg',10,1,'2021-12-26 15:18:13',1,'2021-12-26 15:18:13'),(74,'Image_PetDetail_17fff68b-1394-489c-8c18-c5725a73b96a.jpg',10,1,'2021-12-26 15:18:13',1,'2021-12-26 15:18:13'),(75,'Image_PetDetail_946bd14e-678c-40f6-a031-f9bf76883ce8.jpg',10,1,'2021-12-26 15:18:13',1,'2021-12-26 15:18:13'),(76,'Image_PetDetail_528d3a6c-a16e-420c-80d2-3f53e0393353.jpg',10,1,'2021-12-26 15:22:01',1,'2021-12-26 15:22:01'),(77,'Image_PetDetail_fbb87aa3-4649-4bf0-9189-b181185096ba.jpg',10,1,'2021-12-26 15:22:01',1,'2021-12-26 15:22:01'),(78,'Image_PetDetail_c361eed9-169c-4a0e-9d71-477c65961370.jpg',10,1,'2021-12-26 15:22:01',1,'2021-12-26 15:22:01'),(79,'Image_PetDetail_b2ef84ac-73d2-4be2-9820-edcc74d89a04.jpg',10,1,'2021-12-26 15:44:12',1,'2021-12-26 15:44:12'),(80,'Image_PetDetail_fe59fdf6-3bf0-413d-a5e2-8fe94e145e6b.jpg',10,1,'2021-12-26 15:44:12',1,'2021-12-26 15:44:12'),(81,'Image_PetDetail_51fedae3-0c34-4654-8849-d3b9cfce83a0.jpg',10,1,'2021-12-26 15:44:12',1,'2021-12-26 15:44:12'),(82,'Image_PetDetail_b6ba50b3-c60b-4f86-8627-40f9f3a316b1.jpg',10,1,'2021-12-26 15:47:43',1,'2021-12-26 15:47:43'),(83,'Image_PetDetail_1afdeb05-ed20-42f2-b4cd-6fd35f278275.jpg',10,1,'2021-12-26 15:47:43',1,'2021-12-26 15:47:43'),(84,'Image_PetDetail_e375cc83-a8a2-49fb-b084-8de64c59bda5.jpg',10,1,'2021-12-26 15:47:43',1,'2021-12-26 15:47:43'),(85,'Image_PetDetail_3ae484bb-bd4d-4296-b002-f4d276b8f6f1.jpg',10,1,'2021-12-26 15:51:17',1,'2021-12-26 15:51:17'),(86,'Image_PetDetail_329c55cd-926e-4242-bb19-4f579290c5a1.jpg',10,1,'2021-12-26 15:51:17',1,'2021-12-26 15:51:17'),(87,'Image_PetDetail_a9c02aec-3ad3-48d1-9758-b7ffde70060b.jpg',10,1,'2021-12-26 15:51:17',1,'2021-12-26 15:51:17'),(88,'Image_PetDetail_9795e42f-09a3-4570-845f-3a71c775a6c1.jpg',10,1,'2021-12-26 15:54:33',1,'2021-12-26 15:54:33'),(89,'Image_PetDetail_a3a1fbee-0369-4db0-bd01-b429a2669704.jpg',10,1,'2021-12-26 15:54:33',1,'2021-12-26 15:54:33'),(90,'Image_PetDetail_c7c0f3c0-1dde-47fc-b2f3-692ac86fd7b5.jpg',10,1,'2021-12-26 15:54:33',1,'2021-12-26 15:54:33'),(91,'Image_PetDetail_4583fe9e-2259-4bee-96bd-42f70eb3e5ee.jpg',10,1,'2021-12-26 15:57:37',1,'2021-12-26 15:57:37'),(92,'Image_PetDetail_bea7a6c4-3415-438f-ab7c-5e2a28927cf5.jpg',10,1,'2021-12-26 15:57:37',1,'2021-12-26 15:57:37'),(93,'Image_PetDetail_c1ee226e-9775-4690-9826-a3eeace10782.jpg',10,1,'2021-12-26 15:57:37',1,'2021-12-26 15:57:37'),(94,'Image_PetDetail_b3b10aa7-068c-49ca-a6bf-59a3e6f49da4.jpg',10,1,'2021-12-26 16:01:35',1,'2021-12-26 16:01:35'),(95,'Image_PetDetail_bbbfaae5-94bb-4255-a05d-12e65c3f9c1f.jpg',10,1,'2021-12-26 16:01:35',1,'2021-12-26 16:01:35'),(96,'Image_PetDetail_62faf173-8178-4b1c-b56e-cf398ea89400.jpg',10,1,'2021-12-26 16:01:35',1,'2021-12-26 16:01:35'),(97,'Image_PetDetail_9de46158-259d-44fc-b9b7-b3850999e930.jpg',10,1,'2021-12-26 16:05:13',1,'2021-12-26 16:05:13'),(98,'Image_PetDetail_366e0dae-57b2-4825-a340-103d66417493.jpg',10,1,'2021-12-26 16:05:13',1,'2021-12-26 16:05:13'),(99,'Image_PetDetail_4d7c14c3-7b70-4669-8b57-8c80490caf22.jpg',10,1,'2021-12-26 16:05:13',1,'2021-12-26 16:05:13'),(100,'Image_PetDetail_29e3f998-dbd6-497a-b4fe-2eb772e3bced.jpg',10,1,'2021-12-26 16:07:24',1,'2021-12-26 16:07:24'),(101,'Image_PetDetail_75da4d1c-7c50-4213-83d3-268dde43005d.jpg',10,1,'2021-12-26 16:07:24',1,'2021-12-26 16:07:24'),(102,'Image_PetDetail_f70a2e80-d370-44b0-a572-355a9d7f0909.jpg',10,1,'2021-12-26 16:07:24',1,'2021-12-26 16:07:24'),(103,'Image_PetDetail_2a8a54e9-1e7f-4b9d-a26e-9dafa2fc627f.jpg',10,1,'2021-12-26 16:09:41',1,'2021-12-26 16:09:41'),(104,'Image_PetDetail_d922a268-8ff7-4746-b589-40b829fff423.jpg',10,1,'2021-12-26 16:09:41',1,'2021-12-26 16:09:41'),(105,'Image_PetDetail_4f4874ae-c45a-4fee-a9a7-06d8a1c6eccf.jpg',10,1,'2021-12-26 16:09:41',1,'2021-12-26 16:09:41'),(106,'Image_PetDetail_c9fb6fa5-11d3-4db1-baba-2d68200e780c.jpg',10,1,'2021-12-26 16:12:44',1,'2021-12-26 16:12:44'),(107,'Image_PetDetail_45082117-7d31-4639-968b-9d09e4d65282.jpg',10,1,'2021-12-26 16:12:44',1,'2021-12-26 16:12:44'),(108,'Image_PetDetail_4a52ea77-670d-4fbe-a55c-71ecd5ac2719.jpg',10,1,'2021-12-26 16:12:44',1,'2021-12-26 16:12:44'),(109,'Image_PetDetail_ae3b55d5-7a1e-430a-b61d-6cf61ca69a31.jpg',10,1,'2022-02-02 14:15:14',1,'2022-02-02 14:15:14'),(110,'Image_PetDetail_a9429247-f40c-41a7-b062-f55afe12cc6d.jpeg',10,1,'2022-02-02 14:15:14',1,'2022-02-02 14:15:14'),(111,'Image_PetDetail_be8f1439-6d19-43c6-af51-578ddb61ca4a.jpg',10,1,'2022-02-02 14:15:14',1,'2022-02-02 14:15:14');
/*!40000 ALTER TABLE `productimage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productimagefor`
--

DROP TABLE IF EXISTS `productimagefor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productimagefor` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `productdetailid` bigint unsigned NOT NULL,
  `productimageid` bigint unsigned NOT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`,`productimageid`,`productdetailid`)
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productimagefor`
--

LOCK TABLES `productimagefor` WRITE;
/*!40000 ALTER TABLE `productimagefor` DISABLE KEYS */;
INSERT INTO `productimagefor` VALUES (1,1,1,10,1,'2021-12-17 16:42:33',1,'2021-12-17 16:42:33'),(2,1,2,10,1,'2021-12-17 16:42:33',1,'2021-12-17 16:42:33'),(3,1,3,10,1,'2021-12-17 16:42:33',1,'2021-12-17 16:42:33'),(4,2,4,10,1,'2021-12-17 16:55:17',1,'2021-12-17 16:55:17'),(5,2,5,10,1,'2021-12-17 16:55:17',1,'2021-12-17 16:55:17'),(6,2,6,10,1,'2021-12-17 16:55:17',1,'2021-12-17 16:55:17'),(7,3,7,10,1,'2021-12-17 17:00:13',1,'2021-12-17 17:00:13'),(8,3,8,10,1,'2021-12-17 17:00:13',1,'2021-12-17 17:00:13'),(9,3,9,10,1,'2021-12-17 17:00:13',1,'2021-12-17 17:00:13'),(10,4,10,10,1,'2021-12-17 17:03:45',1,'2021-12-17 17:03:45'),(11,4,11,10,1,'2021-12-17 17:03:45',1,'2021-12-17 17:03:45'),(12,4,12,10,1,'2021-12-17 17:03:45',1,'2021-12-17 17:03:45'),(13,5,13,10,1,'2021-12-17 17:09:45',1,'2021-12-17 17:09:45'),(14,5,14,10,1,'2021-12-17 17:09:45',1,'2021-12-17 17:09:45'),(15,5,15,10,1,'2021-12-17 17:09:45',1,'2021-12-17 17:09:45'),(16,6,16,10,1,'2021-12-17 17:13:18',1,'2021-12-17 17:13:18'),(17,6,17,10,1,'2021-12-17 17:13:18',1,'2021-12-17 17:13:18'),(18,6,18,10,1,'2021-12-17 17:13:18',1,'2021-12-17 17:13:18'),(19,7,19,10,1,'2021-12-17 17:16:42',1,'2021-12-17 17:16:42'),(20,7,20,10,1,'2021-12-17 17:16:42',1,'2021-12-17 17:16:42'),(21,7,21,10,1,'2021-12-17 17:16:42',1,'2021-12-17 17:16:42'),(22,8,22,10,1,'2021-12-17 21:19:54',1,'2021-12-17 21:19:54'),(23,8,23,10,1,'2021-12-17 21:19:54',1,'2021-12-17 21:19:54'),(24,8,24,10,1,'2021-12-17 21:19:54',1,'2021-12-17 21:19:54'),(25,9,25,10,1,'2021-12-17 21:29:11',1,'2021-12-17 21:29:11'),(26,9,26,10,1,'2021-12-17 21:29:11',1,'2021-12-17 21:29:11'),(27,9,27,10,1,'2021-12-17 21:29:11',1,'2021-12-17 21:29:11'),(28,10,28,10,1,'2021-12-17 21:35:37',1,'2021-12-17 21:35:37'),(29,10,29,10,1,'2021-12-17 21:35:37',1,'2021-12-17 21:35:37'),(30,10,30,10,1,'2021-12-17 21:35:37',1,'2021-12-17 21:35:37'),(31,11,31,10,1,'2021-12-17 21:40:41',1,'2021-12-17 21:40:41'),(32,11,32,10,1,'2021-12-17 21:40:41',1,'2021-12-17 21:40:41'),(33,11,33,10,1,'2021-12-17 21:40:41',1,'2021-12-17 21:40:41'),(34,12,34,10,1,'2021-12-17 21:46:15',1,'2021-12-17 21:46:15'),(35,12,35,10,1,'2021-12-17 21:46:15',1,'2021-12-17 21:46:15'),(36,12,36,10,1,'2021-12-17 21:46:15',1,'2021-12-17 21:46:15'),(37,13,37,10,1,'2021-12-17 21:49:16',1,'2021-12-17 21:49:16'),(38,13,38,10,1,'2021-12-17 21:49:16',1,'2021-12-17 21:49:16'),(39,13,39,10,1,'2021-12-17 21:49:16',1,'2021-12-17 21:49:16'),(40,14,40,10,1,'2021-12-17 21:54:21',1,'2021-12-17 21:54:21'),(41,14,41,10,1,'2021-12-17 21:54:21',1,'2021-12-17 21:54:21'),(42,14,42,10,1,'2021-12-17 21:54:21',1,'2021-12-17 21:54:21'),(43,15,43,10,1,'2021-12-17 21:57:32',1,'2021-12-17 21:57:32'),(44,15,44,10,1,'2021-12-17 21:57:32',1,'2021-12-17 21:57:32'),(45,15,45,10,1,'2021-12-17 21:57:32',1,'2021-12-17 21:57:32'),(46,16,46,10,1,'2021-12-17 22:04:43',1,'2021-12-17 22:04:43'),(47,16,47,10,1,'2021-12-17 22:04:43',1,'2021-12-17 22:04:43'),(48,16,48,10,1,'2021-12-17 22:04:43',1,'2021-12-17 22:04:43'),(49,17,49,10,1,'2021-12-17 22:09:53',1,'2021-12-17 22:09:53'),(50,17,50,10,1,'2021-12-17 22:09:53',1,'2021-12-17 22:09:53'),(51,17,51,10,1,'2021-12-17 22:09:53',1,'2021-12-17 22:09:53'),(52,18,52,10,1,'2021-12-17 22:22:34',1,'2021-12-17 22:22:34'),(53,18,53,10,1,'2021-12-17 22:22:34',1,'2021-12-17 22:22:34'),(54,18,54,10,1,'2021-12-17 22:22:34',1,'2021-12-17 22:22:34'),(55,19,55,10,1,'2021-12-17 22:40:19',1,'2021-12-17 22:40:19'),(56,19,56,10,1,'2021-12-17 22:40:19',1,'2021-12-17 22:40:19'),(57,19,57,10,1,'2021-12-17 22:40:19',1,'2021-12-17 22:40:19'),(58,20,58,10,1,'2021-12-17 22:43:09',1,'2021-12-17 22:43:09'),(59,20,59,10,1,'2021-12-17 22:43:09',1,'2021-12-17 22:43:09'),(60,20,60,10,1,'2021-12-17 22:43:09',1,'2021-12-17 22:43:09'),(61,21,61,10,1,'2021-12-17 22:49:06',1,'2021-12-17 22:49:06'),(62,21,62,10,1,'2021-12-17 22:49:06',1,'2021-12-17 22:49:06'),(63,21,63,10,1,'2021-12-17 22:49:06',1,'2021-12-17 22:49:06'),(64,22,64,10,1,'2021-12-26 15:03:24',1,'2021-12-26 15:03:24'),(65,22,65,10,1,'2021-12-26 15:03:24',1,'2021-12-26 15:03:24'),(66,22,66,10,1,'2021-12-26 15:03:24',1,'2021-12-26 15:03:24'),(67,23,67,10,1,'2021-12-26 15:07:58',1,'2021-12-26 15:07:58'),(68,23,68,10,1,'2021-12-26 15:07:58',1,'2021-12-26 15:07:58'),(69,23,69,10,1,'2021-12-26 15:07:58',1,'2021-12-26 15:07:58'),(70,24,70,10,1,'2021-12-26 15:13:00',1,'2021-12-26 15:13:00'),(71,24,71,10,1,'2021-12-26 15:13:00',1,'2021-12-26 15:13:00'),(72,24,72,10,1,'2021-12-26 15:13:00',1,'2021-12-26 15:13:00'),(73,25,73,10,1,'2021-12-26 15:18:13',1,'2021-12-26 15:18:13'),(74,25,74,10,1,'2021-12-26 15:18:13',1,'2021-12-26 15:18:13'),(75,25,75,10,1,'2021-12-26 15:18:13',1,'2021-12-26 15:18:13'),(76,26,76,10,1,'2021-12-26 15:22:01',1,'2021-12-26 15:22:01'),(77,26,77,10,1,'2021-12-26 15:22:01',1,'2021-12-26 15:22:01'),(78,26,78,10,1,'2021-12-26 15:22:01',1,'2021-12-26 15:22:01'),(79,27,79,10,1,'2021-12-26 15:44:12',1,'2021-12-26 15:44:12'),(80,27,80,10,1,'2021-12-26 15:44:12',1,'2021-12-26 15:44:12'),(81,27,81,10,1,'2021-12-26 15:44:12',1,'2021-12-26 15:44:12'),(82,28,82,10,1,'2021-12-26 15:47:43',1,'2021-12-26 15:47:43'),(83,28,83,10,1,'2021-12-26 15:47:43',1,'2021-12-26 15:47:43'),(84,28,84,10,1,'2021-12-26 15:47:43',1,'2021-12-26 15:47:43'),(85,29,85,10,1,'2021-12-26 15:51:17',1,'2021-12-26 15:51:17'),(86,29,86,10,1,'2021-12-26 15:51:17',1,'2021-12-26 15:51:17'),(87,29,87,10,1,'2021-12-26 15:51:17',1,'2021-12-26 15:51:17'),(88,30,88,10,1,'2021-12-26 15:54:33',1,'2021-12-26 15:54:33'),(89,30,89,10,1,'2021-12-26 15:54:33',1,'2021-12-26 15:54:33'),(90,30,90,10,1,'2021-12-26 15:54:33',1,'2021-12-26 15:54:33'),(91,31,91,10,1,'2021-12-26 15:57:37',1,'2021-12-26 15:57:37'),(92,31,92,10,1,'2021-12-26 15:57:37',1,'2021-12-26 15:57:37'),(93,31,93,10,1,'2021-12-26 15:57:37',1,'2021-12-26 15:57:37'),(94,32,94,10,1,'2021-12-26 16:01:35',1,'2021-12-26 16:01:35'),(95,32,95,10,1,'2021-12-26 16:01:35',1,'2021-12-26 16:01:35'),(96,32,96,10,1,'2021-12-26 16:01:35',1,'2021-12-26 16:01:35'),(97,33,97,10,1,'2021-12-26 16:05:13',1,'2021-12-26 16:05:13'),(98,33,98,10,1,'2021-12-26 16:05:13',1,'2021-12-26 16:05:13'),(99,33,99,10,1,'2021-12-26 16:05:13',1,'2021-12-26 16:05:13'),(100,34,100,10,1,'2021-12-26 16:07:24',1,'2021-12-26 16:07:24'),(101,34,101,10,1,'2021-12-26 16:07:24',1,'2021-12-26 16:07:24'),(102,34,102,10,1,'2021-12-26 16:07:24',1,'2021-12-26 16:07:24'),(103,35,103,10,1,'2021-12-26 16:09:41',1,'2021-12-26 16:09:41'),(104,35,104,10,1,'2021-12-26 16:09:41',1,'2021-12-26 16:09:41'),(105,35,105,10,1,'2021-12-26 16:09:41',1,'2021-12-26 16:09:41'),(106,36,106,10,1,'2021-12-26 16:12:44',1,'2021-12-26 16:12:44'),(107,36,107,10,1,'2021-12-26 16:12:44',1,'2021-12-26 16:12:44'),(108,36,108,10,1,'2021-12-26 16:12:44',1,'2021-12-26 16:12:44'),(109,37,109,10,1,'2022-02-02 14:15:14',1,'2022-02-02 14:15:14'),(110,37,110,10,1,'2022-02-02 14:15:14',1,'2022-02-02 14:15:14'),(111,37,111,10,1,'2022-02-02 14:15:14',1,'2022-02-02 14:15:14');
/*!40000 ALTER TABLE `productimagefor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `promotion`
--

DROP TABLE IF EXISTS `promotion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `promotion` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `image` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `fromdate` datetime DEFAULT NULL,
  `todate` datetime DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `promotion`
--

LOCK TABLES `promotion` WRITE;
/*!40000 ALTER TABLE `promotion` DISABLE KEYS */;
INSERT INTO `promotion` VALUES (1,'Black Friday','Image_Promotion_838b3220-fe44-4a82-ba5e-a1fa8b1c2939.jpg','2021-11-18 00:00:00','2021-12-10 00:00:00',10,1,'2021-12-18 15:48:50',1,'2021-12-26 16:44:46'),(2,'Siêu sale 12.12','Image_Promotion_a858bf39-937e-43cf-9f75-6ed49fcbed0a.jpg','2021-12-12 00:00:00','2021-12-27 00:00:00',10,1,'2021-12-26 16:44:08',1,'2021-12-26 16:44:08'),(3,'Sale đón chào tết','Image_Promotion_37be95f1-e627-42fc-9a02-f6f52b6ac897.jpg','2022-01-01 00:00:00','2022-11-20 00:00:00',10,1,'2022-01-02 20:17:38',1,'2022-01-02 20:17:38');
/*!40000 ALTER TABLE `promotion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (10,'Quản trị viên',10),(20,'Nhân viên',10),(30,'Khách hàng',10);
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sex`
--

DROP TABLE IF EXISTS `sex`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sex` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sex`
--

LOCK TABLES `sex` WRITE;
/*!40000 ALTER TABLE `sex` DISABLE KEYS */;
INSERT INTO `sex` VALUES (1,'Đực',10),(2,'Cái',10);
/*!40000 ALTER TABLE `sex` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `size`
--

DROP TABLE IF EXISTS `size`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `size` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `orderview` int DEFAULT NULL,
  `typeproductid` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `size`
--

LOCK TABLES `size` WRITE;
/*!40000 ALTER TABLE `size` DISABLE KEYS */;
INSERT INTO `size` VALUES (1,'Rất nhỏ',1,NULL,10,1,'2021-12-16 20:36:12',1,'2021-12-16 20:36:12'),(2,'Nhỏ',2,NULL,10,1,'2021-12-16 20:36:27',1,'2021-12-16 20:36:27'),(3,'Trung bình',3,NULL,10,1,'2021-12-16 20:36:41',1,'2021-12-16 20:36:41'),(4,'Lớn',4,NULL,10,1,'2021-12-16 20:36:56',1,'2021-12-16 20:36:56'),(5,'Rất lớn',5,NULL,10,1,'2021-12-16 20:37:37',1,'2021-12-16 20:37:37'),(6,'300g',6,20,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32'),(7,'500g',7,20,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32'),(8,'750g',8,20,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32'),(9,'1kg',9,20,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32'),(10,'1,5 kg',10,20,10,1,'2022-06-23 15:47:32',1,'2022-06-23 15:47:32');
/*!40000 ALTER TABLE `size` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=191 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (10,'Hoạt động'),(50,'Khóa'),(90,'Ngừng hoạt động'),(190,'Xóa');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statusdetail`
--

DROP TABLE IF EXISTS `statusdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statusdetail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statusdetail`
--

LOCK TABLES `statusdetail` WRITE;
/*!40000 ALTER TABLE `statusdetail` DISABLE KEYS */;
INSERT INTO `statusdetail` VALUES (1,'Đang bán',10),(2,'Ngừng bán',10),(3,'Hết hàng',10);
/*!40000 ALTER TABLE `statusdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statusorder`
--

DROP TABLE IF EXISTS `statusorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statusorder` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statusorder`
--

LOCK TABLES `statusorder` WRITE;
/*!40000 ALTER TABLE `statusorder` DISABLE KEYS */;
INSERT INTO `statusorder` VALUES (1,'Chờ duyệt',10),(2,'Duyệt và giao hàng',10),(3,'Giao hàng thành công',10),(4,'Hủy đơn hàng',10);
/*!40000 ALTER TABLE `statusorder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statuspayment`
--

DROP TABLE IF EXISTS `statuspayment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statuspayment` (
  `id` int NOT NULL,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statuspayment`
--

LOCK TABLES `statuspayment` WRITE;
/*!40000 ALTER TABLE `statuspayment` DISABLE KEYS */;
INSERT INTO `statuspayment` VALUES (10,'Chưa thanh toán',10),(20,'Đã thanh toán',10);
/*!40000 ALTER TABLE `statuspayment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplier` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `phone` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  `typeproductid` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'Thú kiểng','Số 175, đường số 26, khu dân cư Bình Phú, P10, Q6, TP. HCM','0389853946','thukieng@gmail.com',10,1,'2021-12-16 21:22:26',1,'2021-12-16 21:25:08',10),(2,'Lê Trung Pet','164/1 Tân Thới Hiệp 07, phường Tân Tới Hiệp, Quận 12, TP.HCM','0934068670','letrungpet@gmail.com',10,1,'2021-12-16 21:24:43',1,'2021-12-16 21:24:43',10),(3,'Dogily Petshop','63/14 Lê Văn Sỹ, Phường 13, Quận Phú Nhuận, TP.HCM','0918161911','dogilypetshop@gmail.com',10,1,'2021-12-16 21:26:33',1,'2021-12-16 21:26:33',10),(4,'Pet Xinh','730 Lê Đức Thọ, Gò Vấp, Tp.HCM','0373040479','petxinh@gmail.com',10,1,'2021-12-16 21:27:41',1,'2021-12-16 21:27:41',10),(5,'Nhà vật yêu','924 Nguyễn Trãi, P.14, Q.5, TP.HCM','0362719893','nhavatyeu@gmail.com',10,1,'2021-12-16 21:28:39',1,'2021-12-16 21:28:39',10),(6,'SC Dog Shop','486 Lý Thái Tổ , Phường 10, Quận 10, Tp.HCM','0934909698','scdogshop@gmail.com',10,1,'2021-12-16 21:29:41',1,'2021-12-16 21:29:41',10),(7,'Thế Giới Thú Cưng','424 Lạc Long Quân, Phường 5, Quận 11, TP. HCM','0922777707','tgthucung@gmail.com',10,1,'2021-12-16 21:30:36',1,'2021-12-16 21:30:36',10),(8,'Merge Pet','65/10, khu phố 3, phường Linh Xuân, Q. Thủ Đức, TP.HCM','0383567546','mergepet@gmail.com',10,1,'2021-12-16 21:32:21',1,'2021-12-16 21:32:21',10),(9,'Dinh dưỡng Thú cưng','Đặng Văn Bi, TP Thủ Đức, HCM','0939395890','ddtc@gmail.com',10,1,NULL,1,NULL,20);
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typenews`
--

DROP TABLE IF EXISTS `typenews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `typenews` (
  `id` int NOT NULL,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typenews`
--

LOCK TABLES `typenews` WRITE;
/*!40000 ALTER TABLE `typenews` DISABLE KEYS */;
INSERT INTO `typenews` VALUES (1,'Bài viết',10),(2,'Khuyến mãi',10);
/*!40000 ALTER TABLE `typenews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typepayment`
--

DROP TABLE IF EXISTS `typepayment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `typepayment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typepayment`
--

LOCK TABLES `typepayment` WRITE;
/*!40000 ALTER TABLE `typepayment` DISABLE KEYS */;
INSERT INTO `typepayment` VALUES (10,'Khi nhận hàng',10),(20,'Momo',10),(30,'VN Pay',10);
/*!40000 ALTER TABLE `typepayment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typeproduct`
--

DROP TABLE IF EXISTS `typeproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `typeproduct` (
  `id` int NOT NULL,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typeproduct`
--

LOCK TABLES `typeproduct` WRITE;
/*!40000 ALTER TABLE `typeproduct` DISABLE KEYS */;
INSERT INTO `typeproduct` VALUES (10,'Thú cưng',10),(20,'Thức ăn',10),(30,'Phụ kiện',10),(40,'Chuồng nuôi thú cưng',190);
/*!40000 ALTER TABLE `typeproduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `avatar` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `role` int DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createuser` bigint unsigned DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updateuser` bigint unsigned DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Huỳnh Trọng Nghĩa','huynhtrongnghia1090@gmail.com','0386998130','e1adc3949ba59abbe56e057f2f883e','Image_Avatar_5757d3df-fb54-407e-872b-71f43733f323.png','Tân Ngãi, Vĩnh Long',20,10,1,'2021-12-16 20:31:57',1,'2022-06-02 15:36:08'),(2,'Nguyễn Hoài Nam','18110321@student.hcmute.edu.vn','0366036372','a2a35fb2e5fb865b71e895e1c0b68348',NULL,'123, đường số 4, xã Hòa Tân, TP. Mỹ Tho, tỉnh Tiền Giang',10,10,2,'2021-12-16 21:37:34',2,'2022-06-10 17:42:32'),(3,'Võ Quốc Huy','huyvo@gmail.com','0379999999','e1adc3949ba59abbe56e057f2f883e',NULL,'Biên giới Việt Trung, Tây Bắc',10,10,2,'2021-12-18 16:46:19',2,'2021-12-18 17:58:01'),(4,'Thanh Thanh','thanhthanh@gmail.com','0997631091','e1adc3949ba59abbe56e057f2f883e',NULL,'Phố Núi, Phú Thọ',20,10,2,'2021-12-18 17:15:28',2,'2021-12-27 10:31:28'),(5,'Lâm Phát Tài','tailam@gmail.com','0976543218','e1adc3949ba59abbe56e057f2f883e',NULL,'346 Lê Văn Chí, Thủ Đức, TP.HCM',30,10,2,'2021-12-18 18:05:47',2,'2022-01-06 21:17:13'),(6,'Nguyễn Hoàng Minh','minhhoang@gmail.com','0776543219','e1adc3949ba59abbe56e057f2f883e','Image_Avatar_5ac0388f-5885-42ce-a6b8-4d4622744616.jpg','365 Lê Văn Việt, Thủ Đức, TP.HCM',30,10,2,'2021-12-18 18:07:12',2,'2021-12-27 10:07:10'),(7,'Lê Thị Hương','huongle@gmail.com','0365876598','e1adc3949ba59abbe56e057f2f883e',NULL,'134/6B Hoàng Giang, Nông Cống, Thanh Hóa',30,10,2,'2021-12-26 16:18:21',2,'2021-12-27 10:07:11'),(8,'Bùi Khánh Hải','haikhanhbui@gmail.com','0397384690','e1adc3949ba59abbe56e057f2f883e',NULL,'Tân Vĩnh Thuận, Tân Ngãi, Vĩnh Long',30,10,2,'2021-12-26 16:19:51',2,'2022-01-02 23:58:23'),(9,'Bùi Văn Nghĩa','nghiabui@gmail.com','0378965476','e1adc3949ba59abbe56e057f2f883e',NULL,'Hòa An, Hòa Bình, Tân Quới, Đồng Nai',30,10,2,'2021-12-26 16:22:24',2,'2021-12-27 10:21:40'),(10,'Lâm Quang Vỹ','quangvy@gmail.com','0356183492','e1adc3949ba59abbe56e057f2f883e',NULL,'Bình Thạnh, Thành phố Hồ Chí Minh',30,10,2,'2021-12-26 16:23:36',2,'2021-12-27 10:21:29'),(11,'Nguyễn Văn Pháp','phapvannguyen@gmail.com','0369872301','e1adc3949ba59abbe56e057f2f883e',NULL,'Bình Tân, TP. Hồ Chí Minh',30,10,2,'2021-12-26 16:25:58',2,'2021-12-26 16:25:58'),(12,'Huỳnh Phụng Kiều','kieuhuynh@gmail.com','0368769231','e1adc3949ba59abbe56e057f2f883e',NULL,'134/8B, Vĩnh Thuận, Tân Ngãi, Vĩnh Long',30,10,2,'2021-12-26 16:29:43',2,'2021-12-27 10:06:53'),(13,'Võ Quốc Cường','cuongvo@gmail.com','0386273458','e1adc3949ba59abbe56e057f2f883e',NULL,'Tân Quới Đông, Hòa An, Kiên Giang',30,10,2,'2021-12-26 16:31:28',2,'2021-12-26 16:31:28'),(14,'Đặng Minh Thi','thiminhdang@gmail.com','0342657865','e1adc3949ba59abbe56e057f2f883e',NULL,'Hòa An, Ninh Bình',30,10,2,'2021-12-26 16:37:21',2,'2021-12-27 10:40:10'),(15,'Trần Văn Hoàng','hoangtran@gmail.com','0732365876','e1adc3949ba59abbe56e057f2f883e',NULL,'Kom Tum, DakLak',30,10,2,'2021-12-26 16:38:27',2,'2021-12-27 10:40:11'),(16,'Tây Vĩnh Hòa','hoatay@gmail.com','0367823197','e1adc3949ba59abbe56e057f2f883e',NULL,'Di Linh, Lâm Đồng',30,10,2,'2021-12-27 10:06:10',2,'2021-12-27 11:12:32'),(17,'Phạm Xuân Nhuận','nhuanxuanpham@gmail.com','0398284673','e1adc3949ba59abbe56e057f2f883e',NULL,'Hòa Tây, Bến Tre',30,10,2,'2021-12-27 10:08:29',2,'2021-12-27 10:08:29'),(18,'Hồ Văn Hiếu','hieuho@gmail.com','0387623918','e1adc3949ba59abbe56e057f2f883e',NULL,'Di Linh, Đà Lạt',30,10,2,'2021-12-27 10:10:19',2,'2021-12-27 10:10:48'),(19,'Nguyễn Ngọc Hải','hainguyen@gmail.com','0365271987','e1adc3949ba59abbe56e057f2f883e',NULL,'KomTum, DakLak',30,10,2,'2021-12-27 10:23:23',2,'2021-12-27 10:23:23'),(20,'Đặng Trí Nguyên','nguyendang@gmail.com','0382198740','e1adc3949ba59abbe56e057f2f883e',NULL,'Hòa Bắc, Long Xuyên, An Giang',30,10,2,'2021-12-27 10:25:00',2,'2022-01-02 20:19:57'),(21,'Ngô Văn Minh','ngovanminh@gmail.com','0378398210','e1adc3949ba59abbe56e057f2f883e',NULL,'Hoàng Sơn, Minh Trí, Lào Cai',20,10,2,'2021-12-27 10:31:03',2,'2021-12-27 10:40:08'),(22,'Chu Minh Hiếu','hieuminh@gmail.com','0365198723','e1adc3949ba59abbe56e057f2f883e',NULL,'Tân Vĩnh Thuận, Tân Ngãi, Vĩnh Long',20,50,2,'2021-12-27 11:12:14',3,'2022-06-15 17:27:18'),(23,'Lê Gia Minh','giaminh@gmail.com','0378349821','e1adc3949ba59abbe56e057f2f883e',NULL,'Lê Văn A, Cách Mạng Tháng 8, Thủ Đức',20,50,2,'2021-12-27 11:23:31',3,'2022-06-15 17:27:13'),(24,'Hương Lê','huonglt18401@st.uel.edu.vn','0965218906','e1adc3949ba59abbe56e057f2f883e',NULL,'Nông Cống, Thanh Hóa',30,10,24,'2022-01-02 23:28:30',2,'2022-01-02 23:53:09'),(25,'Nam Nguyễn','namnh@gmail.com','0366036372','e1adc3949ba59abbe56e057f2f883e',NULL,'Chợ Gạo, Tiền Giang',30,10,25,'2022-04-17 14:20:19',25,'2022-04-17 14:20:19'),(26,'Nghĩa','nghiaabc@gmail.com','0989768976','e87f1fcf82d132f9bb018ca6738a19f',NULL,'An Dương Vương',30,10,26,'2022-05-05 16:57:37',26,'2022-05-05 16:57:37'),(27,'Nghĩa','nghiaabcd@gmail.com','0989768977','e87f1fcf82d132f9bb018ca6738a19f',NULL,'An Dương Vương',30,10,27,'2022-05-05 17:01:10',27,'2022-05-05 17:01:10'),(28,'Nghĩa','nghiahuynhtrong@gmail.com','12345264847','e87f1fcf82d132f9bb018ca6738a19f',NULL,'Lê Văn Việt',30,10,28,'2022-05-05 17:45:06',28,'2022-05-05 17:45:06'),(29,'Ngo That An','abcxyzk@gmail.com','0978654879','e87f1fcf82d132f9bb018ca6738a19f',NULL,'abcxy',30,10,29,'2022-05-05 17:54:50',29,'2022-05-05 17:54:50'),(30,'Huỳnh Cris','huynhtrongnghia111@gmail.com','07594937458474','e87f1fcf82d132f9bb018ca6738a19f',NULL,'abcxyz',30,10,30,'2022-05-08 17:23:48',30,'2022-05-08 17:23:48'),(31,'Huỳnh Cris','huynhtrongnghia111@gmail.com','07594937458474','e87f1fcf82d132f9bb018ca6738a19f',NULL,'abcxyz',30,10,31,'2022-05-08 17:23:50',31,'2022-05-08 17:23:50'),(32,'huynh trong','huynhtrongnghia10910@gmail.com','0866880858','e87f1fcf82d132f9bb018ca6738a19f',NULL,'abcxyz',30,10,32,'2022-05-09 17:39:33',32,'2022-05-09 17:39:33'),(33,'ngo','abcxy@gmail.com','03854679799','e87f1fcf82d132f9bb018ca6738a19f',NULL,'abcxyzjsjzj',30,10,33,'2022-05-09 17:40:43',33,'2022-05-09 17:40:43'),(34,'Namit','namnh01@gmail.com','0898989899','25f9e794323b453885f5181f1b624db',NULL,'Tiền Giang',30,10,34,'2022-06-04 08:11:20',34,'2022-06-04 08:11:20');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-28 11:51:19
