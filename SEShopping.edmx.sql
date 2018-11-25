
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2018 03:50:44
-- Generated from EDMX file: C:\Users\TuyMove\Desktop\Tuymove\Project\ShoppingModule\SEShopping.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [se323];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Order_ShopOrderorderID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SESHOP_Shop_Order_Item] DROP CONSTRAINT [FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Order_ShopOrderorderID];
GO
IF OBJECT_ID(N'[dbo].[FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Product_productID1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SESHOP_Shop_Order_Item] DROP CONSTRAINT [FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Product_productID1];
GO
IF OBJECT_ID(N'[dbo].[FK_SESHOP_Shop_Order_Payment_SESHOP_Shop_Order_orderID1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SESHOP_Shop_Order_Payment] DROP CONSTRAINT [FK_SESHOP_Shop_Order_Payment_SESHOP_Shop_Order_orderID1];
GO
IF OBJECT_ID(N'[dbo].[FK_SESHOP_Shop_Order_SESHOP_Shop_member_memberID1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SESHOP_Shop_Order] DROP CONSTRAINT [FK_SESHOP_Shop_Order_SESHOP_Shop_member_memberID1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[SESHOP_Shop_member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SESHOP_Shop_member];
GO
IF OBJECT_ID(N'[dbo].[SESHOP_Shop_Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SESHOP_Shop_Order];
GO
IF OBJECT_ID(N'[dbo].[SESHOP_Shop_Order_Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SESHOP_Shop_Order_Item];
GO
IF OBJECT_ID(N'[dbo].[SESHOP_Shop_Order_Payment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SESHOP_Shop_Order_Payment];
GO
IF OBJECT_ID(N'[dbo].[SESHOP_Shop_Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SESHOP_Shop_Product];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SESHOP_Shop_member'
CREATE TABLE [dbo].[SESHOP_Shop_member] (
    [memberID] int IDENTITY(1,1) NOT NULL,
    [memberName] nvarchar(max)  NULL,
    [memberTel] nvarchar(max)  NULL,
    [memberEmail] nvarchar(max)  NULL,
    [password] nvarchar(max)  NULL,
    [address] nvarchar(max)  NULL
);
GO

-- Creating table 'SESHOP_Shop_Order'
CREATE TABLE [dbo].[SESHOP_Shop_Order] (
    [orderID] int IDENTITY(1,1) NOT NULL,
    [memberID1] int  NULL,
    [orderStatus] nvarchar(max)  NULL
);
GO

-- Creating table 'SESHOP_Shop_Order_Item'
CREATE TABLE [dbo].[SESHOP_Shop_Order_Item] (
    [orderItemID] int IDENTITY(1,1) NOT NULL,
    [productID1] int  NULL,
    [qty] int  NOT NULL,
    [ShopOrderorderID] int  NULL
);
GO

-- Creating table 'SESHOP_Shop_Order_Payment'
CREATE TABLE [dbo].[SESHOP_Shop_Order_Payment] (
    [paymentID] int IDENTITY(1,1) NOT NULL,
    [orderID1] int  NULL,
    [channel] nvarchar(max)  NULL,
    [payment_ref] nvarchar(max)  NULL
);
GO

-- Creating table 'SESHOP_Shop_Product'
CREATE TABLE [dbo].[SESHOP_Shop_Product] (
    [productID] int IDENTITY(1,1) NOT NULL,
    [productName] nvarchar(max)  NULL,
    [productPrice] float  NOT NULL,
    [productImage] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [memberID] in table 'SESHOP_Shop_member'
ALTER TABLE [dbo].[SESHOP_Shop_member]
ADD CONSTRAINT [PK_SESHOP_Shop_member]
    PRIMARY KEY CLUSTERED ([memberID] ASC);
GO

-- Creating primary key on [orderID] in table 'SESHOP_Shop_Order'
ALTER TABLE [dbo].[SESHOP_Shop_Order]
ADD CONSTRAINT [PK_SESHOP_Shop_Order]
    PRIMARY KEY CLUSTERED ([orderID] ASC);
GO

-- Creating primary key on [orderItemID] in table 'SESHOP_Shop_Order_Item'
ALTER TABLE [dbo].[SESHOP_Shop_Order_Item]
ADD CONSTRAINT [PK_SESHOP_Shop_Order_Item]
    PRIMARY KEY CLUSTERED ([orderItemID] ASC);
GO

-- Creating primary key on [paymentID] in table 'SESHOP_Shop_Order_Payment'
ALTER TABLE [dbo].[SESHOP_Shop_Order_Payment]
ADD CONSTRAINT [PK_SESHOP_Shop_Order_Payment]
    PRIMARY KEY CLUSTERED ([paymentID] ASC);
GO

-- Creating primary key on [productID] in table 'SESHOP_Shop_Product'
ALTER TABLE [dbo].[SESHOP_Shop_Product]
ADD CONSTRAINT [PK_SESHOP_Shop_Product]
    PRIMARY KEY CLUSTERED ([productID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [memberID1] in table 'SESHOP_Shop_Order'
ALTER TABLE [dbo].[SESHOP_Shop_Order]
ADD CONSTRAINT [FK_SESHOP_Shop_Order_SESHOP_Shop_member_memberID1]
    FOREIGN KEY ([memberID1])
    REFERENCES [dbo].[SESHOP_Shop_member]
        ([memberID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SESHOP_Shop_Order_SESHOP_Shop_member_memberID1'
CREATE INDEX [IX_FK_SESHOP_Shop_Order_SESHOP_Shop_member_memberID1]
ON [dbo].[SESHOP_Shop_Order]
    ([memberID1]);
GO

-- Creating foreign key on [ShopOrderorderID] in table 'SESHOP_Shop_Order_Item'
ALTER TABLE [dbo].[SESHOP_Shop_Order_Item]
ADD CONSTRAINT [FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Order_ShopOrderorderID]
    FOREIGN KEY ([ShopOrderorderID])
    REFERENCES [dbo].[SESHOP_Shop_Order]
        ([orderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Order_ShopOrderorderID'
CREATE INDEX [IX_FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Order_ShopOrderorderID]
ON [dbo].[SESHOP_Shop_Order_Item]
    ([ShopOrderorderID]);
GO

-- Creating foreign key on [orderID1] in table 'SESHOP_Shop_Order_Payment'
ALTER TABLE [dbo].[SESHOP_Shop_Order_Payment]
ADD CONSTRAINT [FK_SESHOP_Shop_Order_Payment_SESHOP_Shop_Order_orderID1]
    FOREIGN KEY ([orderID1])
    REFERENCES [dbo].[SESHOP_Shop_Order]
        ([orderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SESHOP_Shop_Order_Payment_SESHOP_Shop_Order_orderID1'
CREATE INDEX [IX_FK_SESHOP_Shop_Order_Payment_SESHOP_Shop_Order_orderID1]
ON [dbo].[SESHOP_Shop_Order_Payment]
    ([orderID1]);
GO

-- Creating foreign key on [productID1] in table 'SESHOP_Shop_Order_Item'
ALTER TABLE [dbo].[SESHOP_Shop_Order_Item]
ADD CONSTRAINT [FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Product_productID1]
    FOREIGN KEY ([productID1])
    REFERENCES [dbo].[SESHOP_Shop_Product]
        ([productID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Product_productID1'
CREATE INDEX [IX_FK_SESHOP_Shop_Order_Item_SESHOP_Shop_Product_productID1]
ON [dbo].[SESHOP_Shop_Order_Item]
    ([productID1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------