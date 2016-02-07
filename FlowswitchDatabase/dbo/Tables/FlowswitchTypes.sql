CREATE TABLE [dbo].[FlowswitchTypes] (
    [ID]   INT          IDENTITY (54, 1) NOT NULL,
    [Type] VARCHAR (48) NOT NULL,
    CONSTRAINT [PK_Type_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.type', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FlowswitchTypes';

