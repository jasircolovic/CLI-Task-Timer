# CLI Task Timer

A command-line interface (CLI) application designed to help users efficiently time and manage tasks, making it easy to track how long they spend on various activities. This tool is particularly useful for individuals aiming to optimize their workflow, productivity, or study habits. The project demonstrates the same functionality implemented in Python, C#, and JavaScript, allowing users to choose their preferred programming language.

## Project Overview

The CLI Task Timer project enables users to time and manage tasks from the command line. It is lightweight, intuitive, and ideal for developers, students, freelancers, and professionals who prefer a terminal-based environment.

## Goals

1. Provide a simple interface for tracking task durations.  
2. Help users improve productivity by analyzing time allocation.  
3. Allow users to export task data for further analysis.

## Features

1. **Start/Stop Timer**: Begin or stop tracking a task.  
2. **Task Naming**: Assign custom names to tasks.  
3. **Task History**: View a log of past tasks and their durations.  
4. **Pause/Resume Timer**: Temporarily pause and restart tracking.  
5. **Export Data**: Save task history as text, json, or CSV files.

---

## Implementation in Python, C#, and JavaScript

Each programming language implements the same core features but uses its own syntax and libraries.

### Python

- **Packages**: None required. The Python implementation avoids any external dependencies and only uses the Python standard library.  
- **Storage**: Task data is saved in a local `tasks.json` file.  
- **Commands**:
  - `start <task_name>`: Begin tracking a new task or resume a previously completed one.  
  - `stop <task_name>`: Stop the current active task and update its total time.  
  - `pause <task_name>`: Temporarily pause the current active task without marking it as complete.  
  - `resume <task_name>`: Restart a paused task.  
  - `status <task_name>`: Display the status and total time of a specific task, including live elapsed time if it's active.  
  - `summary`: Display a summary of all tasks, including their total time and statuses.  
- **Instructions**:
  1. Clone the Repository:  
     ```bash
     git clone https://github.com/your-repo/cli-task-timer.git
     cd cli-task-timer
     ```
  2. Run the Application:  
     ```bash
     python task_timer.py
     ```
  3. Example Commands:  
     ```bash
     python task_timer.py start "My Task"
     python task_timer.py status "My Task"
     python task_timer.py pause "My Task"
     python task_timer.py resume "My Task"
     python task_timer.py stop "My Task"
     python task_timer.py summary
     ```

### C#

- **Libraries**:
  - `System.IO`: For file handling.  
  - `System.Data.SQLite`: To interact with the database.  
  - `Json.NET`: For exporting task data to JSON.  
  - `NUnit`: For testing.  
- **Instructions**:
  1. Clone the Repository:  
     ```bash
     git clone https://github.com/your-repo/cli-task-timer.git
     cd cli-task-timer
     ```
  2. Open the Project in Visual Studio or Rider. Install dependencies using NuGet Package Manager.  
  3. Build the Project:  
     - In Visual Studio: Go to Build > Build Solution.  
     - Or, in the terminal:  
       ```bash
       dotnet build
       ```
  4. Run the Application:  
     ```bash
     dotnet run --project CliTaskTimer
     ```
  5. Example Commands:  
     ```bash
     CliTaskTimer.exe start "My Task"
     CliTaskTimer.exe stop "My Task"
     CliTaskTimer.exe history
     CliTaskTimer.exe export --format json
     ```

### JavaScript

- **Packages**:
  - `Node.js`: For execution in server environments.  
  - `Inquirer.js`: For interactive CLI prompts.  
  - `SQLite`: For data storage.  
  - `Jest`: For unit testing.  
- **Instructions**:
  1. Clone the Repository:  
     ```bash
     git clone https://github.com/your-repo/cli-task-timer.git
     cd cli-task-timer
     ```
  2. Install Dependencies:  
     ```bash
     npm install
     ```
  3. Run the Application:  
     ```bash
     node task_timer.js
     ```
  4. Example Commands:  
     ```bash
     node task_timer.js start "My Task"
     node task_timer.js stop "My Task"
     node task_timer.js history
     node task_timer.js export --format csv
     ```
