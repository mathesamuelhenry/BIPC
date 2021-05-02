alter table contribution add column user_added varchar(255) DEFAULT NULL;

alter table contribution add column user_changed varchar(255) DEFAULT NULL;

update contribution set user_added = 'smathe'