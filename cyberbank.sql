-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3307
-- Generation Time: May 12, 2021 at 08:50 PM
-- Server version: 5.7.24
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cyberbank`
--

-- --------------------------------------------------------

--
-- Table structure for table `e_carts`
--

CREATE TABLE `e_carts` (
  `ec_id` int(11) NOT NULL,
  `ec_cartnumber` varchar(16) NOT NULL,
  `ec_cache` float DEFAULT NULL,
  `ec_cvv` int(11) NOT NULL,
  `ec_cartholder_name` varchar(32) NOT NULL,
  `ec_cartholder_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `e_carts`
--

INSERT INTO `e_carts` (`ec_id`, `ec_cartnumber`, `ec_cache`, `ec_cvv`, `ec_cartholder_name`, `ec_cartholder_id`) VALUES
(1, '0000000000000001', 1145.12, 543, 'GLEB KOSHEVOY', 1),
(2, '8836693171428888', 350, 359, 'Roman Korovin', 2),
(5, '8141649920474822', 754.88, 639, 'VLADISLAV STOLNIKOV', 3),
(9, '5798441345394780', -0.00213623, 444, 'KONSTANTIN VAGANOV', 4),
(10, '2130750372217608', 0, 889, 'EGOR KARAEV', 5),
(11, '5143435956594177', 177, 893, 'TIMOFEY NADEYKIN', 6),
(12, '3816346997502127', 430, 225, 'STEPAN MALYSHEV', 7),
(13, '2189363951787016', 280, 971, 'ABOBA ABBA', 8),
(14, '9492994725141657', 128, 643, 'NARUTO UZUMAKI', 9),
(15, '2419503921123744', 775, 280, 'VLADIMIR PUTIN', 10),
(16, '6000807945029930', 664, 965, '1 1', 11),
(17, '6323425936674649', 143, 683, '2 2', 12),
(19, '7209186294283502', 856, 317, '123 123', 14);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `u_id` int(11) NOT NULL,
  `u_username` varchar(32) NOT NULL,
  `u_password` varchar(32) NOT NULL,
  `u_name` varchar(32) NOT NULL,
  `u_surname` varchar(32) NOT NULL,
  `u_date_of_birth` date NOT NULL,
  `u_havecart` int(11) DEFAULT NULL,
  `u_role` varchar(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`u_id`, `u_username`, `u_password`, `u_name`, `u_surname`, `u_date_of_birth`, `u_havecart`, `u_role`) VALUES
(1, 'admin', 'admin', 'Gleb', 'Koshevoy', '2008-04-20', 1, 'admin'),
(2, 'Roma', 'roma', 'Roman', 'Korovin', '2001-05-20', 1, 'user'),
(3, 'Vl4d0ccc', '123', 'Vladislav', 'Stolnikov', '2011-10-20', 1, NULL),
(4, 'Koksya', '12', 'Konstantin', 'Vaganov', '2009-04-20', 1, NULL),
(5, 'Egor', '123', 'Egor', 'Karaev', '2007-05-20', 1, NULL),
(6, 'Tima', 'kpo', 'Timofey', 'Nadeykin', '2006-05-20', 1, NULL),
(7, 'Xoxol', 'salo', 'Stepan', 'Malyshev', '1992-03-21', 1, NULL),
(8, 'Aboba', 'booba', 'Aboba', 'Abba', '1980-06-06', 1, NULL),
(9, 'Naruto', 'Saske', 'Naruto', 'Uzumaki', '1951-12-21', 1, NULL),
(10, 'Vova', 'russia', 'Vladimir', 'Putin', '1952-10-07', 1, NULL),
(11, '1', '1', '1', '1', '2021-05-06', 1, NULL),
(12, '2', '2', '2', '2', '2021-05-09', 1, NULL),
(13, 'aa', 'aa', 'aa', 'aa', '2021-05-02', NULL, NULL),
(14, '123', '123', '123', '123', '2021-05-07', 1, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `e_carts`
--
ALTER TABLE `e_carts`
  ADD PRIMARY KEY (`ec_id`),
  ADD KEY `ec_cartholder_id` (`ec_cartholder_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`u_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `e_carts`
--
ALTER TABLE `e_carts`
  MODIFY `ec_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `u_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `e_carts`
--
ALTER TABLE `e_carts`
  ADD CONSTRAINT `e_carts_ibfk_1` FOREIGN KEY (`ec_cartholder_id`) REFERENCES `users` (`u_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
