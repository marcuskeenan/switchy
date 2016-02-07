CREATE TABLE [dbo].[Notes] (
    [ID]   INT           IDENTITY (12330, 1) NOT NULL,
    [Note] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Notes_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.notes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Notes';

