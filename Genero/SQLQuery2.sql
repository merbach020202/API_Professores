USE Filmes_Eduardo

INSERT INTO Genero VALUES ('Com�dia'), ('Terror'), ('A��o')


INSERT INTO Filme 
VALUES 
	(1,'Todo mundo em p�nico'), 
	(2,'Sobrenatural'), 
	(3,'Miss�o imposs�vel')

INSERT INTO Usuario (Email, Senha, Permissao)
VALUES
	('eduardo.brenn@gmail.com','123','comum'),
	('carlos.roque@gmail.com','123','Administrador')


	SELECT * FROM Genero
	SELECT * FROM Filme
	SELECT * FROM Usuario