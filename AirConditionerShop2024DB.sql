USE [master]
GO
DROP DATABASE [AirConditionerShop2024DB]
GO
/****** Object:  Database [AirConditionerShop2024DB]    Script Date: 2/11/2025 10:07:33 PM ******/
CREATE DATABASE [AirConditionerShop2024DB]

GO
USE [AirConditionerShop2024DB]

GO
/****** Object:  Table [dbo].[SupplierCompany]    Script Date: 2/11/2025 10:07:33 PM ******/
CREATE TABLE [dbo].[SupplierCompany](
	[SupplierId] [nvarchar](20) PRIMARY KEY,
	[SupplierName] [nvarchar](80) NOT NULL,
	[SupplierDescription] [nvarchar](250) NULL,
	[PlaceOfOrigin] [nvarchar](60) NULL,
)
GO
INSERT [dbo].[SupplierCompany] ([SupplierId], [SupplierName], [SupplierDescription], [PlaceOfOrigin]) VALUES (N'SC0005', N'Daikin', N'A global leader in air conditioning manufacturing that provides energy-efficient and reliable for both residential and commercial use.', N'Japan')
INSERT [dbo].[SupplierCompany] ([SupplierId], [SupplierName], [SupplierDescription], [PlaceOfOrigin]) VALUES (N'SC0006', N'Carrier ', N'A well-known brand that offers a variety of air conditioning units, including split systems, window units, and portable systems.', N'Korea')
INSERT [dbo].[SupplierCompany] ([SupplierId], [SupplierName], [SupplierDescription], [PlaceOfOrigin]) VALUES (N'SC0007', N'Mitsubishi Electric', N'A top supplier of ductless air conditioning units that are ideal for small or confined spaces.', N'Germany')
INSERT [dbo].[SupplierCompany] ([SupplierId], [SupplierName], [SupplierDescription], [PlaceOfOrigin]) VALUES (N'SC0008', N'Lennox', N'A popular supplier of central air conditioning systems known for its high-quality and energy-efficient units.', N'United Kingdom')
INSERT [dbo].[SupplierCompany] ([SupplierId], [SupplierName], [SupplierDescription], [PlaceOfOrigin]) VALUES (N'SC0009', N'Trane ', N'A trusted brand that provides a range of air conditioning units, including split systems, heat pumps.', N'Nauy')

GO
/****** Object:  Table [dbo].[StaffMember]    Script Date: 2/11/2025 10:07:33 PM ******/

CREATE TABLE [dbo].[StaffMember](
	[MemberID] [int] PRIMARY KEY,
	[Password] [nvarchar](40) NOT NULL,
	[FullName] [nvarchar](60) NOT NULL,
	[EmailAddress] [nvarchar](60) UNIQUE,
	[Role] [int] NULL,
)
GO
INSERT [dbo].[StaffMember] ([MemberID], [Password], [FullName], [EmailAddress], [Role]) VALUES (1982, N'@1', N'Administrator', N'admin@AirConditionerShop.com.sg', 1)
INSERT [dbo].[StaffMember] ([MemberID], [Password], [FullName], [EmailAddress], [Role]) VALUES (1983, N'@2', N'Staff', N'staff@AirConditionerShop.com.sg', 2)
INSERT [dbo].[StaffMember] ([MemberID], [Password], [FullName], [EmailAddress], [Role]) VALUES (1984, N'@3', N'Manager', N'manager@AirConditionerShop.com.sg', 3)
GO
/****** Object:  Table [dbo].[AirConditioner]    Script Date: 2/11/2025 10:07:33 PM ******/

CREATE TABLE [dbo].[AirConditioner](
	[AirConditionerId] [int] IDENTITY PRIMARY KEY,
	[AirConditionerName] [nvarchar](200) NOT NULL,
	[Warranty] [nvarchar](60) NULL,
	[SoundPressureLevel] [nvarchar](80) NULL,
	[FeatureFunction] [nvarchar](250) NULL,
	[Quantity] [int] NULL,
	[DollarPrice] [float] NULL,
	[SupplierId] [nvarchar](20) NULL references SupplierCompany(SupplierId) on delete cascade on update cascade
)


GO
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'4-16KW A+++ DC Inverter Monoblock Air Source Heat Pump for Hot Water Home Heating Cooling', N'3 years', N'53dB(A)', N'House Heating Cooling and Water Heating', 12, 2978, N'SC0005')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Hisense AC 9000btu 12000btu 18000btu 24000btu Cooling Inverter Super Save Energy wall mounted Wifi Home Air Conditioner Factory', N'5 years', N'18-45dB', N'Split Wall Mounted Air Conditioners', 10, 4412, N'SC0005')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Gree Air To Water Versati III Split Inverter Heat Pump 380v 10kw 12kw 14kw 16kw 18kw', N'2 years', N'48dB(A)', N'House Heating Cooling and Water Heating', 15, 3765, N'SC0006')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Gree 2022 R32 R410a Split Heatpump 10kw 15kw 20kw Germany Warmepumpe Mini Split Inverter Air Source Heat Pump For Sale', N'1 years', N'49/50dB(A)', N'Air Source Heat Pump', 18, 2034, N'SC0006')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'R290 Monoblock DC EVI Invert Air to Water Heat Pump for Home Central Heating air conditioner Sanitary Hot water', N'10 years', N'18-60dB', N'Heating + Hot Water+cooling', 15, 3120, N'SC0007')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Competitive Portable Heat Pump Air Conditioner Hot Water Heating Cooling Heat Pumps', N'6 years', N'44/45dB', N'Swimming Pool Heating Cooling', 10, 3600, N'SC0007')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Lennox Aquarea High Performance Heat Pump 9kW Split Inverter', N'5 years', N'46dB(A)', N'House Heating and Cooling', 12, 2890, N'SC0008')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Lennox Therma V R32 Monobloc Split 16kW Air Source Heat Pump', N'3 years', N'43/44dB(A)', N'Air to Water Heat Pump', 20, 4250, N'SC0008')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Trane Electric Ecodan R32 14kW Monobloc Air Source Heat Pump', N'4 years', N'42dB(A)', N'Central Heating and Cooling', 17, 3999, N'SC0009')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Trane Estia R32 Air to Water Split 11kW Heat Pump', N'7 years', N'47/48dB(A)', N'House Heating and Sanitary Hot Water', 13, 3500, N'SC0009')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Inverter 2 Hp 42XIT018 ', N'2 years', N'46dB(A)', N'Fast cooling function, smooth airflow, smart wind deflector', 13, 2025, N'SC0006')
INSERT [dbo].[AirConditioner] ([AirConditionerName], [Warranty], [SoundPressureLevel], [FeatureFunction], [Quantity], [DollarPrice], [SupplierId]) VALUES (N'Inverter 1.5 Hp ATKF35YVMV/ARKF35YVMV', N'2 years', N'42dB(A)', N'Fast cooling function, antibacterial Streamer technology, anti-mold function', 22, 2024, N'SC0005')

