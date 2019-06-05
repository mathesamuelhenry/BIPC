USE BIPC;

CREATE TABLE account
(
   account_id             int(11) NOT NULL,
   account_number         varchar(50) DEFAULT NULL,
   account_name           varchar(100) DEFAULT NULL,
   bank_name              varchar(50) DEFAULT NULL,
   account_created_date   datetime NOT NULL,
   account_end_date       datetime DEFAULT NULL,
   initial_balance        decimal(11, 2) NOT NULL,
   status                 tinyint(4) DEFAULT '1',
   date_added             datetime DEFAULT NULL,
   date_changed           datetime DEFAULT NULL,
   PRIMARY KEY(account_id)
);

CREATE TABLE contributor
(
   contributor_id    int NOT NULL PRIMARY KEY,
   first_name        varchar(50) NOT NULL,
   last_name         varchar(50) DEFAULT NULL,
   family_name       varchar(50) DEFAULT NULL,
   status            tinyint(4) DEFAULT 1,
   date_added datetime,
   date_changed datetime
);

CREATE TABLE contribution
(
   contribution_id     int(11) NOT NULL PRIMARY KEY,
   account_id          int(11) DEFAULT NULL,
   contributor_id      int DEFAULT NULL,
   contribution_name   varchar(60) DEFAULT NULL,
   category            varchar(50) DEFAULT NULL,
   transaction_type    int DEFAULT 1 COMMENT '1 - credit, 2 - debit',
   transaction_mode    int NOT NULL COMMENT 'CASH/CHECK',
   amount              decimal(11, 2) NOT NULL,
   check_number        varchar(50) DEFAULT NULL,
   transaction_date    datetime DEFAULT NULL,
   note                text DEFAULT NULL,
   status              tinyint(4) DEFAULT 1,
   date_added          datetime,
   date_changed        datetime,
   FOREIGN KEY(contributor_id) REFERENCES contributor(contributor_id)
);

CREATE TABLE table_column
(
   table_column_id    int NOT NULL PRIMARY KEY,
   table_name         varchar(50) NOT NULL,
   column_name        varchar(50) NOT NULL,
   status             tinyint(4) DEFAULT 1,
   date_added datetime,
   date_changed datetime
);

CREATE TABLE column_value_desc
(
   column_value_desc_id    int NOT NULL PRIMARY KEY,
   table_column_id         int NOT NULL,
   value                   varchar(50) NOT NULL,
   description             varchar(500) NOT NULL,
   status                  tinyint(4) DEFAULT 1,
   date_added datetime,
   date_changed datetime,
   FOREIGN KEY(table_column_id) REFERENCES table_column(table_column_id)
);

CREATE TABLE contributor_loan
(
   contributor_loan_id    int NOT NULL PRIMARY KEY,
   contributor_id         int NOT NULL,
   loan_amount            decimal(11, 2) NOT NULL,
   status                 tinyint(4) DEFAULT 1,
   date_added datetime,
   date_changed datetime,
   FOREIGN KEY(contributor_id) REFERENCES contributor(contributor_id)
);