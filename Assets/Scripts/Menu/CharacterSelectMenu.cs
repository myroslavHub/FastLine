using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu: MonoBehaviour
{
	public Text _Default;
	public Text _Red;
	public Text _Green;
	public Text _Cyan;

	private string _selectedText = "Selected";
	private string _selectText = "Select";
	private string _cantSelect = "------";

	public void DefaultSelect()
	{
		CharacterManager.Instance.PlayerType = PlayerType.ptDefault;
		UpdateUI();
	}
	public void RedSelect()
	{
		if (ScoreManager.Instance.TotalRedBall < 20)
			return;
		CharacterManager.Instance.PlayerType = PlayerType.ptRed;
		UpdateUI();
	}
	public void GreenSelect()
	{
		if (ScoreManager.Instance.TotalGreenBall < 20)
			return;
		CharacterManager.Instance.PlayerType = PlayerType.ptGreen;
		UpdateUI();
	}
	public void CyanSelect()
	{
		if (ScoreManager.Instance.TotalCyanBall < 20)
			return;
		CharacterManager.Instance.PlayerType = PlayerType.ptCyan;
		UpdateUI();
	}

	private void OnEnable()
	{
		UpdateUI();
	}
	private void UpdateUI()
	{
		_Default.text = _selectText;
		_Red.text = ScoreManager.Instance.TotalRedBall >= 20 ? _selectText : _cantSelect;
		_Green.text = ScoreManager.Instance.TotalGreenBall >= 20 ? _selectText : _cantSelect;
		_Cyan.text = ScoreManager.Instance.TotalCyanBall >= 20 ? _selectText : _cantSelect;

		if (CharacterManager.Instance.PlayerType == PlayerType.ptDefault)
			_Default.text = _selectedText;
		if (CharacterManager.Instance.PlayerType == PlayerType.ptRed)
			_Red.text = _selectedText;
		if (CharacterManager.Instance.PlayerType == PlayerType.ptGreen)
			_Green.text = _selectedText;
		if (CharacterManager.Instance.PlayerType == PlayerType.ptCyan)
			_Cyan.text = _selectedText;
	}
}