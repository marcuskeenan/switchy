CREATE TABLE [dbo].[Venturis] (
    [ID]   INT          IDENTITY (98, 1) NOT NULL,
    [Type] VARCHAR (48) NOT NULL,
    [Size] VARCHAR (16) NOT NULL,
    CONSTRAINT [PK_Venturis_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.venturis', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Venturis';

