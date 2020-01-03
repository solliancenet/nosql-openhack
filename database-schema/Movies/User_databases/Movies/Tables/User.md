#### 

[Project](../../../../index.md) > [Movies SQL Server](../../../index.md) > [User databases](../../index.md) > [Movies](../index.md) > [Tables](Tables.md) > dbo.User

# ![Tables](../../../../Images/Table32.png) [dbo].[User]

---

## <a name="#description"></a>MS_Description

All user accounts.

## <a name="#properties"></a>Properties

| Property | Value |
|---|---|
| Collation | SQL_Latin1_General_CP1_CI_AS |
| Row Count (~) | 6 |
| Created | 7:14:20 PM Sunday, December 22, 2019 |
| Last Modified | 7:21:54 AM Friday, January 3, 2020 |


---

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_User: UserId](../../../../Images/pkcluster.png)](#indexes) | UserId | int | 4 | NOT NULL | 1 - 1 |
|  | Name | varchar(100) | 100 | NULL allowed |  |
|  | Email | varchar(100) | 100 | NULL allowed |  |
| [![Foreign Keys FK_User_Category: [dbo].[Category].CategoryId](../../../../Images/fk.png)](#foreignkeys) | CategoryId | int | 4 | NULL allowed |  |
|  | Personality | varchar(100) | 100 | NULL allowed |  |


---

## <a name="#indexes"></a>Indexes

| Key | Name | Key Columns | Unique |
|---|---|---|---|
| [![Cluster Primary Key PK_User: UserId](../../../../Images/pkcluster.png)](#indexes) | PK_User | UserId | YES |


---

## <a name="#foreignkeys"></a>Foreign Keys

| Name | No Check | Columns |
|---|---|---|
| FK_User_Category | YES | CategoryId->[[dbo].[Category].[CategoryId]](Category.md) |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[User]
(
[UserId] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CategoryId] [int] NULL,
[Personality] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([UserId])
GO
ALTER TABLE [dbo].[User] WITH NOCHECK ADD CONSTRAINT [FK_User_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[User] NOCHECK CONSTRAINT [FK_User_Category]
GO
EXEC sp_addextendedproperty N'MS_Description', N'All user accounts.', 'SCHEMA', N'dbo', 'TABLE', N'User', NULL, NULL
GO

```


---

## <a name="#uses"></a>Uses

* [[dbo].[Category]](Category.md)


---

## <a name="#usedby"></a>Used By

* [[dbo].[Event]](Event.md)


---

###### Author:  Contoso Video, Ltd.

###### Copyright 2020 - All Rights Reserved

###### Created: 2020/01/03

