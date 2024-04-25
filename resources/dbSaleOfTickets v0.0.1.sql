create database dbSaleOfTickets;

use dbSaleOfTickets;

create table subsidiary (
    idSubsidiary char(12) not null,
    name varchar(100) not null,
    address varchar(255) not null,
    city varchar(100) not null,
    cellPhone varchar(20) not null,
    email varchar(100) not null,
    openingHours varchar(255) not null,
    manager varchar(100) not null,
    description TEXT,

    primary key (idSubsidiary)
) engine = InnoDB;

create table user (
    idUser char(12) not null,
    idSubsidiary char(12) not null,
    username varchar(100) unique not null,
    password varchar(100) not null,
    firstName varchar(50) not null,
    surName varchar(50) not null,
    dni char(8) unique not null,
    birthDate date not null,
    gender bit not null,
    registerDate datetime not null,
    modificationDate datetime not null,

    primary key (idUser),
    foreign key (idSubsidiary) references subsidiary(idSubsidiary)
) engine = InnoDB;


create table vehicle (
    idVehicle char(12) not null,
    plate varchar(7) unique not null,
    model varchar(50) not null,
    seats int not null,
    state bit not null,
    description text,
    registerDate datetime not null,
    modificationDate datetime not null,

    primary key (idVehicle)
) engine = InnoDB;

create table origin (
    idOrigin char(12) not null,
    city varchar(100) not null,
    state bit not null,
    registerDate datetime not null,
    modificationDate datetime not null,

    primary key (idOrigin)
) engine = InnoDB;

create table destiny (
    idDestiny char(12) not null,
    city varchar(100) not null,
    state bit not null,
    registerDate datetime not null,
    modificationDate datetime not null,


    primary key (idDestiny)
) engine = InnoDB;

create table programming (
    idProgramming char(36) not null,
    idOrigin char(12) not null,
    idDestiny char(12) not null,
    idVehicle char(12) not null,
    programmingDate date not null,
    programmingHour time not null,
    state bit not null default 1,

    primary key (idProgramming),
    foreign key (idOrigin) references origin(idOrigin),
    foreign key (idDestiny) references destiny(idDestiny),
    foreign key (idVehicle) references vehicle(idVehicle)
) engine = InnoDB;

create table client (
    idClient char(36) not null,
    identityCard char(20) not null,
    numberCard char(15) unique not null,
    firstName varchar(70) not null,
    surName varchar(40) not null,
    gender bit not null,
    cellPhone char(9) unique not null,
    email varchar(50) unique not null,
    address varchar(100) not null,

    primary key (idClient)
) engine = InnoDB;

create table sale (
    idSale char(36) not null,
    idClient char(36) not null,
    serie varchar(50) unique not null,
    resgisterDate date not null,
    travelDate date not null,
    travelTime time not null,
    totalPrice decimal(10,3) not null,
    state varchar(15) not null,
    description text null,

    primary key (idSale),
    foreign key (idClient) references client(idClient)
) engine = InnoDB;

create table ticket (
    idTicket char(36) not null,
    idSale char(36) not null,
    idProgramming char(36) not null,
    idSubsidiary char(12) not null,
    origin varchar(50) not null,
    destination varchar(50) not null,
    seatNumber int not null,
    registerDate date not null,
    travelDate date not null,
    travelTime time not null,
    price decimal(10,3) not null,
    state char not null,
    description text null,

    primary key (idTicket),
    foreign key (idSale) references sale(idSale),
    foreign key (idProgramming) references programming(idProgramming),
    foreign key (idSubsidiary) references subsidiary(idSubsidiary)
) engine = InnoDB;


create table reserve (
    idReserver char(36) not null,
    idClient char(36) not null,
    idProgramming char(36) not null,
    serie varchar(25) unique not null,
    resgisterDate date not null,
    travelDate date not null,
    travelTime time not null,
    advancement decimal(10,3) not null,
    state varchar(15) not null,
    description text not null,

    primary key (idReserver),
    foreign key (idClient) references client(idClient),
    foreign key (idProgramming) references programming(idProgramming)
) engine = INNODB;


INSERT INTO subsidiary (idSubsidiary, name, address, city, cellPhone, email, openingHours, manager, description) 
VALUES 
('697337296cd1', 'Main Subsidiary', '123 Main Street', 'Cityville', '123-456-7890', 'main@example.com', 'Mon-Fri: 9am-6pm', 'John Manager', 'Main subsidiary location');


INSERT INTO user (idUser,idSubsidiary, username, password, firstName, surName, dni, birthDate, gender, registerDate, modificationDate) 
VALUES 
('0e8e83e5389e', '697337296cd1', 'Lionos', '1001linux', 'Henry', 'Leon', '73505700', '2000-05-15', 1, NOW(), NOW()),
('0e8e83e5386g', '697337296cd1', 'admin', 'admin', 'Jane', 'Smith', '87654321', '1995-08-20', 0, NOW(), NOW());



