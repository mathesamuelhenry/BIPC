use bipc_audit;

CREATE TABLE `audit_contributor` (
  `audit_record_id` int(11) NOT NULL,
  `db_user` varchar(30) NOT NULL,
  `end_user` varchar(30) NOT NULL,
  `action_name` varchar(10) NOT NULL,
  `action_timestamp` datetime NOT NULL,
  `client_ip_address` varchar(64) NOT NULL,
  `contributor_id` int(11) NOT NULL,
  `column_name` varchar(50) NOT NULL,
  `old_value` varchar(255) NOT NULL,
  `new_value` varchar(255) NOT NULL,
  PRIMARY KEY (`audit_record_id`),
  KEY `ix_contributor_id` (`contributor_id`),
  KEY `ix_action_timestamp` (`action_timestamp`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;