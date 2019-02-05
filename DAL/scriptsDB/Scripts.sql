create database [1erParcialDb]
go
use [1erParcialDb]
go




create table Depositos
(
			DepositoId int primary key identity(1,1),
            Fecha Date,
            CuentaId int,
            Concepto varchar(max),
            Monto money
);



create table CuentasBancarias
(
			CuentaId int primary key identity(1,1),
            Fecha Date,
            Nombre varchar(max),
            Balance money
);

select* from CuentasBancarias
select* from Depositos

create table Depositos
create table Depositos

drop database [1erParcialDb]
