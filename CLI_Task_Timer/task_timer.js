
const fs = require('fs'); // load the file system module to handle file operations
const inquirer = require('inquirer'); // load the inquirer module for user prompts

const taskDataPath = './tasks.json'; // define the file path for storing tasks

// load or initialize tasks
const loadTasks = () => {
    if (fs.existsSync(taskDataPath)) { // check if the task data file exists
        return JSON.parse(fs.readFileSync(taskDataPath, 'utf8')); // read and parse the task data file
    }
    return {}; // return an empty object if no file exists
};

// save tasks to file
const saveTasks = (tasks) => {
    fs.writeFileSync(taskDataPath, JSON.stringify(tasks, null, 2)); // write tasks to the file as formatted json
};

// get current timestamp
const getCurrentTime = () => new Date().toISOString(); // return the current date and time in iso format

// main task logic
const taskManager = {
    start(taskName) { // start a new task
        const tasks = loadTasks(); // load existing tasks
        if (tasks[taskName] && tasks[taskName].status === 'active') { // check if the task is already running
            console.log(`Task "${taskName}" is already running.`); // notify user that the task is active
            return; // exit the function
        }
        tasks[taskName] = { // create or update the task
            startTime: getCurrentTime(), // set the start time
            totalTime: tasks[taskName]?.totalTime || 0, // keep existing total time or set to zero
            status: 'active', // set the task status to active
        };
        saveTasks(tasks); // save the updated tasks to file
        console.log(`Started task "${taskName}".`); // notify user that the task has started
    },
    

    resume(taskName) { // resume a paused task
        const tasks = loadTasks(); // load existing tasks
        if (!tasks[taskName] || tasks[taskName].status !== 'paused') { // check if the task is not paused
            console.log(`Task "${taskName}" is not currently paused.`); // notify user that the task is not paused
            return; // exit the function
        }
        tasks[taskName].startTime = getCurrentTime(); // update the start time
        tasks[taskName].status = 'active'; // set the task status to active
        saveTasks(tasks); // save the updated tasks to file
        console.log(`Resumed task "${taskName}".`); // notify user
    },

    status(taskName) { // check the status of a task
        const tasks = loadTasks(); // load existing tasks
        if (!tasks[taskName]) { // check if the task does not exist
            console.log(`Task "${taskName}" does not exist.`); // notify user that the task does not exist
            return; // exit the function
        }
        console.log(`Task "${taskName}" status: ${tasks[taskName].status}. Total time: ${tasks[taskName].totalTime.toFixed(2)} seconds.`); // display task status
    },

    summary() { // display a summary of all tasks
        const tasks = loadTasks(); // load existing tasks
        console.log('Task Summary:'); // print a header
        Object.entries(tasks).forEach(([taskName, task]) => { // iterate over all tasks
            console.log(`- ${taskName}: ${task.totalTime.toFixed(2)} seconds (${task.status})`); // display task details
        });
    },
};

// cli interface
const mainMenu = async () => { // display the main menu
    const { command } = await inquirer.prompt([ // prompt user for a command
        {
            type: 'list', // use a list prompt
            name: 'command', // name the prompt result
            message: 'What would you like to do?', // display a message to the user
            choices: [ // define the available choices
                'Start a task',
                'Stop a task',
                'Pause a task',
                'Resume a task',
                'Check task status',
                'View summary',
                'Exit',
            ],
        },
    ]);

    if (command === 'Exit') { // check if the user chose to exit
        console.log('Goodbye!'); // say goodbye
        return; // exit the program
    }

    if (command === 'View summary') { // check if the user chose to view the summary
        taskManager.summary(); // display the summary
    } else { // handle all other commands
        const { taskName } = await inquirer.prompt([ // prompt the user for a task name
            {
                type: 'input', // use an input prompt
                name: 'taskName', // name the prompt result
                message: 'Enter the task name:', // ask the user for the task name
            },
        ]);
        switch (command) { // handle the command
            case 'Start a task': // if the command is to start a task
                taskManager.start(taskName); // start the task
                break;
            case 'Stop a task': // if the command is to stop a task
                taskManager.stop(taskName); // stop the task
                break;
            case 'Pause a task': // if the command is to pause a task
                taskManager.pause(taskName); // pause the task
                break;
            case 'Resume a task': // if the command is to resume a task
                taskManager.resume(taskName); // resume the task
                break;
            case 'Check task status': // if the command is to check task status
                taskManager.status(taskName); // check the task status
                break;
        }
    }

    await mainMenu(); // loop back to menu
};

// run the app
mainMenu(); // start the main menu
