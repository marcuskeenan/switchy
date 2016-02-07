CREATE TABLE [dbo].[SubSystems] (
    [ID]      INT          IDENTITY (7, 1) NOT NULL,
    [Acronym] VARCHAR (6)  NOT NULL,
    [Name]    VARCHAR (48) NOT NULL,
    CONSTRAINT [PK_SubSystems_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.subsystems', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SubSystems';

