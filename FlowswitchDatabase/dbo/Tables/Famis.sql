CREATE TABLE [dbo].[Famis] (
    [ID]          SMALLINT      IDENTITY (1, 1) NOT NULL,
    [EquipmentID] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Famis_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.famis', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Famis';

