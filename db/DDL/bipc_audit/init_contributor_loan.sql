USE bipc_audit;

# ********************************************************************************************************************************
# TABLE audit_contributor_loan
# ********************************************************************************************************************************

DROP TABLE IF EXISTS bipc_audit.audit_contributor_loan;

CREATE TABLE bipc_audit.audit_contributor_loan (
  audit_record_id INT(11) NOT NULL,
  db_user VARCHAR(30) NOT NULL,
  end_user VARCHAR(30) NOT NULL,
  action_name VARCHAR(10) NOT NULL,
  action_timestamp DATETIME NOT NULL,
  client_ip_address VARCHAR(64) NOT NULL,
  contributor_loan_id INT(11) NOT NULL,
  column_name VARCHAR(50) NOT NULL,
  old_value VARCHAR(255) NOT NULL,
  new_value VARCHAR(255) NOT NULL,
  PRIMARY KEY (audit_record_id)
 ,KEY ix_contributor_loan_id (contributor_loan_id)
 ,KEY ix_action_timestamp (action_timestamp));
 
REPLACE INTO seq_control VALUES ('audit_contributor_loan', 1);

# ********************************************************************************************************************************
# AUDIT STORED PROCEDURE - bipc.contributor_loan_insert_audit
# ********************************************************************************************************************************
DELIMITER $$

DROP PROCEDURE IF EXISTS bipc_audit.sp_contributor_loan_insert_audit;
$$

CREATE PROCEDURE bipc_audit.sp_contributor_loan_insert_audit(
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
   END
$$

DELIMITER ;

# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER INSERT ON "bipc.contributor_loan"
# ********************************************************************************************************************************
DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contributor_loan_insert_audit_trigger
$$
CREATE TRIGGER bipc.contributor_loan_insert_audit_trigger AFTER INSERT ON bipc.contributor_loan
FOR EACH ROW
BEGIN


IF new.contributor_loan_id IS NOT NULL THEN
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'insert', new.contributor_loan_id, 'contributor_loan_id', '', new.contributor_loan_id);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'insert', new.contributor_loan_id, 'contributor_id', '', new.contributor_id);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'insert', new.contributor_loan_id, 'loan_amount', '', new.loan_amount);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'insert', new.contributor_loan_id, 'status', '', new.status);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'insert', new.contributor_loan_id, 'date_added', '', new.date_added);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'insert', new.contributor_loan_id, 'date_changed', '', new.date_changed);
END IF;

END 
$$

DELIMITER ;
# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER UPDATE ON "bipc.contributor_loan"
# ********************************************************************************************************************************

DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contributor_loan_update_audit_trigger
$$
CREATE TRIGGER bipc.contributor_loan_update_audit_trigger AFTER UPDATE ON bipc.contributor_loan
FOR EACH ROW
BEGIN


IF new.contributor_loan_id IS NOT NULL THEN
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'update', new.contributor_loan_id, 'contributor_loan_id', old.contributor_loan_id , new.contributor_loan_id);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'update', new.contributor_loan_id, 'contributor_id', old.contributor_id, new.contributor_id);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'update', new.contributor_loan_id, 'loan_amount', old.loan_amount, new.loan_amount);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'update', new.contributor_loan_id, 'status', old.status, new.status);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'update', new.contributor_loan_id, 'date_added', old.date_added, new.date_added);
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'update', new.contributor_loan_id, 'date_changed', old.date_changed, new.date_changed);
END IF;

END 
$$

DELIMITER ;


# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER DELETE ON "bipc.contributor_loan"
# ********************************************************************************************************************************
DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contributor_loan_delete_audit_trigger
$$
CREATE TRIGGER bipc.contributor_loan_delete_audit_trigger AFTER DELETE ON bipc.contributor_loan
FOR EACH ROW
BEGIN

IF old.contributor_loan_id  IS NOT NULL THEN
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'delete', old.contributor_loan_id, 'contributor_loan_id', old.contributor_loan_id, '');
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'delete', old.contributor_loan_id, 'contributor_id', old.contributor_id, '');
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'delete', old.contributor_loan_id, 'loan_amount', old.loan_amount, '');
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'delete', old.contributor_loan_id, 'status', old.status, '');
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'delete', old.contributor_loan_id, 'date_added', old.date_added, '');
	CALL bipc_audit.sp_contributor_loan_insert_audit('SamuelMathe', 'delete', old.contributor_loan_id, 'date_changed', old.date_changed, '');
END IF;

END 
$$

DELIMITER ;