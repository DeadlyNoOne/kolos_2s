CREATE TABLE Organization (
	OrganizationID int NOT NULL IDENTITY AUTO_INCREMENT;
	OrganizationName nvarchar(100) NOT NULL;
	OrganizationDomain nvarchar(50) NOT NULL;
	CONSTRAINT Organization_pk PRIMARY KEY (OrganizationID);
)

INSERT INTO Organization(OrganizationName, OrganizationDomain)
VALUES {
	(ExDeLi sp zoo, XDL),
	(Apple Inc, Apple),
	(Starzyzm, Oldies),
	(AAAAAAAAA, AAA)
}

CREATE TABLE Membership (
	MemberID int NOT NULL;
	TeamID	int NOT NULL;
	MembershipDate datetime NOT NULL;
	CONSTRAINT Membership_pk PRIMARY KEY (MemberID, TeamID);
)

CREATE TABLE Team (
	TeamID int NOT NULL IDENTITY AUTO_INCREMENT;
	OrganizationID int NOT NULL;
	TeamName nvarchar(50) NOT NULL;
	TeamDescription nvarchar(500);
	CONSTRAINT Team_pk PRIMARY KEY (TeamID);
)

CREATE TABLE Member (
	MemberID int NOT NULL IDENTITY AUTO_INCREMENT;
	OrganizationID int NOT NULL;
	MemberName nvarchar(20) NOT NULL;
	MemberSurname nvarchar(50) NOT NULL;
	MemberNickName nvarchar(20);
	CONSTRAINT Member_pk PRIMARY KEY (MemberID);
)

CREATE TABLE File (
	FileID int NOT NULL IDENTITY AUTO_INCREMENT;
	TeamID int NOT NULL IDENTITY;
	FileName nvarchar(100) NOT NULL;
	FileExtension nvarchar(4) NOT NULL;
	FileSize int NOT NULL;
	CONSTRAINT File_pk PRIMARY KEY (FileID, TeamID);
)

ALTER TABLE Membership ADD CONSTRAINT Membership_MID
    FOREIGN KEY (MemberID)
    REFERENCES Member (MemberID);
	
ALTER TABLE Membership ADD CONSTRAINT Membership_TID
    FOREIGN KEY (TeamID)
    REFERENCES Team (TeamID);
	
ALTER TABLE Member ADD CONSTRAINT Member_Org
    FOREIGN KEY (OrganizationID)
    REFERENCES Organization (OrganizationID);
	
ALTER TABLE File ADD CONSTRAINT File_TID
    FOREIGN KEY (TeamID)
    REFERENCES Team	(TeamID);	
	
ALTER TABLE Team ADD CONSTRAINT Team_OID
    FOREIGN KEY (OrganizationID)
    REFERENCES Organization	(OrganizationID);
	
INSERT INTO Team(OrganizationID, TeamName, TeamDescription)
VALUES
	(2, WindowsHaters, NULL),
	(2, LinuxHaters, NULL),
	(1, FoodDeli, NULL),
	(4, Indian Death Blow, AAAAAAAAAAAAAAA),
	(3, YeOlde, ASDF);
	
INSERT INTO Member (OrganizationID, MemberName, MemberSurname, MemberNickName)
VALUES
	(1, Kaleen, Byardhar, Kalib),
	(2, Steve, Jobs, Boss),
	(3, Janusz, Kowalski, RainbowCrayola),
	(4, Har, Kush, AAAAAA);
	
INSERT INTO File(TeamID, FileName, FileExtension, FileSize)
VALUES
	(1, HowToKillMicrosoft, txt, 666),
	(2, Program, sh, 93485),
	(1, PiratedVirus, dmg, 300),
	(3, Food, jpg, 22222),
	(4, AAAAA, bbb, 99999),
	(5, BoomerTalk, exe, 8347512),
	(2, Arduino, tar, 3497452689),
	(4, BBBBB, aaa, 11111);

INSERT INTO Membership(MemberID, TeamID, MembershipDate)
VALUES
	(1, 3, 09-09-2021),
	(2, 1, 18-03-1980),
	(3, 5, 15-12-2003),
	(4, 4, 11-11-2011);

