#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.Category

# ![Tables](../../../Images/Table32.png) [dbo].[Category]

---

## <a name="#description"></a>MS_Description

Movie categories.

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_Category: CategoryId](../../../Images/pkcluster.png)](#indexes) | CategoryId | int | 4 | NOT NULL | 1 - 1 |
|  | CategoryName | varchar(100) | 100 | NULL allowed |  |
|  | Description | varchar(200) | 200 | NULL allowed |  |
|  | Products | varchar(200) | 200 | NULL allowed |  |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[Category]
(
[CategoryId] [int] NOT NULL IDENTITY(1, 1),
[CategoryName] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Products] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[Category] ADD CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED  ([CategoryId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Movie categories.', 'SCHEMA', N'dbo', 'TABLE', N'Category', NULL, NULL
GO

```


---

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

