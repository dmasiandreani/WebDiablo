USE AppWebDiablo
GO

/*
DROP TABLE [Personaje];
DROP TABLE [Clase];
*/

-----------------------------TABLES
CREATE TABLE [Personaje] (
  [Persj_Id] INT identity(1,1),
  [Persj_Nombre] Varchar(20),
  [Cls_Id] INT,
  [Persj_Lvl] INT,
  [Persj_Xp] INT,
  [Persj_HP] INT,
  [Persj_Mp] INT
);

CREATE TABLE [Clase] (
  [Cls_Id] INT identity(1,1),
  [Cls_Nombre] Varchar(50),
  [Cls_HP_Base] INT,
  [Cls_MP_Base] INT
);

-----------------------------PK
ALTER TABLE [Personaje] ADD CONSTRAINT PK_Personaje PRIMARY KEY (Persj_Id) 
ALTER TABLE [Clase] ADD CONSTRAINT PK_Clase PRIMARY KEY (Cls_Id) 

-----------------------------FK
ALTER TABLE [Personaje] 
	ADD CONSTRAINT FK_Personaje_Clase
	FOREIGN KEY (Cls_Id) REFERENCES Clase(Cls_Id)

-----------------------------DATOS
INSERT INTO [Clase] (Cls_Nombre, Cls_HP_Base, Cls_MP_Base) VALUES ('Barbaro', 350, 50)
INSERT INTO [Clase] (Cls_Nombre, Cls_HP_Base, Cls_MP_Base) VALUES ('Guerrero Divino', 300, 100)
INSERT INTO [Clase] (Cls_Nombre, Cls_HP_Base, Cls_MP_Base) VALUES ('Demon Hunter', 200, 200)
INSERT INTO [Clase] (Cls_Nombre, Cls_HP_Base, Cls_MP_Base) VALUES ('Monje', 300, 100)
INSERT INTO [Clase] (Cls_Nombre, Cls_HP_Base, Cls_MP_Base) VALUES ('Necromancer', 150, 250)
INSERT INTO [Clase] (Cls_Nombre, Cls_HP_Base, Cls_MP_Base) VALUES ('Santero', 150, 250)
INSERT INTO [Clase] (Cls_Nombre, Cls_HP_Base, Cls_MP_Base) VALUES ('Arcanista', 150, 250)

INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('Damian', 3, 10, 200, 3000, 2000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('DamianDM', 3, 60, 0, 40000, 20000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('DamianB', 1, 60, 0, 60000, 10000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('MaximoGD', 2, 50, 54323, 30000, 20000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('MaximoA', 7, 46, 4325, 10000, 20000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('MaximoS', 6, 32, 4325, 9000, 18000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('LinceDM', 3, 60, 0, 10000, 10000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('LinceDM1', 3, 60, 0, 20000, 21000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('LinceDM2', 3, 20, 366, 3000, 2000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('KojimaB', 1, 35, 2534, 3000, 2300)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('KojimaS', 6, 53, 2040, 31000, 50000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('KojimaA', 7, 25, 654, 6000, 12000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('KennysN', 5, 31, 235, 9000, 12000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('KennysN2', 5, 15, 26, 5000, 10000)
INSERT INTO [Personaje] (Persj_Nombre,Cls_Id,Persj_Lvl,Persj_Xp,Persj_HP,Persj_Mp) Values
						('KennysDM', 3, 10, 432, 800, 1000)


/*
Select * FROM [Personaje]
Select * FROM [Clase]
*/
