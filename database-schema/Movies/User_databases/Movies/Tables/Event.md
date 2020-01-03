#### 

[Project](../../../../index.md) > [Movies SQL Server](../../../index.md) > [User databases](../../index.md) > [Movies](../index.md) > [Tables](Tables.md) > dbo.Event

# ![Tables](../../../../Images/Table32.png) [dbo].[Event]

---

## <a name="#description"></a>MS_Description

User clickstream events, such as browsing and adding items to a cart.

## <a name="#properties"></a>Properties

| Property | Value |
|---|---|
| Collation | SQL_Latin1_General_CP1_CI_AS |
| Row Count (~) | 4081 |
| Created | 7:14:20 PM Sunday, December 22, 2019 |
| Last Modified | 4:05:10 AM Friday, January 3, 2020 |


---

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability |
|---|---|---|---|---|
| [![Cluster Primary Key PK_Event: id](../../../../Images/pkcluster.png)](#indexes) | id | varchar(100) | 100 | NOT NULL |
|  | event | varchar(100) | 100 | NULL allowed |
| [![Foreign Keys FK_Event_User: [dbo].[User].userId](../../../../Images/fk.png)](#foreignkeys) | userId | int | 4 | NULL allowed |
|  | itemId | int | 4 | NULL allowed |
|  | orderId | int | 4 | NULL allowed |
|  | contentId | int | 4 | NULL allowed |
|  | sessionId | varchar(100) | 100 | NULL allowed |
|  | created | datetime2 | 8 | NULL allowed |
|  | region | varchar(50) | 50 | NULL allowed |


---

## <a name="#indexes"></a>Indexes

| Key | Name | Key Columns | Unique |
|---|---|---|---|
| [![Cluster Primary Key PK_Event: id](../../../../Images/pkcluster.png)](#indexes) | PK_Event | id | YES |


---

## <a name="#foreignkeys"></a>Foreign Keys

| Name | Columns |
|---|---|
| FK_Event_User | userId->[[dbo].[User].[UserId]](User.md) |


---

## <a name="#sqlscript"></a>SQL Script

```sql
CREATE TABLE [dbo].[Event]
(
[id] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[event] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[userId] [int] NULL,
[itemId] [int] NULL,
[orderId] [int] NULL,
[contentId] [int] NULL,
[sessionId] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[created] [datetime2] NULL,
[region] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
ALTER TABLE [dbo].[Event] ADD CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED  ([id])
GO
ALTER TABLE [dbo].[Event] ADD CONSTRAINT [FK_Event_User] FOREIGN KEY ([userId]) REFERENCES [dbo].[User] ([UserId])
GO
EXEC sp_addextendedproperty N'MS_Description', N'User clickstream events, such as browsing and adding items to a cart.', 'SCHEMA', N'dbo', 'TABLE', N'Event', NULL, NULL
GO

```


---

## <a name="#uses"></a>Uses

* [[dbo].[User]](User.md)


---

###### Author:  Contoso Video, Ltd.

###### Copyright 2020 - All Rights Reserved

###### Created: 2020/01/03

