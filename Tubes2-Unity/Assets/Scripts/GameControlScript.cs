using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
	float timeRemaining = 6.0f;   //Pre-earned time
	float timeExtension = 3.0f;   //time to extend by on collecting powerup
	float timeDeduction = 2.0f;   //time to reduce, on collecting the snag
	float liveRemaining = 4.0f;   //Pre-earned live
	float liveExtension = 1.0f;   //live to extend by on collecting powerup
	float liveDeduction = 1.0f;   //live to reduce, on collecting the snag
	float totalTimeElapsed = 0;   
	float score=0f;      //total score
	public bool isGameOver = false;
	public GUISkin skin;
	// Use this for initialization
	void Start(){
		Time.timeScale = 1;  // set the time scale to 1, to start the game world. This is needed if you restart the game from the game over menu
	}
	
	// Update is called once per frame
	void Update () { 
		if(isGameOver)     //check if isGameOver is true
			return;      //move out of the function
		
		totalTimeElapsed += Time.deltaTime; 
		score = totalTimeElapsed*2;  //calculate the score based on total time elapsed
		timeRemaining -= Time.deltaTime*0.1f; //decrement the time remaining by 1 sec every update
		if(timeRemaining <= 0 || liveRemaining <= 0){
			isGameOver = true;    // set the isGameOver flag to true if timeRemaining is zero
		}
	}

	public void PowerupTimeCollected()
	{
		timeRemaining += timeExtension;   //add time to the time remaining
		if (timeRemaining > 6.0f) {
			timeRemaining = 6.0f;
		}
	}
	
	public void ObstacleTimeCollected()
	{
		timeRemaining -= timeDeduction;   // deduct time
	}

	public void PowerupLiveCollected()
	{
		liveRemaining += liveExtension;   //add time to the time remaining
		if (liveRemaining > 4.0f) {
			liveRemaining = 4.0f;
		}
	}
	
	public void ObstacleLiveCollected()
	{
		liveRemaining -= liveDeduction;   // deduct time
	}

	void OnGUI()
	{
		GUI.skin=skin; //use the skin in game over menu
		//check if game is not over, if so, display the score and the time left
		if(!isGameOver)    
		{
			GUI.Label(new Rect(10, 10, Screen.width/5, Screen.height/6),"IP: "+((float)liveRemaining).ToString("F1"));
			GUI.Label(new Rect(10, 10+Screen.height/6, Screen.width/5, Screen.height/6),"waktu:\n"+((float)timeRemaining).ToString("F1")+" tahun");
			GUI.Label(new Rect(Screen.width-(Screen.width/6), 10, Screen.width/6, Screen.height/6), "SCORE: "+((int)score).ToString());
		}
		//if game over, display game over <span id="IL_AD2" class="IL_AD">menu</span> with score
		else
		{
			Time.timeScale = 0; //set the timescale to zero so as to stop the game world
			
			//display the final score
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "Anda DO!!!\nLama Studi: "+((float) score).ToString("F1"));
			
			//restart the game on click
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			//load the main menu, which as of now has not been created
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			//exit the game
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "EXIT GAME")){
				Application.Quit();
			}
		}
	}
}
