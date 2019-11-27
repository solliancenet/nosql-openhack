#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.User

# ![Tables](../../../Images/Table32.png) [dbo].[User]

---

## <a name="#description"></a>MS_Description

All user accounts.

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability | Identity |
|---|---|---|---|---|---|
| [![Cluster Primary Key PK_User: UserId](../../../Images/pkcluster.png)](#indexes) | UserId | int | 4 | NOT NULL | 1 - 1 |
|  | Name | varchar(100) | 100 | NULL allowed |  |
|  | Email | varchar(100) | 100 | NULL allowed |  |
| [![Foreign Keys FK_User_Category: [dbo].[Category].CategoryId](../../../Images/fk.png)](#foreignkeys) | CategoryId | int | 4 | NULL allowed |  |
|  | Personality | varchar(100) | 100 | NULL allowed |  |


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

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

