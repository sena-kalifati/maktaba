CREATE TABLE [dbo].[StudentTbl] (
    [BookName]  INT          NOT NULL,
    [Author]    VARCHAR (50) NOT NULL,
    [Publisher] VARCHAR (50) NOT NULL,
    [Price]     INT          NOT NULL,
    [Qty]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([BookName] ASC)
);

