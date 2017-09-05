CREATE TABLE [dbo].[Routes]
(
	[RoutePointId]			INT	IDENTITY (1, 1)		NOT NULL,
	[RequestId]				INT						NOT NULL,
	[DestinationPointId]	INT						NOT NULL,
	[DestinationAddress]	CHAR (255)				NOT NULL,
	[NextRoutePointId]		INT						NOT NULL,
	CONSTRAINT PK_Routes_RoutePointId PRIMARY KEY (RoutePointId),
	CONSTRAINT FK_Routes_NextRoutePointId FOREIGN KEY (NextRoutePointId)
		REFERENCES [dbo].[Routes](RoutePointId),
	CONSTRAINT FK_Routes_RequestId FOREIGN KEY (RequestId)
		REFERENCES [dbo].[Requests](RequestId),
	CONSTRAINT FK_Routes_DestinationPointId FOREIGN KEY (DestinationPointId)
		REFERENCES [dbo].[Locations](LocationId),
)