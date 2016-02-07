CREATE TABLE [dbo].[Areas] (
    [ID]              INT          IDENTITY (94, 1) NOT NULL,
    [Area]            VARCHAR (64) NOT NULL,
    [AreaDescription] VARCHAR (64) DEFAULT (NULL) NULL,
    CONSTRAINT [PK_Areas_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.areas', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Areas';

