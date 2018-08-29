// using System.Collections;
// using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Game configuration data
	string[] levelOne = { "fight", "punch", "counter", "parry", "evade" };
	string[] levelTwo = { "joystick", "blades", "ejected", "hovering", "launchpad" };
	string[] levelThree = { "superhuman", "unidentified", "kryptonite", "glitching", "invulnerable" };
	const string menuHint = "You may type 'menu' at any time to\nreturn to the main menu.";

	enum Screen { MainMenu, Password, Success };
	// Game state
	int level;
	string password;
	Screen currentScreen;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}
	
	// string greeting = "Hello Neo";

	void OnUserInput(string input){
		if (currentScreen == Screen.Success || input.ToLower() == "menu"){
			ShowMainMenu();
		}
		else if (input.ToLower() == "close" || input.ToLower() == "quit"|| input.ToLower() == "exit"){
			Terminal.ClearScreen();
			// Terminal.WriteLine("Thanks for playing!");
			Application.Quit();
		}
		else if (currentScreen == Screen.MainMenu){
			RunMainMenu(input);
		}
		else if (currentScreen == Screen.Password){
			RunPasswordCheck(input);
		}
	}

	void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
		Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Please enter your password:");
        Terminal.WriteLine("(password hint)  " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = levelOne[Random.Range(0, levelOne.Length - 1)];
                break;
            case 2:
                password = levelTwo[Random.Range(0, levelTwo.Length - 1)];
                break;
            case 3:
                password = levelThree[Random.Range(0, levelThree.Length - 1)];
                break;
            default:
                break;
        }
    }

    void RunPasswordCheck(string input){

		if (input == password){
			currentScreen = Screen.Success;
			DisplayWinScreen();
		}
		else{
			AskForPassword();
		}
	}

	void DisplayWinScreen(){
		currentScreen = Screen.Success;
		Terminal.ClearScreen();
		ShowLevelReward();
	}

	void ShowLevelReward(){
		switch(level){
			case 1:
				Terminal.WriteLine("I know kung fu.");
				Terminal.WriteLine(
@"
        *****        *****
     ****   ****  ****   ****
      ***               ***
        ****         ****
           ****    ****
              ******
				");
				break;
			case 2:
				Terminal.WriteLine("He's beginning to believe.");
				Terminal.WriteLine(
@"
        *****        *****
     ****   ****  ****   ****
      ***               ***
        ****         ****
           ****    ****
              ******
				");
				break;
			case 3:
				Terminal.WriteLine("There is no spoon");
				Terminal.WriteLine(
@"
        *****        *****
     ****   ****  ****   ****
      ***               ***
        ****         ****
           ****    ****
              ******
				");
				break;
		}
		Terminal.WriteLine("Hit 'enter' to return to the main menu.");
	}

	bool CheckPassword(string password, string input){
		return password == input;
	}

	void RunMainMenu(string input){

		bool isValidLevel = (input == "1" || input == "2" || input == "3" || input == "007");
		
		if (isValidLevel){
			int.TryParse(input, out level);
			AskForPassword();
		}
		else if (input == "007"){
			Terminal.WriteLine("Welcome to The Matrix, Mr. Bond.");
		}
		else {
			Terminal.WriteLine("Your selection is invalid.");
			Terminal.WriteLine(menuHint);
		}
	}




	void ShowMainMenu(){
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("Hello, Neo.\nYour time has come to believe.");
		Terminal.WriteLine("");
		Terminal.WriteLine("1: Self Defense");
		Terminal.WriteLine("2: Helicopter Piloting");
		Terminal.WriteLine("3: Superman Thing");
		Terminal.WriteLine("");
		Terminal.WriteLine("Please select your download...");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
