CREATE TABLE [dbo].[ReturnTbl] (
    [ReturnNum]    INT           NOT NULL,
    [StdId]        INT           NOT NULL,
    [StdName]      VARCHAR (50)  NOT NULL,
    [StdDept]      VARCHAR (50)  NOT NULL,
    [StdPhone]     VARCHAR (50)  NOT NULL,
    [Bookreturned] VARCHAR (100) NOT NULL,
    [IssueDate]    DATE          NOT NULL,
    [ReturnDaate]  DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([ReturnNum] ASC)
);

