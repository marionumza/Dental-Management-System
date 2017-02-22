# Dental-Management-System

This is a College project.

Note: This is not intended to be used in a commercial environment unless stated by the developer (Dasutein). You may contribute to the source code as needed. For general bug fixes, please switch to the 'general-fixes' branch and make your changes there. Once I have reviewed your changes, I will add that to the 'master' branch.

Internal current software version

**0.2.20**

Download the MySQL Server: https://www.mysql.com/

.NET 4.0 Framework (Windows 7 users): https://www.microsoft.com/en-us/download/confirmation.aspx?id=17718

###### INTERNAL SOFTWARE VERSION (FROM OLD VISUAL STUDIO GIT HISTORY)

**0.1.11** — [December 1, 2016 - December 20, 2016]

1. Project Files added
2. Commit 8c8ec8eb: Cleaned up several lines of code under "AdvancedSettings". Added a dialog box for testing the MySQL connection. An About Form was added as a new module. 
3. Commit f6d9ebc7: Rebuilt Login Form GUI. Added a loading screen upon logging into dashboard.
4. Commit e5ee2d19: Recovered several codes from previous branch (*Due to branch migration problems, which caused huge amount of code lost*)
5. Commit 8290737f: Added Settings control panel form. Added Payment module.

**0.1.12** - [December 20, 2016 - January 9, 2017]

1. Commit c0b7be22: Overhauled user interface. Replaced with Modern UI framework.
2. Commit 20efe556: More GUI stuff. Added new Patient Registration module.
3. Commit e0c12f95: Added function to Export to PDF file for the payment module. 
4. Commit 04284fbe: Added Recovery options in Settings.
5. Commit aed18d9d: Updated MetroUI Framework to 1.4.0.0.

**0.1.17** - [January 9, 2017 - January 20, 2017]

1. Commit e6debdea: Redesigned 'Home' screen. Renamed AdvancedSettings to "ConSettings". Added functionality to Patient Registration module for tooth chart.
2. Commit 6dc1117c: UI changes for ConSettings and AppSettings. Reset functionality to Patient added.
3. Commit 93a4de09: Created Hash and Salt functionality for User Account creation.
4. Commit 37f86e91: Fixed UI in Settings module as well as more preperations for MySQL integration.
5. Commit 8f74b552: Fixed minor graphical glitch in Patient_Registration module

**0.1.20** - [January 20, 2017 - February 16, 2017]

1. Commit 6d8c541d: Ability to change between Primary and Permament Tooth chart is now functional.
2. Commit d5d74ba9: Fixed issue where mysql server assumes that the 'Host' machine does not have connection privileges. Other changes include: Renamed ConSettings to 'serverSettings' and 'LoginForm' to 'Login'.
3. Commit 8434222b: Made changes to "serverSettings" and "AppSettings" User interface
4. Commit 430f56fc: Made some improvements to design naming scheme.
5. Commit bbf0e7c1: Function added to create new database. Added new Email component.
6. Commit 0b9f9b07: Improvements to BackgroundWorker to properly load data from the database thus reducing loading times after logging in.
7. INTERNAL VERSION CHANGE TO 0.2.10
