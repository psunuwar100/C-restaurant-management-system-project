create database login

use login;

create table loginInfo(
	id int primary key identity,
	name nvarchar(50) unique, 
	password nvarchar(50)
);
insert into loginInfo (name, password) values ('Kushal123', 'passport');

select * from loginInfo;

select name, password from loginInfo;

create table orderDetails(
	id int primary key identity,
	tableNo int,
	category nvarchar(50), 
	items nvarchar(50), 
	quantity float, 
	unitprice float, 
	totalprice float
);
drop table orderDetails; 
select * from orderDetails;

create table reservationDetails(
	tableNo int primary key,
	color nvarchar(50),
);
drop table reservationDetails;
select * from reservationDetails;
