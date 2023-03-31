
-- create database MeuFeudo
-- go


-- create table Familias
-- (
-- 	ID int IDENTITY(1,1),
-- 	NomeDaFamilia varchar(150),

-- 	PRIMARY KEY(ID)
-- );

-- CREATE TABLE PoderDaFamilia
-- (
-- 	ID int IDENTITY(1,1),
-- 	NivelDePoder varchar(50)

-- 	PRIMARY KEY(ID),
-- );

-- create table MeusFeudos
-- (
-- 	ID int IDENTITY(1,1),
-- 	Nome varchar(100),

-- 	PRIMARY KEY (ID)
-- );



-- create table Areas (
-- 	ID int IDENTITY(1,1),
-- 	FamiliaDaArea int NOT NULL,
-- 	NivelDaFamilia int NOT NULL,
-- 	NomeDaArea varchar(100),
-- 	FeudoPertencente int,

-- 	PRIMARY KEY(ID),
-- 	CONSTRAINT FK_FamiliaPertencente
-- 	FOREIGN KEY(FamiliaDaArea) REFERENCES Familias(ID),
-- 	CONSTRAINT FK_PoderFamiliar 
-- 	FOREIGN KEY (NivelDaFamilia) REFERENCES PoderDaFamilia(ID),
-- 	CONSTRAINT FK_Area_Feudo
-- 	FOREIGN KEY (FeudoPertencente) REFERENCES MeusFeudos(ID)
	
-- );



-- create table Membros
-- (
-- 	ID int IDENTITY(1,1),
-- 	Nome varchar(256),
-- 	Familia int,

-- 	PRIMARY KEY(ID),
-- 	CONSTRAINT FK_FamiliaMembro
-- 	FOREIGN KEY(Familia) REFERENCES Familias(ID)
-- );

-- create table Produtos
-- (
-- 	ID int IDENTITY(1,1),
-- 	Produto varchar(50),

-- 	PRIMARY KEY(ID)

-- );

-- create table Estacoes
-- (
-- 	ID int IDENTITY(1,1),
-- 	Estacao varchar(50),

-- 	PRIMARY KEY(ID)
-- );

-- create table Arrecadacoes
-- (
-- 	ID int IDENTITY(1,1),
-- 	EstacaoDoAno int,
-- 	AreaDeArrecadacao int,
-- 	Arrecadado int,
-- 	Quantidade int,


-- 	PRIMARY KEY(ID), CONSTRAINT FK_ProdutoArrecadado
-- 	FOREIGN KEY(Arrecadado) REFERENCES Produtos(ID),
-- 	CONSTRAINT FK_ArrecadacaoArea FOREIGN KEY (AreaDeArrecadacao) REFERENCES Areas(ID),
-- 	CONSTRAINT FK_EstacaoArrecadacao FOREIGN KEY (EstacaoDoAno) REFERENCES Estacoes(ID)
-- );



-- INSERT INTO Familias
-- VALUES ('valdemort');
-- INSERT INTO Familias
-- VALUES ('Marcapio');
-- INSERT INTO Familias
-- VALUES ('Sonserina');
-- INSERT INTO Familias
-- VALUES ('Valbasten');
-- INSERT INTO Familias
-- VALUES ('ChoGath');
-- INSERT INTO Familias
-- VALUES ('ServidorDeSQL');
-- INSERT INTO Familias
-- VALUES ('MarivanDoRio');
-- INSERT INTO Familias
-- VALUES ('Procopio');

-- INSERT INTO PoderDaFamilia
-- VALUES('Newbie')
-- INSERT INTO PoderDaFamilia
-- VALUES('Subdesenvolvida')
-- INSERT INTO PoderDaFamilia
-- VALUES('Fortinha')
-- INSERT INTO PoderDaFamilia
-- VALUES('Mestre')
-- INSERT INTO PoderDaFamilia
-- VALUES('Grau alto demaize')
-- INSERT INTO PoderDaFamilia
-- VALUES('Socorro Deux pq é muito forte')

-- INSERT INTO MeusFeudos
-- VALUES('Feudo do sul')
-- INSERT INTO MeusFeudos
-- VALUES('Feudo do sul')
-- INSERT INTO MeusFeudos
-- VALUES('Feudo do Norte')
-- INSERT INTO MeusFeudos
-- VALUES('Feudo do Norte')
-- INSERT INTO MeusFeudos
-- VALUES('Feudo do Oeste')
-- INSERT INTO MeusFeudos
-- VALUES('Feudo do Leste')

-- INSERT INTO Areas
-- VALUES('1','3', 'Morro da viúva',1)
-- INSERT INTO Areas
-- VALUES('4','5', 'Morro do dendê',1)
-- INSERT INTO Areas
-- VALUES('8','2', 'Morro da chapada',1)
-- INSERT INTO Areas
-- VALUES('7','6', 'Morro do vietnã',1)





-- INSERT INTO Membros
-- VALUES('Campones manco',1)
-- INSERT INTO Membros
-- VALUES('Campones perneta',1)
-- INSERT INTO Membros
-- VALUES('Campones esfomeado',2)
-- INSERT INTO Membros
-- VALUES('Campones armado',2)
-- INSERT INTO Membros
-- VALUES('Campones doente',3)
-- INSERT INTO Membros
-- VALUES('Campones sem dente',3)
-- INSERT INTO Membros
-- VALUES('Campones sem mão',4)
-- INSERT INTO Membros
-- VALUES('Campones miope',5)
-- INSERT INTO Membros
-- VALUES('Campones simples',5)
-- INSERT INTO Membros
-- VALUES('Campones complexo',6)
-- INSERT INTO Membros
-- VALUES('Campones semi vivo',6)
-- INSERT INTO Membros
-- VALUES('Mario Manco',6)
-- INSERT INTO Membros
-- VALUES('Mario tropeço',8)
-- INSERT INTO Membros
-- VALUES('Marioca do leite',8)
-- INSERT INTO Membros
-- VALUES('Martina do trigo',7)
-- INSERT INTO Membros
-- VALUES('Marta martelo',7)
-- INSERT INTO Membros
-- VALUES('Marcio miudo',4)

-- INSERT INTO Produtos
-- VALUES('Trigo')
-- INSERT INTO Produtos
-- VALUES('Mamão')
-- INSERT INTO Produtos
-- VALUES('Milho')
-- INSERT INTO Produtos
-- VALUES('Mandioca')
-- INSERT INTO Produtos
-- VALUES('Marmelada')
-- INSERT INTO Produtos
-- VALUES('Caramelo')
-- INSERT INTO Produtos
-- VALUES('Uva')
-- INSERT INTO Produtos
-- VALUES('Arroz')
-- INSERT INTO Produtos
-- VALUES('Feijão')
-- INSERT INTO Produtos
-- VALUES('Laticinios')
-- INSERT INTO Produtos
-- VALUES('Café')

-- INSERT INTO Estacoes
-- VALUES('Inverno')
-- INSERT INTO Estacoes
-- VALUES('Outono')
-- INSERT INTO Estacoes
-- VALUES('Verão')
-- INSERT INTO Estacoes
-- VALUES('Primavera')

-- INSERT INTO Arrecadacoes
-- VALUES(1,1,1,202)
-- INSERT INTO Arrecadacoes
-- VALUES(2,1,2,210)
-- INSERT INTO Arrecadacoes
-- VALUES(3,2,3,555)
-- INSERT INTO Arrecadacoes
-- VALUES(4,3,4,144)