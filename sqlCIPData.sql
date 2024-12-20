USE [CIP]
GO

SET IDENTITY_INSERT [dbo].[Customer] ON;
GO
-- Insert data into Customer table
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [DateOfBirth], [Gender], [Email], [PhoneNumber], [Address]) 
VALUES 
(1, N'Nguyễn Văn', N'A', CAST(N'1990-05-12' AS Date), 1, N'nguyenvana@gmail.com', N'0912345678', N'Quận 1, TP. Hồ Chí Minh, Việt Nam'),
(2, N'Trần Thị', N'Bích', CAST(N'1985-08-23' AS Date), 2, N'tranthibich@gmail.com', N'0987654321', N'Quận 5, TP. Hồ Chí Minh, Việt Nam'),
(3, N'Lê Minh', N'Tuấn', CAST(N'1978-03-15' AS Date), 1, N'leminhtuan@yahoo.com', N'0905123456', N'Quận Bình Thạnh, TP. Hồ Chí Minh, Việt Nam'),
(4, N'Phạm Thùy', N'Dung', CAST(N'1992-11-05' AS Date), 2, N'phamthuydung@gmail.com', N'0932987654', N'Quận 1, TP. Hồ Chí Minh, Việt Nam'),
(5, N'Hoàng Quốc', N'Khánh', CAST(N'2000-06-01' AS Date), 1, N'hoangquockhanh@gmail.com', N'0916123456', N'Quận 10, TP. Hồ Chí Minh, Việt Nam'),
(6, N'Đỗ Thanh', N'Hoa', CAST(N'1996-09-20' AS Date), 2, N'dothanhhoa@gmail.com', N'0978654321', N'Quận 3, TP. Hồ Chí Minh, Việt Nam'),
(7, N'Bùi Ngọc', N'Hà', CAST(N'1980-12-25' AS Date), 1, N'buingocha@hotmail.com', N'0909988776', N'Quận Tân Bình, TP. Hồ Chí Minh, Việt Nam'),
(8, N'Võ Thu', N'Trang', CAST(N'1998-04-10' AS Date), 2, N'vothutrang@gmail.com', N'0912456789', N'Quận Phú Nhuận, TP. Hồ Chí Minh, Việt Nam'),
(9, N'Phan Văn', N'Khải', CAST(N'1983-07-18' AS Date), 1, N'phanvankhai@gmail.com', N'0903234567', N'Quận 10, TP. Hồ Chí Minh, Việt Nam'),
(10, N'Lý Ngọc', N'Anh', CAST(N'1995-10-30' AS Date), 2, N'lyngocanh@gmail.com', N'0904456789', N'Quận 1, TP. Hồ Chí Minh, Việt Nam'),
(13, N'Test Subject', N'001', CAST(N'2021-01-01' AS Date), 1, N'testsubject001@example.com', N'0111111111', N'TestLab');
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF;  -- Turn it back off
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON;
GO
-- Insert data into Transaction table
INSERT [dbo].[Transaction] ([Id], [CustomerId], [Timestamp], [Type], [Method], [Total]) 
VALUES 
(1, 1, CAST(N'2024-08-05T14:30:00' AS DateTime2), N'Momo', N'Online', 17400000),
(2, 2, CAST(N'2024-08-10T09:15:00' AS DateTime2), N'ZaloPay', N'Online', 2040000),
(3, 3, CAST(N'2024-08-18T16:45:00' AS DateTime2), N'Cash', N'Offline', 19300000),
(4, 4, CAST(N'2024-08-22T11:00:00' AS DateTime2), N'VNPay', N'Online', 32500000),
(5, 5, CAST(N'2024-08-28T13:25:00' AS DateTime2), N'VTCPay', N'Online', 29800000);
GO
SET IDENTITY_INSERT [dbo].[Transaction] OFF;
GO
SET IDENTITY_INSERT [dbo].[Product] ON;
GO
-- Insert data into Product table
INSERT [dbo].[Product] ([Id], [Name], [Price]) 
VALUES 
(1, N'Điện thoại thông minh', 8700000),
(2, N'Laptop văn phòng', 16900000),
(3, N'Tai nghe không dây', 2500000),
(4, N'Tivi 4K Ultra HD', 12900000),
(5, N'Máy ảnh DSLR', 5300000),
(6, N'Bàn phím cơ', 1200000),
(7, N'Chuột chơi game', 800000),
(8, N'Máy giặt lồng ngang', 4600000),
(9, N'Tủ lạnh Inverter', 9400000),
(10, N'Máy lọc không khí', 3100000);
GO
SET IDENTITY_INSERT [dbo].[Product] OFF;
GO
SET IDENTITY_INSERT [dbo].[TransactionDetail] ON;
GO
-- Insert data into TransactionDetail table
INSERT [dbo].[TransactionDetail] ([Id], [TransactionId], [ProductId], [Amount], [Subtotal]) 
VALUES 
(1, 1, 1, 2, 17400000),
(2, 2, 3, 3, 7500000),
(3, 2, 4, 1, 12900000),
(4, 3, 5, 1, 5300000),
(5, 3, 6, 4, 4800000),
(6, 3, 8, 2, 9200000),
(7, 4, 2, 1, 16900000),
(8, 4, 7, 2, 1600000),
(9, 4, 8, 1, 4600000),
(10, 4, 9, 1, 9400000),
(11, 5, 3, 2, 5000000),
(12, 5, 6, 3, 3600000),
(13, 5, 1, 1, 8700000),
(14, 5, 9, 1, 9400000),
(15, 5, 10, 1, 3100000);
GO
SET IDENTITY_INSERT [dbo].[TransactionDetail] OFF;
GO
