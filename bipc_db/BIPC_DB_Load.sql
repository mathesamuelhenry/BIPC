insert into table_column (
  table_name
  ,column_name
  ,status
  ,date_added
) VALUES (
  'contribution' -- table_name - IN varchar(50)
  ,'category' -- column_name - IN varchar(50)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  (select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'category')
  ,'1' -- value - IN varchar(50)
  ,'Sunday School' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  (select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'category')
  ,'2' -- value - IN varchar(50)
  ,'Visiting Pastor' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  (select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'category')
  ,'3' -- value - IN varchar(50)
  ,'Church Rent' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);


insert into table_column (
  table_name
  ,column_name
  ,status
  ,date_added
) VALUES (
  'contribution' -- table_name - IN varchar(50)
  ,'transaction_type' -- column_name - IN varchar(50)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  (select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'transaction_type')
  ,'1' -- value - IN varchar(50)
  ,'Credit' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);

insert into column_value_desc (
  table_column_id
  ,value
  ,description
  ,status
  ,date_added
) VALUES (
  (select table_column_id from table_column where status = 1 and table_name = 'contribution' and column_name = 'transaction_type')
  ,'2' -- value - IN varchar(50)
  ,'Debit' -- description - IN varchar(500)
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
);