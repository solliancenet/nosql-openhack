#### 

[Project](../../../../index.md) > [Movies SQL Server](../../../index.md) > [User databases](../../index.md) > [Movies](../index.md) > [Tables](Tables.md) > dbo.Orders

# ![Tables](../../../../Images/Table32.png) [dbo].[Orders]

---

## <a name="#description"></a>MS_Description

Placed orders.

## <a name="#properties"></a>Properties

| Property | Value |
|---|---|
| Collation | SQL_Latin1_General_CP1_CI_AS |
| Row Count (~) | 101 |
| Created | 5:00:24 PM Friday, January 3, 2020 |
| Last Modified | 5:01:17 PM Friday, January 3, 2020 |


---

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_Orders: OrderId](../../../../Images/pkcluster.png)](#indexes) | OrderId | int | 4 | NOT NULL | 1 - 1 |
|  | OrderDate | datetime | 8 | NOT NULL |  |
|  | FirstName | varchar(160) | 160 | NOT NULL |  |
|  | LastName | varchar(160) | 160 | NOT NULL |  |
|  | Address | varchar(70) | 70 | NOT NULL |  |
|  | City | varchar(40) | 40 | NOT NULL |  |
|  | State | varchar(40) | 40 | NOT NULL |  |
|  | PostalCode | varchar(10) | 10 | NOT NULL |  |
|  | Country | varchar(40) | 40 | NOT NULL |  |
|  | Phone | varchar(24) | 24 | NOT NULL |  |
|  | SMSOptIn | bit | 1 | NULL allowed |  |
|  | SMSStatus | varchar(100) | 100 | NULL allowed |  |
|  | Email | varchar(100) | 100 | NOT NULL |  |
|  | ReceiptUrl | varchar(100) | 100 | NULL allowed |  |
|  | Total | decimal(18,2) | 9 | NULL allowed |  |
|  | PaymentTransactionId | varchar(100) | 100 | NULL allowed |  |
|  | HasBeenShipped | bit | 1 | NULL allowed |  |


---

## <a name="#indexes"></a>Indexes

| Key | Name | Key Columns | Unique |
|---|---|---|---|
| [![Cluster Primary Key PK_Orders: OrderId](../../../../Images/pkcluster.png)](#indexes) | PK_Orders | OrderId | YES |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[Orders]
(
[OrderId] [int] NOT NULL IDENTITY(1, 1),
[OrderDate] [datetime] NOT NULL,
[FirstName] [varchar] (160) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastName] [varchar] (160) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Address] [varchar] (70) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[City] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[State] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PostalCode] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Country] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Phone] [varchar] (24) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SMSOptIn] [bit] NULL,
[SMSStatus] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ReceiptUrl] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Total] [decimal] (18, 2) NULL,
[PaymentTransactionId] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[HasBeenShipped] [bit] NULL
)
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED  ([OrderId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Placed orders.', 'SCHEMA', N'dbo', 'TABLE', N'Orders', NULL, NULL
GO

```


---

## <a name="#usedby"></a>Used By

* [[dbo].[OrderDetails]](OrderDetails.md)


---

###### Author:  Contoso Video, Ltd.

###### Copyright 2020 - All Rights Reserved

###### Created: 2020/01/03

