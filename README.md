CLI Task Timer

A command-line interface (CLI) application that helps users efficiently time and manage tasks, making it easy to track how long they spend on each activity. This tool is especially useful for individuals who want to optimize their workflow, productivity, or study habits.
Project Overview

The CLI Task Timer project is designed to help users time and manage tasks directly from the command line. This lightweight application is ideal for developers, students, freelancers, and professionals who prefer working in a terminal environment and want a simple tool to track how long they spend on specific tasks.
Goals and Features
Goals:

    Provide a simple, intuitive interface for task timing.
    Help users improve productivity by tracking time spent on each task.
    Enable users to view their task history and analyze how time is allocated.

Features:

    Start/Stop Timer: Begin or end a timer for a specific task.
    Task Naming: Assign custom names to tasks for better organization.
    Task History: View previous tasks and their time durations.
    Pause/Resume: Pause the task timer and resume later as needed.
    Export Data: Option to export task history to a text or CSV file for easy reporting.

Technologies Used:

1. Python:

    Primary language for the core CLI functionality, task management, and timer logic.
    Packages:
        Click: For building the command-line interface.
        SQLite3: For storing task history and logs locally.
        CSV: Used for exporting task data in CSV format.
        Pytest: For testing the application's functionality.

2. C#:

    Used for implementing additional backend logic to handle complex operations such as task reporting and exporting data to different formats.
    Packages:
        System.IO: For reading and writing files.
        System.Data.SQLite: For interacting with SQLite database from the C# backend.
        NUnit: For testing C# components.
        Json.NET: For exporting task history to JSON format if needed.

3. JavaScript:

    Integrated into the project for front-end extensions, such as future integration with web-based task viewing dashboards or for enhanced user interfaces in CLI.
    Packages:
        Node.js: For running JavaScript in server-side environments and handling task-related processes asynchronously.
        Inquirer.js: For building interactive command-line prompts if needed for more user-friendly interactions.
        Express.js: Used for creating a lightweight API that might communicate with the CLI for task reporting.
        Jest: For unit testing the JavaScript components.

    
A command-line interface (CLI) application that helps users efficiently time and manage tasks, making it easy to track how long they spend on each activity. This tool is especially useful for individuals who want to optimize their workflow, productivity, or study habits.


Instructions for Running the Project

    Clone the Repository:
1. Python:

git clone <repository-link>
cd cli-task-timer

Install Dependencies:

pip install -r requirements.txt

Run the Task Timer:

python task_timer.py

Commands:

    Start a new task: task_timer start "Task Name"
    Stop the current task: task_timer stop
    View task history: task_timer history
    Export task data: task_timer export --format csv


2. C# Version

    Clone the Repository:

git clone <repository-link>
cd cli-task-timer

Open the Project:

    Open the project in your preferred C# IDE (such as Visual Studio or Rider).
    Make sure the necessary dependencies (like System.Data.SQLite and Json.NET) are installed via NuGet Package Manager.

Build the Project:

    In Visual Studio: Click on Build > Build Solution.
    Alternatively, you can run the following command in the terminal:

    dotnet build

Run the Task Timer:

    Run the application through the IDE or use the following command in the terminal:

        dotnet run --project CliTaskTimer

    C# Commands:
        Start a new task: CliTaskTimer.exe start "Task Name"
        Stop the current task: CliTaskTimer.exe stop
        View task history: CliTaskTimer.exe history
        Export task data: CliTaskTimer.exe export --format json

3. JavaScript Version

    Clone the Repository:

git clone <repository-link>
cd cli-task-timer

Install Dependencies:

npm install

Run the Task Timer:

node task_timer.js

JavaScript Commands:

    Start a new task: node task_timer.js start "Task Name"
    Stop the current task: node task_timer.js stop
    View task history: node task_timer.js history
    Export task data: node task_timer.js export --format csv
