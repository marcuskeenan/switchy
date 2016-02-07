CREATE TABLE [dbo].[Details2] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [IDold]        INT           NOT NULL,
    [Detail]       VARCHAR (128) NOT NULL,
    [FlowswitchID] INT           NOT NULL,
    CONSTRAINT [PK__Details2__3214EC27440B1D61] PRIMARY KEY CLUSTERED ([ID] ASC)
);

