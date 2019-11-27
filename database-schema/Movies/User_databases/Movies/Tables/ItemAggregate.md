#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.ItemAggregate

# ![Tables](../../../Images/Table32.png) [dbo].[ItemAggregate]

---

## <a name="#description"></a>MS_Description

Experimental: Aggregates, such as buy count, view details count, add item to cart count, and vote count. Ignore the other fields.

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability |
|---|---|---|---|---|
| [![Cluster Primary Key PK_ItemAggregate: id](../../../Images/pkcluster.png)](#indexes) | id | varchar(100) | 100 | NOT NULL |
|  | ItemId | int | 4 | NOT NULL |
|  | BuyCount | int | 4 | NULL allowed |
|  | ViewDetailsCount | int | 4 | NULL allowed |
|  | AddToCartCount | int | 4 | NULL allowed |
|  | VoteCount | int | 4 | NULL allowed |
|  | ProductName | varchar(100) | 100 | NULL allowed |
|  | ImdbId | varchar(100) | 100 | NULL allowed |
|  | Description | varchar(200) | 200 | NULL allowed |
|  | ImagePath | varchar(200) | 200 | NULL allowed |
|  | ThumbnailPath | varchar(200) | 200 | NULL allowed |
|  | UnitPrice | float | 8 | NULL allowed |
|  | CategoryId | int | 4 | NULL allowed |
|  | Category | varchar(200) | 200 | NULL allowed |
|  | Popularity | varchar(100) | 100 | NULL allowed |
|  | OriginalLanguage | varchar(100) | 100 | NULL allowed |
|  | ReleaseDate | varchar(100) | 100 | NULL allowed |
|  | VoteAverage | varchar(100) | 100 | NULL allowed |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[ItemAggregate]
(
[id] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ItemId] [int] NOT NULL,
[BuyCount] [int] NULL,
[ViewDetailsCount] [int] NULL,
[AddToCartCount] [int] NULL,
[VoteCount] [int] NULL,
[ProductName] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ImdbId] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ImagePath] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ThumbnailPath] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UnitPrice] [float] NULL,
[CategoryId] [int] NULL,
[Category] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Popularity] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[OriginalLanguage] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ReleaseDate] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[VoteAverage] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[ItemAggregate] ADD CONSTRAINT [PK_ItemAggregate] PRIMARY KEY CLUSTERED  ([id])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Experimental: Aggregates, such as buy count, view details count, add item to cart count, and vote count. Ignore the other fields.', 'SCHEMA', N'dbo', 'TABLE', N'ItemAggregate', NULL, NULL
GO

```


---

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

