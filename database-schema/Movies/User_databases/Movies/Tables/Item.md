#### 

[Project](../../../../index.md) > [Movies SQL Server](../../../index.md) > [User databases](../../index.md) > [Movies](../index.md) > [Tables](Tables.md) > dbo.Item

# ![Tables](../../../../Images/Table32.png) [dbo].[Item]

---

## <a name="#description"></a>MS_Description

Movie items.

## <a name="#properties"></a>Properties

| Property | Value |
|---|---|
| Collation | SQL_Latin1_General_CP1_CI_AS |
| Row Count (~) | 500 |
| Created | 5:04:18 PM Friday, January 3, 2020 |
| Last Modified | 5:04:34 PM Friday, January 3, 2020 |


---

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_Item: ItemId](../../../../Images/pkcluster.png)](#indexes) | ItemId | int | 4 | NOT NULL | 1 - 1 |
|  | VoteCount | int | 4 | NULL allowed |  |
|  | ProductName | varchar(100) | 100 | NULL allowed |  |
|  | ImdbId | int | 4 | NULL allowed |  |
|  | Description | varchar(200) | 200 | NULL allowed |  |
|  | ImagePath | varchar(200) | 200 | NULL allowed |  |
|  | ThumbnailPath | varchar(200) | 200 | NULL allowed |  |
|  | UnitPrice | decimal(18,2) | 9 | NULL allowed |  |
| [![Foreign Keys FK_Item_Category: [dbo].[Category].CategoryId](../../../../Images/fk.png)](#foreignkeys) | CategoryId | int | 4 | NULL allowed |  |
|  | Category | varchar(200) | 200 | NULL allowed |  |
|  | Popularity | decimal(18,2) | 9 | NULL allowed |  |
|  | OriginalLanguage | varchar(10) | 10 | NULL allowed |  |
|  | ReleaseDate | date | 3 | NULL allowed |  |
|  | VoteAverage | decimal(18,2) | 9 | NULL allowed |  |


---

## <a name="#indexes"></a>Indexes

| Key | Name | Key Columns | Unique |
|---|---|---|---|
| [![Cluster Primary Key PK_Item: ItemId](../../../../Images/pkcluster.png)](#indexes) | PK_Item | ItemId | YES |


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
[VoteCount] [int] NULL,
[ProductName] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ImdbId] [int] NULL,
[Description] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ImagePath] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ThumbnailPath] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UnitPrice] [decimal] (18, 2) NULL,
[CategoryId] [int] NULL,
[Category] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Popularity] [decimal] (18, 2) NULL,
[OriginalLanguage] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ReleaseDate] [date] NULL,
[VoteAverage] [decimal] (18, 2) NULL
)
GO
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED  ([ItemId])
GO
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [FK_Item_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Movie items.', 'SCHEMA', N'dbo', 'TABLE', N'Item', NULL, NULL
GO

```


---

## <a name="#uses"></a>Uses

* [[dbo].[Category]](Category.md)


---

## <a name="#usedby"></a>Used By

* [[dbo].[Cartitem]](Cartitem.md)
* [[dbo].[ItemAggregate]](ItemAggregate.md)
* [[dbo].[OrderDetails]](OrderDetails.md)


---

###### Author:  Contoso Video, Ltd.

###### Copyright 2020 - All Rights Reserved

###### Created: 2020/01/03

