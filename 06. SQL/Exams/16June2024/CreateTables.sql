--		1. Create DB and Tables

CREATE DATABASE LibraryDb;
GO

USE LibraryDb;
GO

CREATE TABLE Contacts (
    Id INT PRIMARY KEY IDENTITY,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    PostAddress NVARCHAR(200),
    Website NVARCHAR(50)
);

CREATE TABLE Authors (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    ContactId INT NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE Genres (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30) NOT NULL
);


CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    YearPublished INT NOT NULL,
    ISBN NVARCHAR(13) UNIQUE NOT NULL,
    AuthorId INT NOT NULL,
    GenreId INT NOT NULL,
    FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    FOREIGN KEY (GenreId) REFERENCES Genres(Id)
);

CREATE TABLE Libraries (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    ContactId INT NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE LibrariesBooks (
    LibraryId INT NOT NULL,
    BookId INT NOT NULL,
    PRIMARY KEY (LibraryId, BookId),
    FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
    FOREIGN KEY (BookId) REFERENCES Books(Id)
);

