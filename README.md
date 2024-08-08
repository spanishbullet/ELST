# ELST - Event Log Storyteller

## Overview

Event Log Viewer is a Windows Forms application designed to read and display Windows Event Log (.evtx) files in a readable format the tells the story hidden in the log file. It provides an interface to load an event log file, extract relevant event information, and display it in a tabular format.

## WARNING
**This is a prototype and is not ready for production. Do not use this on a single copy as there is a posibility it could damage files you upload. Only use this software on a copy or backup of the files you with to analyze. This software is not yet optimized for large files.**

## Features

- **Load and Read .evtx Files**: Select and load Windows Event Log files.
- **Display Event Data**: Show event details such as Event ID, Provider, Level, Time Created, and specific data fields in a DataGridView.
- **Administrative Access**: The application requires administrative privileges to access certain event log files.

## Prerequisites

- **.NET Framework**: This application requires .NET Framework 4.7.2 or later.
- **Visual Studio**: It is recommended to use Visual Studio for development and testing.

## Administrative Privileges

Administrator Access Required: To access certain event logs, the application must be run with administrative privileges. This is configured through the application 

# Manifest File.

Manifest Configuration
The application requires elevated permissions. Ensure the application manifest (app.manifest) contains the following settings:

    <requestedPrivileges>
      <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
    </requestedPrivileges>


## Installation

1. **Clone or Download the Repository**:
   ```bash
   git clone https://github.com/spanishbullet/ELST.git
2. **Open the Solution**:
    - Open the EventLogViewer.sln file in Visual Studio.
3. **Build the Project**:
    - Right-click on the solution in Solution Explorer and select Build.
4. **Run the Application**:
    - Press F5 or click Start to run the application within Visual Studio.

## Usage

1. **Launch the Application**:
    - Start the application from Visual Studio or by running the compiled executable.
2. **Open Event Log File**:
    - Click the "File" button on the main form menu and then "Open" to launch a folder dialog.
    - Select a folder containing the .evtx file(s) you want to use.
3. **View Event Data**:
    - Select and double click the desired .evtx file.
    - The event log data will automatically populate in table format within the DataGridView.
    - Columns include Event ID, Provider, Level, Time Created, and specific fields like Capacity, Manufacturer, Model, etc.
4. **Configure Fields**
    - There are default fields that automatically populate. You can change the visible feilds by right clicking any of the column headers.
    - A dropdown menu will apear and you can select or deselect the feilds you wish to see.
    - You can also drag a column header left or right to change the other the feilds apear in.
5. **Exit**
    - You can click the red "X" in the top right corner of the window.
    - Alternatively you can select "File" in the menu bar and then select "Exit".

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.txt) file for details.

##Contact

For further questions or support, please contact jon.carson.bradford@gmail.com.
