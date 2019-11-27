#### 

[Movies](../index.md) > [Tables](Tables.md) > dbo.Event

# ![Tables](../../../Images/Table32.png) [dbo].[Event]

---

## <a name="#description"></a>MS_Description

Experimental: User clickstream events, such as browsing and adding items to a cart.

## <a name="#columns"></a>Columns

| Key | Name | Data Type | Max Length (Bytes) | Nullability |
|---|---|---|---|---|
| [![Cluster Primary Key PK_Event: id](../../../Images/pkcluster.png)](#indexes) | id | varchar(100) | 100 | NOT NULL |
|  | event | varchar(100) | 100 | NULL allowed |
|  | userId | int | 4 | NULL allowed |
|  | itemId | int | 4 | NULL allowed |
|  | orderId | int | 4 | NULL allowed |
|  | contentId | int | 4 | NULL allowed |
|  | sessionId | varchar(100) | 100 | NULL allowed |
|  | created | datetime2 | 8 | NULL allowed |
|  | region | varchar(50) | 50 | NULL allowed |


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
EXEC sp_addextendedproperty N'MS_Description', N'Experimental: User clickstream events, such as browsing and adding items to a cart.', 'SCHEMA', N'dbo', 'TABLE', N'Event', NULL, NULL
GO

```


---

###### Author:  Contoso Movies, Ltd.

###### Copyright 2019 - All Rights Reserved

###### Created: 2019/11/27

