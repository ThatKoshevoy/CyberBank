-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: May 17, 2021 at 03:10 PM
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
  `ec_cartnumber` varchar(255) NOT NULL,
  `ec_cache` float DEFAULT NULL,
  `ec_cvv` varchar(255) NOT NULL,
  `ec_cartholder_name` varchar(255) NOT NULL,
  `ec_cartholder_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `e_carts`
--

INSERT INTO `e_carts` (`ec_id`, `ec_cartnumber`, `ec_cache`, `ec_cvv`, `ec_cartholder_name`, `ec_cartholder_id`) VALUES
(17, '/inEojHgOSTAO06k4Vh3qeHvQ8mkvO7h2uYVdoPdNjo=', 516, 'eyufTS/vbahc8YaJ/BIOpQ==', '+WuVtPD2AZGo7x1UkgoHUA==', 2),
(19, 'wGF7PJxTqptglWRAywxOxdaw9TqthTC0aUHmdvQi24g=', 147, 'iFhj7GuD3/XuBCpFZNPLnw==', '+WuVtPD2AZGo7x1UkgoHUA==', 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `u_id` int(11) NOT NULL,
  `u_username` varchar(255) NOT NULL,
  `u_password` varchar(255) NOT NULL,
  `u_name` varchar(255) NOT NULL,
  `u_surname` varchar(255) NOT NULL,
  `u_date_of_birth` date NOT NULL,
  `u_havecart` int(11) DEFAULT NULL,
  `u_role` varchar(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`u_id`, `u_username`, `u_password`, `u_name`, `u_surname`, `u_date_of_birth`, `u_havecart`, `u_role`) VALUES
(1, 'DTC5epRqdlXIYp8vG5FwAA==', 'DTC5epRqdlXIYp8vG5FwAA==', 'Wb7VeNcSY3vCpbUr+4ewXw==', 'HmEwX+0To7MVHNXLPiOGxg==', '2001-04-08', 1, 'admin'),
(2, 'L51r9CbxieFS4Qew5g2RyQ==', 'sOYx3s8xME4m71PfVDlWJA==', 'Mmoca8mtxQJ/5SQ7gSuhUw==', 'ZhwLYvtdhSfxuZODt+OtfQ==', '1889-04-20', 1, NULL);

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
  MODIFY `u_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

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
