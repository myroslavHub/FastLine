using UnityEngine;
using System.Linq;

public enum GameState
{
    gsMainMenu, gsPlaying, gsDeathScreen, gsCharacterSelect
}

public class GameManager : MonoBehaviour
{
    public GameObject _MainMenu;
    public GameObject _PlayingCanvas;
    public GameObject _DeathCanvas;
	public GameObject _CharacterSelectCanvas;

    public GameState _GameState;

	public GameObject _ScoreGenerator;
    public GameObject _BackGroundGenerator;
    public GameObject _Player;
	public GameObject _ObjectSpawner;

	private GameObject _scoreGeneratorInstanse;
    private GameObject _backGroundGeneratorInstance;

	void Start()
	{
        GameState = GameState.gsMainMenu;
        _backGroundGeneratorInstance = (GameObject)Instantiate(_BackGroundGenerator, _BackGroundGenerator.transform.position, Quaternion.identity);
	}
    
    public void GoToMainMenu()
    {
        GameState = GameState.gsMainMenu;
    }
	public void GoToCharacterSelectMenu()
	{
		GameState = GameState.gsCharacterSelect;
	}
	public void StartGame()
	{
        GameState = GameState.gsPlaying;
        var list = FindObjectsOfType(typeof(GameObject)).Cast<GameObject>();
		foreach (var o in list)
		{
			if (o.GetComponent<ObjectSpawner>() != null)
				o.GetComponent<ObjectSpawner>().Reset();
			if (o.tag == "Enemy" || o.tag == "Ball" || o.tag == "BackLine")
				Destroy(o);
		}
		ScoreManager.Instance.CurrentReset();
        ColorHelper.ResetBGInfo();
		_scoreGeneratorInstanse = (GameObject)Instantiate(_ScoreGenerator, transform.position, Quaternion.identity);
		if (_backGroundGeneratorInstance != null)
            Destroy(_backGroundGeneratorInstance);
        _backGroundGeneratorInstance = (GameObject)Instantiate(_BackGroundGenerator, _BackGroundGenerator.transform.position, Quaternion.identity);
        Instantiate(_Player, _Player.transform.position, Quaternion.identity);
	}
	public void EndGame()
	{
        ScoreManager.Instance.CurrentSave();
        GameState = GameState.gsDeathScreen;
		if (_scoreGeneratorInstanse != null)
			Destroy(_scoreGeneratorInstanse);
	}

	private GameState GameState
	{
		set
		{
			_GameState = value;
			_MainMenu.SetActive(_GameState == GameState.gsMainMenu);
			_PlayingCanvas.SetActive(_GameState == GameState.gsPlaying);
			_DeathCanvas.SetActive(_GameState == GameState.gsDeathScreen);
			_CharacterSelectCanvas.SetActive(_GameState == GameState.gsCharacterSelect);
		}
	}
}