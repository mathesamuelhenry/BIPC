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

# ********************************************************************************************************************************
# AUDIT STORED PROCEDURE - bipc.contribution_insert_audit
# ********************************************************************************************************************************
DELIMITER $$

DROP PROCEDURE IF EXISTS bipc_audit.sp_contribution_insert_audit;
$$

CREATE PROCEDURE bipc_audit.sp_contribution_insert_audit(
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
   END
$$

DELIMITER ;

# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER INSERT ON "bipc.contribution"
# ********************************************************************************************************************************
DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contribution_insert_audit_trigger
$$
CREATE TRIGGER bipc.contribution_insert_audit_trigger AFTER INSERT ON bipc.contribution
FOR EACH ROW
BEGIN


IF new.contribution_id IS NOT NULL THEN
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'contribution_id', '', new.contribution_id);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'account_id', '', new.account_id);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'contributor_id', '', new.contributor_id);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'contribution_name', '', new.contribution_name);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'category', '', new.category);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'transaction_type', '', new.transaction_type);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'transaction_mode', '', new.transaction_mode);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'amount', '', new.amount);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'check_number', '', new.check_number);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'transaction_date', '', new.transaction_date);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'note', '', new.note);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'status', '', new.status);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'date_added', '', new.date_added);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'insert', new.contribution_id, 'date_changed', '', new.date_changed);
END IF;

END 
$$

DELIMITER ;
# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER UPDATE ON "bipc.contribution"
# ********************************************************************************************************************************

DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contribution_update_audit_trigger
$$
CREATE TRIGGER bipc.contribution_update_audit_trigger AFTER UPDATE ON bipc.contribution
FOR EACH ROW
BEGIN


IF new.contribution_id IS NOT NULL THEN
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'contribution_id', old.contribution_id , new.contribution_id);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'account_id', old.account_id, new.account_id);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'contributor_id', old.contributor_id, new.contributor_id);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'contribution_name', old.contribution_name, new.contribution_name);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'category', old.category, new.category);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'transaction_type', old.transaction_type, new.transaction_type);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'transaction_mode', old.transaction_mode, new.transaction_mode);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'amount', old.amount, new.amount);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'check_number', old.check_number, new.check_number);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'transaction_date', old.transaction_date, new.transaction_date);
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'note', old.note, new.note);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'status', old.status, new.status);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'date_added', old.date_added, new.date_added);
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'update', new.contribution_id, 'date_changed', old.date_changed, new.date_changed);
END IF;

END 
$$

DELIMITER ;


# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER DELETE ON "bipc.contribution"
# ********************************************************************************************************************************
DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contribution_delete_audit_trigger
$$
CREATE TRIGGER bipc.contribution_delete_audit_trigger AFTER DELETE ON bipc.contribution
FOR EACH ROW
BEGIN

IF old.contribution_id IS NOT NULL THEN  
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'contribution_id', old.contribution_id , '');
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'account_id', old.account_id, '');
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'contributor_id', old.contributor_id, '');
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'contribution_name', old.contribution_name, '');
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'category', old.category, '');
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'transaction_type', old.transaction_type, '');
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'transaction_mode', old.transaction_mode, '');
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'amount', old.amount, '');
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'check_number', old.check_number, '');
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'transaction_date', old.transaction_date, '');
  CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'note', old.note, '');
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'status', old.status, '');
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'date_added', old.date_added, '');
	CALL bipc_audit.sp_contribution_insert_audit('SamuelMathe', 'delete', old.contribution_id, 'date_changed', old.date_changed, '');
END IF;

END 
$$

DELIMITER ;