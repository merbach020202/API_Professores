USE Filmes_Eduardo

INSERT INTO Genero VALUES ('Comédia'), ('Terror'), ('Ação')


INSERT INTO Filme 
VALUES 
	(1,'Todo mundo em pânico'), 
	(2,'Sobrenatural'), 
	(3,'Missão impossível')

INSERT INTO Usuario (Email, Senha, Permissao)
VALUES
	('eduardo.brenn@gmail.com','123','comum'),
	('carlos.roque@gmail.com','123','Administrador')


	SELECT * FROM Genero
	SELECT * FROM Filme
	SELECT * FROM Usuario