-- MySQL dump 10.13  Distrib 8.0.21, for macos10.15 (x86_64)
--
-- Host: 127.0.0.1    Database: dotify_v2
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `album_likes`
--

DROP TABLE IF EXISTS `album_likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `album_likes` (
  `user_id` int NOT NULL,
  `album_id` int NOT NULL,
  UNIQUE KEY `album_likes_user_id_album_id_uindex` (`user_id`,`album_id`),
  KEY `album_likes_albums_id_fk` (`album_id`),
  CONSTRAINT `album_likes_albums_id_fk` FOREIGN KEY (`album_id`) REFERENCES `albums` (`id`) ON DELETE CASCADE,
  CONSTRAINT `album_likes_users_id_fk` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `album_likes`
--

LOCK TABLES `album_likes` WRITE;
/*!40000 ALTER TABLE `album_likes` DISABLE KEYS */;
INSERT INTO `album_likes` (`user_id`, `album_id`) VALUES (4,1);
/*!40000 ALTER TABLE `album_likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `albums`
--

DROP TABLE IF EXISTS `albums`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `albums` (
  `id` int NOT NULL AUTO_INCREMENT,
  `artist_id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `cover_art` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `albums_artists_id_fk` (`artist_id`),
  CONSTRAINT `albums_artists_id_fk` FOREIGN KEY (`artist_id`) REFERENCES `artists` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `albums`
--

LOCK TABLES `albums` WRITE;
/*!40000 ALTER TABLE `albums` DISABLE KEYS */;
INSERT INTO `albums` (`id`, `artist_id`, `name`, `cover_art`) VALUES (1,1,'Foo',NULL);
/*!40000 ALTER TABLE `albums` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `artist_likes`
--

DROP TABLE IF EXISTS `artist_likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `artist_likes` (
  `user_id` int NOT NULL,
  `artist_id` int NOT NULL,
  UNIQUE KEY `artist_likes_user_id_artist_id_uindex` (`user_id`,`artist_id`),
  KEY `artist_likes_artists_id_fk` (`artist_id`),
  CONSTRAINT `artist_likes_artists_id_fk` FOREIGN KEY (`artist_id`) REFERENCES `artists` (`id`) ON DELETE CASCADE,
  CONSTRAINT `artist_likes_users_id_fk` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artist_likes`
--

LOCK TABLES `artist_likes` WRITE;
/*!40000 ALTER TABLE `artist_likes` DISABLE KEYS */;
INSERT INTO `artist_likes` (`user_id`, `artist_id`) VALUES (4,1);
/*!40000 ALTER TABLE `artist_likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `artists`
--

DROP TABLE IF EXISTS `artists`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `artists` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `picture` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `artists_user_id_uindex` (`user_id`),
  CONSTRAINT `artists_users_id_fk` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artists`
--

LOCK TABLES `artists` WRITE;
/*!40000 ALTER TABLE `artists` DISABLE KEYS */;
INSERT INTO `artists` (`id`, `user_id`, `name`, `picture`) VALUES (1,2,'Test',NULL),(11,4,'Hallo',NULL);
/*!40000 ALTER TABLE `artists` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `song_likes`
--

DROP TABLE IF EXISTS `song_likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `song_likes` (
  `user_id` int NOT NULL,
  `song_id` int NOT NULL,
  UNIQUE KEY `song_likes_user_id_song_id_uindex` (`user_id`,`song_id`),
  KEY `song_likes_songs_id_fk` (`song_id`),
  CONSTRAINT `song_likes_songs_id_fk` FOREIGN KEY (`song_id`) REFERENCES `songs` (`id`) ON DELETE CASCADE,
  CONSTRAINT `song_likes_users_id_fk` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `song_likes`
--

LOCK TABLES `song_likes` WRITE;
/*!40000 ALTER TABLE `song_likes` DISABLE KEYS */;
/*!40000 ALTER TABLE `song_likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `songs`
--

DROP TABLE IF EXISTS `songs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `songs` (
  `id` int NOT NULL AUTO_INCREMENT,
  `album_id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `duration` int NOT NULL,
  `file_name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `songs_albums_id_fk` (`album_id`),
  CONSTRAINT `songs_albums_id_fk` FOREIGN KEY (`album_id`) REFERENCES `albums` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `songs`
--

LOCK TABLES `songs` WRITE;
/*!40000 ALTER TABLE `songs` DISABLE KEYS */;
INSERT INTO `songs` (`id`, `album_id`, `name`, `duration`, `file_name`) VALUES (1,1,'Test',220,'test.mp3');
/*!40000 ALTER TABLE `songs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `api_token` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `users_api_token_uindex` (`api_token`),
  UNIQUE KEY `users_username_uindex` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`id`, `username`, `password`, `api_token`) VALUES (2,'Test','Test1234','69420'),(4,'Test2','Test1234','6XExLKYNlx6HEVaTk87CJhqGcjulkqd3GPvCWXe6Of1gqIyuNyie7EjRCnq4POcVW3z6LQFkrTjIZiBUhfIjtBaqVkjJ71vEt5UzHK9F2F1Jckebc6jKRwOtI975bsLyGLyJi9zFt8E9N1DgO88cpZocyMfqqh4COoP9MjENyj2qeSc0xxpHikGXKfeBAd9DEeygeYwpWSkbaGUi6iPOI3Y8AcbZaEwOhL5z5yd4Hc7qIGZ1YwWge9yxd4zEEjJ');
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

-- Dump completed on 2021-01-12  1:48:35
