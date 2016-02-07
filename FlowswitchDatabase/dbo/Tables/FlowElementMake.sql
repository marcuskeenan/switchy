CREATE TABLE [dbo].[FlowElementMake] (
    [ID]   INT          IDENTITY (1, 1) NOT NULL,
    [Make] VARCHAR (48) NULL,
    CONSTRAINT [PK_FlowElementMake_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);

