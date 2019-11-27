#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.ItemCategory

# ![Tables](../../../Images/Table32.png) [dbo].[ItemCategory]

---

## <a name="#description"></a>MS_Description

Mapping between items and categories. There should be a relationship between this table and the Category table...

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability |
|---|---|---|---|---|
| [![Cluster Primary Key PK_ItemCategory: CategoryId\ItemId](../../../Images/pkcluster.png)](#indexes) | CategoryId | int | 4 | NOT NULL |
| [![Cluster Primary Key PK_ItemCategory: CategoryId\ItemId](../../../Images/pkcluster.png)](#indexes) | ItemId | int | 4 | NOT NULL |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[ItemCategory]
(
[CategoryId] [int] NOT NULL,
[ItemId] [int] NOT NULL
)
GO
ALTER TABLE [dbo].[ItemCategory] ADD CONSTRAINT [PK_ItemCategory] PRIMARY KEY CLUSTERED  ([CategoryId], [ItemId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Mapping between items and categories. There should be a relationship between this table and the Category table...', 'SCHEMA', N'dbo', 'TABLE', N'ItemCategory', NULL, NULL
GO

```


---

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

