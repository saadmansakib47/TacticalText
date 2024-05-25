# TacticalText

## Overview 
A text and turn based two-player console game developed in C# during my third semester. 

![TTOverview2](https://github.com/saadmansakib47/TacticalText/assets/134169023/a6c8a372-9397-48da-bab8-c910773ae76c)


## Motivation
This project was part of the course SWE 4302 (Object Oriented Concepts II Lab), where we were told to demonstrate the necessity of [clean codes](https://www.freecodecamp.org/news/how-to-write-clean-code/#:~:text=Clean%20code%20is%20written%20in,maintain%2C%20debug%2C%20and%20modify) and [SOLID Principles](https://www.digitalocean.com/community/conceptual-articles/s-o-l-i-d-the-first-five-principles-of-object-oriented-design) by refactoring an existing project that was done earlier by the students or anyone else. I chose 'TacticalTextRPG' which was a toy project done early in my undergrad life, when I was not yet aware of the importance of clean codes, object oriented concepts and even proper version controlling. I observed the structure of the project and refactored it by applying the principles and concepts we were taught in the course. 
A detailed presentation of how the code is made cleaner, and how objected oriented concepts are applied is given [here](https://www.canva.com/design/DAF6TRvuWhM/bFbVo1-RqFZc-YMbLlFiyQ/edit?utm_content=DAF6TRvuWhM&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)


# Getting Started

## Installation & Running the application

To run TacticalText on your local machine, follow these steps:

1. Ensure you have Git installed. If not, download and install it from [https://git-scm.com/downloads](https://git-scm.com/downloads).

2. Clone the GitHub repository to your local machine.

    ```bash
    git clone https://github.com/saadmansakib47/Project-CipherShield-.git
    ```

3. Navigate to the project directory.

    ```bash
    cd TacticalText
    ```

4. Install the project dependencies.

   ```bash
    nuget restore
    ```
   
   Note: Make sure you have [NuGet](https://www.nuget.org/downloads) installed. The nuget restore command fetches the necessary dependencies for the project.
  
5. Make sure you have Visual Studio installed, if not then install it from [https://visualstudio.microsoft.com/downloads/](https://visualstudio.microsoft.com/downloads/)

6. Open Visual Studio. In Visual Studio, click on File > Open > Project/Solution

7. Navigate to the directory where you cloned the TacticalText repository, select the solution file (.sln), and click Open.

8. Once the project is open in Visual Studio, locate the Run button (usually a green play button) in the toolbar or press F5 to build and run the application.


## Details
First, each player will be granted with a budget of 500$. 
Player1 will be prompted to a shop where they can choose the units and number of the units to make their army. 

![P1](https://github.com/saadmansakib47/TacticalText/assets/134169023/65cac849-6a9d-4d12-8291-a2cafd85022f)

For example, Player1 purchased 12 snipers.

![P2](https://github.com/saadmansakib47/TacticalText/assets/134169023/03940bc1-c481-4006-b1bb-563c44e708f0)

Then purchases other types of units and the game prompts to Player2. 

![P3](https://github.com/saadmansakib47/TacticalText/assets/134169023/09d8a28e-a949-4d3c-953e-a68dff7f6ddb)

Player2 buys the units as well. Then the games proceeds them to engage in battle : 

![p4](https://github.com/saadmansakib47/TacticalText/assets/134169023/e64b94f4-63e3-430c-af78-e6a125580651)

Player 1 and Player2 deploy their units. The battle advances with calculating the attack logic of each units.

![p5](https://github.com/saadmansakib47/TacticalText/assets/134169023/53173a58-ccb5-4944-8159-1bf2b45bb835)

After several turns, The one player with remaining units become the winner.








