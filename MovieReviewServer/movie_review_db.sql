-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: movie_review_db
-- ------------------------------------------------------
-- Server version	8.0.43

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
-- Table structure for table `actorfilm`
--

DROP TABLE IF EXISTS `actorfilm`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actorfilm` (
  `ActorsActorId` int NOT NULL,
  `FilmsFilmId` int NOT NULL,
  PRIMARY KEY (`ActorsActorId`,`FilmsFilmId`),
  KEY `IX_ActorFilm_FilmsFilmId` (`FilmsFilmId`),
  CONSTRAINT `FK_ActorFilm_Actors_ActorsActorId` FOREIGN KEY (`ActorsActorId`) REFERENCES `actors` (`ActorId`) ON DELETE CASCADE,
  CONSTRAINT `FK_ActorFilm_film_FilmsFilmId` FOREIGN KEY (`FilmsFilmId`) REFERENCES `film` (`FilmId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actorfilm`
--

LOCK TABLES `actorfilm` WRITE;
/*!40000 ALTER TABLE `actorfilm` DISABLE KEYS */;
INSERT INTO `actorfilm` VALUES (1,2),(2,3),(3,4),(11,4),(4,5),(5,5),(6,6),(7,7),(8,9),(9,9),(1,10),(13,10),(10,11),(4,12),(14,13),(1,14),(1,15),(12,16),(15,16);
/*!40000 ALTER TABLE `actorfilm` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actors`
--

