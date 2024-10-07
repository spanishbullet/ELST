# ELST - Event Log Storyteller

## Overview

Event Log Viewer is a WinForms application designed to read and display Windows Event Log (.evtx) files in a readable format that tells the story hidden in the log file. It provides an interface to load an event log file, extract relevant event information, and display it in a tabular format. To work on this code you must open Visual Studio as administrator.

## Features

- **Drive Search**: Search for all "Microsoft-Windows-Partition%4Diagnostic.evtx" files in a drive or directory.
- **Load and Read .evtx Files**: Select and load miltiple Windows Event Log files in seperate windows or in the same window to see all events together.
- **Display Event Data**: Show event details such as Event ID, Provider, Level, Time Created, and specific data fields in a DataGridView.
- **Customizable View**: Easlily show or hide and reorder event propeties to your needs.
- **Easy Event Viewing**: Easily sort events by device and or timeframe.
- **Search**: Search for anything in all or selected events.
- **Export**: Easily export all or selected events with your desired fields to .xls, .xlsx, .html, and .txt.
- **See Log File Properties**: See details such as path, time created, modified and accessed.
- **View Event Properties**: View individual event properties in freindly or XML format.
- **Administrative Access**: The application requires administrative privileges to access certain event log files.

## Prerequisites

None - this is a standalone app and only needs the files found in the release .zip folder.

## Administrative Privileges

Administrator Access Required: To access certain event logs, the application must be run with administrative privileges. This is configured through the application 

# Manifest File.

Manifest Configuration
The application requires elevated permissions. Ensure the application manifest (app.manifest) contains the following settings:

    <requestedPrivileges>
      <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
    </requestedPrivileges>


## Installation
**Download** the .zip folder found in the Releases section of this GitHub repository.

OR


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

### ELST Startup 

1. **Drive Search:**
     - Click the \"Select Drive\" button to launch a folder dialog.
     -  Select the drive/directory you want to search.
     -  Select the file or files you would like to open from the checked box.
     - Click the \"Open File(s)\" button to open each selected file in it's own window.
     - Click the \"Open Together\" button to open each selected file in the same window.
     - If no files are selected it will open all found files according to the button you click.

2. **Open Manually:**
     - Click the \"Open File\" button to launch a folder dialog.
     - Select the drive/directory you want to search and it will open in it's own window.

### ELST Main Menu

 1. **Menu**
     - File:
         - Open log opens a file dialog to open a new file in the same window.
         - Log Properties opens a window displaying information about the current log file(s).
         - Export opens a window that allows you to export based on desired rows and fields.
         - Exit will close the current window.
     - Analyze:
         - Record Numbers will analyze event record numbers for anomalies such as missing, duplicate and out of order.
         - Time will analyze event times for anomalies such as missing, duplicate and out of order.
     - Reset:
         - Reset Cells will reset all of the cells to white.
     - See:
         - Devices will open a window that allows you to see focused evvent data for each device.
     - Search:
         - Search will open a window that allows you to search through all displayed events.
     - Configure:
         - Columns will open a window that allows you to show, hide and reorder columns.
     - Time Control:
         - There are two time controll boxes that auto populate to the oldest(left box) and the most recent(right box) event times.
         - Type or click the dialog of either box to change the timeframe. This will hide all events outside of the selected timeframe.
         - Click the \"Apply\" button to apply the changes made to the timeframe.
         - Click the \"Reset\" button to revert to the original timeframe to include all events.
2. **Devices**
    - This section displays all of the devices found in the log file.
    - Selecting or unselecting a device will show or hide the event.
    - Click the \"Check All\" button to check and show all devices.
    - Click the \"Uncheck All\" button to uncheck and hide all devices.
3. **Events**
    - Right click a selected row to view either the log or event properties.
    - In the Event Properties window, you can cycle through different events and see their properties.
4. **Status Labels**
    - The first status strip show the number of events displayed vs the number of events in the file.
    - The second status strip shows the full path of the opened file(s).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.txt) file for details.

##Contact

Please open a new Issue on this repository.
For further questions or support, please contact jon.carson.bradford@gmail.com.
