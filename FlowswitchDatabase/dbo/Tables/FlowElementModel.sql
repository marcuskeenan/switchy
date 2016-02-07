CREATE TABLE [dbo].[FlowElementModel] (
    [ID]                INT          IDENTITY (1, 1) NOT NULL,
    [FlowElementMakeID] INT          NOT NULL,
    [Model]             VARCHAR (48) NULL,
    CONSTRAINT [PK_FlowElementModel_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_FlowElementModel_FlowElementMake] FOREIGN KEY ([FlowElementMakeID]) REFERENCES [dbo].[FlowElementMake] ([ID])
);

