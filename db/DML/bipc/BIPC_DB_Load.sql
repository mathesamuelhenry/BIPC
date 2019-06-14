/*
seq_control load
*/

INSERT INTO seq_control VALUES ('contributor', 1);
INSERT INTO seq_control VALUES ('column_value_desc', 1);
INSERT INTO seq_control VALUES ('contribution', 1);
INSERT INTO seq_control VALUES ('table_column', 1);
INSERT INTO seq_control VALUES ('contributor_loan', 1);
INSERT INTO seq_control VALUES ('account', 1);

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

