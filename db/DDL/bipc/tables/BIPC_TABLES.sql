USE BIPC;

CREATE TABLE organization
(
   organization_id   INT(11) NOT NULL,
   name              varchar(50) NOT NULL COMMENT 'Organization Name',
   website           varchar(50) DEFAULT NULL COMMENT 'Org Website',
   industry          varchar(50) NOT NULL,
   address_line_1    varchar(60) NOT NULL,
   address_line_2    varchar(60) DEFAULT NULL,
   address_line_3    varchar(60) DEFAULT NULL,
   city              varchar(35) NOT NULL,
   state             varchar(3) DEFAULT NULL,
   zip               varchar(10) NOT NULL,
   zip4              varchar(4) DEFAULT NULL,
   email             varchar(50) DEFAULT NULL,
   phone             varchar(15) DEFAULT NULL,
   user_added        varchar(255) NOT NULL,
   date_added        datetime NOT NULL,
   user_changed      varchar(255) DEFAULT NULL,
   date_changed      datetime DEFAULT NULL,
   PRIMARY KEY(organization_id),
   UNIQUE KEY (name)
);

CREATE TABLE users
(
   user_id           INT(11) NOT NULL,
   first_name        varchar(50) NOT NULL,
   last_name         varchar(50) NOT NULL,
   email             varchar(50) NOT NULL COMMENT 'login Username', 
   password          varchar(100) NOT NULL,
   status            varchar(2) NOT NULL DEFAULT 'A',
   user_added        varchar(255) NOT NULL,
   date_added        datetime NOT NULL,
   user_changed      varchar(255) DEFAULT NULL,
   date_changed      datetime DEFAULT NULL,
   PRIMARY KEY(user_id),
   UNIQUE KEY (email)
);

CREATE TABLE user_organization
(
   user_organization_id   INT(11) NOT NULL,
   user_id                INT(11) NOT NULL,
   organization_id        INT(11) NOT NULL,
   user_added             varchar(255) NOT NULL,
   date_added             datetime NOT NULL,
   user_changed           varchar(255) DEFAULT NULL,
   date_changed           datetime DEFAULT NULL,
   PRIMARY KEY (user_organization_id),
   UNIQUE KEY (user_id, organization_id),
   FOREIGN KEY(user_id) REFERENCES users(user_id),
   FOREIGN KEY(organization_id) REFERENCES organization(organization_id)
);

CREATE TABLE account
(
   account_id             int(11) NOT NULL,
   account_number         varchar(50) DEFAULT NULL,
   account_name           varchar(100) DEFAULT NULL,
   bank_name              varchar(50) DEFAULT NULL,
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
   account_id          int(11) NOT NULL,
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
   FOREIGN KEY(contributor_id) REFERENCES contributor(contributor_id),
   FOREIGN KEY(account_id) REFERENCES account(account_id)
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

CREATE TABLE kvp (
  kvp_id int(11) NOT NULL,
  kvp_name varchar(50) NOT NULL,
  kvp_key varchar(50) NOT NULL,
  kvp_value varchar(100) NOT NULL,
  user_added varchar(255) NOT NULL,
  date_added datetime NOT NULL,
  user_changed varchar(255) DEFAULT NULL,
  date_changed datetime DEFAULT NULL,
  PRIMARY KEY (kvp_id),
  KEY kvp_name (kvp_name,kvp_key)
);

CREATE TABLE security_question
(
   security_question_id   int(11) NOT NULL,
   question               varchar(255) NOT NULL,
   date_added             datetime NOT NULL,
   date_changed           datetime DEFAULT NULL,
   PRIMARY KEY(security_question_id)
);

CREATE TABLE user_security_question (
  user_security_question_id int(11) NOT NULL,
  user_id int(11) NOT NULL,
  security_question_id int(11) NOT NULL,
  answer varchar(255) NOT NULL,
  user_added varchar(255) NOT NULL,
  date_added datetime NOT NULL,
  user_changed varchar(255) DEFAULT NULL,
  date_changed datetime DEFAULT NULL,
  PRIMARY KEY (user_security_question_id),
  KEY user_id_usqfk_1 (user_id),
  KEY security_question_id_usqfk_1 (security_question_id),
  CONSTRAINT security_question_id_usqfk_1 FOREIGN KEY (security_question_id) REFERENCES security_question (security_question_id),
  CONSTRAINT user_id_usqfk_1 FOREIGN KEY (user_id) REFERENCES users (user_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE role
(
   role_id        INT NOT NULL,
   role_name      varchar(40) NOT NULL,
   user_added     varchar(255) NOT NULL,
   date_added     datetime NOT NULL,
   user_changed   varchar(255) DEFAULT NULL,
   date_changed   datetime DEFAULT NULL,
   PRIMARY KEY(role_id)
);

CREATE TABLE user_role
(
   user_role_id   INT(11) NOT NULL,
   user_id        INT(11) NOT NULL,
   role_id        INT(11) NOT NULL,
   user_added     varchar(255) NOT NULL,
   date_added     datetime NOT NULL,
   user_changed   varchar(255) DEFAULT NULL,
   date_changed   datetime DEFAULT NULL,
   PRIMARY KEY(user_role_id),
   CONSTRAINT user_id_urfk_1 FOREIGN KEY(user_id) REFERENCES users(user_id),
   CONSTRAINT role_id_urfk_1 FOREIGN KEY(role_id) REFERENCES role(role_id)
);

CREATE TABLE organization_category(
organization_category_id int(11) NOT NULL PRIMARY KEY,
organization_id int(11) NOT NULL,
category_name varchar(40) NOT NULL,
is_active tinyint(4) DEFAULT 1,
user_added varchar(255) NOT NULL,
date_added datetime NOT NULL,
user_changed varchar(255) DEFAULT NULL,
date_changed datetime DEFAULT NULL,
CONSTRAINT org_category_ocfk_1 FOREIGN KEY (organization_id) REFERENCES organization (organization_id))
ENGINE=InnoDB DEFAULT CHARSET=latin1;