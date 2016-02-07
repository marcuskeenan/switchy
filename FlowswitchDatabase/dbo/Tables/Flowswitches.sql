CREATE TABLE [dbo].[Flowswitches] (
    [ID]                INT          IDENTITY (2585, 1) NOT NULL,
    [AreaID]            INT          NOT NULL,
    [LocationID]        INT          NOT NULL,
    [VenturiID]         INT          NOT NULL,
    [WaterID]           INT          NOT NULL,
    [SubsystemID]       INT          NOT NULL,
    [TypeID]            INT          NOT NULL,
    [DetailID]          INT          NOT NULL,
    [Name]              VARCHAR (64) NOT NULL,
    [Alias]             VARCHAR (64) NOT NULL,
    [FlowswitchMakeID]  INT          NULL,
    [FlowswitchModelID] INT          NULL,
    CONSTRAINT [PK_Flowswitches_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Flowswitches_Areas] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Areas] ([ID]),
    CONSTRAINT [FK_Flowswitches_FlowswitchMake] FOREIGN KEY ([FlowswitchMakeID]) REFERENCES [dbo].[FlowswitchMake] ([ID]),
    CONSTRAINT [FK_Flowswitches_FlowswitchModel] FOREIGN KEY ([FlowswitchModelID]) REFERENCES [dbo].[FlowswitchModel] ([ID]),
    CONSTRAINT [FK_Flowswitches_Locations] FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Locations] ([ID]),
    CONSTRAINT [FK_Flowswitches_SubSystems] FOREIGN KEY ([SubsystemID]) REFERENCES [dbo].[SubSystems] ([ID]),
    CONSTRAINT [FK_Flowswitches_Type] FOREIGN KEY ([TypeID]) REFERENCES [dbo].[FlowswitchTypes] ([ID]),
    CONSTRAINT [FK_Flowswitches_Venturis] FOREIGN KEY ([VenturiID]) REFERENCES [dbo].[Venturis] ([ID]),
    CONSTRAINT [FK_Flowswitches_WaterSources] FOREIGN KEY ([WaterID]) REFERENCES [dbo].[WaterSources] ([ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.flowswitches', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Flowswitches';

