using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public enum GameState {Init, Ready, Play, GameOver};
	private static GameState currentState = GameState.Init;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState)
		{
			//initialization from Game
			case GameState.Init:
				break;
			//Game is ready to play
			case GameState.Ready:
				break;
			//Game is playing
			case GameState.Play:
				break;
			//Game is over
			case GameState.GameOver:
				break;
			default:
				break;
		}
	}
}
