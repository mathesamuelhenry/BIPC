USE bipc_audit;

# ********************************************************************************************************************************
# TABLE audit_contribution
# ********************************************************************************************************************************

DROP TABLE IF EXISTS bipc_audit.audit_contribution;

CREATE TABLE bipc_audit.audit_contribution (
  audit_record_id INT(11) NOT NULL,
  db_user VARCHAR(30) NOT NULL,
  end_user VARCHAR(30) NOT NULL,
  action_name VARCHAR(10) NOT NULL,
  action_timestamp DATETIME NOT NULL,
  client_ip_address VARCHAR(64) NOT NULL,
  contribution_id INT(11) NOT NULL,
  column_name VARCHAR(50) NOT NULL,
  old_value text NOT NULL,
  new_value text NOT NULL,
  PRIMARY KEY (audit_record_id)
 ,KEY ix_contribution_id (contribution_id)
 ,KEY ix_action_timestamp (action_timestamp));
 
REPLACE INTO seq_control VALUES ('audit_contribution', 1);