/*
seq_control load
*/

INSERT INTO seq_control VALUES ('contributor', 1);
INSERT INTO seq_control VALUES ('column_value_desc', 1);
INSERT INTO seq_control VALUES ('contribution', 1);
INSERT INTO seq_control VALUES ('table_column', 1);
INSERT INTO seq_control VALUES ('contributor_loan', 1);
INSERT INTO seq_control VALUES ('account', 1);
INSERT INTO seq_control VALUES ('organization', 1);
INSERT INTO seq_control VALUES ('users', 1);
INSERT INTO seq_control VALUES ('user_organization', 1);
INSERT INTO seq_control VALUES ('kvp', 1);
INSERT INTO seq_control VALUES ('security_question', 1);
INSERT INTO seq_control VALUES ('user_security_question', 1);
INSERT INTO seq_control VALUES ('role', 1);
INSERT INTO seq_control VALUES ('user_role', 1);

insert into table_column (
  table_column_id
  ,table_name
  ,column_name
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'table_column')
  ,'contribution' -- table_name - IN varchar(50)
  ,'category' -- column_name - IN varchar(50)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'category')
  ,'1' -- value - IN varchar(50)
  ,'Sunday School' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'category')
  ,'2' -- value - IN varchar(50)
  ,'Visiting Pastor' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'category')
  ,'3' -- value - IN varchar(50)
  ,'Church Rent' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);


insert into table_column (
  table_column_id
  ,table_name
  ,column_name
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'table_column')
  ,'contribution' -- table_name - IN varchar(50)
  ,'transaction_type' -- column_name - IN varchar(50)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'transaction_type')
  ,'1' -- value - IN varchar(50)
  ,'Credit' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'transaction_type')
  ,'2' -- value - IN varchar(50)
  ,'Debit' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into table_column (
  table_column_id
  ,table_name
  ,column_name
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'table_column')
  ,'contribution' -- table_name - IN varchar(50)
  ,'transaction_mode' -- column_name - IN varchar(50)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'transaction_mode')
  ,'1' -- value - IN varchar(50)
  ,'Cash' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'transaction_mode')
  ,'2' -- value - IN varchar(50)
  ,'Check' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'transaction_mode')
  ,'3' -- value - IN varchar(50)
  ,'Online' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  column_value_desc_id
  ,table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'column_value_desc')
  ,(select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'transaction_mode')
  ,'4' -- value - IN varchar(50)
  ,'Card' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into table_column (
  table_column_id
  ,table_name
  ,column_name
  ,status
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'table_column')
  ,'TEMP' -- table_name - IN varchar(50)
  ,'opening_balance' -- column_name - IN varchar(50)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

INSERT INTO kvp (
   kvp_id
  ,kvp_name
  ,kvp_key
  ,kvp_value
  ,user_added
  ,date_added
) VALUES (
   fn_get_nextid('kvp') -- kvp_id - IN int(11)
  ,'user_status' -- kvp_name - IN varchar(50)
  ,'A' -- kvp_key - IN varchar(50)
  ,'Active' -- kvp_value - IN varchar(100)
  ,'msamuehenry@gmail.com' -- user_added - IN varchar(255)
  ,now() -- date_added - IN datetime
);

INSERT INTO kvp (
   kvp_id
  ,kvp_name
  ,kvp_key
  ,kvp_value
  ,user_added
  ,date_added
) VALUES (
   fn_get_nextid('kvp') -- kvp_id - IN int(11)
  ,'user_status' -- kvp_name - IN varchar(50)
  ,'I' -- kvp_key - IN varchar(50)
  ,'Inactive' -- kvp_value - IN varchar(100)
  ,'msamuehenry@gmail.com' -- user_added - IN varchar(255)
  ,now() -- date_added - IN datetime
);

INSERT INTO kvp (
   kvp_id
  ,kvp_name
  ,kvp_key
  ,kvp_value
  ,user_added
  ,date_added
) VALUES (
   fn_get_nextid('kvp') -- kvp_id - IN int(11)
  ,'user_status' -- kvp_name - IN varchar(50)
  ,'P' -- kvp_key - IN varchar(50)
  ,'Pending' -- kvp_value - IN varchar(100)
  ,'msamuehenry@gmail.com' -- user_added - IN varchar(255)
  ,now() -- date_added - IN datetime
);

INSERT INTO role (
   role_id
  ,role_name
  ,user_added
  ,date_added
) VALUES (
   fn_get_nextid('role') -- role_id - IN int(11)
  ,'SystemAdmin' -- role_name - IN varchar(40)
  ,'msamuelhenry' -- user_added - IN varchar(255)
  ,now() -- date_added - IN datetime
);

INSERT INTO role (
   role_id
  ,role_name
  ,user_added
  ,date_added
) VALUES (
   fn_get_nextid('role') -- role_id - IN int(11)
  ,'OrgAdmin' -- role_name - IN varchar(40)
  ,'msamuelhenry' -- user_added - IN varchar(255)
  ,now() -- date_added - IN datetime
);

INSERT INTO role (
   role_id
  ,role_name
  ,user_added
  ,date_added
) VALUES (
   fn_get_nextid('role') -- role_id - IN int(11)
  ,'OrgUser' -- role_name - IN varchar(40)
  ,'msamuelhenry' -- user_added - IN varchar(255)
  ,now() -- date_added - IN datetime
);

INSERT INTO security_question (
   security_question_id
  ,question
  ,date_added
) VALUES (
   fn_get_nextid('security_question') -- security_question_id - IN int(11)
  ,'What was the make of your first car?' -- question - IN varchar(255)
  ,now() -- date_added - IN datetime
);

INSERT INTO security_question (
   security_question_id
  ,question
  ,date_added
) VALUES (
   fn_get_nextid('security_question') -- security_question_id - IN int(11)
  ,'What is your favorite team?' -- question - IN varchar(255)
  ,now() -- date_added - IN datetime
);