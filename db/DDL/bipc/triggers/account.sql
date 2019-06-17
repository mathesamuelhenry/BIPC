# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER INSERT ON "bipc.account"
# ********************************************************************************************************************************
DELIMITER $$
DROP TRIGGER IF EXISTS bipc.account_insert_audit_trigger
$$
CREATE TRIGGER bipc.account_insert_audit_trigger AFTER INSERT ON bipc.account
FOR EACH ROW
BEGIN


IF new.account_id IS NOT NULL THEN
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'account_id', '', new.account_id);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'account_number', '', new.account_number);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'account_name', '', new.account_name);
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'bank_name', '', new.bank_name);
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'account_end_date', '', new.account_end_date);
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'initial_balance', '', new.initial_balance);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'status', '', new.status);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'date_added', '', new.date_added);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'insert', new.account_id, 'date_changed', '', new.date_changed);
END IF;

END 
$$

DELIMITER ;
# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER UPDATE ON "bipc.account"
# ********************************************************************************************************************************

DELIMITER $$
DROP TRIGGER IF EXISTS bipc.account_update_audit_trigger
$$
CREATE TRIGGER bipc.account_update_audit_trigger AFTER UPDATE ON bipc.account
FOR EACH ROW
BEGIN


IF new.account_id IS NOT NULL THEN
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'account_id', old.account_id , new.account_id);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'account_number', old.account_number, new.account_number);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'account_name', old.account_name, new.account_name);
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'bank_name', old.bank_name, new.bank_name);
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'account_end_date', old.account_end_date, new.account_end_date);
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'initial_balance', old.initial_balance, new.initial_balance);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'status', old.status, new.status);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'date_added', old.date_added, new.date_added);
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'update', new.account_id, 'date_changed', old.date_changed, new.date_changed);
END IF;

END 
$$

DELIMITER ;


# ********************************************************************************************************************************
# AUDIT TRIGGER - AFTER DELETE ON "bipc.account"
# ********************************************************************************************************************************
DELIMITER $$
DROP TRIGGER IF EXISTS bipc.account_delete_audit_trigger
$$
CREATE TRIGGER bipc.account_delete_audit_trigger AFTER DELETE ON bipc.account
FOR EACH ROW
BEGIN

IF old.account_id  IS NOT NULL THEN
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'account_id', old.account_id , '');
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'account_number', old.account_number, '');
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'account_name', old.account_name, '');
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'bank_name', old.bank_name, '');
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'account_end_date', old.account_end_date, '');
  CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'initial_balance', old.initial_balance, '');
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'status', old.status, '');
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'date_added', old.date_added, '');
	CALL bipc_audit.sp_account_insert_audit('SamuelMathe', 'delete', old.account_id, 'date_changed', old.date_changed, '');
END IF;

END 
$$

DELIMITER ;