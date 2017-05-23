USE [aspnet-WebUI-bf19a8ae-c97c-45a7-90dc-7482b799b6fe]
GO

SET IDENTITY_INSERT [dbo].[Branchs] ON
INSERT INTO [dbo].[Branchs] ([branchID], [branchName], [custAddress], [custCity], [custPhone], [custState], [custZip]) VALUES (1, N'Waterloo', N'123 University st', N'Waterloo Main', N'519-123-3456', N'ON', N'N1N2N3')
INSERT INTO [dbo].[Branchs] ([branchID], [branchName], [custAddress], [custCity], [custPhone], [custState], [custZip]) VALUES (2, N'Kitchener', N'2345 King st', N'Kitchener Sub', N'519-555-9876', N'ON', N'N2N3N4')
SET IDENTITY_INSERT [dbo].[Branchs] OFF

SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([customerID], [CustEmail], [custAddress], [custCity], [custFName], [custLName], [custPhone], [custState], [custZip]) VALUES (1, N'abcabc@def.net', N'11 King st', N'Kitchener', N'Tim', N'Jackson', N'5191230987', N'ON', N'N2N3N4')
INSERT INTO [dbo].[Customers] ([customerID], [CustEmail], [custAddress], [custCity], [custFName], [custLName], [custPhone], [custState], [custZip]) VALUES (2, N'nanana@def.net', N'144 Weber st', N'Kitchener', N'Human', N'Kalson', N'5191230111', N'ON', N'N2N5N4')
SET IDENTITY_INSERT [dbo].[Customers] OFF

SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([orderID], [OrderEmail], [custAddress], [custName], [deliveryDate], [paymentMethod]) VALUES (1, N'yoonsukcho@testemail.com', N'123 Big street Waterloo ON', N'Yoonsuk Cho', N'2016-11-29 12:23:34', N'Cash')
INSERT INTO [dbo].[Orders] ([orderID], [OrderEmail], [custAddress], [custName], [deliveryDate], [paymentMethod]) VALUES (2, N'abcd@def.net', N'123 King st Kitchener ON', N'Cloud High', N'2016-12-04 14:11:00', N'Visa')
INSERT INTO [dbo].[Orders] ([orderID], [OrderEmail], [custAddress], [custName], [deliveryDate], [paymentMethod]) VALUES (3, N'nanana@def.net', N'1378 Weber Drive Kitchener ON', N'Nanana Ohohoh', N'2016-12-08 09:12:00', N'Master')
SET IDENTITY_INSERT [dbo].[Orders] OFF

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([productID], [productImage], [productName], [productPrice]) VALUES (1, N'boardcard.png', N'Some Card', CAST(29.99 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([productID], [productImage], [productName], [productPrice]) VALUES (2, N'camera.png', N'Digital Camera', CAST(499.99 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([productID], [productImage], [productName], [productPrice]) VALUES (3, N'laptop.png', N'Fast but cheap computer', CAST(299.99 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([productID], [productImage], [productName], [productPrice]) VALUES (4, N'tablet.png', N'Thin and light tablet', CAST(199.99 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF

SET IDENTITY_INSERT [dbo].[Qnas] ON
INSERT INTO [dbo].[Qnas] ([qnaId], [content], [createDate], [customerID], [title], [view]) VALUES (1, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', N'2016-11-21 15:45:00', 1, N'Inquiry Payment Method', 1)
INSERT INTO [dbo].[Qnas] ([qnaId], [content], [createDate], [customerID], [title], [view]) VALUES (2, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', N'2016-11-21 11:23:00', 2, N'Request Payment Method', 1)
INSERT INTO [dbo].[Qnas] ([qnaId], [content], [createDate], [customerID], [title], [view]) VALUES (3, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', N'2016-11-21 08:45:00', 1, N'ASK Payment Method', 1)
INSERT INTO [dbo].[Qnas] ([qnaId], [content], [createDate], [customerID], [title], [view]) VALUES (4, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', N'2016-11-21 21:23:00', 2, N'Sorry Payment Method', 1)
INSERT INTO [dbo].[Qnas] ([qnaId], [content], [createDate], [customerID], [title], [view]) VALUES (5, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', N'2016-11-21 22:08:00', 1, N'Hello, Payment Method', 1)
INSERT INTO [dbo].[Qnas] ([qnaId], [content], [createDate], [customerID], [title], [view]) VALUES (6, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', N'2016-11-21 22:08:00', 1, N'What is the problem?', 1)
SET IDENTITY_INSERT [dbo].[Qnas] OFF

SET IDENTITY_INSERT [dbo].[Receipts] ON
INSERT INTO [dbo].[Receipts] ([receiptID], [CustomerscustomerID], [orderID], [paymentDate], [paymentMethod]) VALUES (1, NULL, 3, N'2016-11-23 14:12:15', N'Master')
INSERT INTO [dbo].[Receipts] ([receiptID], [CustomerscustomerID], [orderID], [paymentDate], [paymentMethod]) VALUES (2, NULL, 2, N'2016-11-22 09:05:11', N'Visa')
SET IDENTITY_INSERT [dbo].[Receipts] OFF
