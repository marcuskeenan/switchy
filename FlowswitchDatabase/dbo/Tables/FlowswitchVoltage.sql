CREATE TABLE [dbo].[FlowswitchVoltage] (
    [ID]      INT          IDENTITY (1, 1) NOT NULL,
    [Voltage] VARCHAR (12) NULL,
    CONSTRAINT [PK_FlowswitchVoltage_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);

