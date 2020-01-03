#### 

[Project](../../../../index.md) > [Movies SQL Server](../../../index.md) > [User databases](../../index.md) > [Movies](../index.md) > [Tables](Tables.md) > dbo.Category

# ![Tables](../../../../Images/Table32.png) [dbo].[Category]

---

## <a name="#description"></a>MS_Description

Movie categories.

## <a name="#properties"></a>Properties

| Property | Value |
|---|---|
| Collation | SQL_Latin1_General_CP1_CI_AS |
| Row Count (~) | 19 |
| Created | 7:14:20 PM Sunday, December 22, 2019 |
| Last Modified | 5:04:19 PM Friday, January 3, 2020 |


---

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_Category: CategoryId](../../../../Images/pkcluster.png)](#indexes) | CategoryId | int | 4 | NOT NULL | 1 - 1 |
|  | CategoryName | varchar(100) | 100 | NULL allowed |  |
|  | Description | varchar(200) | 200 | NULL allowed |  |
|  | Products | varchar(200) | 200 | NULL allowed |  |


---

## <a name="#indexes"></a>Indexes

| Key | Name | Key Columns | Unique |
|---|---|---|---|
| [![Cluster Primary Key PK_Category: CategoryId](../../../../Images/pkcluster.png)](#indexes) | PK_Category | CategoryId | YES |


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

## <a name="#usedby"></a>Used By

* [[dbo].[Item]](Item.md)
* [[dbo].[User]](User.md)


---

###### Author:  Contoso Video, Ltd.

###### Copyright 2020 - All Rights Reserved

###### Created: 2020/01/03

