
insert into TipoVeiculo (Id, Descricao) values (1, 'Carro');
insert into TipoVeiculo (Id, Descricao) values (2, 'Moto');
insert into TipoVeiculo (Id, Descricao) values (3, 'Aviao');
insert into TipoVeiculo (Id, Descricao) values (4, 'Navio');
insert into TipoVeiculo (Id, Descricao) values (5, 'Helicoptero');

 
--Carro
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Fusca', 1980, 1);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Chevette', 1970, 1);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Monza', 1995, 1);

--Moto
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'BMW S1000RR', 2009, 2);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Honda PCX', 2010, 2);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Yamaha MT-09', 2018, 2);

--Aviao
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Airbus A350 XWB', 2000, 3);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Airbus A320', 2010, 3);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Airbus A330', 2015, 3);

--Navio
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Catamarã', 1970, 4);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Cruzador', 2014, 4);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Gaseiro', 2015, 4);

--Helicoptero
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Sikorsky CH-54 Tarhe', 1958, 5);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Boeing CH-47 Chinook', 1961, 5);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Kellett-Hughes XH-17', 1952, 5);