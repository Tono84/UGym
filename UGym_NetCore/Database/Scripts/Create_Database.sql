-- ================================= Table Creation - Beginning ================================ --

CREATE DATABASE UGym;

USE UGym;

-- =========================== 1. EmergencyContact Table - Beginning =========================== --

CREATE TABLE EmergencyContact (
    EmergencyContactId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    MobileNumber INT NOT NULL
);

-- ============================== 1. EmergencyContact Table - End ============================== --


-- =============================== 2. MembFile Table - Beginning =============================== --

CREATE TABLE MembFile (
    MembFileId INT IDENTITY(1,1) PRIMARY KEY,
    CirguriesType NVARCHAR(100) NOT NULL,
    QuantCirguries INT NOT NULL,
    DetailCirguries NVARCHAR(100),
    TypeMeds NVARCHAR(100),
    QuantMeds INT,
    AlergyMeds NVARCHAR(100),
    HeartDis NVARCHAR(100),
    ChestPain NVARCHAR(50),
    TimeSitting INT,
    SleepCycle INT,
    LastMonthStress INT,
    TrainMotivation INT,
    FatDifLoss NVARCHAR(50),
    LMonthEnergy NVARCHAR(50),
    StepsDay INT,
    ThreeMonthEx NVARCHAR(5),
    AttendanceMotivation NVARCHAR(20),
    AutoReg NVARCHAR(50),
    Focus INT,
    Nutrition INT,
    StressNutrition NVARCHAR(25)
);

-- ================================== 2. MembFile Table - End ================================== --


-- ================================ 3. QRCode Table - Beginning ================================ --

CREATE TABLE QRCode (
    QRCodeId INT IDENTITY(1,1) PRIMARY KEY,
    LinkQR NVARCHAR(500) NOT NULL
);

-- =================================== 3. QRCode Table - End =================================== --


-- ================================ 4. Roles Table - Beginning ================================= --

CREATE TABLE Roles (
    RolesId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Description NVARCHAR(250)
);

-- =================================== 4. Roles Table - End ==================================== --


-- ============================== 5. Employees Table - Beginning =============================== --

CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeNumber INT NOT NULL,
    Password NVARCHAR(500) NOT NULL,
    FullName NVARCHAR(150) NOT NULL,
    Birthday DATE,
    Gender NVARCHAR(15),
    Email NVARCHAR(100) NOT NULL,
    Address NVARCHAR(150) NOT NULL,
    MobileNumber INT NOT NULL,
    EmergencyContactId INT,
    RoleId INT NOT NULL,
	CONSTRAINT FK_Employees_ContactoEmergencia
		FOREIGN KEY (EmergencyContactId) REFERENCES EmergencyContact(EmergencyContactId),
	CONSTRAINT FK_Employees_Roles
		FOREIGN KEY (RoleId) REFERENCES Roles(RolesId)
);

-- ================================= 5. Employees Table - End ================================== --


-- =============================== 6. Members Table - Beginning ================================ --

CREATE TABLE Members (
    MemberId INT IDENTITY(1,1) PRIMARY KEY,
    MemberNumb INT NOT NULL,
    Password NVARCHAR(500) NOT NULL,
    FullName NVARCHAR(250) NOT NULL,
    Gender NVARCHAR(15),
    Cedula INT NOT NULL,
    Birthday DATE NOT NULL,
    Ocupation NVARCHAR(100),
    KnowGym NVARCHAR(150),
    Motivation NVARCHAR(250),
    Email NVARCHAR(150) NOT NULL,
    Address NVARCHAR(250) NOT NULL,
    MobileNumber NVARCHAR(15) NOT NULL,
    EmergencyContactId INT NOT NULL,
    MembFileId INT,
    QRCodeId INT,
    EmployeeId INT,
    RoleId INT NOT NULL,
	CONSTRAINT FK_Members_EmergencyContact
		FOREIGN KEY (EmergencyContactId) REFERENCES EmergencyContact(EmergencyContactId),
	CONSTRAINT FK_Members_MembFile
		FOREIGN KEY (MembFileId) REFERENCES MembFile(MembFileId),
	CONSTRAINT FK_Members_QRCode
		FOREIGN KEY (QRCodeId) REFERENCES QRCode(QRCodeId),
	CONSTRAINT FK_Members_Employees
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
	CONSTRAINT FK_Members_Roles
		FOREIGN KEY (RoleId) REFERENCES Roles(RolesId)
);

