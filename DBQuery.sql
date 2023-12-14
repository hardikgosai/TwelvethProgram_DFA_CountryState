Create [GETRICountryStateDb]

USE [GETRICountryStateDb]

CREATE TABLE [dbo].[Country]
([CountryId] [int] identity(1,1) not null primary key,
[Name] [varchar](50) not null
)

CREATE TABLE [dbo].[State]
([StateId] [int] identity(1,1) not null primary key,
[Name] [varchar](50) not null,
[CountryId] [int] foreign key references [dbo].[Country](CountryId)
)