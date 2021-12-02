using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoose : MonoBehaviour
{
    [SerializeField] private GameObject[] _characters;

    private int _currentCharacter;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CurrentCharacter"))
        {
            _currentCharacter = PlayerPrefs.GetInt("CurrentCharacter");
        }
        else _currentCharacter = 0;

        _characters[_currentCharacter].SetActive(true);
    }

    public void NextChar()
    {
        if (_currentCharacter != _characters.Length - 1)
        {
            _currentCharacter++;
            _characters[_currentCharacter - 1].SetActive(false);
            _characters[_currentCharacter].SetActive(true);
        }
        else
        {
            _currentCharacter = 0;
            _characters[_characters.Length - 1].SetActive(false);
            _characters[_currentCharacter].SetActive(true);
        }

        PlayerPrefs.SetInt("CurrentCharacter", _currentCharacter);
    }

    public void PreviousChar()
    {
        if (_currentCharacter != 0)
        {
            _currentCharacter--;
            _characters[_currentCharacter + 1].SetActive(false);
            _characters[_currentCharacter].SetActive(true);
        }
        else
        {
            _currentCharacter = _characters.Length - 1;
            _characters[0].SetActive(false);
            _characters[_currentCharacter].SetActive(true);
        }

        PlayerPrefs.SetInt("CurrentCharacter", _currentCharacter);
    }
}
