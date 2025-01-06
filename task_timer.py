#!/usr/bin/env python3

"""
Task Timer CLI
--------------
A terminal-based program to track, pause, resume, stop, and report on tasks.
Data is stored in a local JSON file named 'tasks.json'.

Usage:
  python task_timer.py start <task_name>
  python task_timer.py stop <task_name>
  python task_timer.py pause <task_name>
  python task_timer.py resume <task_name>
  python task_timer.py status <task_name>
  python task_timer.py summary

Examples:
  python task_timer.py start "My Task"
  python task_timer.py status "My Task"
  python task_timer.py pause "My Task"
  python task_timer.py resume "My Task"
  python task_timer.py stop "My Task"
  python task_timer.py summary
"""

import sys
import json
import os
from datetime import datetime

TASK_FILE = 'tasks.json'

def load_tasks():
    """
    Load tasks from the JSON file, or return an empty dictionary if none exists.
    """
    if os.path.isfile(TASK_FILE):
        with open(TASK_FILE, 'r') as f:
            return json.load(f)
    return {}

def save_tasks(tasks):
    """
    Save the tasks dictionary to the JSON file in a formatted way.
    """
    with open(TASK_FILE, 'w') as f:
        json.dump(tasks, f, indent=2)

def get_current_time():
    """
    Return the current time as an ISO 8601 string.
    """
    return datetime.now().isoformat()

def get_display_time(task_data):
    """
    Return the displayed time for a task:
    - If 'active', add live elapsed time to the 'totalTime'.
    - If 'paused' or 'completed', just return the 'totalTime'.
    """
    status = task_data['status']
    total_time = task_data['totalTime']
    if status == 'active':
        # Calculate how much time has elapsed since last start
        start_time = datetime.fromisoformat(task_data['startTime'])
        elapsed = (datetime.now() - start_time).total_seconds()
        return total_time + elapsed
    else:
        # Paused or completed; just use totalTime
        return total_time

def start(task_name):
    """
    Start a new task (or resume an existing completed one). Updates the status to 'active'.
    """
    tasks = load_tasks()

    # If a task is already active, warn the user
    if task_name in tasks and tasks[task_name]['status'] == 'active':
        print(f"Task \"{task_name}\" is already running.")
        return

    tasks[task_name] = {
        'startTime': get_current_time(),
        'totalTime': tasks.get(task_name, {}).get('totalTime', 0.0),
        'status': 'active'
    }
    save_tasks(tasks)
    print(f"Started task \"{task_name}\".")

def stop(task_name):
    """
    Stop an active task, mark it as completed, and update 'totalTime'.
    """
    tasks = load_tasks()

    if task_name not in tasks or tasks[task_name]['status'] != 'active':
        print(f"Task \"{task_name}\" is not currently active.")
        return

    start_time = datetime.fromisoformat(tasks[task_name]['startTime'])
    elapsed_time = (datetime.now() - start_time).total_seconds()
    tasks[task_name]['totalTime'] += elapsed_time
    tasks[task_name]['status'] = 'completed'
    save_tasks(tasks)
    print(f"Stopped task \"{task_name}\". Total time: {tasks[task_name]['totalTime']:.2f} seconds.")

def status(task_name):
    """
    Print the status of a specific task, including up-to-date total time if it's active.
    """
    tasks = load_tasks()
    if task_name not in tasks:
        print(f"Task \"{task_name}\" does not exist.")
        return

    current_time = get_display_time(tasks[task_name])
    print(f"Task \"{task_name}\" status: {tasks[task_name]['status']}. "
          f"Total time: {current_time:.2f} seconds.")

def summary():
    """
    Display a summary of all tasks, including the updated time if they're active.
    """
    tasks = load_tasks()
    if not tasks:
        print("No tasks found.")
        return

    print("Task Summary:")
    for t_name, t_data in tasks.items():
        display_time = get_display_time(t_data)
        print(f"- {t_name}: {display_time:.2f} seconds ({t_data['status']})")

def usage():
    """
    Print usage instructions.
    """
    print("Usage:")
    print("  python task_timer.py start <task_name>")
    print("  python task_timer.py stop <task_name>")
    print("  python task_timer.py pause <task_name>")
    print("  python task_timer.py resume <task_name>")
    print("  python task_timer.py status <task_name>")
    print("  python task_timer.py summary")
    print("\nExamples:")
    print("  python task_timer.py start \"My Task\"")
    print("  python task_timer.py status \"My Task\"")
    print("  python task_timer.py pause \"My Task\"")
    print("  python task_timer.py resume \"My Task\"")
    print("  python task_timer.py stop \"My Task\"")
    print("  python task_timer.py summary")

def main():
    if len(sys.argv) < 2:
        usage()
        sys.exit(1)

    command = sys.argv[1].lower()

    if command == 'start':
        if len(sys.argv) < 3:
            print("Error: Missing task name.")
            sys.exit(1)
        task_name = " ".join(sys.argv[2:])
        start(task_name)

    elif command == 'stop':
        if len(sys.argv) < 3:
            print("Error: Missing task name.")
            sys.exit(1)
        task_name = " ".join(sys.argv[2:])
        stop(task_name)


    elif command == 'status':
        if len(sys.argv) < 3:
            print("Error: Missing task name.")
            sys.exit(1)
        task_name = " ".join(sys.argv[2:])
        status(task_name)

    elif command == 'summary':
        summary()

    else:
        usage()
        sys.exit(1)

if __name__ == '__main__':
    main()
