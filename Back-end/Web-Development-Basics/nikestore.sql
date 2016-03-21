-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 03, 2015 at 01:35 PM
-- Server version: 5.6.26
-- PHP Version: 5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `nikestore`
--

-- --------------------------------------------------------

--
-- Table structure for table `admins`
--

CREATE TABLE IF NOT EXISTS `admins` (
  `Id` int(11) NOT NULL,
  `Username` varchar(40) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Role` varchar(10) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admins`
--

INSERT INTO `admins` (`Id`, `Username`, `Password`, `Role`) VALUES
(1, 'admin', 'a1a', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
  `Id` int(11) NOT NULL,
  `CategoryName` varchar(30) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`Id`, `CategoryName`) VALUES
(1, 'Men'),
(2, 'Women'),
(3, 'Kids');

-- --------------------------------------------------------

--
-- Table structure for table `contactus`
--

CREATE TABLE IF NOT EXISTS `contactus` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Text` text NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `contactus`
--

INSERT INTO `contactus` (`Id`, `Name`, `Email`, `Text`) VALUES
(1, 'John', 'mail@mail.com', 'Hi!'),
(2, '', '', ''),
(3, '', '', ''),
(4, '', '', ''),
(5, '', '', ''),
(6, '', '', ''),
(7, '', '', ''),
(8, '', '', ''),
(9, '', '', ''),
(10, '', '', ''),
(11, '', '', ''),
(12, '', '', ''),
(13, '', '', ''),
(14, '', '', ''),
(15, '', '', ''),
(16, '', '', ''),
(17, '', '', ''),
(18, '', '', ''),
(19, '', '', ''),
(20, '', '', ''),
(21, '', '', ''),
(22, '', '', ''),
(23, '', '', ''),
(24, '', '', ''),
(25, '', '', ''),
(26, '', '', ''),
(27, '', '', ''),
(28, '', '', ''),
(29, '', '', ''),
(30, 'Petar', 'mail@mail.com', 'Text'),
(31, '', '', ''),
(32, '', '', ''),
(33, '', '', ''),
(34, '', '', ''),
(35, '', '', ''),
(36, '', '', ''),
(37, '', '', ''),
(38, '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `editors`
--

CREATE TABLE IF NOT EXISTS `editors` (
  `id` int(11) NOT NULL,
  `Username` varchar(40) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Role` varchar(10) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `editors`
--

INSERT INTO `editors` (`id`, `Username`, `Password`, `Role`) VALUES
(1, 'editor', 'e1e', 'Editor');

-- --------------------------------------------------------

--
-- Table structure for table `shirts`
--

CREATE TABLE IF NOT EXISTS `shirts` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Price` decimal(10,0) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `CreatedOn` varchar(20) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `Promotion` int(11) NOT NULL,
  `Product` varchar(15) NOT NULL,
  `OrderBy` varchar(15) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shirts`
--

INSERT INTO `shirts` (`Id`, `Name`, `Price`, `Quantity`, `CreatedOn`, `OwnerId`, `CategoryId`, `Promotion`, `Product`, `OrderBy`) VALUES
(5, 'Nike Pro Crew', '65', 8, '2015-10-01', 10, 1, 0, 'Shirts', 'Id'),
(10, 'Nike AeroReact', '130', 15, '2015-10-02', 22, 1, 10, 'Shirts', 'Id'),
(13, 'Element Sphere', '85', 7, '2015-10-03', 15, 3, 0, 'Shirts', 'Id'),
(14, 'Nike Hyperwarm', '55', 9, '2015-10-03', 16, 1, 0, 'Shirts', 'Id'),
(15, 'Nike Dri-FIT', '90', 5, '2015-10-03', 17, 2, 0, 'Shirts', 'Id'),
(16, 'Nike Half-Zip', '70', 4, '2015-10-03', 22, 3, 0, 'Shirts', 'Id'),
(17, 'Nike Miler', '50', 6, '2015-10-03', 22, 1, 10, 'Shirts', 'Id'),
(18, 'Nike DIT-Fit', '45', 10, '2015-10-03', 22, 2, 15, 'Shirts', 'Id'),
(19, 'Nike T2', '55', 9, '2015-10-03', 18, 2, 0, 'Shirts', 'Id');

-- --------------------------------------------------------

--
-- Table structure for table `shoes`
--

CREATE TABLE IF NOT EXISTS `shoes` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Price` decimal(10,0) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `CreatedOn` varchar(20) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `Promotion` int(11) NOT NULL,
  `Product` varchar(15) NOT NULL,
  `OrderBy` varchar(15) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `shoes`
--

INSERT INTO `shoes` (`Id`, `Name`, `Price`, `Quantity`, `CreatedOn`, `OwnerId`, `CategoryId`, `Promotion`, `Product`, `OrderBy`) VALUES
(1, 'LeBronXIII iD', '245', 20, '2015-09-02', 10, 1, 0, 'Shoes', 'Id'),
(3, 'Nike Air Zoom', '120', 10, '2015-09-02', 9, 1, 20, 'Shoes', 'Id'),
(8, 'Nike Air Struck', '160', 5, '2015-09-02', 12, 3, 10, 'Shoes', 'Id'),
(9, 'Nike Zoom Speed', '100', 4, '2015-09-02', 15, 2, 10, 'Shoes', 'Id'),
(10, 'Nike Air Pegasus', '150', 19, '2015-09-02', 9, 1, 10, 'Shoes', 'Id'),
(14, 'Jordan CP3', '175', 9, '2015-09-02', 19, 1, 0, 'Shoes', 'Id'),
(19, 'Nike Metcon', '120', 10, '2015-09-28', 14, 2, 0, 'Shoes', 'Id'),
(20, 'KD 8', '180', 20, '2015-10-01', 12, 2, 0, 'Shoes', 'Id'),
(21, 'Air Jordan Low', '145', 12, '2015-10-01', 16, 2, 20, 'Shoes', 'Id'),
(23, 'Nike CJ3', '160', 10, '2015-10-03', 22, 1, 0, 'Shoes', 'Id'),
(24, 'Nike Air Zoom 19', '160', 10, '2015-10-03', 22, 2, 0, 'Shoes', 'Id'),
(25, 'Nike Agility', '130', 10, '2015-10-03', 22, 2, 10, 'Shoes', 'Id'),
(26, 'Nike Free iD', '140', 10, '2015-10-03', 15, 3, 0, 'Shoes', '');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `Id` int(11) NOT NULL,
  `Username` varchar(20) NOT NULL,
  `Pass_hash` varchar(100) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `RegisteredOn` varchar(20) NOT NULL,
  `Cash` decimal(10,0) DEFAULT NULL,
  `Role` varchar(10) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Username`, `Pass_hash`, `Email`, `RegisteredOn`, `Cash`, `Role`) VALUES
