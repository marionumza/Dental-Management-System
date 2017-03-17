# Dental-Management-System

This is a College project for Software Engineering.

Note: This is not intended to be used in a commercial environment unless stated by the developer (Dasutein). You may contribute to the source code as needed. For general bug fixes or new features, please switch to the 'general-fixes' branch and make your changes there. 

To login to the system, default username = **admin** and password = **1234**

Internal current software version: **0.0.2.100** as of ***March 18, 2017***

For this software to work properly, you need the following...

- MySQL Server: https://www.mysql.com/
- .NET 4.0 Framework (Windows 7 users): https://www.microsoft.com/en-us/download/confirmation.aspx?id=17718

###### HOW TO COMPILE

1. Click on "Clone or Download" and Choose whichever options. Download ZIP or Open in Visual Studio
2. Open Solution Project File
3. Build > Build Solution
4. Go to /bin/debug/ in the Solution File directory. "DentalManagement.exe" should appear.

###### SYSTEM REQUIREMENTS

- At least a DUAL CORE processor above 1.4 GHz for optimal performance. 
- 1366 x 768 resolution or greater is recommended.
- OS: Windows 7, Windows 8.1, or Windows 10.

###### COMPONENTS USED TO BUILD THIS SOFTWARE

- Metro Framework 
- iTextPDF
- MySQL
- MySqlBackup.NET
- Mimekit

###### INTERNAL SOFTWARE VERSION (FROM VISUAL STUDIO GIT HISTORY)

**0.1.11** — [December 1, 2016 - December 20, 2016]

- Project Files added
- Commit 8c8ec8eb: Cleaned up several lines of code under "AdvancedSettings". Added a dialog box for testing the MySQL connection. An About Form was added as a new module. 
- Commit f6d9ebc7: Rebuilt Login Form GUI. Added a loading screen upon logging into dashboard.
- Commit e5ee2d19: Recovered several codes from previous branch (*Due to branch migration problems, which caused huge amount of code lost*)
- Commit 8290737f: Added Settings control panel form. Added Payment module.

**0.1.12** - [December 20, 2016 - January 9, 2017]

- Commit c0b7be22: Overhauled user interface. Replaced with Modern UI framework.
- Commit 20efe556: More GUI stuff. Added new Patient Registration module.
- Commit e0c12f95: Added function to Export to PDF file for the payment module. 
- Commit 04284fbe: Added Recovery options in Settings.
- Commit aed18d9d: Updated MetroUI Framework to 1.4.0.0.

**0.1.17** - [January 9, 2017 - January 20, 2017]

- Commit e6debdea: Redesigned 'Home' screen. Renamed AdvancedSettings to "ConSettings". Added functionality to Patient Registration module for tooth chart.
- Commit 6dc1117c: UI changes for ConSettings and AppSettings. Reset functionality to Patient added.
- Commit 93a4de09: Created Hash and Salt functionality for User Account creation.
- Commit 37f86e91: Fixed UI in Settings module as well as more preperations for MySQL integration.
- Commit 8f74b552: Fixed minor graphical glitch in Patient_Registration module

**0.1.20** - [January 20, 2017 - February 16, 2017]

- Commit 6d8c541d: Ability to change between Primary and Permament Tooth chart is now functional.
- Commit d5d74ba9: Fixed issue where mysql server assumes that the 'Host' machine does not have connection privileges. Other changes include: Renamed ConSettings to 'serverSettings' and 'LoginForm' to 'Login'.
- Commit 8434222b: Made changes to "serverSettings" and "AppSettings" User interface
- Commit 430f56fc: Made some improvements to design naming scheme.
- Commit bbf0e7c1: Function added to create new database. Added new Email component.
- Commit 0b9f9b07: Improvements to BackgroundWorker to properly load data from the database thus reducing loading times after logging in.
- INTERNAL VERSION CHANGE TO 0.2.10 AND MIGRATION TO GITHUB FOR VERSION CONTROL.
