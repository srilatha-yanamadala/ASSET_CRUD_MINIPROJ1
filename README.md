# Welcome to AssetTracking Miniproject!

Hi! I'm Srilatha and this is my first mini project in C#. 

**Asset Tracking ** is a project done  as part of my c# training and it does the following.

 -  Reads user's laptop / mobile assets details
 -  Stores them in the database, by using the Entity framework core in C#. 
 -  Performs CRUD operations on the data, based on user's input.
 
**CRUD** -- **C**reate **R**ead **U**pdate and **D**elete


### To Run the application
 1. Clone the repository to your local folder
 2. Open the project in Visual Studio
 3. Right click on AssetTracking.ConsoleApp project and select Set as Starup project option.
 4. In Package manager console, select the default project as AssetTracking:Data 
 5. Then run below commands: 
	a. add-migration init
	b. update-database
	
	***Note***: These 2 commands will create the AssetTrackingContext database and tables.

 6. Once the above 2 commands are done, refresh sql server and check that the below tables are present:
	1. Computer
	2. Office
	3. Phone
	
 7. After verificying the table creation,  just run the program.cs 

 8. Use the sample test data provided below.

 9. Once the execution is completed, verify the data in the tables. (Computer, office and Phone)


##################################################################


**Current status of the project:**

 - Only CREATE and READ operations are done as of now. 
 - Delete operation is checked and it's working fine for one record, when ID is passed.
 
 
**TODO:**

UPDATE is still to be done.
DELETE is partially done and tested.
Text formatting based on the validity dates


##################################################################


**SAMPLE TEST DATA**

Enter 'q' twice, to come out of the program.

***laptop***

 Model:  Inspiron / xps (Note that the computer's Brand name is hard coded to DELL for  quick testing, this can be changed)
 
 Purchase date: 2020-01-01
 
 Purchase Price: 650.99

***mobile***

 Model:  iPhone10 (Note that the phone's Brand name is hard coded to APPLE for quick testing, this can be changed)
 
 Purchase date: 2020-01-01
 
 Purchase Price: 650.99



