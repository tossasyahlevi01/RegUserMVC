create database DBRegUser
use DBRegUser



create table UserAccount
(
UserNumber varchar(500) primary key not null,
EmailAddress  varchar(500) not null,
Passwords varchar(10) not null,
CreatedDated datetime not null,
IsActive bit not null,
ModifyDated datetime null
)

alter table UserAccountDetail add FullName varchar(500) null

select*from UserAccount
select*from UserAccountDetail

create table UserAccountDetail
(
UserAccountDetailId bigint primary key identity(1,1) not null,
NumberPhone varchar(20) not null,
Nationality varchar(200) not null,
UserNumber varchar(500) not null,
FOREIGN KEY (UserNumber) REFERENCES UserAccount(UserNumber)
)


use proc_pr_mm_sm
