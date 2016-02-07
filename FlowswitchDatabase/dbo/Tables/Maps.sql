CREATE TABLE [dbo].[Maps] (
    [ID]               INT NOT NULL,
    [FlowswitchID]     INT NOT NULL,
    [NoteID]           INT NOT NULL,
    [ServiceRequestID] INT NOT NULL,
    CONSTRAINT [PK_Maps_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.maps', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Maps';

