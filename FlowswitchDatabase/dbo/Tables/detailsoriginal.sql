CREATE TABLE [dbo].[detailsoriginal] (
    [ID]     INT           IDENTITY (195, 1) NOT NULL,
    [Detail] VARCHAR (128) NOT NULL,
    CONSTRAINT [PK_details_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'detailsoriginal';

