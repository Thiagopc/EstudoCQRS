CREATE SCHEMA `estudo` ;

USE `estudo`;

CREATE TABLE product(
-- id int auto_increment,
id varchar(36),
name varchar(100),
description varchar(250),
price numeric(9,2),
CONSTRAINT product_pk_id primary key (id)
);

CREATE TABLE outbox(
-- id int auto_increment,
id varchar(36),
name varchar(150),
operation varchar(100),
`message` TEXT,
CONSTRAINT outbox_pk_id PRIMARY KEY (id));
