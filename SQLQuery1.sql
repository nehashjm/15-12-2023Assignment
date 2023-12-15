create database LibraryDB
on primary (name='Library_Db', Filename='D:\mphasis Simplilearn\Phase2\Assignment\Day7\Library_Db.mdf')
log on (name='Library_Db_log',filename='D:\mphasis Simplilearn\Phase2\Assignment\Day7\Library_Db_log.ldf')
COLLATE SQL_Latin1_General_CP1_CI_AS

use LibraryDB

create table books
(BookId int primary key,
Title nvarchar(50),
Author nvarchar(50),
Genere nvarchar(50),
Quantity int)
insert into books values (1,'2states','chetan','romantic',30)
select * from books