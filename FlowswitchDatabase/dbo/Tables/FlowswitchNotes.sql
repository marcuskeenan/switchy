CREATE TABLE [dbo].[FlowswitchNotes] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [IDold]        INT           NULL,
    [Note]         VARCHAR (128) NOT NULL,
    [FlowswitchID] INT           NOT NULL,
    CONSTRAINT [PK__FlowswitchNotes_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_FlowswitchNotes_Flowswitches] FOREIGN KEY ([FlowswitchID]) REFERENCES [dbo].[Flowswitches] ([ID])
);

