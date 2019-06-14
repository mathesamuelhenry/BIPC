SET @year = '2017';

SELECT CASE
          WHEN IFNULL(ct.first_name, '') = '' THEN cn.contribution_name
          ELSE CONCAT(ct.first_name, ' ', ct.last_name)
       END
          AS 'Contributor Name / Type',
       cvd_category.description AS 'Category',
       cvd_trans_type.description AS 'Transaction Type',
       cvd_trans_mode.description AS 'Transaction Mode',
       cn.amount as 'Amount',
       cn.check_number as 'Check #',
       DATE_FORMAT(cn.transaction_date, '%m/%e/%Y') as 'Transaction Date',
       cn.note as 'Note',
       DATE_FORMAT(cn.transaction_date, '%Y') AS 'Transaction Year'
  FROM bipc.contribution cn
       LEFT JOIN contributor ct
          ON cn.contributor_id = ct.contributor_id AND ct.status = 1
       LEFT JOIN table_column t_category
          ON     t_category.table_name = 'Contribution'
             AND t_category.column_name = 'category'
       LEFT JOIN column_value_desc cvd_category
          ON     cvd_category.table_column_id = t_category.table_column_id
             AND cvd_category.value = cn.category
             AND cvd_category.status = 1
       LEFT JOIN table_column t_trans_type
          ON     t_trans_type.table_name = 'Contribution'
             AND t_trans_type.column_name = 'transaction_type'
       LEFT JOIN column_value_desc cvd_trans_type
          ON     cvd_trans_type.table_column_id =
                    t_trans_type.table_column_id
             AND cvd_trans_type.value = cn.transaction_type
             AND cvd_trans_type.status = 1
       LEFT JOIN table_column t_trans_mode
          ON     t_trans_mode.table_name = 'Contribution'
             AND t_trans_mode.column_name = 'transaction_mode'
       LEFT JOIN column_value_desc cvd_trans_mode
          ON     cvd_trans_mode.table_column_id =
                    t_trans_mode.table_column_id
             AND cvd_trans_mode.value = cn.transaction_mode
             AND cvd_trans_mode.status = 1
 WHERE     cn.status = 1
       AND DATE_FORMAT(cn.transaction_date, '%Y') = @year
ORDER BY cn.transaction_date, cn.date_added;