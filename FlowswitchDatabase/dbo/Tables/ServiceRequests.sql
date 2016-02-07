CREATE TABLE [dbo].[ServiceRequests] (
    [ID]             INT          IDENTITY (30, 1) NOT NULL,
    [FamisWorkOrder] VARCHAR (32) NOT NULL,
    [Cater]          VARCHAR (32) NOT NULL,
    CONSTRAINT [PK_ServiceRequests_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'flowswitchdatabase.servicerequests', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ServiceRequests';

