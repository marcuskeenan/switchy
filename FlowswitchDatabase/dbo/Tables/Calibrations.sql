CREATE TABLE [dbo].[Calibrations] (
    [ID]           INT           IDENTITY (12053, 1) NOT NULL,
    [MaxInches]    VARCHAR (11)  DEFAULT (NULL) NULL,
    [MaxGallons]   VARCHAR (11)  DEFAULT (NULL) NULL,
    [TripInches]   VARCHAR (11)  DEFAULT (NULL) NULL,
    [TripGallons]  VARCHAR (11)  DEFAULT (NULL) NULL,
    [TechnicainID] INT           DEFAULT (NULL) NULL,
    [DateAdded]    DATETIME2 (0) DEFAULT (NULL) NULL,
    CONSTRAINT [PK_calibrations_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [added]
    ON [dbo].[Calibrations]([DateAdded] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.calibrations', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Calibrations';

