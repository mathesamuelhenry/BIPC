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