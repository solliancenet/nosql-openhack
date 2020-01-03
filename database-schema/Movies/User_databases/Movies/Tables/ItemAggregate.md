#### 

[Project](../../../../index.md) > [Movies SQL Server](../../../index.md) > [User databases](../../index.md) > [Movies](../index.md) > [Tables](Tables.md) > dbo.ItemAggregate

# ![Tables](../../../../Images/Table32.png) [dbo].[ItemAggregate]

---

## <a name="#description"></a>MS_Description

Aggregates, such as buy count, view details count, add item to cart count, and vote count. 1:1 relationship with Items. A batch process updates these counts, which is an internal process we cannot share at this time.

## <a name="#properties"></a>Properties

| Property | Value |
|---|---|
| Collation | SQL_Latin1_General_CP1_CI_AS |
| Row Count (~) | 500 |
| Created | 7:14:20 PM Sunday, December 22, 2019 |
| Last Modified | 5:04:34 PM Friday, January 3, 2020 |


---

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability |
|---|---|---|---|---|
| [![Cluster Primary Key PK_ItemAggregate: id](../../../../Images/pkcluster.png)](#indexes) | id | varchar(100) | 100 | NOT NULL |
| [![Foreign Keys FK_ItemAggregate_Item: [dbo].[Item].ItemId](../../../../Images/fk.png)](#foreignkeys) | ItemId | int | 4 | NOT NULL |
|  | BuyCount | int | 4 | NULL allowed |
|  | ViewDetailsCount | int | 4 | NULL allowed |
|  | AddToCartCount | int | 4 | NULL allowed |
|  | VoteCount | int | 4 | NULL allowed |


---

## <a name="#indexes"></a>Indexes

| Key | Name | Key Columns | Unique |
|---|---|---|---|
| [![Cluster Primary Key PK_ItemAggregate: id](../../../../Images/pkcluster.png)](#indexes) | PK_ItemAggregate | id | YES |


---

## <a name="#foreignkeys"></a>Foreign Keys

| Name | Columns |
|---|---|
| FK_ItemAggregate_Item | ItemId->[[dbo].[Item].[ItemId]](Item.md) |


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
[VoteCount] [int] NULL
)
GO
ALTER TABLE [dbo].[ItemAggregate] ADD CONSTRAINT [PK_ItemAggregate] PRIMARY KEY CLUSTERED  ([id])
GO
ALTER TABLE [dbo].[ItemAggregate] ADD CONSTRAINT [FK_ItemAggregate_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([ItemId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Aggregates, such as buy count, view details count, add item to cart count, and vote count. 1:1 relationship with Items. A batch process updates these counts, which is an internal process we cannot share at this time.', 'SCHEMA', N'dbo', 'TABLE', N'ItemAggregate', NULL, NULL
GO

```


---

## <a name="#uses"></a>Uses

* [[dbo].[Item]](Item.md)


---

###### Author:  Contoso Video, Ltd.

###### Copyright 2020 - All Rights Reserved

###### Created: 2020/01/03

