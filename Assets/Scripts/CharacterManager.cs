using UnityEngine;

public enum PlayerType
{
	ptDefault, ptCyan, ptGreen, ptRed
}

public class CharacterManager
{
	private const string PLAYER_TYPE = "Player type";

	private PlayerType _PlayerType;

	public PlayerType PlayerType
	{
		get { return _PlayerType; }
		set
		{
			_PlayerType = value;
			PlayerPrefs.SetInt(PLAYER_TYPE, (int)_PlayerType);
		}
	}

	#region Singleton
	private static readonly CharacterManager _Instance = new CharacterManager();

	private CharacterManager()
	{
		_PlayerType = (PlayerType)PlayerPrefs.GetInt(PLAYER_TYPE, 0);
	}

	public static CharacterManager Instance
	{
		get { return _Instance; }
	}

	#endregion
}
