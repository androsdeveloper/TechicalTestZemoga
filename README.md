
Name candidate: Andrés Alzate

This project has two main projects
	1. Zemoga.Presentation
	2. Zemoga.Service

1. Zemoga.Presentation

	Considerations: 
	
	- In writer/index you can see only Posts with rejected == true

	- In editor/index you can see only Posts with PendingApproval == true

	-This project doesn´t have design because it wasn´t neccesary in the technical test

	-Skipped standard database modeling because testing needs to focus on .net
	
	- In this moment i don´t have a personal suscription in azure for publish the solution,
	but if you can lend me one, I'll do it in a moment

	- to see the writer in the grid, a user must be inserted in the user table with id 1 (this hardcode when inserting)

	Note: 
	it is recommended to run visual studio as administrator to install the package.json dependencies without problems

	Database context is in Zemoga.DAL, it was generated with Microsoft.EntityFrameworkDesign
	Connection is very simple to ease its review, in case that there is a problem execute this command 
	in "Package Manager Console"

		Scaffold-DbContext "Server=.;Database=Test;Integrated Security=True""
		Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

	USERS EDITOR AND WRITER

	For Writer user
	UserName: writer@writer.com
	Pass: 123

	For Editor user
	UserName: editor@editor.com
	Pass: 123

	Note:
	Logic about login is in AccountController in Zemoga.Presentation, roles and users are like hardcodes
	
	In injection of dependencies the native of .net core was used in startup, it's very simple really

2. Zemoga.Service
	I have implemented Swagger to facilitate the test of the service
	The URL is https://localhost:[your Port]/index.html or if you prefer use POSTMAN, 
	for time i don't use security like oauth, the authorization is for whatever request

Time of test: Approximately 6.5 hours