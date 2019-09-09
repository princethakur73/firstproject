CREATE DATABASE  IF NOT EXISTS `hvmschool` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `hvmschool`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: hvmschool
-- ------------------------------------------------------
-- Server version	5.7.20-log

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
-- Table structure for table `classmaster`
--

DROP TABLE IF EXISTS `classmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classmaster` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `RomanName` varchar(45) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classmaster`
--

LOCK TABLES `classmaster` WRITE;
/*!40000 ALTER TABLE `classmaster` DISABLE KEYS */;
INSERT INTO `classmaster` VALUES (1,'Nursery','Nursery','',0,'2018-05-20 00:00:00',1,'2018-05-20 00:00:00',1),(2,'KG','KG','',1,'2018-05-20 00:00:00',1,'2018-05-20 00:00:00',1);
/*!40000 ALTER TABLE `classmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contactus`
--

DROP TABLE IF EXISTS `contactus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contactus` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Subject` varchar(100) DEFAULT NULL,
  `Message` varchar(500) DEFAULT NULL,
  `CreateByUserIPAddress` varchar(45) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactus`
--

LOCK TABLES `contactus` WRITE;
/*!40000 ALTER TABLE `contactus` DISABLE KEYS */;
/*!40000 ALTER TABLE `contactus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `downloads`
--

DROP TABLE IF EXISTS `downloads`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `downloads` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClassMasterId` int(11) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `Title` varchar(100) DEFAULT NULL,
  `FileName` varchar(150) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `IsPublish` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `downloads`
--

LOCK TABLES `downloads` WRITE;
/*!40000 ALTER TABLE `downloads` DISABLE KEYS */;
INSERT INTO `downloads` VALUES (3,1,'2018-05-20 00:00:00','Date Sheet','Date Sheet-05-20-2018-3596.xls',1,'','2018-05-20 23:36:27',1,'2018-05-20 23:39:50',1);
/*!40000 ALTER TABLE `downloads` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gallery`
--

DROP TABLE IF EXISTS `gallery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gallery` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(155) DEFAULT NULL,
  `SessionId` int(11) DEFAULT NULL,
  `EventDate` datetime DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gallery`
--

LOCK TABLES `gallery` WRITE;
/*!40000 ALTER TABLE `gallery` DISABLE KEYS */;
INSERT INTO `gallery` VALUES (1,'School Extra Curricular Activities',2,'2018-03-25 00:00:00','School Extra Curricular Activities','','2018-03-25 20:57:06',1,'2018-03-25 22:56:30',0),(2,'dfssf',1,'2018-04-08 00:00:00','fdsdsfsd','','2018-04-08 23:27:33',1,'2018-04-08 23:27:33',1),(3,'hawan-ceremony',2,'2018-06-04 00:00:00','testing','','2018-06-04 01:16:12',1,'2018-06-04 01:16:12',1);
/*!40000 ALTER TABLE `gallery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gallerypicturemapping`
--

DROP TABLE IF EXISTS `gallerypicturemapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gallerypicturemapping` (
  `GalleryId` int(11) NOT NULL,
  `PictureId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gallerypicturemapping`
--

LOCK TABLES `gallerypicturemapping` WRITE;
/*!40000 ALTER TABLE `gallerypicturemapping` DISABLE KEYS */;
INSERT INTO `gallerypicturemapping` VALUES (1,36),(1,37),(1,38),(1,39),(1,40),(1,41),(1,42),(1,43),(1,44),(1,45),(1,46),(1,47),(1,48),(1,49),(3,50),(3,51),(3,52);
/*!40000 ALTER TABLE `gallerypicturemapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `galleryvideomapping`
--

DROP TABLE IF EXISTS `galleryvideomapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `galleryvideomapping` (
  `GalleryId` int(11) NOT NULL,
  `VideoId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `galleryvideomapping`
--

