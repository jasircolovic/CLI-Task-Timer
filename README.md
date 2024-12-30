CLI Task Timer

A command-line interface (CLI) application designed to help users efficiently time and manage tasks, making it easy to track how long they spend on various activities. This tool is particularly useful for individuals aiming to optimize their workflow, productivity, or study habits. The project demonstrates the same functionality implemented in Python, C#, and JavaScript, allowing users to choose their preferred programming language.

Project Overview

The CLI Task Timer project enables users to time and manage tasks from the command line. It is lightweight, intuitive, and ideal for developers, students, freelancers, and professionals who prefer a terminal-based environment.

Goals
	1.	Provide a simple interface for tracking task durations.
	2.	Help users improve productivity by analyzing time allocation.
	3.	Allow users to export task data for further analysis.

Features
	1.	Start/Stop Timer: Begin or stop tracking a task.
	2.	Task Naming: Assign custom names to tasks.
	3.	Task History: View a log of past tasks and their durations.
	4.	Pause/Resume Timer: Temporarily pause and restart tracking.
	5.	Export Data: Save task history as text or CSV files.

Implementation in Python, C#, and JavaScript

Each programming language implements the same core features but uses its own syntax and libraries.

Python
	•	Packages:
	•	Click: For CLI interactions.
	•	SQLite3: To store task history.
	•	CSV: For exporting task data.
	•	Pytest: For testing functionality.

C#
	•	Libraries:
	•	System.IO: For file handling.
	•	System.Data.SQLite: To interact with the database.
	•	Json.NET: For exporting task data to JSON.
	•	NUnit: For testing.

JavaScript
	•	Packages:
	•	Node.js: For execution in server environments.
	•	Inquirer.js: For interactive CLI prompts.
	•	SQLite: For data storage.
	•	Jest: For unit testing.

Instructions for Running the Project

Python Version
	1.	Clone the Repository:

git clone <repository-link>
cd cli-task-timer


	2.	Install Dependencies:

pip install -r requirements.txt


	3.	Run the Application:

python task_timer.py



Commands:
	•	Start a new task: task_timer start "Task Name"
	•	Stop the current task: task_timer stop
	•	View task history: task_timer history
	•	Export data: task_timer export --format csv

C# Version
	1.	Clone the Repository:

git clone <repository-link>
cd cli-task-timer


	2.	Open the Project:
Open it in Visual Studio or Rider. Install dependencies using NuGet Package Manager.
	3.	Build the Project:
	•	In Visual Studio: Go to Build > Build Solution.
	•	Or, in the terminal:

dotnet build


	4.	Run the Application:

dotnet run --project CliTaskTimer



Commands:
	•	Start a new task: CliTaskTimer.exe start "Task Name"
	•	Stop the current task: CliTaskTimer.exe stop
	•	View task history: CliTaskTimer.exe history
	•	Export data: CliTaskTimer.exe export --format json

JavaScript Version
	1.	Clone the Repository:

git clone <repository-link>
cd cli-task-timer


	2.	Install Dependencies:

npm install


	3.	Run the Application:

node task_timer.js



Commands:
	•	Start a new task: node task_timer.js start "Task Name"
	•	Stop the current task: node task_timer.js stop
	•	View task history: node task_timer.js history
	•	Export data: node task_timer.js export --format csv