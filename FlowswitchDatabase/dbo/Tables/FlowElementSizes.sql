CREATE TABLE [dbo].[FlowElementSizes] (
    [ID]                 INT          IDENTITY (1, 1) NOT NULL,
    [FlowElementModelID] INT          NOT NULL,
    [Size]               VARCHAR (48) NULL,
    CONSTRAINT [PK_FlowElementSizes_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_FlowElementSizes_FlowElementModel] FOREIGN KEY ([FlowElementModelID]) REFERENCES [dbo].[FlowElementModel] ([ID])
);

