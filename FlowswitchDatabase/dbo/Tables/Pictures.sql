CREATE TABLE [dbo].[Pictures] (
    [ID]           INT          IDENTITY (2613, 1) NOT NULL,
    [FlowswitchID] INT          NOT NULL,
    [Picture]      VARCHAR (64) NOT NULL,
    CONSTRAINT [PK_Pictures_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.pictures', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Pictures';

