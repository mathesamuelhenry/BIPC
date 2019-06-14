USE BIPC;

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

ALTER TABLE contribution ADD COLUMN account_id int(11) DEFAULT NULL AFTER contribution_id;

INSERT INTO seq_control VALUES ('account', 1);

SELECT account_id
  INTO @account_id
  FROM account
 WHERE account_name = 'BOFA_OLD';

SELECT @account_id;

UPDATE contribution
   SET account_id = @account_id;

/* Run later */
ALTER TABLE contribution MODIFY COLUMN account_id int(11) NOT NULL;

ALTER TABLE contribution ADD CONSTRAINT FOREIGN KEY(account_id) REFERENCES account(account_id);


