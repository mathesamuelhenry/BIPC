insert into organization (
   organization_id
  ,name
  ,website
  ,industry
  ,address_line_1
  ,address_line_2
  ,address_line_3
  ,city
  ,state
  ,zip
  ,zip4
  ,email
  ,phone
  ,user_added
  ,date_added
) VALUES (
   fn_get_nextid('organization') -- organization_id - IN bigint(20)
  ,'Bethel India Pentecostal church' -- name - IN varchar(50)
  ,'www.bipcpalmbeach.com'  -- website - IN varchar(50)
  ,'Non Profit' -- industry - IN varchar(50)
  ,'1415 N K St' -- address_line_1 - IN varchar(60)
  ,NULL  -- address_line_2 - IN varchar(60)
  ,NULL  -- address_line_3 - IN varchar(60)
  ,'Lake Worth' -- city - IN varchar(35)
  ,'FL'  -- state - IN varchar(3)
  ,'33460' -- zip - IN varchar(10)
  ,NULL  -- zip4 - IN varchar(4)
  ,'msamuelhenry@gmail.com'  -- email - IN varchar(50)
  ,'5076195340'  -- phone - IN varchar(15)
  ,'Samuel' -- user_added - IN varchar(30)
  ,now() -- date_added - IN datetime
);