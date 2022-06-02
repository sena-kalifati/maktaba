CREATE TABLE [dbo].[BookTbl] (
    [BookName]  VARCHAR (50) NOT NULL,
    [Author]    VARCHAR (50) NOT NULL,
    [Publisher] VARCHAR (50) NOT NULL,
    [Price]     INT          NOT NULL,
    [Qty]       INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([BookName] ASC)
);

