CREATE TABLE [dbo].[WaterSources] (
    [ID]     INT          IDENTITY (58, 1) NOT NULL,
    [Source] VARCHAR (48) NOT NULL,
    CONSTRAINT [PK_WaterSources_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.watersources', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WaterSources';

