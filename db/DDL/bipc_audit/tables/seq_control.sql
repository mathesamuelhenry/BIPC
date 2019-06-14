USE bipc_audit;

CREATE TABLE seq_control
(
   obj_name   varchar(50) NOT NULL,
   next_id    int NOT NULL,
   PRIMARY KEY(obj_name)
);