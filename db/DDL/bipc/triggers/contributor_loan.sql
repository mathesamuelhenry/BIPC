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