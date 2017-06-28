# SCServer
Configuration Server, that push modules access information to the multiple client apps. 

# Prerequisites 
Visual Studio 2013 Update 4, SQL Server 2014, Git for Windows

#Technologies 
MVC Webapi, C#, Unity IoC, Nibernate, FluentNhiberate.

# Project Definitions 

1. SCServer.Api: It is a MVC web api project in C#.  It contains controller and end points where data can fetched for different customers provider they sceret key.

2. SCSServer.Common:  It contain common helper classes, which are used throughout project like json conversions, app settings and connection string reader.

3.  SCServer.Core : This class library contains, Model and DTO classes, Nhiberate mapping and interface for Repository and Services. This CORE project provide all abstractions needed to run the web api. we can provide this class library to multiple data provider, and each one can has its own implementation of these given interface and models.

4.  SCServer.Repository : This class library contains generic and customized implementations of all CURD operation.

5.  SCServer.Servies    : This class library reference SCServer.Repository for database operations and business logics can be added here.
