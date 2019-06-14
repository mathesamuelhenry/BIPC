CREATE DATABASE bipc_audit;

USE bipc_audit;

# ********************************************************************************************************************************
# TABLE audit_contributor
# ********************************************************************************************************************************

DROP TABLE IF EXISTS bipc_audit.audit_contributor;

CREATE TABLE bipc_audit.audit_contributor (
  audit_record_id INT(11) NOT NULL,
  db_user VARCHAR(30) NOT NULL,
  end_user VARCHAR(30) NOT NULL,
  action_name VARCHAR(10) NOT NULL,
  action_timestamp DATETIME NOT NULL,
  client_ip_address VARCHAR(64) NOT NULL,
  contributor_id INT(11) NOT NULL,
  column_name VARCHAR(50) NOT NULL,
  old_value VARCHAR(255) NOT NULL,
  new_value VARCHAR(255) NOT NULL,
  PRIMARY KEY (audit_record_id)
 ,KEY ix_contributor_id (contributor_id)
 ,KEY ix_action_timestamp (action_timestamp));
 
# ********************************************************************************************************************************
# TABLE seq_control
# ********************************************************************************************************************************

CREATE TABLE seq_control
(
   obj_name   varchar(50) NOT NULL,
   next_id    int NOT NULL,
   PRIMARY KEY(obj_name)
);

REPLACE INTO seq_control VALUES ('audit_contributor', 1);
REPLACE INTO seq_control VALUES ('audit_account', 1);
REPLACE INTO seq_control VALUES ('audit_contribution', 1);
REPLACE INTO seq_control VALUES ('audit_table_column', 1);
REPLACE INTO seq_control VALUES ('audit_column_value_desc', 1);
REPLACE INTO seq_control VALUES ('audit_contributor_loan', 1);

# ********************************************************************************************************************************
# BIPC_AUDIT fn_get_nextid
# ********************************************************************************************************************************

DROP FUNCTION IF EXISTS fn_get_nextid;

CREATE FUNCTION `fn_get_nextid`(i_table_name VARCHAR(64))
   RETURNS int(11)
   READS SQL DATA DETERMINISTIC
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

# ********************************************************************************************************************************
# AUDIT STORED PROCEDURE - bipc.contributor_insert_audit
# ********************************************************************************************************************************
DELIMITER $$

DROP PROCEDURE IF EXISTS bipc_audit.sp_contributor_insert_audit;
$$

CREATE PROCEDURE bipc_audit.sp_contributor_insert_audit(
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
   END
$$

DELIMITER ;

# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER INSERT ON "bipc.contributor"
# ********************************************************************************************************************************
DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contributor_insert_audit_trigger
$$
CREATE TRIGGER bipc.contributor_insert_audit_trigger AFTER INSERT ON bipc.contributor
FOR EACH ROW
BEGIN


IF new.contributor_id IS NOT NULL THEN
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'insert', new.contributor_id, 'contributor_id', '', new.contributor_id);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'insert', new.contributor_id, 'first_name', '', new.first_name);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'insert', new.contributor_id, 'last_name', '', new.last_name);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'insert', new.contributor_id, 'family_name', '', new.family_name);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'insert', new.contributor_id, 'status', '', new.status);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'insert', new.contributor_id, 'date_added', '', new.date_added);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'insert', new.contributor_id, 'date_changed', '', new.date_changed);
END IF;

END 
$$

DELIMITER ;
# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER UPDATE ON "bipc.contributor"
# ********************************************************************************************************************************

DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contributor_update_audit_trigger
$$
CREATE TRIGGER bipc.contributor_update_audit_trigger AFTER UPDATE ON bipc.contributor
FOR EACH ROW
BEGIN


IF new.contributor_id IS NOT NULL THEN
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'update', new.contributor_id, 'contributor_id', old.contributor_id , new.contributor_id);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'update', new.contributor_id, 'first_name', old.first_name, new.first_name);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'update', new.contributor_id, 'last_name', old.last_name, new.last_name);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'update', new.contributor_id, 'family_name', old.family_name, new.family_name);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'update', new.contributor_id, 'status', old.status, new.status);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'update', new.contributor_id, 'date_added', old.date_added, new.date_added);
	CALL bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'update', new.contributor_id, 'date_changed', old.date_changed, new.date_changed);
END IF;

END 
$$

DELIMITER ;


# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER DELETE ON "bipc.contributor"
# ********************************************************************************************************************************
DELIMITER $$
DROP TRIGGER IF EXISTS bipc.contributor_delete_audit_trigger
$$
CREATE TRIGGER bipc.contributor_delete_audit_trigger AFTER DELETE ON bipc.contributor
FOR EACH ROW
BEGIN

IF old.contributor_id  IS NOT NULL THEN
	CALL  bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'delete', old.contributor_id , 'contributor_id', old.contributor_id, '');
	CALL  bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'delete', old.contributor_id , 'first_name', old.first_name, '');
	CALL  bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'delete', old.contributor_id , 'last_name', old.last_name, '');
	CALL  bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'delete', old.contributor_id , 'family_name', old.family_name, '');
	CALL  bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'delete', old.contributor_id , 'status', old.status, '');
	CALL  bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'delete', old.contributor_id , 'date_added', old.date_added, '');
	CALL  bipc_audit.sp_contributor_insert_audit('SamuelMathe', 'delete', old.contributor_id , 'date_changed', old.date_changed, '');
END IF;

END 
$$

DELIMITER ;