CREATE DATABASE BD_Red_Riders_01;
USE BD_Red_Riders_01;

-- Cadastro do restaurante
CREATE TABLE cadastrar_restaurante (
    id_cres INT PRIMARY KEY AUTO_INCREMENT,
    nome_cres VARCHAR(300),
    telefone_cres VARCHAR(50),
    endereco_cres VARCHAR(400),
    cnpj_cres VARCHAR(50),
    imagem_cres VARCHAR(500)
);

-- Cadastro de cardápios
CREATE TABLE cadastrar_cardapio (
    id_ccar INT PRIMARY KEY AUTO_INCREMENT,
    nome_ccar VARCHAR(300),
    descricao_ccar VARCHAR(400),
    id_cres_fk INT,
    FOREIGN KEY (id_cres_fk) REFERENCES cadastrar_restaurante(id_cres)
);

-- Cadastro de pratos
CREATE TABLE cadastrar_pratos (
    id_cpra INT PRIMARY KEY AUTO_INCREMENT,
    nome_cpra VARCHAR(300),
    preco_cpra FLOAT,
    descricao_cpra VARCHAR(400),
    id_ccar_fk INT,
    FOREIGN KEY (id_ccar_fk) REFERENCES cadastrar_cardapio(id_ccar)
);

-- Cadastro de clientes
CREATE TABLE cadastrar_cliente (
    id_ccli INT PRIMARY KEY AUTO_INCREMENT,
    nome_ccli VARCHAR(300),
    endereco_ccli VARCHAR(400),
    distancia_moradia_ccli VARCHAR(200),
    forma_pagamento_ccli VARCHAR(200),
    forma_contato_ccli VARCHAR(200),
    id_cres_fk INT,
    FOREIGN KEY (id_cres_fk) REFERENCES cadastrar_restaurante(id_cres)
);

-- Cadastro do entregador
CREATE TABLE cadastrar_entregador (
    id_cent INT PRIMARY KEY AUTO_INCREMENT,
    nome_cent VARCHAR(300),
    cpf_cent VARCHAR(15),
    rg_cent VARCHAR(30),
    cnh_cent VARCHAR(30),
    telefone_cent VARCHAR(50)
);

-- Veículos
CREATE TABLE Veiculo (
    id_vei INT PRIMARY KEY AUTO_INCREMENT,
    nome_dono_vei VARCHAR(300),
    modelo_vei VARCHAR(15),
    marca_vei VARCHAR(50),
    placa_vei VARCHAR(50),
    cor_vei VARCHAR(50),
    rotaimg_vei VARCHAR(250),
    id_cent_fk INT,
    FOREIGN KEY (id_cent_fk) REFERENCES cadastrar_entregador(id_cent)
);

-- Novo pedido
CREATE TABLE novo_pedido (
    id_nope INT PRIMARY KEY AUTO_INCREMENT,
    nome_restaurante_nope VARCHAR(300),
    preco_nope FLOAT,
    endereco_entrega_nope VARCHAR(400),
    endereco_buscar_nope VARCHAR(400),
    distancia_nope VARCHAR(100),
    quantidade_nope INT,
    descricao_nope VARCHAR(400),
    cliente_nope VARCHAR(400),
    status_nope VARCHAR(100),
    id_cres_fk INT,
    FOREIGN KEY (id_cres_fk) REFERENCES cadastrar_restaurante(id_cres),
    id_cent_fk INT,
    FOREIGN KEY (id_cent_fk) REFERENCES cadastrar_entregador(id_cent)
);