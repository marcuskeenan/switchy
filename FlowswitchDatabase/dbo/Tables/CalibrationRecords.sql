CREATE TABLE [dbo].[CalibrationRecords] (
    [ID]               INT           IDENTITY (12053, 1) NOT NULL,
    [MaxInches]        VARCHAR (11)  CONSTRAINT [DF__calibrati__MaxIn__00551192] DEFAULT (NULL) NULL,
    [MaxGallons]       VARCHAR (11)  CONSTRAINT [DF__calibrati__MaxGa__014935CB] DEFAULT (NULL) NULL,
    [TripInches]       VARCHAR (11)  CONSTRAINT [DF__calibrati__TripI__023D5A04] DEFAULT (NULL) NULL,
    [TripGallons]      VARCHAR (11)  CONSTRAINT [DF__calibrati__TripG__03317E3D] DEFAULT (NULL) NULL,
    [TechnicianID]     INT           CONSTRAINT [DF__calibrati__Techn__0425A276] DEFAULT (NULL) NULL,
    [DateAdded]        DATETIME2 (0) CONSTRAINT [DF__calibrati__DateA__0519C6AF] DEFAULT (NULL) NULL,
    [FlowswitchID]     INT           NOT NULL,
    [Note]             VARCHAR (255) NULL,
    [ServiceRequestID] INT           NULL,
    CONSTRAINT [PK_CalibrationRecords_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_CalibrationRecords_Flowswitches] FOREIGN KEY ([FlowswitchID]) REFERENCES [dbo].[Flowswitches] ([ID]),
    CONSTRAINT [FK_CalibrationRecords_ServiceRequests] FOREIGN KEY ([ServiceRequestID]) REFERENCES [dbo].[ServiceRequests] ([ID]),
    CONSTRAINT [FK_CalibrationRecords_Technicians] FOREIGN KEY ([TechnicianID]) REFERENCES [dbo].[Technicians] ([ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.calibrationrecords', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CalibrationRecords';

