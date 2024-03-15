# This is our sample schema which is loaded in our default environment.
# Your script will run in an empty database named "coderpad" as a user
# of the same name. Please bootstrap your data below!

create table member
(
	id            int AUTO_INCREMENT,
    account       int, 
	first_name    varchar(255),
	last_name     varchar(255),
	primary key(id)
);

insert into member
	(first_name, last_name, account)
values
	('John',   'Smith',     20000),
	('Ava',    'Muffinson', 10000),
	('Cailin', 'Ninson',    30000),
	('Mike',   'Peterson',  20000),
	('Ian',    'Peterson',  80000),
	('John',   'Mills',     50000);

create table projects
(
	id            int AUTO_INCREMENT,
	title         varchar(255),
	start_date    date,
	end_date      date,
	budget        int,

	primary key(id)
);

insert into projects
	(title, start_date, end_date, budget)
values
	('Build a cool site',        '2011-10-28', '2012-01-26', 1000000),
	('Update TPS Reports',       '2011-07-20', '2011-10-28',  100000),
	('Design 3 New Silly Walks', '2009-05-11', '2009-08-19',     100);

create table departments
(
	id            int auto_increment,
	name          varchar(255),

	primary key(id)
);

insert into departments
	(name)
values
	('Reporting'),
	('Engineering'),
	('Marketing'),
	('Biz Dev'),
	('Silly Walks');

create table employees_projects
(
	project_id    int,
	employee_id   int,

	key(project_id),
	key(employee_id)
);

insert into employees_projects
	(project_id, employee_id)
values
	(2, 1),
	(3, 2),
	(1, 3),
	(1, 4),
	(1, 5);
