#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.Cartitem

# ![Tables](../../../Images/Table32.png) [dbo].[Cartitem]

---

## <a name="#description"></a>MS_Description

Movies added to a user's cart.

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability |
|---|---|---|---|---|
| [![Cluster Primary Key PK_Cartitem: CartItemId](../../../Images/pkcluster.png)](#indexes) | CartItemId | varchar(100) | 100 | NOT NULL |
|  | CartId | varchar(100) | 100 | NULL allowed |
|  | ItemId | int | 4 | NULL allowed |
|  | Quantity | int | 4 | NULL allowed |
|  | DateCreated | datetime | 8 | NULL allowed |


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
EXEC sp_addextendedproperty N'MS_Description', N'Movies added to a user''s cart.', 'SCHEMA', N'dbo', 'TABLE', N'Cartitem', NULL, NULL
GO

```


---

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

