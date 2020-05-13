CREATE TABLE [dbo].[Student] (
    [StudentID]      INT           IDENTITY (1, 1) NOT NULL,
    [LastName]       NVARCHAR (50) NOT NULL,
    [FirstName]      NVARCHAR (50) NOT NULL,
    [EnrollmentDate] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC)
)