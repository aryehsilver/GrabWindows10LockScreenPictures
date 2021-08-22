# Grab Windows 10 Lock Screen Pictures
A program to copy the spotlight images and save them to a local folder. This can be set as a Task Schedule which will run daily etc.

## Usage
Download the program [from the release page](https://github.com/aryehsilver/GrabWindows10LockScreenPictures/releases), and run the installer.

Upon running the program the first time, a `locations.txt` file will be created in `C:\Users\{your_username_here}\AppData\Roaming\Grab Windows 10 Lock Screen Pictures`. This file will contain the current username.

To add usernames to grab images for, open the `locations.txt` file and add usernames one per line.

The images are saved to `C:\Users\{username}\Pictures\Spotlight Images` using the first username in the text file. To save to a different user, change the order of the usernames. To change the save location within the user's folder; can only be done by editing the `program.cs` file directly.