-- ================================== 6. Members Table - End =================================== --


-- =========================== 7. PaymentFrequency Table - Beginning =========================== --

CREATE TABLE PaymentFrequency (
    PaymentId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(25) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Amount DECIMAL(10,2) NOT NULL
);

-- ============================== 7. PaymentFrequency Table - End ============================== --


-- ======================= 8. MembersPaymentFrequency Table - Beginning ======================== --

CREATE TABLE MembersPaymentFrequency (
    MemberId INT NOT NULL,
    PaymentId INT NOT NULL,
    DatePayment DATE NOT NULL,
    PRIMARY KEY (MemberId, PaymentId),
	CONSTRAINT FK_MembersPaymentFrequency_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
	CONSTRAINT FK_MembersPaymentFrequency_PaymentFrequency
		FOREIGN KEY (PaymentId) REFERENCES PaymentFrequency(PaymentId)
);

-- ========================== 8. MembersPaymentFrequency Table - End =========================== --


-- =========================== 9. MembershipTypes Table - Beginning ============================ --

CREATE TABLE MembershipTypes (
    MembershipTypeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Type NVARCHAR(50) NOT NULL
);

-- ============================== 9. MembershipTypes Table - End =============================== --


-- ======================= 10. MembersMembershipTypes Table - Beginning ======================== --

CREATE TABLE MembersMembershipTypes (
    MemberId INT NOT NULL,
    MembershipTypeId INT NOT NULL,
    DateStart DATE NOT NULL,
    DateExp DATE NOT NULL,
    Status NVARCHAR(50),
    PRIMARY KEY (MemberId, MembershipTypeId),
	CONSTRAINT FK_MembersMembershipTypes_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
	CONSTRAINT FK_MembersMembershipTypes_MembershipTypes
		FOREIGN KEY (MembershipTypeId) REFERENCES MembershipTypes(MembershipTypeId)
);

-- ========================== 10. MembersMembershipTypes Table - End =========================== --


-- =============================== 11. Admins Table - Beginning ================================ --

CREATE TABLE Admins (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    RoleId INT NOT NULL,
	CONSTRAINT FK_Admins_Roles
		FOREIGN KEY (RoleId) REFERENCES Roles(RolesId)
);

-- ================================== 11. Admins Table - End =================================== --


-- =========================== 12. RepCardsTherapy Table - Beginning =========================== --

