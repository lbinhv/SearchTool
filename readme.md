************ Project name: Search Tool

- Search Tool makes it easy for user to find a string in CSV file.

- The project have two main function:
	+ The first one is provider the Method to create Csv File, and store it in your local drive.
	+ The second on is provider the method to find the string character in Csv file.

- The project have two solutions:
	+ SearchTool: is the MVC project, it contact with end user.
	+ SearchTool.Service: is the Library project to store all business.
	
************* Prerequisites:

Before you begin, ensure you have met the following requirements:
Windows:
- Clone the develop branch

- Open the project by Visual Studio 2019

- Open the Web config in the "SearchTool" project to set value for the Following info below:
	<add key="Pattern" value="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 " /> : This is the random string pattern
	<add key="FolderPath" value="C://MyDir//" />: The directory where you want to store your new CSV file (Please set enough roles for the directory)
	<add key="FileName" value="Testing.csv" />: The Csv's filename
	<add key="Delimiter" value="|" />: the delimiter between each column in CSV file
	<add key="MaxContentLength" value="2000" />: The maximum content length 
	<add key="MinContentLength" value="1000" />: The minimum content length
    <add key="TotalRows" value="100000" />: The maximum number of rows will be created in the CSV file.

************ Installing The Project:

- Open the project in your machine by Visual Studio 2019, try to clean and rebuild the solution.

- Run the project by your visual studio or host it to IIS7 or above.

Using The Search Tool Project:

************ Please follow these steps:

- Step 1: Provide all required keys in the web configuration and project run.
- Step 2: Click the "Insert Data" button in the Home Page and wait until the process is completed.
- Step 3: Tell the tool which keywords you want to find in the CSV file by entering the value in the "TextBox" field and then clicking the "Search Data" button.

************ Contributing to SearchTool project

To contribute to SearchTool project, follow these steps:
- Step 1: Fork this repository.
- Step 2: Create a branch: git checkout -b <branch_name>.
- Step 3: Make your changes and commit them: git commit -m '<commit_message>'
- Step 4: Push to the original branch: git push origin <project_name>/<location>
- Step 5: Create the pull request.
