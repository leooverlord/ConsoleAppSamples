declare @TipoCarro uniqueidentifier;
set @TipoCarro = NEWID();

declare @Moto uniqueidentifier;
set @Moto = NEWID();

declare @Aviao uniqueidentifier;
set @Aviao = NEWID();

declare @Navio uniqueidentifier;
set @Navio = NEWID();

declare @Helicoptero uniqueidentifier;
set @Helicoptero = NEWID();

insert into TipoVeiculo (Id, Tipo, Descricao) values (@TipoCarro, 1, 'Carro');
insert into TipoVeiculo (Id, Tipo, Descricao) values (@Moto, 2, 'Moto');
insert into TipoVeiculo (Id, Tipo, Descricao) values (@Aviao, 3, 'Aviao');
insert into TipoVeiculo (Id, Tipo, Descricao) values (@Navio, 4, 'Navio');
insert into TipoVeiculo (Id, Tipo, Descricao) values (@Helicoptero, 5, 'Helicoptero');

 
--Carro
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Fusca', 1980, @TipoCarro);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Chevette', 1970, @TipoCarro);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Monza', 1995, @TipoCarro);

--Moto
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'BMW S1000RR', 2009, @Moto);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Honda PCX', 2010, @Moto);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Yamaha MT-09', 2018, @Moto);

--Aviao
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Airbus A350 XWB', 2000, @Aviao);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Airbus A320', 2010, @Aviao);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Airbus A330', 2015, @Aviao);

--Navio
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Catamarã', 1970, @Navio);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Cruzador', 2014, @Navio);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Gaseiro', 2015, @Navio);

--Helicoptero
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Sikorsky CH-54 Tarhe', 1958, @Helicoptero);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Boeing CH-47 Chinook', 1961, @Helicoptero);
insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (NEWID(), 'Kellett-Hughes XH-17', 1952, @Helicoptero);