DROP TABLE IF EXISTS `actors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actors` (
  `ActorId` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `last_name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `birth_day` date NOT NULL,
  PRIMARY KEY (`ActorId`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actors`
--

LOCK TABLES `actors` WRITE;
/*!40000 ALTER TABLE `actors` DISABLE KEYS */;
INSERT INTO `actors` VALUES (1,'Leonardo','DiCaprio','1974-11-11'),(2,'Matthew','McConaughey','1969-11-04'),(3,'Brad','Pitt','1963-12-18'),(4,'Joaquin','Phoenix','1974-10-28'),(5,'Russell','Crowe','1964-04-07'),(6,'Keanu','Reeves','1964-09-02'),(7,'Christian','Bale','1974-01-30'),(8,'Ryan','Gosling','1980-11-12'),(9,'Emma','Stone','1988-11-06'),(10,'Timothée','Chalamet','1995-12-27'),(11,'Samuel L.','Jackson','1948-12-21'),(12,'Marlon','Brando','1924-04-03'),(13,'Margot','Robbie','1990-07-02'),(14,'Miles','Teller','1987-02-20'),(15,'Al','Pacino','1940-04-25');
/*!40000 ALTER TABLE `actors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `film`
--

DROP TABLE IF EXISTS `film`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `film` (
  `FilmId` int NOT NULL AUTO_INCREMENT,
  `title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `year` int NOT NULL,
  `genre` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `producer` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `poster_link` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`FilmId`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `film`
--

LOCK TABLES `film` WRITE;
/*!40000 ALTER TABLE `film` DISABLE KEYS */;
INSERT INTO `film` VALUES (2,'Inception',2010,'Sci-Fi','Emma Thomas','https://image.tmdb.org/t/p/w600_and_h900_face/7NCFUxQNExfxd0kmkTqIwd1cMol.jpg'),(3,'Interstellar',2014,'Sci-Fi','Christopher Nolan','https://image.tmdb.org/t/p/w600_and_h900_face/bMKiLh0mES4Uiococ240lbbTGXQ.jpg'),(4,'Pulp Fiction',1994,'Crime','Lawrence Bender','https://image.tmdb.org/t/p/w600_and_h900_face/hOpN58hkQGZph5LHhyRrryy1hzF.jpg'),(5,'Il Gladiatore',2000,'Action','Douglas Wick','https://image.tmdb.org/t/p/w600_and_h900_face/euOKjQaV1QXtzLyNZAa1PMHGJlJ.jpg'),(6,'Matrix',1999,'Action','Joel Silver','https://image.tmdb.org/t/p/w600_and_h900_face/yQZX4scmfYtj4ccKFNGZJlOj1y9.jpg'),(7,'The Dark Knight',2008,'Action','Charles Roven','https://image.tmdb.org/t/p/w600_and_h900_face/qIhsgno1mjbzUbs4H6DaRjhskAR.jpg'),(8,'Parasite',2019,'Thriller','Kwak Sin-ae','https://image.tmdb.org/t/p/w600_and_h900_face/mMM8kcfspicib7AmPTvf97Rarwn.jpg'),(9,'La La Land',2016,'Musical','Fred Berger','https://image.tmdb.org/t/p/w600_and_h900_face/cWYy1YTVaZRAuxLtX1tYNvtzAt1.jpg'),(10,'The Wolf of Wall Street',2013,'Biography','Martin Scorsese','https://image.tmdb.org/t/p/w600_and_h900_face/ouASmpTP0qkHZFTttjczMkhFscS.jpg'),(11,'Dune',2021,'Sci-Fi','Mary Parent','https://image.tmdb.org/t/p/w600_and_h900_face/zolKD2yscZd86GviNa6pBPc6N9o.jpg'),(12,'Joker',2019,'Drama','Todd Phillips','https://image.tmdb.org/t/p/w600_and_h900_face/y1AthYH1r2j4N4cYn2HdrEGgrnJ.jpg'),(13,'Whiplash',2014,'Drama','Jason Blum','https://image.tmdb.org/t/p/w600_and_h900_face/7fn624j5lj3xTme2SgiLCeuedmO.jpg'),(14,'Shutter Island',2010,'Thriller','Mike Medavoy','https://image.tmdb.org/t/p/w600_and_h900_face/kgPRqDDr5RFkIly6CJrBPHYs2qS.jpg'),(15,'Django Unchained',2012,'Western','Stacey Sher','https://image.tmdb.org/t/p/w600_and_h900_face/igYptikalrjsMueMx6rz15lE4Ts.jpg'),(16,'Il Padrino',1972,'Crime','Albert S. Ruddy','https://image.tmdb.org/t/p/w600_and_h900_face/gemuM3FvVaWSEBrfk6nVFIOBhBY.jpg');
/*!40000 ALTER TABLE `film` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reviews`
--

DROP TABLE IF EXISTS `reviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reviews` (
  `UserId` int NOT NULL,
  `FilmId` int NOT NULL,
  `rating` int NOT NULL,
  `short_review` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`UserId`,`FilmId`),
  KEY `IX_Reviews_FilmId` (`FilmId`),
  CONSTRAINT `FK_Reviews_film_FilmId` FOREIGN KEY (`FilmId`) REFERENCES `film` (`FilmId`) ON DELETE CASCADE,
  CONSTRAINT `FK_Reviews_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reviews`
--

LOCK TABLES `reviews` WRITE;
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
INSERT INTO `reviews` VALUES (1,2,1,'Che merda 2'),(1,12,4,'Un po cupo questo Joker, ma fatto bene.'),(2,2,5,'La bomba, filmone'),(2,3,5,'Interstellar mi ha commosso, colonna sonora top.'),(2,9,1,'Non mi piace'),(3,4,4,'Pulp Fiction è un classico intramontabile.'),(4,5,5,'Il Gladiatore: un film epico sotto ogni aspetto.'),(5,6,4,'Matrix ha cambiato il genere Sci-Fi.'),(6,7,5,'Il miglior Batman di sempre.'),(7,8,4,'Parasite è geniale e imprevedibile.'),(8,9,3,'La La Land è carino, ma non il mio genere.'),(9,10,5,'DiCaprio fantastico in Wolf of Wall Street.'),(10,11,4,'Dune è visivamente mozzafiato.'),(11,12,5,'Joker: uninterpretazione da Oscar.'),(12,13,5,'Whiplash è pura tensione musicale.'),(13,14,4,'Shutter Island ti tiene col fiato sospeso.'),(14,15,5,'Django è il miglior film di Tarantino.'),(15,16,5,'Il Padrino è la perfezione cinematografica.'),(16,2,4,'Bello');
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `email` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `registration_date` date NOT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'marco88','marco@email.it','pass123','2023-01-10'),(2,'sofia_v','sofia@email.com','sofiapass','2023-02-15'),(3,'luca_dr','luca@web.it','lucaluca','2023-03-20'),(4,'giulia_smith','giulia@provider.com','giu2024','2023-05-12'),(5,'admin_test','admin@movie.com','adminroot','2023-01-01'),(6,'cinefilo99','cine@email.it','filmone','2023-06-30'),(7,'elena_rossi','elena@rossi.it','elenapass','2023-07-22'),(8,'stefano_b','stefano@web.it','stef89','2023-08-05'),(9,'chiara_m','chiara@email.com','chiara123','2023-09-18'),(10,'davide_lux','davide@provider.it','luxpass','2023-10-02'),(11,'fra_green','francesco@email.com','fra2023','2023-11-11'),(12,'valeria_c','valeria@web.it','valepass','2023-12-05'),(13,'andrea_pro','andrea@email.it','andrea90','2024-01-14'),(14,'marta_film','marta@web.it','martapass','2024-02-20'),(15,'piero_v','piero@email.com','pieropass','2024-03-01'),(16,'culo','dffds@dff.it','mario','2026-03-25');
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

-- Dump completed on 2026-03-25 17:40:13
