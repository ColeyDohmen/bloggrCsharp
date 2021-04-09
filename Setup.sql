USE bloggrcoley;

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

CREATE TABLE blogs
(
creatorId VARCHAR(255) NOT NULL,
id INT NOT NULL AUTO_INCREMENT,
title VARCHAR(255),
body VARCHAR(255),
imgUrl VARCHAR(255),
published TINYINT,
PRIMARY KEY (id)

);

CREATE TABLE comments
(
creatorId VARCHAR(255) NOT NULL,
id INT NOT NULL AUTO_INCREMENT,
body VARCHAR(255),
blog VARCHAR(255),
PRIMARY KEY (id)
);

-- DROP TABLE blogs;
-- DROP TABLE comments;