# WiShark
Simulating the packet capturing and analysis operations of Wireshark using C#

## INTRODUCTION
Wireshark is the world’s foremost and widely-used network protocol analyzer. It is used for network troubleshooting, analysis, software and communications protocol development, and education.

## PROJECT DESCRIPTION 
The project was built with the purpose of simulating the packet capturing and analysis operations of Wireshark. C# was used to build both the backend and the project’s Graphical User Interface(GUI). The project’s features include:
-	Selecting the desired Capture Network (Ethernet, WIFI, ...etc.).
-	Controlling the Start and Stop sniffing.
-	Showing the user main details of the packets in a table.
-	If the user clicks on a packet, it will show him a detailed view for UDP or TCP protocols.
-	If the user clicks on a packet, it will show him hex view
-	The captured packets can be filtered based on the main columns of the table

## Prerequisites
- Net 4.0 and WinPcap should be installed for proper execution of the program.
  -	You can download WinPcap from here https://www.winpcap.org/install/
  -	You can download .Net 4.0 from here https://www.microsoft.com/en-us/download/details.aspx?id=17851
## Code Build
  ### 1.  Graphical User Interface (GUI)
  To design the User Interface we used two forms, one for the user’s greeting page which contains a list of devices for the user to     choose from to determine which one he would like to start capturing packets.
  
  ![Alt text](https://user-images.githubusercontent.com/26356497/34335433-4a1664b6-e957-11e7-9cc8-95596941a94c.PNG)
 
The other form represents the page where the packets captured, and their information are displayed along with the controlling properties that are allowed for the user.

![Alt text](https://user-images.githubusercontent.com/26356497/34335434-4ac88358-e957-11e7-8c96-706f8d42ee9c.PNG)
 
### 2.  Backend Structure
The phases for building the backend structure of the application were as following:
1.	Determining the needed packages such as PacketDotNet, SharpPcap.WinPcap…etc. 
2.	Making the devices global
3.	Building a function for getting devices
4.	Setting up hex viewer
5.	Setting up the function for receiving packet 
6.	Determining packet data name
7.	Retrieving data from packets
8.	Determining IP protocol
9.	Displaying packet information in readable format for the user
10.	Stop and Start functions for the user to be able to control the capturing process

## Features
-	Controlling Start and Stop sniffing
 
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335432-49ea9052-e957-11e7-9734-82b66e2ba753.PNG)

-	Showing main details of packets in a table
 
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335596-ae122238-e958-11e7-80c9-f2366ecd302b.PNG)

-	Detailed view for UDP and TCP protocols
 
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335436-4bc2ffa4-e957-11e7-90e9-bf77253ccae3.PNG)
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335437-4d420ab4-e957-11e7-9508-84181326c702.PNG)
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335439-4d6479e6-e957-11e7-903e-10bd1be18292.PNG)
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335440-4d85902c-e957-11e7-8fb3-a3086e69da0c.PNG)
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335442-4e4dc95c-e957-11e7-8563-a198c9eccf72.PNG)
 

-	Hex view

![Alt text](https://user-images.githubusercontent.com/26356497/34335443-4e887d4a-e957-11e7-9ebe-9b032dec9597.PNG)

-	Filtering Captured Packets based on the main columns of the table
 
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335444-4f0cc7c6-e957-11e7-963c-03413b30acd6.PNG)
 
-	Saving captured packets to file and loading captured packets from file

![Alt text](https://user-images.githubusercontent.com/26356497/34335445-4f2f7fb4-e957-11e7-98e1-58b5854aa697.PNG)

- Shawing statistics
 
 ![Alt text](https://user-images.githubusercontent.com/26356497/34335446-4f5366f4-e957-11e7-87f8-7a25cf6a5cdb.PNG)


