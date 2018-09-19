using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
	InTheShip,
	ShipCommand
}

public class GameManager : BaseSingleton<GameManager> 
{
	public delegate void ChangePlayerStateHandler(PlayerState playerState);
	public static event ChangePlayerStateHandler OnChangePlayerState;
}
