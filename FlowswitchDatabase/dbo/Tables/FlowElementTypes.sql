CREATE TABLE [dbo].[FlowElementTypes] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Type]        VARCHAR (MAX) NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_FlowElementTypes_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);

