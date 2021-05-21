-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: May 21, 2021 at 10:11 AM
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
-- Table structure for table `credit_cards`
--

CREATE TABLE `credit_cards` (
  `cr_c_id` int(11) NOT NULL,
  `cr_ca_cache` double NOT NULL,
  `cr_c_need_cache` double NOT NULL,
  `cr_c_cardnuber` varchar(255) NOT NULL,
  `cr_c_id_cvv` varchar(255) NOT NULL,
  `cr_c_id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `credit_cards`
--

INSERT INTO `credit_cards` (`cr_c_id`, `cr_ca_cache`, `cr_c_need_cache`, `cr_c_cardnuber`, `cr_c_id_cvv`, `cr_c_id_user`) VALUES
(3, 4500, 4500, '4794607430404170', '102', 3),
(4, 120000, 120000, '3015997924655714', '407', 7),
(5, 9999, 10000, '9461113764377491', '537', 5),
(6, 1254, 1254, '4194198144126600', '560', 6);

-- --------------------------------------------------------

--
-- Table structure for table `credit_requests`
--

CREATE TABLE `credit_requests` (
  `c_r_id` int(11) NOT NULL,
  `cr_description` varchar(1000) NOT NULL,
  `cr_value` double NOT NULL,
  `cr_email` varchar(50) NOT NULL,
  `cr_id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `e_carts`
--

CREATE TABLE `e_carts` (
  `e_id` int(11) NOT NULL,
  `ec_cartnumber` varchar(255) NOT NULL,
  `ec_cache` double DEFAULT NULL,
  `ec_cvv` varchar(255) NOT NULL,
  `ec_cartholder_name` varchar(255) NOT NULL,
  `ec_cartholder_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `e_carts`
--

INSERT INTO `e_carts` (`e_id`, `ec_cartnumber`, `ec_cache`, `ec_cvv`, `ec_cartholder_name`, `ec_cartholder_id`) VALUES
(1, 'wGF7PJxTqptglWRAywxOxdaw9TqthTC0aUHmdvQi24g=', 5467563098112, 'iFhj7GuD3/XuBCpFZNPLnw==', '+WuVtPD2AZGo7x1UkgoHUA==', 1),
(2, '/inEojHgOSTAO06k4Vh3qeHvQ8mkvO7h2uYVdoPdNjo=', 516, 'eyufTS/vbahc8YaJ/BIOpQ==', '+WuVtPD2AZGo7x1UkgoHUA==', 2),
(3, 'rbFIAaaaOCjNSBOWmkcPOASLg3TKIqBTWHryb+z/LNA=', 19865, 'R8xrXZUMJ91Pox0SvNWy2Q==', 'hma2S3kF/mt9ogXJ6FwONQ==', 3),
(4, 'v4xYqb3iZFox7EyjiLRC6uDfgXUSJK0Sv6OERFA5TuA=', 1653, 'itjg98ZyybGhaRSgn+aG9g==', 'yw2OJ5WzunFnrNq6jmBklgjrUECdv+N00ZTGOGHgW0A=', 4),
(5, '/P2a0tCaGpLvJXkeCHQSoQODdivREGnNnhrAQV8k9V8=', 654, '8lrc1jKFcCKBgIYcubyrdA==', 'QlLCIScVzjkJvlp3EpzKLriC0hydLZIqFQB02halJmM=', 5),
(6, 'mgGFDAxXmvZmCKxF1COprS9ShRWrGLlUHcmo+GmncyQ=', 987, 'LLlfNxrvAiU5GnoYri7gfw==', 'mhKV7g2EzLQjNtcqZUepOA==', 6),
(7, 'egy95/Nz4GTsZ1ONGF0n8HWvU+OFpiK2nfeYbGWWBNU=', 886, '+D8+PSaabS7oO2XZsSa9jQ==', 'ityefnJyuTEJdnuKiAJy9qzMeRzRa6II7VWFgCYUozw=', 7);

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
  `u_havecredit` int(11) NOT NULL,
  `u_role` varchar(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`u_id`, `u_username`, `u_password`, `u_name`, `u_surname`, `u_date_of_birth`, `u_havecart`, `u_havecredit`, `u_role`) VALUES
(1, 'DTC5epRqdlXIYp8vG5FwAA==', 'DTC5epRqdlXIYp8vG5FwAA==', 'Wb7VeNcSY3vCpbUr+4ewXw==', 'HmEwX+0To7MVHNXLPiOGxg==', '2001-04-08', 1, 0, 'admin'),
(2, 'L51r9CbxieFS4Qew5g2RyQ==', 'sOYx3s8xME4m71PfVDlWJA==', 'Mmoca8mtxQJ/5SQ7gSuhUw==', 'ZhwLYvtdhSfxuZODt+OtfQ==', '1889-04-20', 1, 0, NULL),
(3, 'Z+KNzFZtt9kPZ23hbrkQ1Q==', 'gBqHe27eDt5qqq0P00KpRQ==', 'NHu9fOFgQxu2Usj3cJQVZA==', '4eCEWu2ztG1PWJwhdvPqjw==', '2021-05-06', 1, 1, NULL),
(4, 'yp5qKl1zONC5C7d9jsHpAQ==', 'RYc0hRCX5WB1bgfyB8kiOw==', 'QtluvBJVcsg4gIELNQBCtA==', 'I6/28JK6y3FTzqSea7nHCA==', '2001-06-18', 1, 0, NULL),
(5, 'KXEEoKHbteJuDOieXU1qtg==', 'LonhFNY3MjNxfd6Xfv5vBA==', '5AenZeuhga0h67lYD5Tp9w==', 'SJgdYfSN6mecf569UJSvlQ==', '2001-10-11', 1, 1, NULL),
(6, 'ufWBS4+P9z4JDHyKv3ZMWQ==', 'k7Nn1LIt5fkLO0TTqjwK1Q==', 'ufWBS4+P9z4JDHyKv3ZMWQ==', 'xt46mkP/Bu6oryJrj2PYIA==', '2021-08-04', 1, 1, NULL),
(7, 'LF91C4q39ogmiU+kPgB/VQ==', 'V0x5MQQ5Zuxv46EAu1J1zQ==', 'ah2uUWsOCh8lp1r0IRSoMA==', 'NMgT1l0pC2F8F2BQPgY39g==', '2000-12-29', 1, 1, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `credit_cards`
--
ALTER TABLE `credit_cards`
  ADD PRIMARY KEY (`cr_c_id`),
  ADD KEY `cr_c_id_user` (`cr_c_id_user`);

--
-- Indexes for table `credit_requests`
--
ALTER TABLE `credit_requests`
  ADD PRIMARY KEY (`c_r_id`),
  ADD KEY `id_user` (`cr_id_user`);

--
-- Indexes for table `e_carts`
--
ALTER TABLE `e_carts`
  ADD PRIMARY KEY (`e_id`),
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
-- AUTO_INCREMENT for table `credit_cards`
--
ALTER TABLE `credit_cards`
  MODIFY `cr_c_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `credit_requests`
--
ALTER TABLE `credit_requests`
  MODIFY `c_r_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `e_carts`
--
ALTER TABLE `e_carts`
  MODIFY `e_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `u_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `credit_cards`
--
ALTER TABLE `credit_cards`
  ADD CONSTRAINT `credit_cards_ibfk_1` FOREIGN KEY (`cr_c_id_user`) REFERENCES `users` (`u_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `credit_requests`
--
ALTER TABLE `credit_requests`
  ADD CONSTRAINT `credit_requests_ibfk_1` FOREIGN KEY (`cr_id_user`) REFERENCES `users` (`u_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `e_carts`
--
ALTER TABLE `e_carts`
  ADD CONSTRAINT `e_carts_ibfk_1` FOREIGN KEY (`ec_cartholder_id`) REFERENCES `users` (`u_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