CREATE TABLE RepCardsTherapy (
    RepCardTherapyId INT IDENTITY(1,1) PRIMARY KEY,
    LinkRepCardTherapy NVARCHAR(500) NOT NULL,
    DateLoad DATE NOT NULL,
    MemberId INT NOT NULL,
    EmployeeId INT NOT NULL,
	CONSTRAINT FK_RepCardsTherapy_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
	CONSTRAINT FK_RepCardsTherapy_Employees
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- ============================== 12. RepCardsTherapy Table - End ============================== --


-- =========================== 13. RepCardsInbody Table - Beginning ============================ --

CREATE TABLE RepCardsInbody (
    InformeInbodyId INT IDENTITY(1,1) PRIMARY KEY,
    LinkRepCardeInbody NVARCHAR(500) NOT NULL,
    DateLoad DATE NOT NULL,
    MemberId INT NOT NULL,
    EmployeeId INT NOT NULL,
	CONSTRAINT FK_RepCardsInbody_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
	CONSTRAINT FK_RepCardsInbody_Employees
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- ============================== 13. RepCardsInbody Table - End =============================== --


-- ============================ 14. NutritionPlan Table - Beginning ============================ --

CREATE TABLE NutritionPlan (
    NutritionPlanId INT IDENTITY(1,1) PRIMARY KEY,
    NutritionPlan NVARCHAR(500) NOT NULL,
    DateLoad DATE NOT NULL,
    MemberId INT NOT NULL,
    EmployeeId INT NOT NULL,
	CONSTRAINT FK_NutritionPlan_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
	CONSTRAINT FK_NutritionPlan_Employees
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- =============================== 14. NutritionPlan Table - End =============================== --


-- ========================= 15. RepCardsEvaluation Table - Beginning ========================== --

CREATE TABLE RepCardsEvaluation (
    RepCardEvaluationId INT IDENTITY(1,1) PRIMARY KEY,
    LinkRepCardEvaluation NVARCHAR(500) NOT NULL,
    DateLoad DATE NOT NULL,
    MemberId INT NOT NULL,
    EmployeeId INT NOT NULL,
	CONSTRAINT FK_RepCardsEvaluation_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
	CONSTRAINT FK_RepCardsEvaluation_Employees
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- ============================ 15. RepCardsEvaluation Table - End ============================= --


-- ============================== 16. Template Table - Beginning =============================== --

CREATE TABLE Template (
    TemplateId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- ================================= 16. Template Table - End ================================== --


-- ============================== 17. Routines Table - Beginning =============================== --

CREATE TABLE Routines (
    RoutineId INT IDENTITY(1,1) PRIMARY KEY,
    DateCreation DATE NOT NULL,
    EmployeeId INT NOT NULL,
    Comments NVARCHAR(500),
    TemplateId INT,
	CONSTRAINT FK_Routines_Employees
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
	CONSTRAINT FK_Routines_Template
		FOREIGN KEY (TemplateId) REFERENCES Template(TemplateId)
);

-- ================================= 17. Routines Table - End ================================== --


-- ============================== 18. Exercices Table - Beginning ============================== --

CREATE TABLE Exercices (
    ExerciceId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Video NVARCHAR(250)
);

-- ================================= 18. Exercices Table - End ================================= --


-- ========================== 19. RoutinesExercices Table - Beginning ========================== --

CREATE TABLE RoutinesExercices (
    RoutineId INT NOT NULL,
    ExerciseId INT NOT NULL,
    Description NVARCHAR(250),
    Duration TIME,
    Series INT,
    Reps INT,
    PRIMARY KEY (RoutineId, ExerciseId),
	CONSTRAINT FK_RoutinesExercices_Routines
		FOREIGN KEY (RoutineId) REFERENCES Routines(RoutineId),
	CONSTRAINT FK_RoutinesExercices_Exercices
		FOREIGN KEY (ExerciseId) REFERENCES Exercices(ExerciceId)
);

-- ============================= 19. RoutinesExercices Table - End ============================= --


-- ====================== 20. MembersRoutinesExercices Table - Beginning ======================= --

CREATE TABLE MembersRoutinesExercices (
    MemberId INT NOT NULL,
    RoutineId INT NOT NULL,
    ExerciseId INT NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    PRIMARY KEY (MemberId, RoutineId, ExerciseId),
    CONSTRAINT FK_MembersRoutinesExercices_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
    CONSTRAINT FK_MembersRoutinesExercices_RoutinesExercices
		FOREIGN KEY (RoutineId, ExerciseId) REFERENCES RoutinesExercices(RoutineId, ExerciseId)
);

-- ========================= 20. MembersRoutinesExercices Table - End ========================== --


-- ========================= 21. TemplatesExercices Table - Beginning ========================== --

CREATE TABLE TemplatesExercices (
    TemplateId INT NOT NULL,
    ExerciceId INT NOT NULL,
    Description NVARCHAR(250),
    Duration TIME,
    Series INT,
    Reps INT,
    PRIMARY KEY (TemplateId, ExerciceId),
	CONSTRAINT FK_TemplatesExercices_Template
		FOREIGN KEY (TemplateId) REFERENCES Template(TemplateId),
	CONSTRAINT FK_TemplatesExercices_Exercices
		FOREIGN KEY (ExerciceId) REFERENCES Exercices(ExerciceId)
);

-- ============================ 21. TemplatesExercices Table - End ============================= --


-- =============================== 22. Classes Table - Beginning =============================== --

CREATE TABLE Classes (
    ClassId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- ================================== 22. Classes Table - End ================================== --


-- =========================== 23. CoachesClasses Table - Beginning ============================ --

CREATE TABLE CoachesClasses (
    ClassId INT NOT NULL,
    CoachId INT NOT NULL,
    Slots INT NOT NULL,
    Date DATE NOT NULL,
    Time TIME NOT NULL,
    PRIMARY KEY (ClassId, CoachId),
	CONSTRAINT FK_CoachesClasses_Classes
		FOREIGN KEY (ClassId) REFERENCES Classes(ClassId),
	CONSTRAINT FK_CoachesClasses_Employees
		FOREIGN KEY (CoachId) REFERENCES Employees(EmployeeId)
);

-- ============================== 23. CoachesClasses Table - End =============================== --


-- ======================== 24. MembersCoachesClasses Table - Beginning ======================== --

CREATE TABLE MembersCoachesClasses (
    ClassesId INT NOT NULL,
	CoachId INT NOT NULL,
    MemberId INT NOT NULL,
    Description NVARCHAR(250),
    PRIMARY KEY (ClassesId,CoachId, MemberId),
	CONSTRAINT FK_MembersCoachesClasses_Classes
		FOREIGN KEY (CoachId, ClassesId) REFERENCES CoachesClasses(ClassId, CoachId),
	CONSTRAINT FK_MembersCoachesClasses_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId)
);

-- =========================== 24. MembersCoachesClasses Table - End =========================== --


-- =============================== 25. Spaces Table - Beginning ================================ --

CREATE TABLE Spaces (
    SpacesId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- ================================== 25. Spaces Table - End =================================== --


-- ============================ 26. Reservations Table - Beginning ============================= --

CREATE TABLE Reservations (
    ReservationId INT IDENTITY(1,1) PRIMARY KEY,
    DateReservation DATE NOT NULL,
    TimeReservationStart TIME NOT NULL,
    TimeReservationEnd TIME NOT NULL,
    MemberId INT NOT NULL,
    SpacesId INT NOT NULL,
	CONSTRAINT FK_Reservations_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
	CONSTRAINT FK_Reservations_Spaces
		FOREIGN KEY (SpacesId) REFERENCES Spaces(SpacesId)
);

-- =============================== 26. Reservations Table - End ================================ --


-- ================================= 27. Ads Table - Beginning ================================= --

CREATE TABLE Ads (
    AdId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    MediaLink NVARCHAR(250),
    EmployeeId INT NOT NULL,
	CONSTRAINT FK_Ads_Employees
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- ==================================== 27. Ads Table - End ==================================== --


-- =============================== 28. Reports Table - Beginning =============================== --

CREATE TABLE Reports (
    ReportId INT IDENTITY(1,1) PRIMARY KEY,
    ReportName NVARCHAR NOT NULL,
    DateCreated DATE NOT NULL,
    ReportType NVARCHAR(50) NOT NULL,
    Description NVARCHAR(200),
    ReportDate TEXT,
    EmployeeId INT NOT NULL,
	CONSTRAINT FK_Reports_Employees
		FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- ================================== 28. Reports Table - End ================================== --


-- ============================= 29. Attendance Table - Beginning ============================== --

CREATE TABLE Attendance (
    AttendanceId INT IDENTITY(1,1) PRIMARY KEY,
    DateAttendance DATE NOT NULL,
    TimeAttendance TIME NOT NULL,
    MemberId INT NOT NULL,
	CONSTRAINT FK_Attendance_Members
		FOREIGN KEY (MemberId) REFERENCES Members(MemberId)
);

-- ================================ 29. Attendance Table - End ================================= --

-- =================================== Table Creation - End ==================================== --