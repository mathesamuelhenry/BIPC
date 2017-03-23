DROP FUNCTION IF EXISTS fn_get_nextid;
CREATE FUNCTION `fn_get_nextid`(i_db_name VARCHAR(30),i_table_name VARCHAR(64)) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
    SET @curr_isolation=@@tx_isolation;
    SET session tx_isolation="READ-COMMITTED"; 
    UPDATE seq_control SET next_id = LAST_INSERT_ID(next_id + 1) WHERE obj_name = i_table_name;
    SET @next_id= LAST_INSERT_ID() * 10 + 1;   
    SET session tx_isolation= @curr_isolation;   
    RETURN @next_id;
END;