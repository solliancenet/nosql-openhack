#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.Item

# ![Tables](../../../Images/Table32.png) [dbo].[Item]

---

## <a name="#description"></a>MS_Description

Movie items. NOTE: Ignore the aggregate columns here ;)

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_Item: ItemId](../../../Images/pkcluster.png)](#indexes) | ItemId | int | 4 | NOT NULL | 1 - 1 |
|  | BuyCount | int | 4 | NULL allowed |  |
|  | ViewDetailsCount | int | 4 | NULL allowed |  |
|  | AddToCartCount | int | 4 | NULL allowed |  |
|  | VoteCount | int | 4 | NULL allowed |  |
|  | ProductName | varchar(100) | 100 | NULL allowed |  |
|  | ImdbId | int | 4 | NULL allowed |  |
|  | Description | varchar(200) | 200 | NULL allowed |  |
|  | ImagePath | varchar(200) | 200 | NULL allowed |  |
|  | ThumbnailPath | varchar(200) | 200 | NULL allowed |  |
|  | UnitPrice | float | 8 | NULL allowed |  |
| [![Foreign Keys FK_Item_Category: [dbo].[Category].CategoryId](../../../Images/fk.png)](#foreignkeys) | CategoryId | int | 4 | NULL allowed |  |
|  | Category | varchar(200) | 200 | NULL allowed |  |
|  | Popularity | varchar(100) | 100 | NULL allowed |  |
|  | OriginalLanguage | varchar(100) | 100 | NULL allowed |  |
|  | ReleaseDate | varchar(100) | 100 | NULL allowed |  |
|  | VoteAverage | varchar(100) | 100 | NULL allowed |  |


---

## <a name="#foreignkeys"></a>Foreign Keys

| Name | Columns |
|---|---|
| FK_Item_Category | CategoryId->[[dbo].[Category].[CategoryId]](Category.md) |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[Item]
(
[ItemId] [int] NOT NULL IDENTITY(1, 1),
[BuyCount] [int] NULL,
[ViewDetailsCount] [int] NULL,
[AddToCartCount] [int] NULL,
[VoteCount] [int] NULL,
[ProductName] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ImdbId] [int] NULL,
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
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED  ([ItemId])
GO
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [FK_Item_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Movie items. NOTE: Ignore the aggregate columns here ;)', 'SCHEMA', N'dbo', 'TABLE', N'Item', NULL, NULL
GO

```


---

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

