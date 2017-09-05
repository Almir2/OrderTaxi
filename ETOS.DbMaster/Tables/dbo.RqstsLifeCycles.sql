CREATE TABLE [dbo].[RqstsLifeCycles]
(
	[EventId]		INT	IDENTITY (1, 1)		NOT NULL, 
    [RequestId]		INT						NOT NULL,
    [EventDateTime] DATETIME				NOT NULL, 
    [StatusId]		INT						NOT NULL, 
    [AuthorId]		INT						NOT NULL,
	CONSTRAINT PK_RqstsLifeCycles_EventId PRIMARY KEY (EventId),
	CONSTRAINT FK_RqstsLifeCycles_RequestId FOREIGN KEY (RequestId)
		REFERENCES [dbo].[Requests](RequestId),
	CONSTRAINT FK_RqstsLifeCycles_StatusId FOREIGN KEY (StatusId)
		REFERENCES [dbo].[Statuses](StatusId),
	CONSTRAINT FK_RqstsLifeCycles_AuthorId FOREIGN KEY (AuthorId)
		REFERENCES [dbo].[Employees](EmployeeId),
)