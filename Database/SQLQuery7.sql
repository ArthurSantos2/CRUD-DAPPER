
create database MeuFeudo
go


create table Familias
(
	ID int,
	NomeDaFamilia varchar(150),

	PRIMARY KEY(ID)
);

CREATE TABLE PoderDaFamilia
(
	ID int,
	NivelDePoder varchar(50)

	PRIMARY KEY(ID),
);

create table Areas (
	ID int,
	FamiliaDaArea int NOT NULL,
	NivelDaFamilia int NOT NULL,
	NomeDaArea varchar(100),

	PRIMARY KEY(ID),
	CONSTRAINT FK_FamiliaPertencente
	FOREIGN KEY(FamiliaDaArea) REFERENCES Familias(ID),
	CONSTRAINT FK_PoderFamiliar
	FOREIGN KEY (NivelDaFamilia) REFERENCES PoderDaFamilia(ID);
	
);

create table MeusFeudos
(
	ID int,
	AreaDePosse int,
	Nome varchar(100),

	PRIMARY KEY(ID),
	CONSTRAINT FK_AreasDePosseFeudal
	FOREIGN KEY(AreaDePosse) REFERENCES Areas(ID)

);

create table Membros
(
	ID int,
	Nome varchar(256),
	Familia int,

	PRIMARY KEY(ID),
	CONSTRAINT FK_FamiliaMembro
	FOREIGN KEY(Familia) REFERENCES Familias(ID)
);

create table Produtos
(
	ID int,
	Produto varchar(50),

	PRIMARY KEY(ID)

);

create table Estacoes
(
	ID int,
	Estacao varchar(50),

	PRIMARY KEY(ID)
);

create table Arrecadacoes
(
	ID int,
	EstacaoDoAno int,
	AreaDeArrecadacao int,
	Arrecadado int,
	Quantidade int,


	PRIMARY KEY(ID), CONSTRAINT FK_ProdutoArrecadado
	FOREIGN KEY(Arrecadado) REFERENCES Produtos(ID),
	CONSTRAINT FK_ArrecadacaoArea FOREIGN KEY (AreaDeArrecadacao) REFERENCES Areas(ID),
	CONSTRAINT FK_EstacaoArrecadacao FOREIGN KEY (EstacaoDoAno) REFERENCES Estacoes(ID)
);



INSERT INTO Familias
VALUES (1,'valdemort');
INSERT INTO Familias
VALUES (2,'Marcapio');
INSERT INTO Familias
VALUES (3,'Sonserina');
INSERT INTO Familias
VALUES (4,'Valbasten');
INSERT INTO Familias
VALUES (5,'ChoGath');
INSERT INTO Familias
VALUES (6,'ServidorDeSQL');
INSERT INTO Familias
VALUES (7,'MarivanDoRio');
INSERT INTO Familias
VALUES (8,'Procopio');

INSERT INTO PoderDaFamilia
VALUES(1,'Newbie')
INSERT INTO PoderDaFamilia
VALUES(2,'Subdesenvolvida')
INSERT INTO PoderDaFamilia
VALUES(3,'Fortinha')
INSERT INTO PoderDaFamilia
VALUES(4,'Mestre')
INSERT INTO PoderDaFamilia
VALUES(5,'Grau alto demaize')
INSERT INTO PoderDaFamilia
VALUES(6,'Socorro Deux pq é muito forte')


INSERT INTO Areas
VALUES(1,'1','3', 'Morro da viúva')
INSERT INTO Areas
VALUES(2,'4','5', 'Morro do dendê')
INSERT INTO Areas
VALUES(3,'8','2', 'Morro da chapada')
INSERT INTO Areas
VALUES(4,'7','6', 'Morro do vietnã')


INSERT INTO MeusFeudos
VALUES(1,1,'Feudo do sul')
INSERT INTO MeusFeudos
VALUES(2,1,'Feudo do sul')
INSERT INTO MeusFeudos
VALUES(3,2,'Feudo do Norte')
INSERT INTO MeusFeudos
VALUES(4,2,'Feudo do Norte')
INSERT INTO MeusFeudos
VALUES(5,3,'Feudo do Oeste')
INSERT INTO MeusFeudos
VALUES(6,4,'Feudo do Leste')



INSERT INTO Membros
VALUES(1,'Campones manco',1)
INSERT INTO Membros
VALUES(2,'Campones perneta',1)
INSERT INTO Membros
VALUES(3,'Campones esfomeado',2)
INSERT INTO Membros
VALUES(4,'Campones armado',2)
INSERT INTO Membros
VALUES(5,'Campones doente',3)
INSERT INTO Membros
VALUES(6,'Campones sem dente',3)
INSERT INTO Membros
VALUES(7,'Campones sem mão',4)
INSERT INTO Membros
VALUES(8,'Campones miope',5)
INSERT INTO Membros
VALUES(9,'Campones simples',5)
INSERT INTO Membros
VALUES(10,'Campones complexo',6)
INSERT INTO Membros
VALUES(11,'Campones semi vivo',6)
INSERT INTO Membros
VALUES(12,'Mario Manco',6)
INSERT INTO Membros
VALUES(13,'Mario tropeço',8)
INSERT INTO Membros
VALUES(14,'Marioca do leite',8)
INSERT INTO Membros
VALUES(15,'Martina do trigo',7)
INSERT INTO Membros
VALUES(16,'Marta martelo',7)
INSERT INTO Membros
VALUES(17,'Marcio miudo',4)

INSERT INTO Produtos
VALUES(1,'Trigo')
INSERT INTO Produtos
VALUES(2,'Mamão')
INSERT INTO Produtos
VALUES(3,'Milho')
INSERT INTO Produtos
VALUES(4,'Mandioca')
INSERT INTO Produtos
VALUES(5,'Marmelada')
INSERT INTO Produtos
VALUES(6,'Caramelo')
INSERT INTO Produtos
VALUES(7,'Uva')
INSERT INTO Produtos
VALUES(8,'Arroz')
INSERT INTO Produtos
VALUES(9,'Feijão')
INSERT INTO Produtos
VALUES(10,'Laticinios')
INSERT INTO Produtos
VALUES(11,'Café')

INSERT INTO Estacoes
VALUES(1,'Inverno')
INSERT INTO Estacoes
VALUES(2,'Outono')
INSERT INTO Estacoes
VALUES(3,'Verão')
INSERT INTO Estacoes
VALUES(4,'Primavera')

INSERT INTO Arrecadacoes
VALUES(1,1,1,1,202)
INSERT INTO Arrecadacoes
VALUES(2,2,1,2,210)
INSERT INTO Arrecadacoes
VALUES(3,3,2,3,555)
INSERT INTO Arrecadacoes
VALUES(4,4,3,4,144)
	



