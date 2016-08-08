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

SELECT cvd.value, cvd.description
  FROM table_column tc
       JOIN column_value_desc cvd
          ON     tc.table_column_id = cvd.table_column_id
             AND tc.table_name = 'contribution'
             AND tc.column_name = 'category'
 WHERE tc.status = 1 AND cvd.status = 1;
 
 
 INSERT INTO contribution (
  contributor_id
  ,contribution_name
  ,category
  ,transaction_type
  ,transaction_mode
  ,amount
  ,check_number
  ,transaction_date
  ,status
  ,date_added
) VALUES (
  null   -- contributor_id - IN int(11)
  ,''  -- contribution_name - IN varchar(60)
  ,''  -- category - IN varchar(50)
  ,0   -- transaction_type - IN int(11)
  ,NULL -- transaction_mode - IN int(11)
  ,NULL -- amount - IN decimal(11,2)
  ,''  -- check_number - IN varchar(50)
  ,''  -- transaction_date - IN datetime
  ,0   -- status - IN tinyint(4)
  ,''  -- date_added - IN datetime
);


SELECT                           -- Concat(cr.last_name, ', ', cr.first_name),
      cn.contribution_name AS 'Contributor Name',
       cvd.description AS Category,
       cn.transaction_type AS Type,
       cn.transaction_mode AS Mode,
       cn.amount AS Amount,
       cn.check_number AS 'Check #',
       cn.transaction_date AS 'Transaction DT',
       cn.date_added AS 'Date Added'
  FROM contribution cn
       LEFT JOIN contributor cr ON cr.contributor_id = cn.contributor_id
       LEFT JOIN table_column tc
          ON     tc.table_name = 'contribution'
             AND tc.column_name = 'category'
             AND tc.status = 1
       LEFT JOIN column_value_desc cvd
          ON     cvd.table_column_id = tc.table_column_id
             AND cvd.value = cn.category
             AND cvd.status = 1
 WHERE cn.status = 1
ORDER BY cn.date.added DESC;