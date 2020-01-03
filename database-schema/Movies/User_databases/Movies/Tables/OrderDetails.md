#### 

[Project](../../../../index.md) > [Movies SQL Server](../../../index.md) > [User databases](../../index.md) > [Movies](../index.md) > [Tables](Tables.md) > dbo.OrderDetails

# ![Tables](../../../../Images/Table32.png) [dbo].[OrderDetails]

---

## <a name="#description"></a>MS_Description

All details related to placed orders.

## <a name="#properties"></a>Properties

| Property | Value |
|---|---|
| Collation | SQL_Latin1_General_CP1_CI_AS |
| Row Count (~) | 430 |
| Created | 5:01:16 PM Friday, January 3, 2020 |
| Last Modified | 5:04:26 PM Friday, January 3, 2020 |


---

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_OrderDetails_1: OrderDetailId](../../../../Images/pkcluster.png)](#indexes) | OrderDetailId | int | 4 | NOT NULL | 1 - 1 |
| [![Foreign Keys FK_OrderDetails_Orders: [dbo].[Orders].OrderId](../../../../Images/fk.png)](#foreignkeys) | OrderId | int | 4 | NOT NULL |  |
|  | Email | varchar(100) | 100 | NOT NULL |  |
| [![Foreign Keys FK_OrderDetails_Item: [dbo].[Item].ProductId](../../../../Images/fk.png)](#foreignkeys) | ProductId | int | 4 | NULL allowed |  |
|  | Quantity | int | 4 | NULL allowed |  |
|  | UnitPrice | decimal(18,2) | 9 | NULL allowed |  |


---

## <a name="#indexes"></a>Indexes

| Key | Name | Key Columns | Unique |
|---|---|---|---|
| [![Cluster Primary Key PK_OrderDetails_1: OrderDetailId](../../../../Images/pkcluster.png)](#indexes) | PK_OrderDetails_1 | OrderDetailId | YES |


---

## <a name="#foreignkeys"></a>Foreign Keys

| Name | No Check | Columns |
|---|---|---|
| FK_OrderDetails_Item | YES | ProductId->[[dbo].[Item].[ItemId]](Item.md) |
| FK_OrderDetails_Orders | YES | OrderId->[[dbo].[Orders].[OrderId]](Orders.md) |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[OrderDetails]
(
[OrderDetailId] [int] NOT NULL IDENTITY(1, 1),
[OrderId] [int] NOT NULL,
[Email] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ProductId] [int] NULL,
[Quantity] [int] NULL,
[UnitPrice] [decimal] (18, 2) NULL
)
GO
ALTER TABLE [dbo].[OrderDetails] ADD CONSTRAINT [PK_OrderDetails_1] PRIMARY KEY CLUSTERED  ([OrderDetailId])
GO
ALTER TABLE [dbo].[OrderDetails] WITH NOCHECK ADD CONSTRAINT [FK_OrderDetails_Item] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[OrderDetails] WITH NOCHECK ADD CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] NOCHECK CONSTRAINT [FK_OrderDetails_Item]
GO
ALTER TABLE [dbo].[OrderDetails] NOCHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
EXEC sp_addextendedproperty N'MS_Description', N'All details related to placed orders.', 'SCHEMA', N'dbo', 'TABLE', N'OrderDetails', NULL, NULL
GO

```


---

## <a name="#uses"></a>Uses

* [[dbo].[Item]](Item.md)
* [[dbo].[Orders]](Orders.md)


---

###### Author:  Contoso Video, Ltd.

###### Copyright 2020 - All Rights Reserved

###### Created: 2020/01/03

