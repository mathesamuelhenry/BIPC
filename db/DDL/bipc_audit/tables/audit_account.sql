USE bipc_audit;

# ********************************************************************************************************************************
# TABLE audit_account
# ********************************************************************************************************************************

DROP TABLE IF EXISTS bipc_audit.audit_account;

CREATE TABLE bipc_audit.audit_account (
  audit_record_id INT(11) NOT NULL,
  db_user VARCHAR(30) NOT NULL,
  end_user VARCHAR(30) NOT NULL,
  action_name VARCHAR(10) NOT NULL,
  action_timestamp DATETIME NOT NULL,
  client_ip_address VARCHAR(64) NOT NULL,
  account_id INT(11) NOT NULL,
  column_name VARCHAR(50) NOT NULL,
  old_value VARCHAR(255) NOT NULL,
  new_value VARCHAR(255) NOT NULL,
  PRIMARY KEY (audit_record_id)
 ,KEY ix_account_id (account_id)
 ,KEY ix_action_timestamp (action_timestamp));
 
REPLACE INTO seq_control VALUES ('audit_account', 1);
