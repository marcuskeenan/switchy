CREATE TABLE [dbo].[Rotameters] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (MAX) NULL,
    [Type] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Rotameters_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.rotameters', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rotameters';

