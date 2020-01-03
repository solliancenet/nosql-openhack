#### 

[Project](../../../../index.md) > [Movies SQL Server](../../../index.md) > [User databases](../../index.md) > [Movies](../index.md) > [Tables](Tables.md) > dbo.Cartitem

# ![Tables](../../../../Images/Table32.png) [dbo].[Cartitem]

---

## <a name="#description"></a>MS_Description

Movies added to a user's cart.

## <a name="#properties"></a>Properties

| Property | Value |
|---|---|
| Collation | SQL_Latin1_General_CP1_CI_AS |
| Row Count (~) | 0 |
| Created | 7:14:20 PM Sunday, December 22, 2019 |
| Last Modified | 5:04:27 PM Friday, January 3, 2020 |


---

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability |
|---|---|---|---|---|
| [![Cluster Primary Key PK_Cartitem: CartItemId](../../../../Images/pkcluster.png)](#indexes) | CartItemId | varchar(100) | 100 | NOT NULL |
|  | CartId | varchar(100) | 100 | NULL allowed |
| [![Foreign Keys FK_Cartitem_Item: [dbo].[Item].ItemId](../../../../Images/fk.png)](#foreignkeys) | ItemId | int | 4 | NULL allowed |
|  | Quantity | int | 4 | NULL allowed |
|  | DateCreated | datetime | 8 | NULL allowed |


---

## <a name="#indexes"></a>Indexes

| Key | Name | Key Columns | Unique |
|---|---|---|---|
| [![Cluster Primary Key PK_Cartitem: CartItemId](../../../../Images/pkcluster.png)](#indexes) | PK_Cartitem | CartItemId | YES |


---

## <a name="#foreignkeys"></a>Foreign Keys

| Name | Columns |
|---|---|
| FK_Cartitem_Item | ItemId->[[dbo].[Item].[ItemId]](Item.md) |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[Cartitem]
(
[CartItemId] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CartId] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ItemId] [int] NULL,
[Quantity] [int] NULL,
[DateCreated] [datetime] NULL
)
GO
ALTER TABLE [dbo].[Cartitem] ADD CONSTRAINT [PK_Cartitem] PRIMARY KEY CLUSTERED  ([CartItemId])
GO
ALTER TABLE [dbo].[Cartitem] ADD CONSTRAINT [FK_Cartitem_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([ItemId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Movies added to a user''s cart.', 'SCHEMA', N'dbo', 'TABLE', N'Cartitem', NULL, NULL
GO

```


---

## <a name="#uses"></a>Uses

* [[dbo].[Item]](Item.md)


---

###### Author:  Contoso Video, Ltd.

###### Copyright 2020 - All Rights Reserved

###### Created: 2020/01/03

