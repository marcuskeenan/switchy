CREATE TABLE [dbo].[FlowElements] (
    [ID]                INT IDENTITY (1, 1) NOT NULL,
    [FlowElementTypeID] INT NULL,
    [MakeID]            INT NULL,
    [ModelID]           INT NULL,
    [SizeID]            INT NULL,
    CONSTRAINT [PK_FlowElements_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_FlowElements_FlowElementMake] FOREIGN KEY ([MakeID]) REFERENCES [dbo].[FlowElementMake] ([ID]),
    CONSTRAINT [FK_FlowElements_FlowElementTypes] FOREIGN KEY ([FlowElementTypeID]) REFERENCES [dbo].[FlowElementTypes] ([ID])
);

