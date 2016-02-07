CREATE TABLE [dbo].[Locations] (
    [ID]       INT           IDENTITY (595, 1) NOT NULL,
    [Location] VARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Locations_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.locations', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Locations';

