CREATE TABLE `account` (
  `account_id` int(11) NOT NULL,
  `account_number` varchar(50) DEFAULT NULL,
  `account_name` varchar(100) DEFAULT NULL,
  `bank_name` varchar(50) DEFAULT NULL,
  `account_end_date` datetime DEFAULT NULL,
  `initial_balance` decimal(11,2) NOT NULL,
  `status` tinyint(4) DEFAULT '1',
  `date_added` datetime DEFAULT NULL,
  `date_changed` datetime DEFAULT NULL,
  PRIMARY KEY (`account_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `table_column` (
  `table_column_id` int(11) NOT NULL,
  `table_name` varchar(50) NOT NULL,
  `column_name` varchar(50) NOT NULL,
  `status` tinyint(4) DEFAULT '1',
  `date_added` datetime DEFAULT NULL,
  `date_changed` datetime DEFAULT NULL,
  PRIMARY KEY (`table_column_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `column_value_desc` (
  `column_value_desc_id` int(11) NOT NULL,
  `table_column_id` int(11) NOT NULL,
  `value` varchar(50) NOT NULL,
  `description` varchar(500) NOT NULL,
  `status` tinyint(4) DEFAULT '1',
  `date_added` datetime DEFAULT NULL,
  `date_changed` datetime DEFAULT NULL,
  PRIMARY KEY (`column_value_desc_id`),
  KEY `column_value_desc_ibfk_1` (`table_column_id`),
  CONSTRAINT `column_value_desc_ibfk_1` FOREIGN KEY (`table_column_id`) REFERENCES `table_column` (`table_column_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `contributor_loan` (
  `contributor_loan_id` int(11) NOT NULL,
  `contributor_id` int(11) NOT NULL,
  `loan_amount` decimal(11,2) NOT NULL,
  `status` tinyint(4) DEFAULT '1',
  `date_added` datetime DEFAULT NULL,
  `date_changed` datetime DEFAULT NULL,
  PRIMARY KEY (`contributor_loan_id`),
  KEY `contributor_id` (`contributor_id`),
  CONSTRAINT `contributor_loan_ibfk_1` FOREIGN KEY (`contributor_id`) REFERENCES `contributor` (`contributor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `contributor` (
  `contributor_id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `family_name` varchar(50) DEFAULT NULL,
  `status` tinyint(4) DEFAULT '1',
  `date_added` datetime DEFAULT NULL,
  `date_changed` datetime DEFAULT NULL,
  PRIMARY KEY (`contributor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `contribution` (
  `contribution_id` int(11) NOT NULL,
  `account_id` int(11) NOT NULL,
  `contributor_id` int(11) DEFAULT NULL,
  `contribution_name` varchar(60) DEFAULT NULL,
  `category` varchar(50) DEFAULT NULL,
  `transaction_type` int(11) DEFAULT '1' COMMENT '1 - credit, 2 - debit',
  `transaction_mode` int(11) NOT NULL COMMENT 'CASH/CHECK',
  `amount` decimal(11,2) NOT NULL,
  `check_number` varchar(50) DEFAULT NULL,
  `transaction_date` datetime DEFAULT NULL,
  `note` text,
  `status` tinyint(4) DEFAULT '1',
  `date_added` datetime DEFAULT NULL,
  `date_changed` datetime DEFAULT NULL,
  PRIMARY KEY (`contribution_id`),
  KEY `contribution_ibfk_1` (`contributor_id`),
  KEY `account_id` (`account_id`),
  CONSTRAINT `contribution_ibfk_1` FOREIGN KEY (`contributor_id`) REFERENCES `contributor` (`contributor_id`),
  CONSTRAINT `contribution_ibfk_2` FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `contributor_loan` (
  `contributor_loan_id` int(11) NOT NULL,
  `contributor_id` int(11) NOT NULL,
  `loan_amount` decimal(11,2) NOT NULL,
  `status` tinyint(4) DEFAULT '1',
  `date_added` datetime DEFAULT NULL,
  `date_changed` datetime DEFAULT NULL,
  PRIMARY KEY (`contributor_loan_id`),
  KEY `contributor_id` (`contributor_id`),
  CONSTRAINT `contributor_loan_ibfk_1` FOREIGN KEY (`contributor_id`) REFERENCES `contributor` (`contributor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `seq_control` (
  `obj_name` varchar(50) NOT NULL,
  `next_id` int(11) NOT NULL,
  PRIMARY KEY (`obj_name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;












