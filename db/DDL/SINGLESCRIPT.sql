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
  CONSTRAINT `column_value_desc_ibfk_1` FOREIGN KEY (`table_column_id`) REFERENCES `table_column` (`table_column_id`)
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

DROP FUNCTION IF EXISTS bipc.fn_get_nextid;
CREATE FUNCTION bipc.`fn_get_nextid`(i_table_name VARCHAR(64)) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
    SET @curr_isolation=@@tx_isolation;
    SET session tx_isolation="READ-COMMITTED"; 
    UPDATE seq_control SET next_id = LAST_INSERT_ID(next_id + 1) WHERE obj_name = i_table_name;
    SET @next_id= LAST_INSERT_ID() * 1 + 1;   
    SET session tx_isolation= @curr_isolation;   
    RETURN @next_id;
END;



CREATE DATABASE bipc_audit;

use bipc_audit;

CREATE TABLE `audit_account` (
  `audit_record_id` int(11) NOT NULL,
  `db_user` varchar(30) NOT NULL,
  `end_user` varchar(30) NOT NULL,
  `action_name` varchar(10) NOT NULL,
  `action_timestamp` datetime NOT NULL,
  `client_ip_address` varchar(64) NOT NULL,
  `account_id` int(11) NOT NULL,
  `column_name` varchar(50) NOT NULL,
  `old_value` varchar(255) NOT NULL,
  `new_value` varchar(255) NOT NULL,
  PRIMARY KEY (`audit_record_id`),
  KEY `ix_account_id` (`account_id`),
  KEY `ix_action_timestamp` (`action_timestamp`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `audit_contribution` (
  `audit_record_id` int(11) NOT NULL,
  `db_user` varchar(30) NOT NULL,
  `end_user` varchar(30) NOT NULL,
  `action_name` varchar(10) NOT NULL,
  `action_timestamp` datetime NOT NULL,
  `client_ip_address` varchar(64) NOT NULL,
  `contribution_id` int(11) NOT NULL,
  `column_name` varchar(50) NOT NULL,
  `old_value` text NOT NULL,
  `new_value` text NOT NULL,
  PRIMARY KEY (`audit_record_id`),
  KEY `ix_contribution_id` (`contribution_id`),
  KEY `ix_action_timestamp` (`action_timestamp`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

CREATE TABLE `audit_contributor_loan` (
  `audit_record_id` int(11) NOT NULL,
  `db_user` varchar(30) NOT NULL,
  `end_user` varchar(30) NOT NULL,
  `action_name` varchar(10) NOT NULL,
  `action_timestamp` datetime NOT NULL,
  `client_ip_address` varchar(64) NOT NULL,
  `contributor_loan_id` int(11) NOT NULL,
  `column_name` varchar(50) NOT NULL,
  `old_value` varchar(255) NOT NULL,
  `new_value` varchar(255) NOT NULL,
  PRIMARY KEY (`audit_record_id`),
  KEY `ix_contributor_loan_id` (`contributor_loan_id`),
  KEY `ix_action_timestamp` (`action_timestamp`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `seq_control` (
  `obj_name` varchar(50) NOT NULL,
  `next_id` int(11) NOT NULL,
  PRIMARY KEY (`obj_name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

DROP FUNCTION IF EXISTS bipc_audit.fn_get_nextid;
CREATE FUNCTION bipc_audit.`fn_get_nextid`(i_table_name VARCHAR(64)) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
      SET @curr_isolation = @@tx_isolation;
      SET SESSION tx_isolation = "READ-COMMITTED";
      
      UPDATE seq_control
         SET next_id = next_id + 1
       WHERE obj_name = i_table_name;

      SELECT next_id
        INTO @next_id
        FROM seq_control
       WHERE obj_name = i_table_name;

      SET SESSION tx_isolation = @curr_isolation;
      RETURN @next_id;
   END;
   
   
DROP PROCEDURE IF EXISTS bipc_audit.sp_account_insert_audit;
CREATE PROCEDURE bipc_audit.`sp_account_insert_audit`(
   end_user          VARCHAR(30),
   action_name       VARCHAR(7),
   account_id    INT,
   column_name       VARCHAR(50),
   old_value         VARCHAR(255),
   new_value         VARCHAR(255))
BEGIN
      DECLARE v_client_ip   VARCHAR(64);

      SELECT SUBSTRING_INDEX(USER(), '@', -1)
        INTO v_client_ip;

      IF    action_name <> 'update'
         OR old_value <> new_value
         OR (old_value IS NULL AND new_value IS NOT NULL)
      THEN
         INSERT INTO bipc_audit.audit_account(audit_record_id,
                                                  db_user,
                                                  end_user,
                                                  action_name,
                                                  action_timestamp,
                                                  client_ip_address,
                                                  account_id,
                                                  column_name,
                                                  old_value,
                                                  new_value)
         VALUES (bipc_audit.fn_get_nextid('audit_account'),
                 SUBSTRING_INDEX(USER(), '@', 1),
                 IF(end_user IS NULL, '', end_user),
                 action_name,
                 NOW(),
                 v_client_ip,
                 account_id,
                 column_name,
                 CAST(IF(old_value IS NULL, '', old_value) AS CHAR),
                 CAST(IF(new_value IS NULL, '', new_value) AS CHAR));
      END IF;
   END;

DROP PROCEDURE IF EXISTS bipc_audit.sp_contribution_insert_audit;
CREATE PROCEDURE bipc_audit.`sp_contribution_insert_audit`(
   end_user          VARCHAR(30),
   action_name       VARCHAR(7),
   contribution_id    INT,
   column_name       VARCHAR(50),
   old_value         VARCHAR(255),
   new_value         VARCHAR(255))
BEGIN
      DECLARE v_client_ip   VARCHAR(64);

      SELECT SUBSTRING_INDEX(USER(), '@', -1)
        INTO v_client_ip;

      IF    action_name <> 'update'
         OR old_value <> new_value
         OR (old_value IS NULL AND new_value IS NOT NULL)
      THEN
         INSERT INTO bipc_audit.audit_contribution(audit_record_id,
                                                  db_user,
                                                  end_user,
                                                  action_name,
                                                  action_timestamp,
                                                  client_ip_address,
                                                  contribution_id,
                                                  column_name,
                                                  old_value,
                                                  new_value)
         VALUES (bipc_audit.fn_get_nextid('audit_contribution'),
                 SUBSTRING_INDEX(USER(), '@', 1),
                 IF(end_user IS NULL, '', end_user),
                 action_name,
                 NOW(),
                 v_client_ip,
                 contribution_id,
                 column_name,
                 CAST(IF(old_value IS NULL, '', old_value) AS CHAR),
                 CAST(IF(new_value IS NULL, '', new_value) AS CHAR));
      END IF;
   END;

DROP PROCEDURE IF EXISTS bipc_audit.sp_contributor_insert_audit;
CREATE PROCEDURE bipc_audit.`sp_contributor_insert_audit`(
   end_user          VARCHAR(30),
   action_name       VARCHAR(7),
   contributor_id    INT,
   column_name       VARCHAR(50),
   old_value         VARCHAR(255),
   new_value         VARCHAR(255))
BEGIN
      DECLARE v_client_ip   VARCHAR(64);

      SELECT SUBSTRING_INDEX(USER(), '@', -1)
        INTO v_client_ip;

      IF    action_name <> 'update'
         OR old_value <> new_value
         OR (old_value IS NULL AND new_value IS NOT NULL)
      THEN
         INSERT INTO bipc_audit.audit_contributor(audit_record_id,
                                                  db_user,
                                                  end_user,
                                                  action_name,
                                                  action_timestamp,
                                                  client_ip_address,
                                                  contributor_id,
                                                  column_name,
                                                  old_value,
                                                  new_value)
         VALUES (bipc_audit.fn_get_nextid('audit_contributor'),
                 SUBSTRING_INDEX(USER(), '@', 1),
                 IF(end_user IS NULL, '', end_user),
                 action_name,
                 NOW(),
                 v_client_ip,
                 contributor_id,
                 column_name,
                 CAST(IF(old_value IS NULL, '', old_value) AS CHAR),
                 CAST(IF(new_value IS NULL, '', new_value) AS CHAR));
      END IF;
   END;

DROP PROCEDURE IF EXISTS bipc_audit.sp_contributor_loan_insert_audit;
CREATE PROCEDURE bipc_audit.`sp_contributor_loan_insert_audit`(
   end_user          VARCHAR(30),
   action_name       VARCHAR(7),
   contributor_loan_id    INT,
   column_name       VARCHAR(50),
   old_value         VARCHAR(255),
   new_value         VARCHAR(255))
BEGIN
      DECLARE v_client_ip   VARCHAR(64);

      SELECT SUBSTRING_INDEX(USER(), '@', -1)
        INTO v_client_ip;

      IF    action_name <> 'update'
         OR old_value <> new_value
         OR (old_value IS NULL AND new_value IS NOT NULL)
      THEN
         INSERT INTO bipc_audit.audit_contributor_loan(audit_record_id,
                                                  db_user,
                                                  end_user,
                                                  action_name,
                                                  action_timestamp,
                                                  client_ip_address,
                                                  contributor_loan_id,
                                                  column_name,
                                                  old_value,
                                                  new_value)
         VALUES (bipc_audit.fn_get_nextid('audit_contributor_loan'),
                 SUBSTRING_INDEX(USER(), '@', 1),
                 IF(end_user IS NULL, '', end_user),
                 action_name,
                 NOW(),
                 v_client_ip,
                 contributor_loan_id,
                 column_name,
                 CAST(IF(old_value IS NULL, '', old_value) AS CHAR),
                 CAST(IF(new_value IS NULL, '', new_value) AS CHAR));
      END IF;
   END;
