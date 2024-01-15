using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public enum CharacterList
    {
        Liam,
        Kira
    }

    [SerializeField] private CharacterList _activeCharacter;
    [SerializeField] private List<Character> _characterData;
    [SerializeField] private Text
        _hairText,
        _shirtText,
        _pantsText,
        _shoesText;


    private Character _currentCharacter;

    void Start()
    {
        _activeCharacter = CharacterList.Liam;
        LoadCharacter(_activeCharacter);
        UpdateUIText();
    }

    void LoadCharacter(CharacterList character)
    {
        foreach (Character c in _characterData)
        {
            c.gameObject.SetActive(false);
        }

        _currentCharacter = _characterData[(int)character];
        ResetParts();
        _currentCharacter.gameObject.SetActive(true);
    }

    public void ResetParts()
    {
        _currentCharacter._hairIndex = 0;
        _currentCharacter._shirtIndex = 0;
        _currentCharacter._pantsIndex = 0;
        _currentCharacter._shoesIndex = 0;

        SetActivePart(_currentCharacter._characterHair, _currentCharacter._hairIndex);
        SetActivePart(_currentCharacter._characterShirt, _currentCharacter._shirtIndex);
        SetActivePart(_currentCharacter._characterPants, _currentCharacter._pantsIndex);
        SetActivePart(_currentCharacter._characterShoes, _currentCharacter._shoesIndex);

        UpdateUIText();
    }

    private CharacterList CycleCharacter(CharacterList character)
    {
        int nextCharacter = ((int)character + 1) % System.Enum.GetValues(typeof(CharacterList)).Length;
        return (CharacterList)nextCharacter;
    }

    public void LoadCycledCharacter()
    {
        _activeCharacter = CycleCharacter(_activeCharacter);
        LoadCharacter(_activeCharacter);
    }

    private void ChangeIndex(ref int currentIndex, int changeAmount, int arrayLength)
    {
        currentIndex = (currentIndex + changeAmount + arrayLength) % arrayLength;
        UpdateUIText();
    }

    public void SetActivePart(GameObject[] parts, int index)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].SetActive(i == index);
        }
    }

    public void PreviousHair()
    {
        ChangeIndex(ref _currentCharacter._hairIndex, -1, _currentCharacter._characterHair.Length);
        SetActivePart(_currentCharacter._characterHair, _currentCharacter._hairIndex);
    }

    public void NextHair()
    {
        ChangeIndex(ref _currentCharacter._hairIndex, 1, _currentCharacter._characterHair.Length);
        SetActivePart(_currentCharacter._characterHair, _currentCharacter._hairIndex);
    }

    public void PreviousShirt()
    {
        ChangeIndex(ref _currentCharacter._shirtIndex, -1, _currentCharacter._characterShirt.Length);
        SetActivePart(_currentCharacter._characterShirt, _currentCharacter._shirtIndex);
    }

    public void NextShirt()
    {
        ChangeIndex(ref _currentCharacter._shirtIndex, 1, _currentCharacter._characterShirt.Length);
        SetActivePart(_currentCharacter._characterShirt, _currentCharacter._shirtIndex);
    }

    public void PreviousPants()
    {
        ChangeIndex(ref _currentCharacter._pantsIndex, -1, _currentCharacter._characterPants.Length);
        SetActivePart(_currentCharacter._characterPants, _currentCharacter._pantsIndex);
    }

    public void NextPants()
    {
        ChangeIndex(ref _currentCharacter._pantsIndex, 1, _currentCharacter._characterPants.Length);
        SetActivePart(_currentCharacter._characterPants, _currentCharacter._pantsIndex);
    }

    public void PreviousShoes()
    {
        ChangeIndex(ref _currentCharacter._shoesIndex, -1, _currentCharacter._characterShoes.Length);
        SetActivePart(_currentCharacter._characterShoes, _currentCharacter._shoesIndex);
    }

    public void NextShoes()
    {
        ChangeIndex(ref _currentCharacter._shoesIndex, 1, _currentCharacter._characterShoes.Length);
        SetActivePart(_currentCharacter._characterShoes, _currentCharacter._shoesIndex);
    }

    void UpdateUIText()
    {
        _hairText.text = "Hair: " + _currentCharacter._hairIndex;
        _shirtText.text = "Shirt: " + _currentCharacter._shirtIndex;
        _pantsText.text = "Pants: " + _currentCharacter._pantsIndex;
        _shoesText.text = "Shoes: " + _currentCharacter._shoesIndex;
    }
}
