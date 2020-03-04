CREATE DATABASE auth;
USE auth;

CREATE TABLE auth_method(
auth_method_id int(11) NOT NULL,
auth_method_name varchar(50) NOT NULL,
user_added varchar(255) NOT NULL,
date_added datetime NOT NULL,
user_changed varchar(255) DEFAULT NULL,
date_changed datetime DEFAULT NULL,
PRIMARY KEY (auth_method_id),
UNIQUE KEY (auth_method_name)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE auth_group(
auth_group_id int(11) NOT NULL,
auth_method_id int(11) NOT NULL,
auth_group_name varchar(50) NOT NULL,
user_added varchar(255) NOT NULL,
date_added datetime NOT NULL,
user_changed varchar(255) DEFAULT NULL,
date_changed datetime DEFAULT NULL,
PRIMARY KEY (auth_group_id),
UNIQUE KEY (auth_group_name),
FOREIGN KEY (auth_method_id) REFERENCES auth_method (auth_method_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE auth_user (
  auth_user_id int(11) NOT NULL,
  auth_group_id int(11) NOT NULL,
  first_name varchar(50) NOT NULL,
  last_name varchar(50) NOT NULL,
  email varchar(50) NOT NULL COMMENT 'login Username',
  username varchar(50) NOT NULL,
  password varchar(100) NOT NULL,
  status varchar(2) NOT NULL DEFAULT 'A',
  user_added varchar(255) NOT NULL,
  date_added datetime NOT NULL,
  user_changed varchar(255) DEFAULT NULL,
  date_changed datetime DEFAULT NULL,
  PRIMARY KEY (auth_user_id),
  UNIQUE KEY (auth_group_id, email),
  FOREIGN KEY (auth_group_id) REFERENCES auth_group (auth_group_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE security_question (
  security_question_id int(11) NOT NULL,
  question varchar(255) NOT NULL,
  user_added varchar(255) NOT NULL,
  date_added datetime NOT NULL,
  user_changed varchar(255) DEFAULT NULL,
  date_changed datetime DEFAULT NULL,
  PRIMARY KEY (security_question_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE role (
  role_id int(11) NOT NULL,
  role_name varchar(40) NOT NULL,
  user_added varchar(255) NOT NULL,
  date_added datetime NOT NULL,
  user_changed varchar(255) DEFAULT NULL,
  date_changed datetime DEFAULT NULL,
  PRIMARY KEY (role_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE user_role (
  user_role_id int(11) NOT NULL,
  auth_user_id int(11) NOT NULL,
  role_id int(11) NOT NULL,
  user_added varchar(255) NOT NULL,
  date_added datetime NOT NULL,
  user_changed varchar(255) DEFAULT NULL,
  date_changed datetime DEFAULT NULL,
  PRIMARY KEY (user_role_id),
  FOREIGN KEY (role_id) REFERENCES role (role_id),
  FOREIGN KEY (auth_user_id) REFERENCES auth_user (auth_user_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE user_security_question (
  user_security_question_id int(11) NOT NULL,
  auth_user_id int(11) NOT NULL,
  security_question_id int(11) NOT NULL,
  answer varchar(255) NOT NULL,
  user_added varchar(255) NOT NULL,
  date_added datetime NOT NULL,
  user_changed varchar(255) DEFAULT NULL,
  date_changed datetime DEFAULT NULL,
  PRIMARY KEY (user_security_question_id),
  FOREIGN KEY (security_question_id) REFERENCES security_question (security_question_id),
  FOREIGN KEY (auth_user_id) REFERENCES auth_user (auth_user_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE seq_control (
  obj_name varchar(50) NOT NULL,
  next_id int(11) NOT NULL,
  PRIMARY KEY (obj_name)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO seq_control VALUES ('auth_user', 1);

INSERT INTO auth_method (
   auth_method_id
  ,auth_method_name
  ,user_added
  ,date_added
) VALUES (
   1 -- auth_method_id - IN int(11)
  ,'MD5' -- auth_method_name - IN varchar(50)
  ,'Samuel' -- user_added - IN varchar(255)
  , now() -- date_added - IN datetime
);

INSERT INTO auth_group (
   auth_group_id
  ,auth_method_id
  ,auth_group_name
  ,user_added
  ,date_added
) VALUES (
   1 -- auth_group_id - IN int(11)
  ,1 -- auth_method_id - IN int(11)
  ,'NP' -- auth_group_name - IN varchar(50)
  ,'Samuel' -- user_added - IN varchar(255)
  ,now() -- date_added - IN datetime
);

CREATE TABLE login_history(
login_history_id int(11) NOT NULL PRIMARY KEY,
auth_user_id int(11) NOT NULL,
login_date datetime,
user_added varchar(255) NOT NULL,
date_added datetime NOT NULL,
user_changed varchar(255) DEFAULT NULL,
date_changed datetime DEFAULT NULL,
FOREIGN KEY (auth_user_id) REFERENCES auth_user (auth_user_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
