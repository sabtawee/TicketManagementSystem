CREATE TABLE Tickets (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
    Owner NVARCHAR(100),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'In Progress', 'Completed'))
);

select * from Tickets(nolock)


ALTER TABLE Tickets
ADD CreatedAt DATETIME NOT NULL DEFAULT GETDATE();