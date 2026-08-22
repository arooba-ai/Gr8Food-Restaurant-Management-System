-- =====================================================================
-- Gr8Food Sample Data Script
-- Run this in SSMS against GR8Foodsdb to populate OrderDetails & Cart
-- =====================================================================

-- OrderDetails: links existing Orders (IDs 1-6) to existing Menu items.
-- Adjust MenuID values if your Menu table uses different IDs.
-- Use: SELECT MenuID, Name, Price FROM Menu  to verify before running.

INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (1, 1, 2, 18.00);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (1, 3, 1, 12.50);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (2, 2, 1, 9.90);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (2, 5, 2, 19.80);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (3, 4, 3, 30.00);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (3, 7, 1, 11.50);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (4, 6, 2, 24.00);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (4, 8, 1, 15.00);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (5, 9, 1, 13.50);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (5, 10, 2, 21.00);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (6, 1, 1,  9.00);
INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) VALUES (6, 4, 2, 20.00);

-- Cart: sample items for customer testing (cleared on checkout).
-- FoodName must match an item in your Menu table (case-sensitive for GetMenuID lookup).
-- Use: SELECT Name, Price FROM Menu  to pick real names.

INSERT INTO Cart (FoodName, Price, Quantity, Total) VALUES ('Nasi Lemak',  8.50, 2, 17.00);
INSERT INTO Cart (FoodName, Price, Quantity, Total) VALUES ('Milo Ais',    3.50, 1,  3.50);
