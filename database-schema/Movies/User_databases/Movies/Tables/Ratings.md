#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.Ratings

# ![Tables](../../../Images/Table32.png) [dbo].[Ratings]

---

## <a name="#description"></a>MS_Description

Movie ratings for each user.

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability |
|---|---|---|---|---|
| [![Cluster Primary Key PK_Ratings: id](../../../Images/pkcluster.png)](#indexes) | id | varchar(100) | 100 | NOT NULL |
|  | itemId | int | 4 | NOT NULL |
|  | rating | float | 8 | NOT NULL |
|  | userId | int | 4 | NOT NULL |
|  | ratingTimeStamp | datetime2 | 8 | NULL allowed |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[Ratings]
(
[id] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[itemId] [int] NOT NULL,
[rating] [float] NOT NULL,
[userId] [int] NOT NULL,
[ratingTimeStamp] [datetime2] NULL
)
GO
ALTER TABLE [dbo].[Ratings] ADD CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED  ([id])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Movie ratings for each user.', 'SCHEMA', N'dbo', 'TABLE', N'Ratings', NULL, NULL
GO

```


---

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

