#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.Orders

# ![Tables](../../../Images/Table32.png) [dbo].[Orders]

---

## <a name="#description"></a>MS_Description

Placed orders.

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_Orders: OrderId](../../../Images/pkcluster.png)](#indexes) | OrderId | int | 4 | NOT NULL | 1 - 1 |
|  | OrderDate | datetime | 8 | NULL allowed |  |
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
|  | Total | decimal(18,0) | 9 | NULL allowed |  |
|  | PaymentTransactionId | varchar(100) | 100 | NULL allowed |  |
|  | HasBeenShipped | bit | 1 | NULL allowed |  |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[Orders]
(
[OrderId] [int] NOT NULL IDENTITY(1, 1),
[OrderDate] [datetime] NULL,
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
[Total] [decimal] (18, 0) NULL,
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

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