(9, 'ivo', '$2y$10$1eQl9t0oERWZe8brqBetM.oO9FSQNTzfXg0bhY68B0Ln.Fxq2InDC', 'ivo@mail.com', '', '1598', 'User'),
(10, 'maria', '$2y$10$ZYPhJGi3GP1SgzeAkIOR6.G/8M6V3kbvGW/au8yi8K0tExeQnzf9e', 'maria@mail.com', '2015-09-27', '1565', 'User'),
(11, 'momo', '$2y$10$zY/PNWruEzkumqnvF2GCLOtQTOlZ.fgPyfxl/k6Z4UgEyhnyQGdP6', 'momo@mail.com', '2015-09-27', '1504', 'User'),
(12, 'user', '$2y$10$Uu8GG2BLmGV9P90jOofVI.1JUHFcQ9qFFhtvtFYOSgklhc7/WKJWe', 'u@mail.com', '2015-09-29', '1500', 'User'),
(13, 'pesho1', '$2y$10$xzKqY.ci9w4cZa7c5I5Tw.tNVr0MGBtkv1VcxIwgH5ukeflSao2nm', 'p@gmail.com', '2015-09-30', '1500', 'User'),
(14, 'user123', '$2y$10$7Y9gFc4cT/CD7EsjDyKk1.kfg/2Je3dy26JsHNiZpzZycvToThDLa', 'user123@mail.com', '2015-09-30', '1500', 'User'),
(15, 'tushe2000', '$2y$10$u1dynCeNGWpfNZuD9ZXcS.cauLEfCQ05YefgDXjGJxrEVAnRVaBPO', 't@mail.com', '2015-09-30', '1500', 'User'),
(16, 'ivanov', '$2y$10$cmGxDKw9QnA4/lbhnXD7h.CWIKet/jk95wzPp4VHMiUEkPupuZU4a', 'ivanov@mail.com', '2015-09-30', '1555', 'User'),
(17, 'petar', '$2y$10$/P7qIe6D2Qkj5XtCdaPKE.6P79uiUXwptoKXfaqGlkKHWGpDs2cCu', '12312@mail.com', '2015-09-30', '1500', 'User'),
(18, 'ivooo', '$2y$10$QWJnvs6KI28h9xcbAqLnReGkhkSXE3oVONpOSUd6GjdlvytjkjaAK', 'mai@mail.com', '2015-09-30', '1500', 'User'),
(19, 'pinco', '$2y$10$bOSUBKHGeQkxSJzOk4FDquckwXZ7n8XXRF7qxGKM25wY8R2Ttx/tG', 'pinco@mail.com', '2015-09-30', '1500', 'User'),
(20, 'iii', '$2y$10$yjWH36pz0VebQqIZHhRdSu7qmb26ZAifi8Bv6mQE9L0Nmrh4Wd2O.', 'iii@mail.com', '2015-09-30', '1500', 'User'),
(21, 'tosho123', '$2y$10$bgT0R54WjYeAJ5guEr3vQ.Mdj0PgsXTSgNXvGO3G/eqzO8I0xBEjy', '12333@mail.com', '2015-09-30', '1500', 'User'),
(22, 'user2', '$2y$10$f19/Dsn210cFbtSctbpzwOZmtMfbXK7rYZgC0Byt6ATfdJ0DmmqLu', 'user2@mail.com', '2015-10-01', '1031', 'User'),
(23, 'pesho', '$2y$10$zf/B9uCxfbviYakQ4ssgvOXBqAP5KVGlx0UgfXzFuUW8M5LCuECki', 'pesho@mail.com', '2015-10-03', '1500', 'User');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `contactus`
--
ALTER TABLE `contactus`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `editors`
--
ALTER TABLE `editors`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `shirts`
--
ALTER TABLE `shirts`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CategoryId` (`CategoryId`),
  ADD KEY `OwnerId` (`OwnerId`);

--
-- Indexes for table `shoes`
--
ALTER TABLE `shoes`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `OwnerId` (`OwnerId`),
  ADD KEY `OwnerId_2` (`OwnerId`),
  ADD KEY `OwnerId_3` (`OwnerId`),
  ADD KEY `OwnerId_4` (`OwnerId`),
  ADD KEY `CategoryId` (`CategoryId`),
  ADD KEY `OwnerId_5` (`OwnerId`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admins`
--
ALTER TABLE `admins`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `contactus`
--
ALTER TABLE `contactus`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=39;
--
-- AUTO_INCREMENT for table `editors`
--
ALTER TABLE `editors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `shirts`
--
ALTER TABLE `shirts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT for table `shoes`
--
ALTER TABLE `shoes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=27;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=24;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
