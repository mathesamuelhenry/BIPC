# ********************************************************************************************************************************
# AUDIT STORED PROCEDURE - bipc.account_insert_audit
# ********************************************************************************************************************************
DELIMITER $$

DROP PROCEDURE IF EXISTS bipc_audit.sp_account_insert_audit;
$$

CREATE PROCEDURE bipc_audit.sp_account_insert_audit(
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
   END
$$

DELIMITER ;
