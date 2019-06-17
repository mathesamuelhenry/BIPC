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