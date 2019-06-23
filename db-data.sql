USE [PhotographyAutomationDB]
GO
SET ANSI_PADDING ON
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'f3a342eb-e332-e911-aad7-742f68c6e6e6', NULL, N'Root', N'/173203677750903.275198238888107.1929032355/', CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), 1, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'92e49896-d63d-e911-aae0-742f68c6e6e6', NULL, N'1397', N'/173203677750903.275198238888107.1929032355/104605482832585.172909875804275.3671597573/', CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'93e49896-d63d-e911-aae0-742f68c6e6e6', NULL, N'12', N'/173203677750903.275198238888107.1929032355/104605482832585.172909875804275.3671597573/87998538837917.234499316018755.4097516364/', CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'1e558136-806e-e911-82b2-00271005f7f4', NULL, N'1398', N'/173203677750903.275198238888107.1929032355/163602302140948.157546683170465.4247371151/', CAST(N'2019-05-04T19:50:57.0825630+04:30' AS DateTimeOffset), CAST(N'2019-05-04T19:50:57.0825630+04:30' AS DateTimeOffset), CAST(N'2019-05-04T19:50:57.0825630+04:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'1f558136-806e-e911-82b2-00271005f7f4', NULL, N'2', N'/173203677750903.275198238888107.1929032355/163602302140948.157546683170465.4247371151/39951644129968.213621565963338.2077679045/', CAST(N'2019-05-04T19:50:59.0946781+04:30' AS DateTimeOffset), CAST(N'2019-05-04T19:50:59.0946781+04:30' AS DateTimeOffset), CAST(N'2019-05-04T19:50:59.0946781+04:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'7c87c33b-967c-e911-a2f8-00271005f7f4', NULL, N'3', N'/173203677750903.275198238888107.1929032355/163602302140948.157546683170465.4247371151/218873327760226.58602950833896.132922427/', CAST(N'2019-05-22T18:03:51.1109355+04:30' AS DateTimeOffset), CAST(N'2019-05-22T18:03:51.1109355+04:30' AS DateTimeOffset), CAST(N'2019-05-22T18:03:51.1109355+04:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
SET ANSI_PADDING OFF
SET IDENTITY_INSERT [dbo].[TblPrintSizePrices] ON 

INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (20, N'3.50 x 4.50', 3.5000, 4.5000, 180000, 150000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (21, N'5.00 x 5.00', 5.0000, 5.0000, 180000, 150000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (22, N'5.00 x 7.00', 5.0000, 7.0000, 250000, 200000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (23, N'6.00 x 4.00', 6.0000, 4.0000, 180000, 150000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (24, N'6.00 x 9.00', 6.0000, 9.0000, 250000, 200000, N'حداقل تعداد چاپ 6 عدد می باشد.')
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (25, N'10 x 15', 10.0000, 15.0000, 160000, 130000, N'')
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (28, N'2 x 3', 2.0000, 3.0000, 150000, 120000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (29, N'3 x 4', 3.0000, 4.0000, 150000, 120000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (1028, N'6.5 x 4.5', 6.5000, 4.5000, 180000, 150000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (1029, N'8 x 10', 8.0000, 10.0000, 150000, 120000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (1030, N'13 x 18', 13.0000, 18.0000, 160000, 130000, NULL)
SET IDENTITY_INSERT [dbo].[TblPrintSizePrices] OFF
SET IDENTITY_INSERT [dbo].[TblPrintServices] ON 

INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (1, N'10', N'شاسی 8 میل', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (2, N'11', N'شاسی 16 میل', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (3, N'12', N'قاب و شیشه سفید', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (4, N'13', N'قاب و شیشه قهوه ای', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (5, N'14', N'قاب شاسی سفید', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (6, N'15', N'قاب شاسی قهوه ای', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (7, N'16', N'فریم 2 سانتی سفید', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (9, N'17', N'فریم 2 سانتی قهوه ای', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (10, N'18', N'فریم 4 سانتی سفید', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (12, N'19', N'فریم 4 سانتی قهوه ای', NULL)
SET IDENTITY_INSERT [dbo].[TblPrintServices] OFF
SET IDENTITY_INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ON 

INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ([Id], [PrintServiceId], [PrintSizePriceId], [Code], [Price], [Description]) VALUES (16, 1, 1030, N'Sh8m13x18', 70000, NULL)
INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ([Id], [PrintServiceId], [PrintSizePriceId], [Code], [Price], [Description]) VALUES (17, 2, 1030, N'', 80000, NULL)
SET IDENTITY_INSERT [dbo].[TblPrintServices_TblPrintSizePrice] OFF
SET IDENTITY_INSERT [dbo].[TblAtelierType] ON 

INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (1, 10, N'آتلیه پرسنلی')
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (2, 20, N'آتلیه هنری')
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (3, 30, N'آتلیه کودک')
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (4, 40, N'فضای باز سرو')
SET IDENTITY_INSERT [dbo].[TblAtelierType] OFF
SET IDENTITY_INSERT [dbo].[TblBookingStatus] ON 

INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (2, 10, N'فعال')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (3, 20, N'غیر فعال')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (4, 30, N'حذف')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (5, 40, N'ورود به آتلیه')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (6, 50, N'در انتظار بیعانه')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (7, 60, N'لغو مشتری')
SET IDENTITY_INSERT [dbo].[TblBookingStatus] OFF
SET IDENTITY_INSERT [dbo].[TblCustomer] ON 

INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (13, N'علی', N'موذن صفایی', 1, N'اصفهان', N'3136676755', N'9332350909', N'alisafaie@gmail.com', N'1290795274 ', 0, 1, CAST(N'1983-09-03' AS Date), CAST(N'2014-02-18' AS Date), 1, 0, NULL, CAST(N'2019-01-13 20:37:11.500' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (14, N'علی', N'مؤذن صفایی', 1, N'اصفهان، خ هفت دست شرقی', N'3136676755', N'9133138675', N'', N'1290795274 ', NULL, 0, CAST(N'1983-09-03' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-05-18 15:48:04.413' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (15, N'کوشا', N'کیانی فلاورجانی', 0, N'', N'3132337738', N'9999999999', N'', N'           ', NULL, 0, CAST(N'1987-06-01' AS Date), NULL, NULL, 0, NULL, CAST(N'2019-02-28 11:32:38.573' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (16, N'علی', N'احمدی', 1, N'', N'3136676755', N'9888888888', N'', N'           ', NULL, 0, CAST(N'1974-09-03' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-02 13:21:21.633' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (17, N'علی', N'احمدیان', 0, N'', N'3136676755', N'9777777777', N'', N'           ', 0, 0, NULL, NULL, 1, 0, NULL, CAST(N'2019-01-17 17:37:42.633' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (18, N'عزیز', N'عزیزیان', 1, N'', N'3136676855', N'9666666665', N'aziz@azizian.com', N'           ', NULL, 0, CAST(N'1983-09-03' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-16 18:35:16.920' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (19, N'کوشا', N'کیانی', 0, N'', N'3136676755', N'9131666288', N'kooshakiani@yahoo.com', N'           ', NULL, 0, CAST(N'1987-06-01' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-16 18:35:05.157' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (20, N'علی', N'کیانی', 0, N'', N'3136249500', N'9131152123', N'', N'           ', 0, 0, CAST(N'1958-05-03' AS Date), NULL, 1, 0, NULL, CAST(N'2019-02-27 19:30:46.880' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (21, N'احسان', N'بابائیان', 1, N'', N'3132352553', N'9131684870', N'', N'           ', NULL, 1, CAST(N'1981-07-27' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-16 18:33:16.347' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (22, N'حسین', N'موذن صفایی', 1, N'', N'3132337738', N'9131188156', N'', N'           ', NULL, 1, CAST(N'1948-12-23' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-06-10 12:09:49.270' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (23, N'زهرا', N'فلفلیان', 0, N'', N'3132337738', N'9133081799', N'', N'           ', NULL, 1, NULL, NULL, NULL, 0, NULL, CAST(N'2019-03-07 21:54:34.607' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (24, N'حمیدرضا', N'خباز زاده', 1, N'', N'3134510265', N'9123365946', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, CAST(N'2019-06-02 13:04:41.817' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (27, N'شمیم', N'آل یاسین', 1, N'', N'3136676755', N'9303345002', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, CAST(N'2019-05-05 18:28:36.663' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (28, N'احمد', N'کیانی', 1, N'', N'3136565677', N'9123334444', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, CAST(N'2019-06-09 19:26:22.133' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (29, N'فاطمه', N'رهنما', 0, N'', N'3136676677', N'9132151076', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, CAST(N'2019-06-10 09:52:00.327' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (30, N'فریناز', N'بیدادی', 0, N'', N'3137389922', N'9352391592', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, CAST(N'2019-06-16 11:43:40.253' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TblCustomer] OFF
SET IDENTITY_INSERT [dbo].[TblPhotographyType] ON 

INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (1, 10, N'پرسنلی')
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (2, 20, N'کودک')
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (3, 30, N'خانوادگی')
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (4, 40, N'نامزدی')
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (5, 50, N'جشن')
SET IDENTITY_INSERT [dbo].[TblPhotographyType] OFF
SET IDENTITY_INSERT [dbo].[TblBooking] ON 

INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1, 15, CAST(N'2019-02-28' AS Date), CAST(N'09:48:24' AS Time), 0, 4, 2, 2, 0, 0, 6, CAST(N'2019-01-17 09:48:41.960' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (2, 18, CAST(N'2019-02-28' AS Date), CAST(N'10:00:00' AS Time), 2, 1, 1, 1, 0, 0, 6, CAST(N'2019-01-17 17:57:50.387' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (3, 18, CAST(N'2019-02-28' AS Date), CAST(N'20:25:00' AS Time), 2, 1, 1, 1, 0, 0, 6, CAST(N'2019-01-17 17:59:07.350' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (4, 18, CAST(N'2019-02-27' AS Date), CAST(N'18:41:00' AS Time), 2, 4, 2, 4, 0, 0, 6, CAST(N'2019-01-17 18:41:55.020' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (5, 18, CAST(N'2019-02-28' AS Date), CAST(N'18:30:00' AS Time), 2, 3, 2, 1, 0, 0, 6, CAST(N'2019-01-17 18:49:23.000' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (14, 14, CAST(N'2019-03-05' AS Date), CAST(N'18:00:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-02 11:19:37.810' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (15, 19, CAST(N'2019-02-27' AS Date), CAST(N'19:00:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-02-26 18:00:38.933' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (16, 21, CAST(N'2019-03-19' AS Date), CAST(N'11:00:00' AS Time), 2, 2, 3, 3, 0, 0, 6, CAST(N'2019-03-16 18:33:36.130' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (17, 22, CAST(N'2019-03-14' AS Date), CAST(N'10:00:00' AS Time), 2, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-07 21:36:55.843' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (18, 24, CAST(N'2019-03-12' AS Date), CAST(N'17:00:00' AS Time), 2, 1, 1, 3, 0, 0, 6, CAST(N'2019-03-09 12:41:53.727' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (20, 14, CAST(N'2019-05-08' AS Date), CAST(N'09:30:00' AS Time), 0, 2, 3, 1, 0, 0, 6, CAST(N'2019-05-04 21:22:47.960' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (21, 14, CAST(N'2019-03-29' AS Date), CAST(N'11:30:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-29 13:43:16.013' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1021, 14, CAST(N'2019-03-30' AS Date), CAST(N'10:30:00' AS Time), 2, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-29 14:57:25.080' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1022, 14, CAST(N'2019-03-30' AS Date), CAST(N'17:00:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-30 11:02:02.403' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1023, 14, CAST(N'2019-05-05' AS Date), CAST(N'16:30:00' AS Time), 1, 1, 1, 4, 0, 0, 6, CAST(N'2019-05-02 19:26:47.830' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1024, 14, CAST(N'2019-05-04' AS Date), CAST(N'13:00:00' AS Time), 2, 1, 1, 1, 0, 0, 6, CAST(N'2019-05-04 12:52:08.260' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1025, 14, CAST(N'2019-05-06' AS Date), CAST(N'12:45:00' AS Time), 2, 2, 3, 4, 0, 0, 6, CAST(N'2019-05-04 21:24:05.157' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1026, 27, CAST(N'2019-05-08' AS Date), CAST(N'17:30:00' AS Time), 0, 3, 3, 5, 0, 0, 5, CAST(N'2019-05-05 18:10:47.447' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1027, 24, CAST(N'2019-05-09' AS Date), CAST(N'19:00:00' AS Time), 0, 3, 2, 1, 0, 0, 5, CAST(N'2019-05-09 15:02:01.200' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1028, 14, CAST(N'2019-05-13' AS Date), CAST(N'17:00:00' AS Time), 0, 2, 3, 3, 0, 0, 5, CAST(N'2019-05-13 12:18:48.090' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1029, 14, CAST(N'2019-05-18' AS Date), CAST(N'17:00:00' AS Time), 0, 2, 3, 5, 0, 0, 5, CAST(N'2019-05-18 15:48:30.367' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1030, 29, CAST(N'2019-06-11' AS Date), CAST(N'20:00:00' AS Time), 0, 2, 3, 3, 0, 0, 5, CAST(N'2019-06-10 09:52:45.057' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1031, 22, CAST(N'2019-06-13' AS Date), CAST(N'17:30:00' AS Time), 2, 3, 2, 3, 0, 0, 5, CAST(N'2019-06-10 12:10:42.533' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1032, 30, CAST(N'2019-06-20' AS Date), CAST(N'10:30:00' AS Time), 0, 2, 3, 5, 0, 0, 5, CAST(N'2019-06-16 11:44:03.430' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TblBooking] OFF
SET IDENTITY_INSERT [dbo].[TblOrderStatus] ON 

INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (3, 10, N'ورود به آتلیه')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (4, 20, N'بارگزاری عکس')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (5, 30, N'انتخاب عکس و سایز')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (6, 40, N'انتخاب آلبوم و خدمات ')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (8, 50, N'تعیین اولویت')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (9, 60, N'در حال پردازش')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (10, 70, N'بازبینی عکس')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (11, 80, N'در حال چاپ')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (12, 90, N'خدمات اضافه')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (13, 100, N'ساخت آلبوم')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (14, 110, N'تائید مالی')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (15, 120, N'تحویل به مشتری')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (16, 130, N'راکد')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (17, 140, N'ارسال ناقص فایل ها')
SET IDENTITY_INSERT [dbo].[TblOrderStatus] OFF
SET IDENTITY_INSERT [dbo].[TblOrderPrintStatus] ON 

INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (1, 10, N'---')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (4, 20, N'انتخاب عکس')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (6, 30, N'بازبینی عکس')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (7, 40, N'در حال رتوش و پردازش')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (8, 50, N'بررسی عکس های رتوش شده')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (10, 60, N'در حال چاپ')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (12, 70, N'ساخت آلبوم')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (13, 80, N'در حال انجام خدمات')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (14, 90, N'چاپ شده')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (15, 100, N'قبل از چاپ Ok')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (17, 110, N'در صف رتوش')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (18, 120, N'تحویل به مشتری')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (19, 130, N'راکد انتخاب عکس')
INSERT [dbo].[TblOrderPrintStatus] ([Id], [Code], [Name]) VALUES (22, 140, N'راکد چاپ شده')
SET IDENTITY_INSERT [dbo].[TblOrderPrintStatus] OFF
