using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour{

	
	public static int playerTurnAxisTouch =0;
	public static int playerMoveAxisTouch =0;
	public static int playerFireAxisTouch =0;

	void Start()
	{
		playerTurnAxisTouch =0;
		playerMoveAxisTouch =0;
		playerFireAxisTouch =0;
	}

//Turn
	public void PlayerTurnRightUIPointerUp(){
		playerTurnAxisTouch =0;
	}
	public void PlayerTurnRightUIPointerDown(){
		playerTurnAxisTouch =1;
	}
	public void PlayerTurnLeftUIPointerUp(){
		playerTurnAxisTouch =0;
	}
	public void PlayerTurnLefttUIPointerDown(){
		playerTurnAxisTouch =-1;
	}


//Move
	public void PlayerMoveForwardUIPointerUp(){
		playerMoveAxisTouch =0;
	}
	public void PlayerMoveForwardUIPointerDown(){
		playerMoveAxisTouch =1;
	}
	public void PlayerMoveBackUIPointerUp(){
		playerMoveAxisTouch =0;
	}
	public void PlayerMoveBackUIPointerDown(){
		playerMoveAxisTouch =-1;
	}


//Fire	
	public void PlayerFireUIPointerUp(){
		playerFireAxisTouch =0;
	}
	public void PlayerFireUIPointerDown(){
		playerFireAxisTouch =1;
	}
}
