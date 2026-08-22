-- ============================================================
-- GR8Foodsdb Schema Update Script
-- Run this in SQL Server Management Studio against GR8Foodsdb
-- ============================================================

USE GR8Foodsdb;
GO

-- 1. Add Date column to Feedback (required by Manager's FeedbackForm)
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME='Feedback' AND COLUMN_NAME='Date')
BEGIN
    ALTER TABLE Feedback ADD Date DATETIME DEFAULT GETDATE();
    PRINT 'Added Date column to Feedback.';
END

-- 2. Add Reply column to Feedback (required by Manager's FeedbackForm)
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME='Feedback' AND COLUMN_NAME='Reply')
BEGIN
    ALTER TABLE Feedback ADD Reply NVARCHAR(500) NULL;
    PRINT 'Added Reply column to Feedback.';
END

-- 3. Verify Cart table column name (code uses FoodName not Food)
IF EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME='Cart' AND COLUMN_NAME='Food')
BEGIN
    EXEC sp_rename 'Cart.Food', 'FoodName', 'COLUMN';
    PRINT 'Renamed Cart.Food to Cart.FoodName.';
END

-- 4. Sample user inserts for testing all 4 roles
-- (Only run once — skip if users already exist)
/*
INSERT INTO Users (Name, Role, Email, Password, WalletBalance, Phone) VALUES
('Ahmad Customer', 'Customer',     'customer@test.com',  'pass123', 100.00, '0123456789'),
('Bob Chef',       'Chef',         'chef@test.com',       'pass123', 0.00,  '0123456780'),
('Carol Admin',    'System Admin', 'admin@test.com',      'pass123', 0.00,  '0123456781'),
('Dave Manager',   'Manager',      'manager@test.com',    'pass123', 0.00,  '0123456782');
*/
GO
