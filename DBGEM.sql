create database db_gem;
use db_gem;

CREATE TABLE Instrumentos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome_instrumento VARCHAR(100) NOT NULL UNIQUE,
    quantidade_maxima INT NOT NULL
);

-- Tabela de Alunos
CREATE TABLE Alunos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(14) UNIQUE NOT NULL,
    dt_cadastro DATE NOT NULL,
    dt_nascimento DATE NOT NULL,
    telefone VARCHAR(20),
    email VARCHAR(100),
    cep VARCHAR(10),
    endereco VARCHAR(255),
    numero VARCHAR(10),
    bairro VARCHAR(100),
    cidade VARCHAR(100),
    estado VARCHAR(2),
    estado_civil VARCHAR(20),
    foto_perfil LONGBLOB,
    id_instrumento INT, 
    FOREIGN KEY (id_instrumento) REFERENCES Instrumentos(id)
);

-- Tabela de Professores (Sem relação com Alunos)
CREATE TABLE Professores (
    id_professor INT PRIMARY KEY AUTO_INCREMENT,
    nome_professor VARCHAR(255) NOT NULL,
    senha_professor VARCHAR(255) NOT NULL,
    perfil_professor varchar(15)
);

-- Tabela de Hinos
CREATE TABLE Hinos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    numero_hino INT NOT NULL UNIQUE CHECK (numero_hino BETWEEN 1 AND 480),
    nome_hino VARCHAR(255) NOT NULL
);

-- Tabela Relacional para Hinos Passados pelos Alunos
CREATE TABLE Aluno_Hino (
    id_aluno INT,
    id_hino INT,
    data_passagem DATE NOT NULL,
    PRIMARY KEY (id_aluno, id_hino),
    FOREIGN KEY (id_aluno) REFERENCES Alunos(id),
    FOREIGN KEY (id_hino) REFERENCES Hinos(id)
);


INSERT INTO hinos (numero_hino, nome_hino) VALUES
(1, 'Amém'),
(2, 'Jesus o Bom Pastor'),
(3, 'Em Fervente Oração'),
(4, 'Mais Perto Quero Estar'),
(5, 'Oh Que Belos Hinos'),
(6, 'A Deus Demos Glória'),
(7, 'Quão Grande És Tu'),
(8, 'A Tua Voz Escuto'),
(9, 'O Rei Está Voltando'),
(10, 'Paz no Vale'),
(11, 'Fala, Senhor'),
(12, 'Ao Único'),
(13, 'Vencendo Vem Jesus'),
(14, 'Sou Feliz com Jesus'),
(15, 'Sublime Amor'),
(16, 'Cristo Cura Sim'),
(17, 'Em Jesus Tenho Alegria'),
(18, 'O Bom Consolador'),
(19, 'Descansa no Senhor'),
(20, 'Foi na Cruz'),
(21, 'Mais de Cristo'),
(22, 'Com Tua Mão'),
(23, 'Céu e Terra Louvem a Deus'),
(24, 'Aquieta Minh’Alma'),
(25, 'Em Espírito e em Verdade'),
(26, 'A Jesus Dai Louvor'),
(27, 'Nascer de Novo'),
(28, 'O Senhor É Meu Pastor'),
(29, 'Rude Cruz'),
(30, 'Te Exaltamos'),
(31, 'Graça Maravilhosa'),
(32, 'Teu Sangue Me Lava'),
(33, 'Pelas Mãos de Jesus'),
(34, 'Aos Pés da Cruz'),
(35, 'Confia no Senhor'),
(36, 'Hosana nas Alturas'),
(37, 'Cristo, Nome Doce'),
(38, 'Ao Deus Eterno'),
(39, 'A Rocha Eterna'),
(40, 'O Cordeiro Triunfante'),
(41, 'Digno é o Cordeiro'),
(42, 'Luz do Mundo'),
(43, 'Desperta, Igreja'),
(44, 'A Última Trombeta'),
(45, 'Fé Inabalável'),
(46, 'Vivifica-me, Senhor'),
(47, 'Alvo Mais Que a Neve'),
(48, 'Glória a Ti, Jesus'),
(49, 'Eu Sei que Meu Redentor Vive'),
(50, 'Jesus Está Chamando'),
(51, 'O Nome de Jesus'),
(52, 'A Fonte Transbordante'),
(53, 'Santo Espírito'),
(54, 'Glorioso És Tu'),
(55, 'Cristo é o Rei'),
(56, 'Jesus é Meu Guia'),
(57, 'Amor Tão Grande'),
(58, 'Chamado por Deus'),
(59, 'Tocou-me'),
(60, 'Redenção em Cristo'),
(61, 'Tu És Santo'),
(62, 'Alegria Sem Fim'),
(63, 'Senhor, Eu Te Amo'),
(64, 'Majestade'),
(65, 'Em Teus Braços'),
(66, 'És Fiel, Senhor'),
(67, 'Caminho da Cruz'),
(68, 'Quero Ser um Vaso Novo'),
(69, 'O Grande Eu Sou'),
(70, 'Adorarei ao Cordeiro'),
(71, 'Cristo Reina'),
(72, 'Amigo Verdadeiro'),
(73, 'És o Meu Refúgio'),
(74, 'Rei dos Reis'),
(75, 'Senhor da Glória'),
(76, 'Eu Navegarei'),
(77, 'A Ele a Glória'),
(78, 'Grandioso és Tu'),
(79, 'Somente Crê'),
(80, 'Jesus, Minha Esperança'),
(81, 'Emanuel'),
(82, 'Deus de Aliança'),
(83, 'O Leão de Judá'),
(84, 'A Cruz Me Salvou'),
(85, 'Te Louvarei, Senhor'),
(86, 'Espírito de Vida'),
(87, 'És Minha Luz'),
(88, 'Sou Teu'),
(89, 'Reina em Mim'),
(90, 'Maravilhosa Graça'),
(91, 'Em Tua Presença'),
(92, 'Canta Minh’Alma'),
(93, 'Minha Fé Está em Ti'),
(94, 'Tudo Entregarei'),
(95, 'Ao Teu Nome'),
(96, 'Salvo por Jesus'),
(97, 'Glória ao Salvador'),
(98, 'Liberdade em Cristo'),
(99, 'Senhor do Meu Coração'),
(100, 'Sempre Fiel é o Senhor');



INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 1, '2025-01-01');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 2, '2025-01-02');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 3, '2025-01-03');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 4, '2025-01-04');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 5, '2025-01-05');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 6, '2025-01-06');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 7, '2025-01-07');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 8, '2025-01-08');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 9, '2025-01-09');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 10, '2025-01-10');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 11, '2025-01-11');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 12, '2025-01-12');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 13, '2025-01-13');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 14, '2025-01-14');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 15, '2025-01-15');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 16, '2025-01-16');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 17, '2025-01-17');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 18, '2025-01-18');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 19, '2025-01-19');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 20, '2025-01-20');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 21, '2025-01-21');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 22, '2025-01-22');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 23, '2025-01-23');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 24, '2025-01-24');
INSERT INTO Aluno_Hino (id_aluno, id_hino, data_passagem) VALUES (1, 25, '2025-01-25');
