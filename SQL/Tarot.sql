CREATE TABLE Bills (
    BillId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    PaymentId int NOT NULL,
    BillingDate datetime NULL,
    TotalAmount int,
);

CREATE TABLE Booking (
    BookingId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CustomerId int NOT NULL,
    TarotReaderId int NOT NULL,
    Date date,
    StartTime datetime NULL,
    EndTime datetime NULL,
    Status bit,
    Description varchar(1000),
    ScheduleId int NOT NULL,
);

CREATE TABLE Customer (
    CustomerId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    UserId int NOT NULL,
    Description varchar(1000),
    Status bit,
);

CREATE TABLE Feedback (
    FeedbackId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CustomerId int NOT NULL,
    TarotReaderId int NOT NULL,
    Rating int,
    Comments varchar(1000),
    Date date,
);

CREATE TABLE Payment (
    PaymentId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    BookingId int NOT NULL,
    Amount int,
    PaymentDate datetime NULL,
    PaymentMethod varchar(255),
    Status bit,
);

CREATE TABLE Role (
    RoleId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RoleName varchar(255),
);

CREATE TABLE Schedule (
    ScheduleId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TarotReaderId int NOT NULL,
    Date date,
    StartTime datetime NULL,
    EndTime datetime NULL,
    TotalPrice float,
    CustomerId int NOT NULL,
);

CREATE TABLE SessionType (
    SessionTypeId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
    Description varchar(1000),
    Price float,
    Status bit,
);

CREATE TABLE TarotReader (
    TarotReaderId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    UserId int NOT NULL,
    Description varchar(1000),
    Status bit,
);

CREATE TABLE TarotReaderSessionType (
    TarotReaderId int NOT NULL,
    SessionTypeId int NOT NULL,
);

CREATE TABLE [User] (
    UserId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
    DateOfBirth date,
    PhoneNumber varchar(255),
    Gender int,
    Email varchar(255),
    Password varchar(255),
    Address varchar(1000),
    IsActive bit,
    RoleId int NOT NULL,
);

ALTER TABLE Feedback ADD CONSTRAINT FKFeedback349691 FOREIGN KEY (TarotReaderId) REFERENCES TarotReader (TarotReaderId);
ALTER TABLE Feedback ADD CONSTRAINT FKFeedback523885 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId);
ALTER TABLE [User] ADD CONSTRAINT FKUser68428 FOREIGN KEY (RoleId) REFERENCES Role (RoleId);
ALTER TABLE TarotReader ADD CONSTRAINT FKTarotReade394369 FOREIGN KEY (UserId) REFERENCES [User] (UserId);
ALTER TABLE TarotReaderSessionType ADD CONSTRAINT FKTarotReade300986 FOREIGN KEY (TarotReaderId) REFERENCES TarotReader (TarotReaderId);
ALTER TABLE TarotReaderSessionType ADD CONSTRAINT FKTarotReade360396 FOREIGN KEY (SessionTypeId) REFERENCES SessionType (SessionTypeId);
ALTER TABLE Customer ADD CONSTRAINT FKCustomer106605 FOREIGN KEY (UserId) REFERENCES [User] (UserId);
ALTER TABLE Schedule ADD CONSTRAINT FKSchedule103941 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId);
ALTER TABLE Booking ADD CONSTRAINT FKBooking249093 FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId);
ALTER TABLE Schedule ADD CONSTRAINT FKSchedule769635 FOREIGN KEY (TarotReaderId) REFERENCES TarotReader (TarotReaderId);
ALTER TABLE Booking ADD CONSTRAINT FKBooking848920 FOREIGN KEY (TarotReaderId) REFERENCES TarotReader (TarotReaderId);
ALTER TABLE Booking ADD CONSTRAINT FKBooking92278 FOREIGN KEY (ScheduleId) REFERENCES Schedule (ScheduleId);
ALTER TABLE Payment ADD CONSTRAINT FKPayment52084 FOREIGN KEY (BookingId) REFERENCES Booking (BookingId);
ALTER TABLE Bills ADD CONSTRAINT FKBills90038 FOREIGN KEY (PaymentId) REFERENCES Payment (PaymentId);
