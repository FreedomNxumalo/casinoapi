# casino api
casino api

Database 

Create Database Casino
go

use Casino
go 

Create table Player
(
  playerId int primary key identity(1,1) not null,
  Fullname nvarchar(50) not null,
  amount decimal(19,2) not null, 
  isActive bit not null
)
go

Create table Transaction
(
  transactionId int primary key identity(1,1) not null,
	amount decimal(19,2) not null, 
	playerId int not null foreign key(playerId) References Players(playerId),
	transactionTypeId int not null foreign key(transactionTypeId) References TransactionType(transactionTypeId)
)

Create table TransactionType
( 
  transactionTypeId int primary key identity(1,1) not null,
  TransactionType nvarchar(50) not null
)
go

insert into TransactionType
values ('WAGER')
go

insert into TransactionType
values ('WIN')
go
