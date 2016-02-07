CREATE TABLE [dbo].[FlowswitchModel] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [FlowSwitchMakeID] INT           NOT NULL,
    [Model]            VARCHAR (48)  NULL,
    [Description]      VARCHAR (MAX) NULL,
    CONSTRAINT [PK_FlowswitchModel_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_FlowswitchModel_FlowswitchMake] FOREIGN KEY ([FlowSwitchMakeID]) REFERENCES [dbo].[FlowswitchMake] ([ID])
);

