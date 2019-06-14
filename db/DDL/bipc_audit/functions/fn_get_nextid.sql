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