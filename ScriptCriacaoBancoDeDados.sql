CREATE DATABASE IF NOT EXISTS db_locacaoimoveis;
USE db_locacaoimoveis;


CREATE TABLE IF NOT EXISTS imoveis (
    Id CHAR(36) NOT NULL PRIMARY KEY, 
    Cep VARCHAR(8) NOT NULL,           
    Adress VARCHAR(255) NOT NULL,      
    Neighborhood VARCHAR(255) NOT NULL,
    City VARCHAR(100) NOT NULL,
    State VARCHAR(2) NOT NULL,         
    Value DECIMAL(10,2) NOT NULL,      
    Status INT NOT NULL CHECK (Status BETWEEN 1 AND 3) 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE INDEX idx_imoveis_cep ON imoveis(Cep);