LOCK TABLES `galleryvideomapping` WRITE;
/*!40000 ALTER TABLE `galleryvideomapping` DISABLE KEYS */;
/*!40000 ALTER TABLE `galleryvideomapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `log` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ShortMessage` varchar(4000) DEFAULT NULL,
  `FullMessage` varchar(4000) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `CreateByUserIP` varchar(45) DEFAULT NULL,
  `PageUrl` varchar(500) DEFAULT NULL,
  `ReferrerUrl` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `member`
--

DROP TABLE IF EXISTS `member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `member` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Desigination` varchar(100) DEFAULT NULL,
  `Image` varchar(100) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COMMENT='																				';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `member`
--

LOCK TABLES `member` WRITE;
/*!40000 ALTER TABLE `member` DISABLE KEYS */;
INSERT INTO `member` VALUES (1,'Mr. D.P. Sharma','President 3','1a49f155-167c-413f-ae95-be1fabbeaa65.jpg',1,'\0','2018-04-05 22:21:49',1,'2018-04-05 22:58:10',1),(5,'dsfsdf','dfsf',NULL,0,'\0','2018-04-08 19:23:36',1,'2018-04-08 19:23:36',1),(6,'dsdsf','dfds',NULL,0,'\0','2018-04-08 19:23:47',1,'2018-04-08 19:23:47',1),(7,'fgfdg','ffg',NULL,0,'\0','2018-04-08 19:23:59',1,'2018-04-08 19:23:59',1),(8,'hgd','dfgf',NULL,0,'\0','2018-04-08 19:24:06',1,'2018-04-08 19:24:06',1),(9,'bdfg','fg',NULL,0,'\0','2018-04-08 19:24:22',1,'2018-04-08 19:24:22',1),(10,'dfg','fgdfg',NULL,0,'\0','2018-04-08 19:24:32',1,'2018-04-08 19:24:32',1),(11,'dfhgfdgh','fgfd',NULL,0,'\0','2018-04-08 19:24:46',1,'2018-04-08 19:24:46',1),(12,'fgfdFDS','bgdfg',NULL,0,'\0','2018-04-08 19:25:03',1,'2018-04-08 19:25:03',1),(13,'fggd','sfgdsg',NULL,0,'\0','2018-04-08 19:25:15',1,'2018-04-08 19:25:15',1),(14,'fhgdgf','fgd',NULL,0,'\0','2018-04-08 19:25:34',1,'2018-04-08 19:25:34',1),(15,'dffsd','gsgsd','5f0b62aa-459c-4de0-91a2-86ce2c37bc80.PNG',0,'\0','2018-04-08 21:40:46',1,'2018-04-08 21:40:46',1);
/*!40000 ALTER TABLE `member` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menu` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MenuCode` varchar(45) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `ParentMenuId` int(11) DEFAULT NULL,
  `Controller` varchar(45) DEFAULT NULL,
  `Action` varchar(45) DEFAULT NULL,
  `Icon` varchar(45) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,'1000','Home',0,'Home','Index',NULL,0,''),(2,'2000','About Us',0,NULL,NULL,NULL,1,''),(3,'2001','Origins & History',2,'AboutUs','OriginsHistory',NULL,0,''),(4,'2002','President\'s Message',2,'AboutUs','PresidentMessage',NULL,1,''),(5,'2003','Director\'s Message',2,'AboutUs','DirectorMessage',NULL,2,''),(6,'2004','Principal\'s Message',2,'AboutUs','PrincipalMessage',NULL,3,''),(7,'2005','Vision & Mission',2,'AboutUs','VisionMission',NULL,4,''),(8,'2006','Mandatory Disclosure',2,'AboutUs','MandatoryDisclosure',NULL,5,''),(9,'2007','Course Offered',2,'AboutUs','CourseOffered',NULL,6,''),(10,'2008','Affiliation to CBSE',2,'AboutUs','AffiliationCBSE',NULL,7,''),(11,'2009','Management Members',2,'Member','Index',NULL,8,''),(12,'2010','Faculty Details',2,'StaffDetail','Index',NULL,9,''),(13,'2011','Our Infrastructure',2,'AboutUs','OurInfrastructure',NULL,10,''),(14,'2012','Our Facilities',2,'AboutUs','OurFacilities',NULL,11,''),(15,'2013','Our Rules',2,'AboutUs','OurRules',NULL,12,''),(16,'3000','Admission',0,NULL,NULL,NULL,2,''),(17,'3001','Admission Rules',16,'Admission','AdmissionRule',NULL,0,''),(18,'3002','Fee Structure',16,'Admission','FeeStructure',NULL,1,''),(19,'4000','Students',0,NULL,NULL,NULL,3,''),(20,'4001','Sports',19,'Students','Sports',NULL,0,''),(21,'4002','Activities & Events',19,'Students','ActivitiesEvents',NULL,1,''),(22,'4003','On Roll Students',19,'Students','OnRollStudents',NULL,2,''),(23,'4004','Transfer Certificate',19,'Students','TransferCertificate',NULL,3,''),(24,'4005','Download',19,'Downloads','Index',NULL,4,''),(25,'5000','Gallery',0,'Gallery','Index',NULL,4,''),(28,'6000','Achievements',0,NULL,NULL,NULL,5,''),(29,'6001','Our Toppers',28,'Toppers','Index',NULL,0,''),(30,'7000','Kindergarten',0,'Kindergarten','Index',NULL,6,''),(31,'8000','Academics',0,NULL,NULL,NULL,7,''),(32,'8001','DateSheet',31,'Academics','DateSheet',NULL,0,''),(33,'8002','Schedule',31,'Academics','Schedule',NULL,1,''),(34,'8003','Result',31,'Academics','Result',NULL,2,''),(35,'9000','Contact Us',0,'Home','ContactUs',NULL,8,''),(36,'10000','Masters',0,NULL,NULL,NULL,0,''),(37,'10001','Class Master',36,'ClassMaster','Index',NULL,1,''),(38,'10002','News',36,'News','Index',NULL,2,''),(39,'10003','Home Page Slide',36,'Slide','Index',NULL,3,'');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `news`
--

DROP TABLE IF EXISTS `news`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `news` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime DEFAULT NULL,
  `Title` varchar(100) DEFAULT NULL,
  `FileName` varchar(50) DEFAULT NULL,
  `ShortDescription` varchar(250) DEFAULT NULL,
  `Description` text,
  `IsActive` bit(1) DEFAULT NULL,
  `SortId` bit(1) DEFAULT NULL,
  `Views` int(11) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `news`
--

LOCK TABLES `news` WRITE;
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
INSERT INTO `news` VALUES (1,'2018-05-22 00:00:00','Transfer Certificate','transfer-certificate-05-22-2018-4422.jpg','Tesdtin dfdsfv  gkfG dfv dfa','<p>Testing</p>\r\n','','',0,'2018-05-22 22:21:47',1,'2018-05-22 23:17:34',1),(2,'2018-05-22 00:00:00','Change in school timings',NULL,'School Timings w.e.f November 20,2017 will be as follows:-',NULL,'','',0,'2018-05-22 23:19:18',1,'2018-05-22 23:19:18',1);
/*!40000 ALTER TABLE `news` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagecontents`
--

DROP TABLE IF EXISTS `pagecontents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagecontents` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PageId` int(11) DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  `Contents` text,
  `SortId` int(11) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagecontents`
--

LOCK TABLES `pagecontents` WRITE;
/*!40000 ALTER TABLE `pagecontents` DISABLE KEYS */;
INSERT INTO `pagecontents` VALUES (1,3,'Content',NULL,1,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(2,4,'Name',NULL,1,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(3,4,'Desigination',NULL,2,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(4,4,'Content',NULL,3,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(5,5,'Name',NULL,1,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(6,5,'Desigination',NULL,2,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(7,5,'Content',NULL,3,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(8,6,'Name',NULL,1,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(9,6,'Desigination',NULL,2,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1),(10,6,'Content',NULL,3,'2018-03-14 00:00:00',1,'2018-03-14 00:00:00',1);
/*!40000 ALTER TABLE `pagecontents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagepicutremapping`
--

DROP TABLE IF EXISTS `pagepicutremapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagepicutremapping` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PageId` int(11) DEFAULT NULL,
  `PictureId` int(11) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagepicutremapping`
--

LOCK TABLES `pagepicutremapping` WRITE;
/*!40000 ALTER TABLE `pagepicutremapping` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagepicutremapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pages`
--

DROP TABLE IF EXISTS `pages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pages` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MenuCode` varchar(45) DEFAULT NULL,
  `Title` varchar(100) DEFAULT NULL,
  `Image` varchar(45) DEFAULT NULL,
  `Seo` varchar(150) DEFAULT NULL,
  `MetaKeywords` varchar(250) DEFAULT NULL,
  `MetaDescription` varchar(300) DEFAULT NULL,
  `MetaTitle` varchar(200) DEFAULT NULL,
  `Contents` text,
  `IsPublish` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pages`
--

LOCK TABLES `pages` WRITE;
/*!40000 ALTER TABLE `pages` DISABLE KEYS */;
INSERT INTO `pages` VALUES (1,'1000','Home',NULL,'home','home','home','home','<section class=\"slider slider-style02 slider-university\">','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(2,'2000','About Us',NULL,'about-us','about us','about us','about us','about us','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(3,'2001','Origins History',NULL,'Origins-History','Origins History','Origins History','Origins History','<h2>Introduction 1</h2>\r\n\r\n<p>The management and staff of HVM Convent strive to provide the students with good opportunities and a proper platform so that they can work towards attainment of their personal goals thus helping to fulfill the goals of the society. Our aim is that students work with enthusiasm and interest because God always blesses and helps those who help themselves.</p>\r\n\r\n<h2>History</h2>\r\n\r\n<p>HVM Convent School is promoted under the umbrella of Harsh Education Society (Regd.). President Mr. D.P. Sharma who is a great visionary in the field of Education and Chairperson Mrs. Meena Sharma, a renowned Educationist fulfilled the dream of starting a CBSE school on April 1, 2009 with the vision and mission for the holistic development of each child through quality education.</p>\r\n\r\n<h2>Origin</h2>\r\n\r\n<p>It came into existence in April 2009 with classes from Nursery to VIII. Now it takes pride in the galaxy of 1100 students up to X. it is also the matter of great pride that school has got affiliation up to XII and first session of XI will start in session 2013 &ndash; 2014. It is located on a sprawling 2 (two) acre area. The infrastructural facilities of the school are excellent and are equipped with modern educational and allied amenities.</p>\r\n\r\n<h2>Motto</h2>\r\n\r\n<p>&lsquo;Work is Worship&rsquo; mean - Children must treat the work they do as an art of worship so that they can rise and roar high to reach the pinnacle of glory and make us proud.</p>\r\n','','2018-02-28 00:00:00',1,'2018-05-07 23:44:02',1),(4,'2002','President Message',NULL,'PresidentMessage','PresidentMessage','PresidentMessage','PresidentMessage','<p><img src=\"/Content/Client/images/president.jpg\" /></p>\r\n\r\n<p>Mr. D.P. Sharma<br />\r\nPresident</p>\r\n\r\n<h2>Mr. D.P. Sharma</h2>\r\n\r\n<h3><em>(President)</em></h3>\r\n\r\n<p>The management and staff of HVM Convent strive to provide the students with good opportunities and a proper platform so that they can work towards attainment of their personal goals thus helping to fulfill the goals of the society.</p>\r\n','','2018-02-28 00:00:00',1,'2018-03-13 20:47:02',1),(5,'2003','Director Message',NULL,'DirectorMessage','DirectorMessage','DirectorMessage','DirectorMessage','DirectorMessage','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(6,'2004','PrincipalMessage',NULL,'PrincipalMessage','PrincipalMessage','PrincipalMessage','PrincipalMessage','PrincipalMessage','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(7,'2005','VisionMission',NULL,'VisionMission','VisionMission','VisionMission','VisionMission','<h2>HVM Vision</h2>\r\n\r\n<p>&lsquo;Work is Worship&rsquo; mean - Children must treat the work they do as an art of worship so that they can rise and roar high to reach the pinnacle of glory and make us proud.</p>\r\n\r\n<p><img alt=\"\" src=\"/Content/Client/images/vision.jpg\" /></p>\r\n\r\n<h2>HVM Mission</h2>\r\n\r\n<p>The management and staff of HVM Convent strive to provide the students with good opportunities and a proper platform so that they can work towards attainment of their personal goals thus helping to fulfill the goals of the society. Our aim is that students work with enthusiasm and interest because God always blesses and helps those who help themselves.</p>\r\n\r\n<p><img alt=\"\" src=\"/Content/Client/images/mission.jpg\" /></p>\r\n','','2018-02-28 00:00:00',1,'2018-03-05 23:23:40',1),(8,'2006','MandatoryDisclosure',NULL,'MandatoryDisclosure','MandatoryDisclosure','MandatoryDisclosure','MandatoryDisclosure','MandatoryDisclosure','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(9,'2007','Course Offered',NULL,'CourseOffered','CourseOffered','CourseOffered','CourseOffered','<p>CourseOffered</p>\r\n','','2018-02-28 00:00:00',1,'2018-05-08 00:02:59',1),(10,'2008','Affiliation to CBSE',NULL,'AffiliationtoCBSE','AffiliationtoCBSE','AffiliationtoCBSE','AffiliationtoCBSE','<h2>C.B.S.E Affiliation 1</h2>\r\n\r\n<p>HVM Convent Sr. Sec. School Ludhiana is Affiliated with C.B.S.E. New Delhi. School code 25408 &amp; Affiliation No. 1630652</p>\r\n','','2018-02-28 00:00:00',1,'2018-05-07 23:58:42',1),(11,'2009','ManagementMembers',NULL,'ManagementMembers','ManagementMembers','ManagementMembers','ManagementMembers','<h2>Offered Subjects</h2>\r\n\r\n<p>The school offers a wide choice of subjects in the various streams such as medical , non-medical , commerce and humanities , including a wide array of practical subjects also.</p>\r\n\r\n<h3>Subjects offered in Senior Secondary Classes</h3>\r\n\r\n<h1>Medical &amp; Non-Medical</h1>\r\n\r\n<ul>\r\n	<li>English Core</li>\r\n	<li>Physics</li>\r\n	<li>Chemistry</li>\r\n	<li>Biology/Maths</li>\r\n	<li>Physical Education/Math</li>\r\n	<li>Infomatic Practices</li>\r\n</ul>\r\n\r\n<h1>Commerce</h1>\r\n\r\n<ul>\r\n	<li>English Core</li>\r\n	<li>Business Studies</li>\r\n	<li>Accountancy</li>\r\n	<li>Economics</li>\r\n	<li>Physical Education/Math</li>\r\n	<li>Infomatic Practices</li>\r\n</ul>\r\n\r\n<h1>Humanities</h1>\r\n\r\n<ul>\r\n	<li>English Core</li>\r\n	<li>Punjabi</li>\r\n	<li>Economics</li>\r\n	<li>Hindi Core</li>\r\n	<li>Physical Education</li>\r\n	<li>Infomatic Practices</li>\r\n</ul>\r\n','','2018-02-28 00:00:00',1,'2018-03-05 23:22:38',1),(12,'2010','FacultyDetails',NULL,'FacultyDetails','FacultyDetails','FacultyDetails','FacultyDetails','<ul>\r\n	<li>Faculty Details</li>\r\n	<li>Pay Scale</li>\r\n	<li>Total Staff</li>\r\n</ul>\r\n\r\n<h3>Faculty Detail</h3>\r\n\r\n<h2>Adminstrative Staff</h2>\r\n\r\n<table>\r\n	<thead>\r\n		<tr>\r\n			<th>Sr.No.</th>\r\n			<th>Staff Image</th>\r\n			<th>Name</th>\r\n			<th>Designation</th>\r\n			<th>Appointment Date</th>\r\n			<th>Professional Qualification</th>\r\n			<th>Acadmic Qualification</th>\r\n			<th>Training Status</th>\r\n			<th>Job Status</th>\r\n		</tr>\r\n	</thead>\r\n	<tbody>\r\n		<tr>\r\n			<td>1</td>\r\n			<td><img src=\"/Content/Client/images/radhika-jain.jpg\" /></td>\r\n			<td>Ms. Radhika Jain</td>\r\n			<td>Director</td>\r\n			<td>01.12.2017</td>\r\n			<td>B.Ed</td>\r\n			<td>M.Com</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>2</td>\r\n			<td><img src=\"/Content/Client/images/sunita-kumari-img.jpg\" /></td>\r\n			<td>Ms. Sunita Kumari</td>\r\n			<td>Principal</td>\r\n			<td>1.12.2017</td>\r\n			<td>M.Ed</td>\r\n			<td>M.A.(Eng. Hons.)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>3</td>\r\n			<td><img src=\"/Content/Client/images/parveen-thakur.jpg\" /></td>\r\n			<td>Mr. Parveen Thakur</td>\r\n			<td>CCE Coordinator</td>\r\n			<td>12.07.2010</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.(His.)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>4</td>\r\n			<td><img src=\"/Content/Client/images/mohandeep.jpg\" /></td>\r\n			<td>Mr. Mohandeep</td>\r\n			<td>ICT Coordinator</td>\r\n			<td>03.11.2011</td>\r\n			<td>MCSE</td>\r\n			<td>M.Sc(IT)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n	</tbody>\r\n</table>\r\n\r\n<h1>Teaching Staff</h1>\r\n\r\n<table>\r\n	<thead>\r\n		<tr>\r\n			<th>Sr.No.</th>\r\n			<th>Staff Image</th>\r\n			<th>Name</th>\r\n			<th>Designation</th>\r\n			<th>Appointment Date</th>\r\n			<th>Professional Qualification</th>\r\n			<th>Acadmic Qualification</th>\r\n			<th>Training Status</th>\r\n			<th>Job Status</th>\r\n		</tr>\r\n	</thead>\r\n	<tbody>\r\n		<tr>\r\n			<td>1</td>\r\n			<td><img src=\"/Content/Client/images/gopal-krishan.jpg\" /></td>\r\n			<td>Gopal Krishan</td>\r\n			<td>PGT</td>\r\n			<td>01.03.2013</td>\r\n			<td>B.P.Ed</td>\r\n			<td>M.A. (Phy. Edu.)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>2</td>\r\n			<td><img src=\"/Content/Client/images/manjeet-kaur.jpg\" /></td>\r\n			<td>Manjeet Kaur</td>\r\n			<td>PGT</td>\r\n			<td>01.09.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Pol. Science)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>3</td>\r\n			<td><img src=\"/Content/Client/images/meenal-arora.jpg\" /></td>\r\n			<td>Meenal Arora</td>\r\n			<td>PGT</td>\r\n			<td>25.03.2013</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>4</td>\r\n			<td><img src=\"/Content/Client/images/neelam-kaushal.jpg\" /></td>\r\n			<td>Neelam Kaushal</td>\r\n			<td>PGT</td>\r\n			<td>01.10.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.Sc (Zoology)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>5</td>\r\n			<td><img src=\"/Content/Client/images/rohit-kumar.jpg\" /></td>\r\n			<td>Rohit Kumar</td>\r\n			<td>PGT</td>\r\n			<td>01.04.2014</td>\r\n			<td>B.Ed</td>\r\n			<td>M.Com</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>6</td>\r\n			<td><img src=\"/Content/Client/images/upender-joshi.jpg\" /></td>\r\n			<td>Upender Joshi</td>\r\n			<td>PGT</td>\r\n			<td>26.03.2014</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (English)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>7</td>\r\n			<td><img src=\"/Content/Client/images/no-img.jpg\" /></td>\r\n			<td>Harsh Sharma</td>\r\n			<td>PGT</td>\r\n			<td>01.08.2015</td>\r\n			<td>&nbsp;</td>\r\n			<td>B.Tech</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>8</td>\r\n			<td><img src=\"/Content/Client/images/neha-sehgal.jpg\" /></td>\r\n			<td>Neha Sehgal</td>\r\n			<td>TGT</td>\r\n			<td>02.05.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>9</td>\r\n			<td><img src=\"/Content/Client/images/pooja-sharma.jpg\" /></td>\r\n			<td>Pooja Sharma</td>\r\n			<td>TGT</td>\r\n			<td>03.11.2011</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Eng.)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>10</td>\r\n			<td><img src=\"/Content/Client/images/rachu.jpg\" /></td>\r\n			<td>Rachu</td>\r\n			<td>TGT</td>\r\n			<td>02.09.2013</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Hindi)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>11</td>\r\n			<td><img src=\"/Content/Client/images/renu-arora.jpg\" /></td>\r\n			<td>Renu Arora</td>\r\n			<td>TGT</td>\r\n			<td>02.05.2016</td>\r\n			<td>&nbsp;</td>\r\n			<td>B.Tech(ECE)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>12</td>\r\n			<td><img src=\"/Content/Client/images/rimpy.jpg\" /></td>\r\n			<td>Rimpy</td>\r\n			<td>TGT</td>\r\n			<td>01.08.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Pol. Science)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>13</td>\r\n			<td><img src=\"/Content/Client/images/sumitra-rani.jpg\" /></td>\r\n			<td>Sumitra Rani</td>\r\n			<td>TGT</td>\r\n			<td>01.04.2015</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (History)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>14</td>\r\n			<td><img src=\"/Content/Client/images/veena-rani.jpg\" /></td>\r\n			<td>Veena Rani</td>\r\n			<td>TGT</td>\r\n			<td>27.03.2014</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>15</td>\r\n			<td><img src=\"/Content/Client/images/gurpreet-kaur.jpg\" /></td>\r\n			<td>Gurpreet Kaur</td>\r\n			<td>TGT</td>\r\n			<td>16.07.2011</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Punjabi)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>16</td>\r\n			<td><img src=\"/Content/Client/images/harsharan-kaur.jpg\" /></td>\r\n			<td>Harsharan Kaur</td>\r\n			<td>TGT</td>\r\n			<td>25.04.2011</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Economics)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>17</td>\r\n			<td><img src=\"/Content/Client/images/harwinder-kaur.jpg\" /></td>\r\n			<td>Harwinder Kaur</td>\r\n			<td>TGT</td>\r\n			<td>01.04.2015</td>\r\n			<td>M.P.Ed</td>\r\n			<td>B.P.Ed</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>18</td>\r\n			<td><img src=\"/Content/Client/images/inderjit-kaur.jpg\" /></td>\r\n			<td>Inderjit Kaur</td>\r\n			<td>TGT</td>\r\n			<td>02.01.2011</td>\r\n			<td>B.Lib.</td>\r\n			<td>B.A.</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>19</td>\r\n			<td><img src=\"/Content/Client/images/jaspreet-kaur.jpg\" /></td>\r\n			<td>Jaspreet Kaur</td>\r\n			<td>TGT</td>\r\n			<td>23.04.2012</td>\r\n			<td>B.Ed</td>\r\n			<td>B.Com</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>20</td>\r\n			<td><img src=\"/Content/Client/images/manish-kumar.jpg\" /></td>\r\n			<td>Manish Kumar</td>\r\n			<td>TGT</td>\r\n			<td>06.05.2010</td>\r\n			<td>M.P.Ed</td>\r\n			<td>B.P.Ed</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>21</td>\r\n			<td><img src=\"/Content/Client/images/teenu.jpg\" /></td>\r\n			<td>Teenu</td>\r\n			<td>PRT</td>\r\n			<td>23.08.2013</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Sanskrit)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>22</td>\r\n			<td><img src=\"/Content/Client/images/vanita-kashyap.jpg\" /></td>\r\n			<td>Vanita Kashyap</td>\r\n			<td>PRT</td>\r\n			<td>01.07.2012</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>23</td>\r\n			<td><img src=\"/Content/Client/images/prerna.jpg\" /></td>\r\n			<td>Prerna</td>\r\n			<td>PRT</td>\r\n			<td>01.04.2015</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (History)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>24</td>\r\n			<td><img src=\"/Content/Client/images/renuka.jpg\" /></td>\r\n			<td>Renuka</td>\r\n			<td>PRT</td>\r\n			<td>01.04.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.(Punjabi)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>25</td>\r\n			<td><img src=\"/Content/Client/images/rita.jpg\" /></td>\r\n			<td>Rita</td>\r\n			<td>PRT</td>\r\n			<td>22.03.2012</td>\r\n			<td>NTT</td>\r\n			<td>M.A.(Hindi)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>26</td>\r\n			<td><img src=\"/Content/Client/images/anjali-dhir.jpg\" /></td>\r\n			<td>Anjali Dhir</td>\r\n			<td>PRT</td>\r\n			<td>01.03.2012</td>\r\n			<td>B.Ed</td>\r\n			<td>B.Com</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>27</td>\r\n			<td><img src=\"/Content/Client/images/baldina.jpg\" /></td>\r\n			<td>Baldina</td>\r\n			<td>PRT</td>\r\n			<td>01.10.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Hindi)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>28</td>\r\n			<td><img src=\"/Content/Client/images/hardeep-kaur.jpg\" /></td>\r\n			<td>Hardeep Kaur</td>\r\n			<td>PRT</td>\r\n			<td>01.08.2013</td>\r\n			<td>&nbsp;</td>\r\n			<td>M.A. (Eng.)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>29</td>\r\n			<td><img src=\"/Content/Client/images/harpreet-kaur.jpg\" /></td>\r\n			<td>Harpreet Kaur</td>\r\n			<td>PRT</td>\r\n			<td>01.08.2016</td>\r\n			<td>&nbsp;</td>\r\n			<td>B.A.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>30</td>\r\n			<td><img src=\"/Content/Client/images/inderdeep-kaur.jpg\" /></td>\r\n			<td>Inderdeep Kaur</td>\r\n			<td>PRT</td>\r\n			<td>04.07.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Eco.)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>31</td>\r\n			<td><img src=\"/Content/Client/images/jaspreet-kaur-31.jpg\" /></td>\r\n			<td>Jaspreet Kaur</td>\r\n			<td>PRT</td>\r\n			<td>01.08.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>MBA</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>32</td>\r\n			<td><img src=\"/Content/Client/images/jiwan-jyoti.jpg\" /></td>\r\n			<td>Jiwan Jyoti</td>\r\n			<td>PRT</td>\r\n			<td>01.08.2013</td>\r\n			<td>&nbsp;</td>\r\n			<td>B.A.</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>33</td>\r\n			<td><img src=\"/Content/Client/images/jyoti-aggarwal.jpg\" /></td>\r\n			<td>Jyoti Aggarwal</td>\r\n			<td>PRT</td>\r\n			<td>03.07.2013</td>\r\n			<td>NTT</td>\r\n			<td>B.A.</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>34</td>\r\n			<td><img src=\"/Content/Client/images/kanika.jpg\" /></td>\r\n			<td>Kanika</td>\r\n			<td>PRT</td>\r\n			<td>19.11.2013</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Eng.)</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>35</td>\r\n			<td><img src=\"/Content/Client/images/kiran-sharma.jpg\" /></td>\r\n			<td>Kiran Sharma</td>\r\n			<td>PRT</td>\r\n			<td>14.04.2012</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>36</td>\r\n			<td><img src=\"/Content/Client/images/nisha-bhandari.jpg\" /></td>\r\n			<td>Nisha Bhandari</td>\r\n			<td>PRT</td>\r\n			<td>01.04.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (Music Vocal)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>37</td>\r\n			<td><img src=\"/Content/Client/images/pushpinder-kaur.jpg\" /></td>\r\n			<td>Pushpinder Kaur</td>\r\n			<td>NTT</td>\r\n			<td>04.12.2015</td>\r\n			<td>D.Pharmacy</td>\r\n			<td>B.Sc.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>38</td>\r\n			<td><img src=\"/Content/Client/images/rchna-sharma.jpg\" /></td>\r\n			<td>Rachna Sharma</td>\r\n			<td>NTT</td>\r\n			<td>02.09.2013</td>\r\n			<td>B.Ed</td>\r\n			<td>B.A.</td>\r\n			<td>Trained</td>\r\n			<td>Confirmed</td>\r\n		</tr>\r\n		<tr>\r\n			<td>39</td>\r\n			<td><img src=\"/Content/Client/images/rinki.jpg\" /></td>\r\n			<td>Rinki</td>\r\n			<td>NTT</td>\r\n			<td>01.04.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.(Hindi)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>40</td>\r\n			<td><img src=\"/Content/Client/images/seema-lal.jpg\" /></td>\r\n			<td>Seema Lal</td>\r\n			<td>NTT</td>\r\n			<td>02.05.2016</td>\r\n			<td>NTT</td>\r\n			<td>M.A. (Pol. Science)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>41</td>\r\n			<td><img src=\"/Content/Client/images/geetu.jpg\" /></td>\r\n			<td>Geetu</td>\r\n			<td>NTT</td>\r\n			<td>01.04.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>42</td>\r\n			<td><img src=\"/Content/Client/images/kiran-gulati.jpg\" /></td>\r\n			<td>Kiran Gulati</td>\r\n			<td>NTT</td>\r\n			<td>15.04.2015</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>43</td>\r\n			<td><img src=\"/Content/Client/images/no-img.jpg\" /></td>\r\n			<td>Poornima Sharma</td>\r\n			<td>PGT</td>\r\n			<td>01.04.2016</td>\r\n			<td>&nbsp;</td>\r\n			<td>MBBS</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>44</td>\r\n			<td><img src=\"/Content/Client/images/no-img.jpg\" /></td>\r\n			<td>Bharat Bhushan</td>\r\n			<td>TGT</td>\r\n			<td>16.08.2016</td>\r\n			<td>&nbsp;</td>\r\n			<td>B.A.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>45</td>\r\n			<td><img src=\"/Content/Client/images/no-img.jpg\" /></td>\r\n			<td>Pooja Jain</td>\r\n			<td>PRT</td>\r\n			<td>09.07.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>46</td>\r\n			<td><img src=\"/Content/Client/images/no-img.jpg\" /></td>\r\n			<td>Pooja Rani</td>\r\n			<td>PRT</td>\r\n			<td>20.11.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.Sc.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>47</td>\r\n			<td><img src=\"/Content/Client/images/no-img.jpg\" /></td>\r\n			<td>Sonia Khurana</td>\r\n			<td>PRT</td>\r\n			<td>04.07.2016</td>\r\n			<td>B.Ed</td>\r\n			<td>M.A. (History)</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>48</td>\r\n			<td><img src=\"/Content/Client/images/no-img.jpg\" /></td>\r\n			<td>Neeru</td>\r\n			<td>NTT</td>\r\n			<td>02.05.2016</td>\r\n			<td>NTT</td>\r\n			<td>B.A.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n		<tr>\r\n			<td>49</td>\r\n			<td><img src=\"/Content/Client/images/no-img.jpg\" /></td>\r\n			<td>Priyanka</td>\r\n			<td>NTT</td>\r\n			<td>01.04.2015</td>\r\n			<td>&nbsp;</td>\r\n			<td>B.A.</td>\r\n			<td>Trained</td>\r\n			<td>Probation</td>\r\n		</tr>\r\n	</tbody>\r\n</table>\r\n<!-- #tab1 -->\r\n\r\n<h3>Pay Scale</h3>\r\n\r\n<h2>Adminstrative Staff</h2>\r\n\r\n<table>\r\n	<thead>\r\n		<tr>\r\n			<th>Sr. No</th>\r\n			<th>Designation</th>\r\n			<th>Pay Scale</th>\r\n			<th>Grand Pay</th>\r\n			<th>DA</th>\r\n			<th>HRA</th>\r\n			<th>EPF</th>\r\n		</tr>\r\n	</thead>\r\n	<tbody>\r\n		<tr>\r\n			<td>1</td>\r\n			<td>PGT</td>\r\n			<td>10300-34800</td>\r\n			<td>4200</td>\r\n			<td>5%</td>\r\n			<td>&nbsp;</td>\r\n			<td>&nbsp;</td>\r\n		</tr>\r\n		<tr>\r\n			<td>2</td>\r\n			<td>Principal</td>\r\n			<td>31100-67000</td>\r\n			<td>8400</td>\r\n			<td>5%</td>\r\n			<td>&nbsp;</td>\r\n			<td>&nbsp;</td>\r\n		</tr>\r\n		<tr>\r\n			<td>3</td>\r\n			<td>PRT</td>\r\n			<td>9300-34800</td>\r\n			<td>2170</td>\r\n			<td>5%</td>\r\n			<td>&nbsp;</td>\r\n			<td>&nbsp;</td>\r\n		</tr>\r\n		<tr>\r\n			<td>4</td>\r\n			<td>TGT</td>\r\n			<td>10300-34800</td>\r\n			<td>3600</td>\r\n			<td>5%</td>\r\n			<td>&nbsp;</td>\r\n			<td>&nbsp;</td>\r\n		</tr>\r\n		<tr>\r\n			<td>5</td>\r\n			<td>Vice Principal</td>\r\n			<td>10300-34800</td>\r\n			<td>4200</td>\r\n			<td>5%</td>\r\n			<td>&nbsp;</td>\r\n			<td>&nbsp;</td>\r\n		</tr>\r\n	</tbody>\r\n</table>\r\n<!-- #tab2 -->\r\n\r\n<h3>Total Staff</h3>\r\n\r\n<h2>Staff Designation</h2>\r\n\r\n<table>\r\n	<tbody>\r\n		<tr>\r\n			<td><strong>Designation </strong></td>\r\n			<td><strong>Total Staff</strong></td>\r\n		</tr>\r\n		<tr>\r\n			<td>PGT</td>\r\n			<td>11</td>\r\n		</tr>\r\n		<tr>\r\n			<td>TGT</td>\r\n			<td>23</td>\r\n		</tr>\r\n		<tr>\r\n			<td>PRT</td>\r\n			<td>49</td>\r\n		</tr>\r\n	</tbody>\r\n</table>\r\n<!-- #tab3 -->','','2018-02-28 00:00:00',1,'2018-03-05 23:21:32',1),(13,'2011','OurInfrastructure',NULL,'OurInfrastructure','OurInfrastructure','OurInfrastructure','OurInfrastructure','<h2>Library</h2>\r\n\r\n<p><img src=\"/Content/Client/images/school-library.jpg\" /></p>\r\n\r\n<p>The fully computerized school library is central for Elementary, Middle and High School with 300 volumes of encyclopedias &amp; more than 12000 books. The library is a reading as well as a breeding place where ideas breed in the intellectually charged minds of the students and the teachers.<br />\r\n<br />\r\nThe school subscribes about 9 different newspapers &amp; about 35 magazines, pertaining to the interests of the readers. CD library has also been provided with a large collection of CD&rsquo;s on various subjects.</p>\r\n\r\n<h2>Science Laboratories</h2>\r\n\r\n<p><img src=\"/Content/Client/images/science-laboratories.jpg\" /></p>\r\n\r\n<p>The fully computerized school library is central for Elementary, Middle and High School with 300 volumes of encyclopedias &amp; more than 12000 books. The library is a reading as well as a breeding place where ideas breed in the intellectually charged minds of the students and the teachers.<br />\r\n<br />\r\nThe school subscribes about 9 different newspapers &amp; about 35 magazines, pertaining to the interests of the readers. CD library has also been provided with a large collection of CD&rsquo;s on various subjects.</p>\r\n\r\n<h2>Class Rooms</h2>\r\n\r\n<p><img src=\"/Content/Client/images/science-laboratories.jpg\" /></p>\r\n\r\n<p>The school has spacious, well furnished and well-maintained classrooms. The rooms are beautifully decorated and present an amicable atmosphere for the teaching-learning process, which aims at &lsquo;adding value&rsquo; to each passing day.</p>\r\n\r\n<h2>Computer Labs</h2>\r\n\r\n<p><img src=\"/Content/Client/images/computer-labs.jpg\" /></p>\r\n\r\n<p>Keeping in mind the ever growing needs of children in connection with computers, there is a provision of a well equipped computer room with computers, printers, web cameras and scanners. Students are given a practical exposure in taming the computers to make them serve their needs and purposes.<br />\r\n<br />\r\nThe formal curriculum extends beyond the usual formulae &amp; enriches their learning through a wide variety of multimedia program.</p>\r\n\r\n<h2>E-Classrooms</h2>\r\n\r\n<p><img src=\"/Content/Client/images/e-classrooms.jpg\" /></p>\r\n\r\n<p>The school has introduced E-learning program that provides qualitative audio-visual teaching. The classrooms are equipped with smart boards which have topic oriented modules for better learning. The school has a highly progressive outlook and emphasizes on everlasting knowledge.</p>\r\n\r\n<h2>Physical Culture</h2>\r\n\r\n<p><img src=\"/Content/Client/images/physical-culture.jpg\" /></p>\r\n\r\n<p>Physical culture at HVM develops the spirit of sportsmanship, co-operation, team-spirit and courage. They strengthen the physique and inculcate the feelings caring and sharing. The emphasis is on &lsquo;Sports for all&rsquo;.<br />\r\n<br />\r\nThe school boasts of the requisite infrastructure for the pursuit of outdoor games like Basketball, Volleyball, Badminton, Athletics, Kho-Kho, Cricket, Handball and Football; indoor games like chess, Carom and Table-Tennis. The school organizes Annual athletic meet and participates in various Inter-school competitions at Zonal, State and National level.</p>\r\n','','2018-02-28 00:00:00',1,'2018-03-05 23:16:08',1),(14,'2012','OurFacilities',NULL,'OurFacilities','OurFacilities','OurFacilities','OurFacilities','<h2>HVM Facilities</h2>\r\n\r\n<p>The school is located in New Subhash Nagar Ludhiana. The grounds are well landscaped and provide diverse playing areas. The entire ambience of the school is student friendly. The classrooms are spacious and well equipped and the school is resourced with modern and well maintained facilities.</p>\r\n\r\n<p>These Includes:</p>\r\n\r\n<ul>\r\n	<li>Smart class enabled classrooms.</li>\r\n	<li>Sports fields, Sandpit and Play Areas</li>\r\n	<li>Two well equipped Computer Labs.</li>\r\n	<li>Well Stocked Library &amp; Resource Centre.</li>\r\n	<li>Art, Craft &amp; Activity Rooms.</li>\r\n	<li>Music &amp; Dance Rooms.</li>\r\n	<li>Multipurpose Hall (Under construction).</li>\r\n</ul>\r\n\r\n<p>State of the Art laboratories for:</p>\r\n\r\n<ul>\r\n	<li>Physics</li>\r\n	<li>Chemistry</li>\r\n	<li>Biology</li>\r\n	<li>Social Studies</li>\r\n	<li>English</li>\r\n	<li>Mathematics</li>\r\n</ul>\r\n\r\n<p>Transport Facility</p>\r\n\r\n<p>School is having own Transportation facility as listed below. School is Charging nominal fee for the transportation according to the distance covered.</p>\r\n','','2018-02-28 00:00:00',1,'2018-03-05 23:05:24',1),(15,'2013','OurRules',NULL,'OurRules','OurRules','OurRules','OurRules','<h2>General School Rules</h2>\r\n\r\n<ul>\r\n	<li>Every student must reach school five minutes prior to morning assembly.</li>\r\n	<li>The school reserves the right to terminate the continuance of the students with unsatisfactory progress in studies or whose conduct is a bad example for others.</li>\r\n	<li>Bullying or use of foul language are punishable offences anyone found doing the same is liable to be expelled from school.</li>\r\n	<li>Students are strictly forbidden to bring objectionable literature/pictures/i-pods/ CDs/Pen-drives/Floppies etc. to school.</li>\r\n	<li>Damaging or losing school properly is a serious offence. Any such damage will have to be made good by the defaulter only. Damage done by accident should be reported to the class incharge immediately.</li>\r\n	<li>In the interest of their own safety, students are advised not to buy or receive any gifts/food stuffs from anyone at all en route.</li>\r\n	<li>Students are not allowed to wear any jewellery or bring any valuables to school. School is not responsible for the loss of any such belongings.</li>\r\n	<li>Students cannot leave school campus on any pretext during school hours except in an emergency with the prior permission of the principal.</li>\r\n	<li>Strict adherence to prescribed uniform, cleanliness and personal hygiene is to be ensured.</li>\r\n	<li>No physical violence is permitted in the school premises. Creating indiscipline, using unfair means in examination or deviation from any school rules will result in the strict disciplinary action.</li>\r\n	<li>Bringing mobile phones to school is strictly forbidden. Mobile Phone once confiscated shall remain in school&#39;s possession.</li>\r\n	<li>Uniform brings the feeling of oneness. Strict adherence to prescribed uniform, cleanliness and personal hygiene is to be ensured.</li>\r\n</ul>\r\n\r\n<h2>School Uniform Rules</h2>\r\n\r\n<p>The wearing of the uniform is a sacred ritual as its brings about uniformity at HVM, the unique feeling of &lsquo;oneness&rsquo;, thus underlying the sense of pride in the school dress.</p>\r\n\r\n<ul>\r\n	<li>Students must wear uniform outside the campus while representing the school.</li>\r\n	<li>Girls with long hair are required to plait their hair in two braids. All girls must wear blue ribbons.</li>\r\n	<li>Non &ndash;Sikh boys should get their hair cut at regular intervals and ensure that it remains combed and tidy.</li>\r\n</ul>\r\n\r\n<h2>Transport Facility</h2>\r\n\r\n<p>School is having own Transportation facility as listed below. School is Charging nominal fee for the transportation according to the distance covered.</p>\r\n','','2018-02-28 00:00:00',1,'2018-03-05 23:04:40',1),(16,'3000','Admission',NULL,'Admission','Admission','Admission','Admission','Admission','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(17,'3001','AdmissionRules',NULL,'AdmissionRules','AdmissionRules','AdmissionRules','AdmissionRules','<h2>Rules of Admission in School</h2>\r\n\r\n<p>Admission Procedure</p>\r\n\r\n<p>Application for registration of only those children who attain a minimum age of 21/2 years will be entertained. It is mandatory on the part of parents to submit an attested photocopy of the date of birth certificate from Municipal Corporation, one recent family photograph &amp; two photographs of the child along with the Registration form for admission. However, the original date of birth certificate must be produced at the time of admission for verification purpose. Registration of the child does not guarantee admission.<br />\r\n<br />\r\nThe children will be enrolled for registration in the month of Dec./Jan., with a non refundable Registration Fee (which includes Prospectus, Admission form, test, interview etc.) of Rs. 300/- per child. The admission should be taken within the stipulated date and time lest the privilege is lost for getting admission in HVM Convent Senior Secondary School. The same cannot be challenged in any court of Law.</p>\r\n\r\n<p>Admission of all classes will be subject to the availability of seats.</p>\r\n\r\n<p>Age Requirement</p>\r\n\r\n<p>A child should complete the age indicated below against the class on the commencement of the academic year.</p>\r\n\r\n<table>\r\n	<thead>\r\n	</thead>\r\n	<tbody>\r\n		<tr>\r\n			<td>Pre Nursery 21/2 to 3 1/2 years</td>\r\n		</tr>\r\n		<tr>\r\n			<td>Nursery 31/2 to 4 1/2 years</td>\r\n		</tr>\r\n		<tr>\r\n			<td>K.G. 41/2 to 5 1/2 years</td>\r\n		</tr>\r\n	</tbody>\r\n</table>\r\n\r\n<p>Transfer Certificate</p>\r\n\r\n<p>Students migrating from other schools must produce their transfer certificate, progress report and character certificate of their previous schools. Correct date of birth is to be submitted at the time of admission. It is the prerogative of the Principal to reject or grant admission to any class without assigning any reason to any application. Admission to HVM Convent Senior Secondary School is a privilege and not a right.</p>\r\n','','2018-02-28 00:00:00',1,'2018-03-05 23:27:38',1),(18,'3002','FeeStructure',NULL,'FeeStructure','FeeStructure','FeeStructure','FeeStructure','FeeStructure','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(19,'4000','Students',NULL,'Students','Students','Students','Students','Students','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(20,'4001','Sports',NULL,'Sports','Sports','Sports','Sports','Sports','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(21,'4002','ActivitiesEvents',NULL,'ActivitiesEvents','ActivitiesEvents','ActivitiesEvents','ActivitiesEvents','ActivitiesEvents','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(22,'4003','OnRollStudents',NULL,'OnRollStudents','OnRollStudents','OnRollStudents','OnRollStudents','OnRollStudents','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(23,'4004','TransferCertificate',NULL,'TransferCertificate','TransferCertificate','TransferCertificate','TransferCertificate','TransferCertificate','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(24,'4005','Download',NULL,'Download','Download','Download','Download','Download','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(25,'5000','Gallery',NULL,'Gallery','Gallery','Gallery','Gallery','Gallery','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(26,'5001','Photo',NULL,'Photo','Photo','Photo','Photo','Photo','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(27,'5002','Video',NULL,'Video','Video','Video','Video','Video','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(28,'6000','Achievements',NULL,'Achievements','Achievements','Achievements','Achievements','Achievements','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(29,'6001','OurToppers',NULL,'OurToppers','OurToppers','OurToppers','OurToppers','OurToppers','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(30,'7000','Kindergarten',NULL,'Kindergarten','Kindergarten','Kindergarten','Kindergarten','Kindergarten','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(31,'8000','Acedemics',NULL,'Acedemics','Acedemics','Acedemics','Acedemics','Acedemics','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(32,'8001','DateSheet',NULL,'DateSheet','DateSheet','DateSheet','DateSheet','DateSheet','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(33,'8002','Schedule',NULL,'Schedule','Schedule','Schedule','Schedule','Schedule','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(34,'8003','Result',NULL,'Result','Result','Result','Result','Result','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1),(35,'9000','ContactUs',NULL,'ContactUs','ContactUs','ContactUs','ContactUs','ContactUs','','2018-02-28 00:00:00',1,'2018-02-28 00:00:00',1);
/*!40000 ALTER TABLE `pages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `picture`
--

DROP TABLE IF EXISTS `picture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `picture` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(100) DEFAULT NULL,
  `Type` varchar(10) DEFAULT NULL,
  `Name` varchar(1000) DEFAULT NULL,
  `Extension` varchar(45) DEFAULT NULL,
  `TitleAttribute` varchar(100) DEFAULT NULL,
  `AltAttribute` varchar(100) DEFAULT NULL,
  `MimeType` varchar(45) DEFAULT NULL,
  `Size` int(11) DEFAULT NULL,
  `PageId` int(11) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `IsDefault` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `picture`
--

LOCK TABLES `picture` WRITE;
/*!40000 ALTER TABLE `picture` DISABLE KEYS */;
INSERT INTO `picture` VALUES (36,'curricular-activites-4.jpg','File','fedf0b40-ba90-4d0b-83c5-6298f58a484c','.jpg','curricular-activites-4.jpg','curricular-activites-4.jpg','image/jpeg',101190,1,1,'\0','2018-06-04 01:10:56',1,'2018-06-04 01:10:56',1),(37,'curricular-activites-2.jpg','File','6881a6aa-694a-4755-837f-78fe37222fe7','.jpg','curricular-activites-2.jpg','curricular-activites-2.jpg','image/jpeg',101227,1,1,'\0','2018-06-04 01:10:58',1,'2018-06-04 01:10:58',1),(38,'curricular-activites-6.jpg','File','3039516d-3b3e-454a-860b-763c3157da4a','.jpg','curricular-activites-6.jpg','curricular-activites-6.jpg','image/jpeg',100758,1,1,'\0','2018-06-04 01:10:59',1,'2018-06-04 01:10:59',1),(39,'curricular-activites-5s.jpg','File','c66492af-a015-4b33-b5db-a04b44bb1f7f','.jpg','curricular-activites-5s.jpg','curricular-activites-5s.jpg','image/jpeg',28291,1,1,'\0','2018-06-04 01:11:00',1,'2018-06-04 01:11:00',1),(40,'curricular-activites-7.jpg','File','672a647b-4062-4de8-97a5-3d787b7df7cd','.jpg','curricular-activites-7.jpg','curricular-activites-7.jpg','image/jpeg',135310,1,1,'\0','2018-06-04 01:11:01',1,'2018-06-04 01:11:01',1),(41,'curricular-activites-7s.jpg','File','d2145219-9de6-4625-84a5-a3b40bd74131','.jpg','curricular-activites-7s.jpg','curricular-activites-7s.jpg','image/jpeg',35365,1,1,'\0','2018-06-04 01:11:01',1,'2018-06-04 01:11:01',1),(42,'curricular-activites-3s.jpg','File','8bea43ed-ed3b-48a8-8b74-1d11608f39a5','.jpg','curricular-activites-3s.jpg','curricular-activites-3s.jpg','image/jpeg',34281,1,1,'\0','2018-06-04 01:11:02',1,'2018-06-04 01:11:02',1),(43,'curricular-activites-1.jpg','File','424b8869-beb7-4b2e-bdb5-7d41fe75361f','.jpg','curricular-activites-1.jpg','curricular-activites-1.jpg','image/jpeg',122323,1,1,'\0','2018-06-04 01:11:02',1,'2018-06-04 01:11:02',1),(44,'curricular-activites-3.jpg','File','0fbeb20d-945b-439f-bc1c-a860f7b54f9e','.jpg','curricular-activites-3.jpg','curricular-activites-3.jpg','image/jpeg',136094,1,1,'\0','2018-06-04 01:11:03',1,'2018-06-04 01:11:03',1),(45,'curricular-activites-1s.jpg','File','12b54cab-4008-411f-a642-495fcf30860d','.jpg','curricular-activites-1s.jpg','curricular-activites-1s.jpg','image/jpeg',31628,1,1,'\0','2018-06-04 01:11:03',1,'2018-06-04 01:11:03',1),(46,'curricular-activites-6s.jpg','File','f2b676db-14bd-4a7f-b814-0effc84eaac1','.jpg','curricular-activites-6s.jpg','curricular-activites-6s.jpg','image/jpeg',25459,1,1,'\0','2018-06-04 01:11:04',1,'2018-06-04 01:11:04',1),(47,'curricular-activites-4s.jpg','File','25b42989-2c71-4bb3-b6c8-c346179cea13','.jpg','curricular-activites-4s.jpg','curricular-activites-4s.jpg','image/jpeg',25908,1,1,'\0','2018-06-04 01:11:05',1,'2018-06-04 01:11:05',1),(48,'curricular-activites-2s.jpg','File','a66c3285-3f38-4509-b086-2a75217cae96','.jpg','curricular-activites-2s.jpg','curricular-activites-2s.jpg','image/jpeg',27739,1,1,'\0','2018-06-04 01:11:05',1,'2018-06-04 01:11:05',1),(49,'curricular-activites-5.jpg','File','4a359231-824e-43a6-92a5-c393d4ede09b','.jpg','curricular-activites-5.jpg','curricular-activites-5.jpg','image/jpeg',113980,1,1,'\0','2018-06-04 01:11:06',1,'2018-06-04 01:11:06',1),(50,'hawan-ceremony-1.jpg','File','42b3b255-a959-407a-93ae-20b67fc7554d','.jpg','hawan-ceremony-1.jpg','hawan-ceremony-1.jpg','image/jpeg',185946,3,1,'\0','2018-06-04 01:16:52',1,'2018-06-04 01:16:52',1),(51,'hawan-ceremony-1s.jpg','File','13c87b08-8944-4f8a-b904-233a7f80ef0e','.jpg','hawan-ceremony-1s.jpg','hawan-ceremony-1s.jpg','image/jpeg',46278,3,1,'\0','2018-06-04 01:16:52',1,'2018-06-04 01:16:52',1),(52,'hawan-ceremony-2.jpg','File','f17943a7-ea10-41fe-b82f-463670aefbd4','.jpg','hawan-ceremony-2.jpg','hawan-ceremony-2.jpg','image/jpeg',180088,3,1,'\0','2018-06-04 01:16:53',1,'2018-06-04 01:16:53',1);
/*!40000 ALTER TABLE `picture` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `Id` int(11) NOT NULL,
  `Name` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Admin'),(2,'Client');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `session`
--

DROP TABLE IF EXISTS `session`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `session` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `session`
--

LOCK TABLES `session` WRITE;
/*!40000 ALTER TABLE `session` DISABLE KEYS */;
INSERT INTO `session` VALUES (1,'2016-17','',1,'2018-03-21 00:00:00',1),(2,'2017-18','',2,'2018-03-21 00:00:00',1),(3,'2018-19','',3,'2018-03-21 00:00:00',1);
/*!40000 ALTER TABLE `session` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `slide`
--

DROP TABLE IF EXISTS `slide`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `slide` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(200) DEFAULT NULL,
  `Image` varchar(50) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `slide`
--

LOCK TABLES `slide` WRITE;
/*!40000 ALTER TABLE `slide` DISABLE KEYS */;
INSERT INTO `slide` VALUES (1,NULL,'3b8092b4-d6d2-4857-8b15-07e1905b17b3.jpg','\0',2,1,'2018-06-01 01:03:29','2018-06-01 01:45:06',1),(2,' ','9a24b361-9279-4583-ac3f-52304d5b4106.jpg','',0,1,'2018-06-01 01:38:33','2018-06-01 01:38:33',1),(3,' ','fb5b14ee-6824-4333-b276-d10d668afb30.jpg','',1,1,'2018-06-01 01:38:48','2018-06-01 01:38:48',1);
/*!40000 ALTER TABLE `slide` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staffdetail`
--

DROP TABLE IF EXISTS `staffdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `staffdetail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GroupId` varchar(100) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Image` varchar(100) DEFAULT NULL,
  `Desigination` varchar(100) DEFAULT NULL,
  `AppointmentDate` date DEFAULT NULL,
  `ProfessionalQualification` varchar(100) DEFAULT NULL,
  `AcadmicQualification` varchar(100) DEFAULT NULL,
  `TrainingStatus` varchar(45) DEFAULT NULL,
  `JobStatus` varchar(45) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staffdetail`
--

LOCK TABLES `staffdetail` WRITE;
/*!40000 ALTER TABLE `staffdetail` DISABLE KEYS */;
INSERT INTO `staffdetail` VALUES (1,'Adminstrative','tst ','63952dfc-c442-4f49-93cc-1ea6f10df637.jpg','sa','2018-04-18','Prof Quali','t545tgsg','Trained','Confirmed',0,'\0','2018-04-04 23:52:49',1,'2018-04-04 23:52:49',1),(2,'Adminstrative','Amandeep Singh','319cf506-d9e3-415d-89a5-5d25d5539858.JPG','sa','2018-04-05','dfdf','dsggs','Trainee','Confirmed',0,'\0','2018-04-05 20:54:01',1,'2018-04-05 21:29:55',1),(4,'Adminstrative','Spiritual ',NULL,'sa','2018-04-12','Prof Quali','t545tgsg','Trained','Confirmed',2,'\0','2018-04-05 21:31:24',1,'2018-04-05 21:31:24',1);
/*!40000 ALTER TABLE `staffdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `toppers`
--

DROP TABLE IF EXISTS `toppers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `toppers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `ClassMasterId` int(11) DEFAULT NULL,
  `CGPA` varchar(100) DEFAULT NULL,
  `Image` varchar(100) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='																				';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `toppers`
--

LOCK TABLES `toppers` WRITE;
/*!40000 ALTER TABLE `toppers` DISABLE KEYS */;
/*!40000 ALTER TABLE `toppers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transfercertificate`
--

DROP TABLE IF EXISTS `transfercertificate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transfercertificate` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Class` varchar(45) DEFAULT NULL,
  `AdmissionNo` varchar(45) DEFAULT NULL,
  `FileName` varchar(45) DEFAULT NULL,
  `IsPublish` bit(1) DEFAULT NULL,
  `ExpireAfterDays` int(11) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transfercertificate`
--

LOCK TABLES `transfercertificate` WRITE;
/*!40000 ALTER TABLE `transfercertificate` DISABLE KEYS */;
/*!40000 ALTER TABLE `transfercertificate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `MobileNo` varchar(20) DEFAULT NULL,
  `MobileNoConfirmed` bit(1) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `EmailConfirmed` bit(1) DEFAULT NULL,
  `UserName` varchar(100) DEFAULT NULL,
  `PasswordHash` varchar(500) DEFAULT NULL,
  `SecurityStamp` varchar(500) DEFAULT NULL,
  `MasterPassword` varchar(45) DEFAULT NULL,
  `TwoFactorEnabled` bit(1) DEFAULT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` bit(1) DEFAULT NULL,
  `AccessFailedCount` int(11) DEFAULT NULL,
  `CreateUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='						';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,NULL,NULL,'Amandeep Singh','0001-01-01',NULL,'\0','adsofficial5@gmail.com','\0','adsofficial5@gmail.com','AKvx/LiFoA2WCeLIt9J/2Aj2QGhmhLJNkgOZKzGehRxolqjpIA6HL70Kd0835JY1YQ==','134c8a31-1b3f-48e9-bc01-c45600dcdd57',NULL,'\0',NULL,'\0',0,NULL),(2,NULL,NULL,NULL,'0001-01-01',NULL,'\0','adsofficial@gmail.com','\0','adsofficial@gmail.com','AN0FKI/T+XbiONX10xAns9bnQcvsRed1PW1rc9TuqkrmKCcIZ/wKVtNt7Q8wV/GkGg==','66640153-3520-41fe-8aea-e3dda669d889',NULL,'\0',NULL,'\0',0,NULL),(3,NULL,NULL,'Amandeep Singh','0001-01-01',NULL,'\0','asasas@gmail.com','\0','Amandeep Singh','AItNCqH5CEfvUpiATsbcF6snvuJBiVMhXLyE/QQesT5k5zno3K8XxtXHgg+V+TZ2wg==','3109945c-5eba-4804-9d32-66156620ab7f','aman','\0',NULL,'\0',0,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userclaims`
--

DROP TABLE IF EXISTS `userclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` bigint(20) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `user_claims_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userclaims`
--

LOCK TABLES `userclaims` WRITE;
/*!40000 ALTER TABLE `userclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `userclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userlogins`
--

DROP TABLE IF EXISTS `userlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` bigint(20) NOT NULL,
  KEY `user_login_user_idx` (`UserId`),
  CONSTRAINT `user_login_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userlogins`
--

LOCK TABLES `userlogins` WRITE;
/*!40000 ALTER TABLE `userlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `userlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usermenu`
--

DROP TABLE IF EXISTS `usermenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usermenu` (
  `Id` int(11) NOT NULL,
  `MenuId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `RoleId` int(11) DEFAULT NULL,
  `IsDelete` bit(1) DEFAULT NULL,
  `IsUpdate` bit(1) DEFAULT NULL,
  `IsAccess` bit(1) DEFAULT NULL,
  `IsView` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usermenu`
--

LOCK TABLES `usermenu` WRITE;
/*!40000 ALTER TABLE `usermenu` DISABLE KEYS */;
INSERT INTO `usermenu` VALUES (1,1,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(2,2,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(3,3,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(4,4,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(5,5,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(6,6,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(7,7,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(8,8,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(9,9,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(10,10,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(11,11,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(12,12,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(13,13,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(14,14,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(15,15,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(16,16,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(17,17,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(18,18,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(19,19,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(20,20,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(21,21,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(22,22,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(23,23,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(24,24,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(25,25,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(26,26,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(27,27,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(28,28,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(29,29,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(30,30,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(31,31,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(32,32,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(33,33,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(34,34,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(35,35,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(36,36,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(37,37,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(38,38,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1),(39,39,1,1,'','','','','2018-02-25 00:00:00',1,'2018-02-25 00:00:00',1);
/*!40000 ALTER TABLE `usermenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userroles` (
  `UserId` bigint(20) NOT NULL,
  `RoleId` int(11) NOT NULL,
  KEY `user_roles_user_idx` (`UserId`),
  KEY `user_roles_roles_idx` (`RoleId`),
  CONSTRAINT `user_roles_roles` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `user_roles_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES (1,1);
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `video`
--

DROP TABLE IF EXISTS `video`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `video` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(100) DEFAULT NULL,
  `Type` varchar(10) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Extension` varchar(45) DEFAULT NULL,
  `TitleAttribute` varchar(100) DEFAULT NULL,
  `AltAttribute` varchar(100) DEFAULT NULL,
  `Size` int(11) DEFAULT NULL,
  `MimeType` varchar(45) DEFAULT NULL,
  `SortId` int(11) DEFAULT NULL,
  `IsDefault` bit(1) DEFAULT NULL,
  `CreateByDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `video`
--

LOCK TABLES `video` WRITE;
/*!40000 ALTER TABLE `video` DISABLE KEYS */;
/*!40000 ALTER TABLE `video` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'hvmschool'
--
/*!50003 DROP PROCEDURE IF EXISTS `Sp_GalleryPictureDeleteById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_GalleryPictureDeleteById`(
_Id int
)
BEGIN
 Delete gpm,p from gallerypicturemapping gpm inner join picture p on gpm.pictureId= p.id where p.id=_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_GalleryVideoDeleteById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_GalleryVideoDeleteById`(
_Id int
)
BEGIN
 Delete gvm,v from galleryvideomapping gvm inner join video v on gvm.videoId= v.id where v.id=_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_ClassMaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_ClassMaster`(
_Id int(11),
_Name varchar(50),
_SortId int,
_IsActive bit,
_UserId int
)
BEGIN
if(_Id=0) then
			INSERT INTO classmaster
			(Name,
			SortId,
			IsActive,
			CreateByDate,
			CreateByUserId,
			ModifyByDate,
			ModifyByUserId)
			VALUES
			(_Name,
			_SortId,
			_IsActive,
			now(),
			_UserId,
			now(),
			_UserId);

else
			UPDATE classmaster
			SET
			Name = _Name,
			SortId = _SortId,
			IsActive=_IsActive,
			ModifyByDate = now(),
			ModifyByUserId = _UserId
			WHERE Id = _Id;

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_ContactUs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_ContactUs`(
_Name varchar(100),
_Email	varchar(100),
_Subject varchar(100),
_Message varchar(500),
_UserIPAddress varchar(45)
)
BEGIN
			INSERT INTO contactus
						(Name,
						Email,
						Subject,
						Message,
						CreateByUserIPAddress,
						CreateByDate)
						VALUES
						(_Name,
						_Email,
						_Subject,
						_Message,
						_UserIPAddress,
						NOw());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_Downloads` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_Downloads`(
_Id int(11),
_ClassMasterId int(11),
_Date Datetime,
_Title varchar(100),
_FileNames varchar(150),
_IsPublish bit,
_SortId int,
_UserId int
)
BEGIN
if(_Id=0) then
			INSERT INTO downloads
						(ClassMasterId,
						Date,
						Title,
						FileName,
						SortId,
						IsPublish,
						CreateByDate,
						CreateByUserId,
						ModifyByDate,
						ModifyByUserId)
						VALUES
						(_ClassMasterId,
						_Date ,
						_Title,
						_FileNames,
						_SortId,
						_IsPublish,
						now() ,
						_UserId ,
						now() ,
						_UserId );


else
			UPDATE downloads
					SET
					ClassMasterId = _ClassMasterId,
					Date = _Date,
					Title = _Title,
					FileName = _FileNames,
					SortId = _SortId,
					IsPublish = _IsPublish,
					ModifyByDate = now(),
					ModifyByUserId = _UserId
					WHERE Id = _Id;

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_Gallery` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_Gallery`(
_Id int(11),
_Name varchar(155),
_SessionId int,
_EventDate varchar(150),
_Description varchar(500),
_IsActive bit,
_UserId int(11))
BEGIN
	if(_Id=0) then
			INSERT INTO gallery
                                        (Name,
                                        SessionId,
                                        EventDate,
                                        Description,
                                        IsActive,
                                        CreateByDate,
                                        CreateByUserId,
                                        ModifyByDate,
                                        ModifyByUserId)
                                        VALUES
                                        (_Name,
                                        _SessionId,
                                        _EventDate,
                                        _Description,
                                        _IsActive,
                                        now(),
                                        _UserId,
                                        Now(),
                                        _UserId);
                                        SELECT LAST_INSERT_ID();
	else
          UPDATE gallery
                                   SET  Name = _Name     
                                        ,SessionId=_SessionId
                                        ,EventDate=_EventDate
                                        ,Description=_Description
                                        ,IsActive=_IsActive
                                        ,ModifyByDate = now()
                                        ,ModifyByUserId =_UserId
                                    WHERE Id=_Id;
		Select _Id;
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_Gallery_Picture` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_Gallery_Picture`(
_Id	int,
_GalleryId int,
_Title	varchar(100),
_Type	varchar(10),
_Name	varchar(1000),
_Extension	varchar(45),
_TitleAttribute	varchar(100),
_AltAttribute	varchar(100),
_MimeType	varchar(45),
_Size	int,
_PageId int,
_SortId int,
_IsDefault bit,
_UserId int 
)
BEGIN
if(_Id=0)
THEN
		INSERT INTO picture
		(Id,
		Title,
		Type,
		Name,
		Extension,
		TitleAttribute,
		AltAttribute,
		MimeType,
		Size,
		PageId,
		SortId,
		IsDefault,
		CreateByDate,
		CreateByUserId,
		ModifyByDate,
		ModifyByUserId)
		VALUES
		(_Id ,
		_Title ,
		_Type ,
		_Name ,
		_Extension ,
		_TitleAttribute ,
		_AltAttribute ,
		_MimeType ,
		_Size ,
		_PageId ,
		_SortId ,
		_IsDefault ,
		now() ,
		_UserId ,
		now() ,
		_UserId );

		
	set _Id= (SELECT LAST_INSERT_ID());	

	INSERT INTO gallerypicturemapping
	(GalleryId,
	PictureId)
	VALUES
	(_GalleryId,
	_Id);
   
	Select _Id;

else
	UPDATE picture
	SET
	Title = _Title ,
	Type = _Type ,
	Name = _Name ,
	Extension = _Extension ,
	TitleAttribute = _TitleAttribute ,
	AltAttribute = _AltAttribute ,
	MimeType = _MimeType ,
	Size = _Size ,
	PageId = _PageId ,
	SortId = _SortId ,
	IsDefault = _IsDefault ,
	ModifyByDate = now() ,
	ModifyByUserId = _UserId 
	WHERE Id = _Id;
 SELECT _Id;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_Gallery_Video` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_Gallery_Video`(
_Id	int,
_GalleryId int,
_Title	varchar(100),
_Type	varchar(10),
_Name	varchar(1000),
_Extension	varchar(45),
_TitleAttribute	varchar(100),
_AltAttribute	varchar(100),
_MimeType	varchar(45),
_Size	int,
_SortId int,
_IsDefault bit,
_UserId int 
)
BEGIN
if(_Id=0)
THEN
		INSERT INTO video
(Title,
Type,
Name,
Extension,
TitleAttribute,
AltAttribute,
Size,
MimeType,
SortId,
IsDefault,
CreateByDate,
CreateByUserId,
ModifyByDate,
ModifyByUserId)
VALUES
(_Title,
_Type,
_Name,
_Extension,
_TitleAttribute,
_AltAttribute,
_Size,
_MimeType,
_SortId,
_IsDefault,
now(),
_UserId,
now(),
_UserId);


		
	set _Id= (SELECT LAST_INSERT_ID());	

	INSERT INTO galleryvideomapping
	(GalleryId,
	VideoId)
	VALUES
	(_GalleryId,
	_Id);
   
	Select _Id;

else
		UPDATE video
			SET
			Title = _Title,
			Type = _Type,
			Name = _Name,
			Extension = _Extension,
			TitleAttribute = _TitleAttribute,
			AltAttribute = _AltAttribute,
			Size = _Size,
			SortId=_SortId,
			MimeType = _MimeType,
			IsDefault = _IsDefault,
			ModifyByDate = now(),
			ModifyByUserId = _UserId
		WHERE Id =_Id;
 SELECT _Id;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_Member` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_Member`(
_Id int(11),
_Name varchar(50),
_Desigination varchar(100),
_Image varchar(100),
_SortId int,
_IsActive bit,
_UserId int
)
BEGIN
if(_Id=0) then
			INSERT INTO member
			(Name,
			Desigination,
			Image,
			SortId,
			IsActive,
			CreateByDate,
			CreateByUserId,
			ModifyByDate,
			ModifyByUserId)
			VALUES
			(_Name,
			_Desigination,
			_Image,
			_SortId,
			_IsActive,
			now(),
			_UserId,
			now(),
			_UserId);

else
			UPDATE member
			SET
			Name = _Name,
			Desigination = _Desigination,
			Image = _Image,
			SortId = _SortId,
			IsActive=_IsActive,
			ModifyByDate = now(),
			ModifyByUserId = _UserId
			WHERE Id = _Id;

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_News` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_News`(
_Id int(11),
_Date datetime,
_Title varchar(100),
_FileNames	varchar(50),
_ShortDescription varchar(200),
_Description text,
_SortId int,
_IsActive bit,
_UserId int
)
BEGIN
if(_Id=0) then
			INSERT INTO news
							(Date,
							Title,
							FileName,
							ShortDescription,
							Description,
							IsActive,
							SortId,
							Views,
							CreateByDate,
							CreateByUserId,
							ModifyByDate,
							ModifyByUserId)
							VALUES
							(_Date,
							_Title,
							_FileNames,
							_ShortDescription,
							_Description,
							_IsActive,
							_SortId,
							0,
							now(),
							_UserId,
							NOw(),
							_UserId);


else
			UPDATE news
					SET
					Date=_Date,
					Title = _Title,
					FileName = _FileNames,
					ShortDescription=_ShortDescription,
					Description = _Description,
					IsActive = _IsActive,
					SortId = _SortId,
					ModifyByDate = NOw(),
					ModifyByUserId = _UserId
					WHERE Id = _Id;


end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_Page` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_Page`(
_Id int(11),
_MenuCode varchar(45),
_Title varchar(200),
_Seo varchar(150),
_MetaKeywords varchar(250),
_MetaDescription varchar(300),
_MetaTitle varchar(200),
_IsPublish bit,
_Contents text,
_UserId int(11)
)
BEGIN

			UPDATE pages
			SET
					Title = _Title,
					Seo = _Seo,
					MetaKeywords = _MetaKeywords,
					MetaDescription = _MetaDescription,
					MetaTitle = _MetaTitle,
					Contents = _Contents,
					IsPublish = _IsPublish,
					ModifyByDate = NoW(),
					ModifyByUserId = _UserId
			WHERE Id = _Id and MenuCode=_MenuCode;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_Slide` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_Slide`(
_Id int(11),
_Title varchar(100),
_Image varchar(100),
_SortId int,
_IsActive bit,
_UserId int
)
BEGIN
if(_Id=0) then
		INSERT INTO slide
					(Title,
					Image,
					IsActive,
					SortId,
					CreateByUserId,
					CreateByDate,
					ModifyByDate,
					ModifyByUserId)
					VALUES
					(_Title,
					_Image,
					_IsActive,
					_SortId,
					_UserId,
					now(),
					now(),
					_UserId);


else
			UPDATE slide
					SET
					Title = _Title,
					Image = _Image,
					IsActive = _IsActive,
					SortId = _SortId,
					ModifyByDate = NOw(),
					ModifyByUserId = _UserId
					WHERE Id = _Id;

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_StaffDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_StaffDetail`(
_Id int(11),
_Name varchar(155),
_Desigination varchar(100),
_Image varchar(100),
_GroupId varchar(100),
_AppointmentDate Date,
_ProfessionalQualification varchar(100),
_AcadmicQualification varchar(100),
_TrainingStatus varchar(45),
_JobStatus varchar(45),
_SortId int(11),
_IsActive bit,
_UserId int(11)
)
BEGIN
if(_Id=0) then
			INSERT INTO staffdetail
						(GroupId,
						Name,
						Image,
						Desigination,
						AppointmentDate,
						ProfessionalQualification,
						AcadmicQualification,
						TrainingStatus,
						JobStatus,
						SortId,
						IsActive,
						CreateByDate,
						CreateByUserId,
						ModifyByDate,
						ModifyByUserId)
						VALUES
						(_GroupId,
						_Name,
						_Image,
						_Desigination,
						_AppointmentDate,
						_ProfessionalQualification,
						_AcadmicQualification,
						_TrainingStatus,
						_JobStatus,
						_SortId,
						_IsActive,
						now(),
						_UserId,
						now(),
						_UserId);
	else
         UPDATE staffdetail
				SET
				GroupId = _GroupId,
				Name = _Name,
				Image = _Image,
				Desigination = _Desigination,
				AppointmentDate = _AppointmentDate,
				ProfessionalQualification = _ProfessionalQualification,
				AcadmicQualification = _AcadmicQualification,
				TrainingStatus = _TrainingStatus,
				JobStatus = _JobStatus,
				SortId = _SortId,
				IsActive = _IsActive,
				ModifyByDate = now(),
				ModifyByUserId = _UserId
				WHERE Id = _Id;

	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_Toppers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_Toppers`(
_Id int(11),
_Name varchar(50),
_CGPA varchar(100),
_ClassMasterId	int,
_Image varchar(100),
_SortId int,
_IsActive bit,
_UserId int
)
BEGIN
if(_Id=0) then
			INSERT INTO toppers
			(Name,
			ClassMasterId,
			CGPA,
			Image,
			SortId,
			IsActive,
			CreateByDate,
			CreateByUserId,
			ModifyByDate,
			ModifyByUserId)
			VALUES
			(_Name,
			_ClassMasterId,
			_CGPA,
			_Image,
			_SortId,
			_IsActive,
			now(),
			_UserId,
			now(),
			_UserId);

else
			UPDATE toppers
			SET
			Name = _Name,
			ClassMasterId=_ClassMasterId,
			CGPA = _CGPA,
			Image = _Image,
			SortId = _SortId,
			IsActive=_IsActive,
			ModifyByDate = now(),
			ModifyByUserId = _UserId
			WHERE Id = _Id;

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Save_TransferCerticate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Save_TransferCerticate`(
_Id int(11),
_Name varchar(45),
_Class varchar(45),
_AdmissionNo varchar(45),
_FileNames varchar(45),	
_IsPublish bit,
_ExpireAfterDays int,
_UserId int
)
BEGIN
if(_Id=0) then
			INSERT INTO transfercertificate
						(Name,
						Class,
						AdmissionNo,
						FileName,
						IsPublish,
						ExpireAfterDays,
						CreateByDate,
						CreateByUserId,
						ModifyByDate,
						ModifyByUserId)
						VALUES
						(_Name,
						_Class,
						_AdmissionNo,
						_FileNames,
						_IsPublish,
						_ExpireAfterDays,
						NOw(),
						_UserId,
						Now(),
						_UserId);
else
			UPDATE transfercertificate
						SET
						Name = _Name,
						Class = _Class,
						AdmissionNo = _AdmissionNo,
						FileName = _FileNames,
						IsPublish = _IsPublish,
						ExpireAfterDays = _ExpireAfterDays,
						ModifyByDate =Now(),
						ModifyByUserId = _UserId
						WHERE Id = _Id;

end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_ClassMaster_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_ClassMaster_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
	declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT Id,
				Name,
				SortId,
				CreateByDate,
				CreateByUserId,
				ModifyByDate,
				ModifyByUserId
		FROM classmaster
        order by name
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from classmaster;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_ContactUs_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_ContactUs_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
	declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT Id,
				Name,
				Email,
				Subject,
				Message,
				CreateByDate,
				CreateByUserIPAddress
		FROM contactus
        order by CreateByDate desc
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from contactus;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_Downloads_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_Downloads_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
	declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT  d.Id,
				d.ClassMasterId,
				cm.Name ClassName,
				d.Date,
				d.Title,
				d.FileName,	
				d.SortId,
				d.CreateByDate,
				d.CreateByUserId,
				d.ModifyByDate,
				d.ModifyByUserId
		FROM downloads d
		join classmaster cm on d.ClassMasterId=cm.Id
        order by cm.SortId
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from downloads;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_Gallery_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_Gallery_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT *
		FROM gallery
        order by name
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from gallery;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_Member_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_Member_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
	declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT Id,
				Name,
				Desigination,
				Image,
				SortId,
				CreateByDate,
				CreateByUserId,
				ModifyByDate,
				ModifyByUserId
		FROM member
        order by name
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from member;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_News_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_News_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
	declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT Id,
				Date,
				Title,
				FileName,
				ShortDescription,
				Description,
				IsActive,
				SortId,
				Views,
				CreateByDate,
				CreateByUserId
		FROM news
        order by CreateByDate desc
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from news;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_Slide_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_Slide_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
	declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT Id,
				Title,
				Image,
				IsActive,
				SortId   
			FROM slide
        order by SortId
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from slide;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_StaffDetail_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_StaffDetail_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT Id,
				GroupId,
				Name,
				Image,
				Desigination,
				AppointmentDate,
				ProfessionalQualification,
				AcadmicQualification,
				TrainingStatus,
				JobStatus,
				CreateByDate,
				CreateByUserId,
				ModifyByDate,
				ModifyByUserId
			FROM staffdetail
        order by name
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from staffdetail;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_Toppers_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_Toppers_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
	declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT Id,
				Name,
				CGPA,
				Image,
				SortId,
				CreateByDate,
				CreateByUserId,
				ModifyByDate,
				ModifyByUserId
		FROM toppers
        order by name
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from toppers;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Select_TransaferCerticate_List` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Select_TransaferCerticate_List`(
_IsCount bit,
_PageNumber int,
_PageSize int
)
BEGIN
	declare RowStart int default 0;
    set RowStart=_PageSize * (_PageNumber-1);
	if(!_IsCount) then
		SELECT Id,
				Name,
				Class,
				AdmissionNo,
				FileName,
				IsPublish,
				ExpireAfterDays
		FROM transfercerticate
        order by CreateByDate desc
		limit RowStart,_PageSize	; 
    else
            Select count(Id) 
				from transfercerticate;		
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-01-20 13:08:31
