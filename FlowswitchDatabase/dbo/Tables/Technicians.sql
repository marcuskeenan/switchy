CREATE TABLE [dbo].[Technicians] (
    [ID]        INT          IDENTITY (32, 1) NOT NULL,
    [LastName]  VARCHAR (48) NOT NULL,
    [FirstName] VARCHAR (48) NOT NULL,
    [Username]  VARCHAR (64) NOT NULL,
    [Active]    INT          NOT NULL,
    CONSTRAINT [PK_Technicians_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.technicians', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Technicians';

