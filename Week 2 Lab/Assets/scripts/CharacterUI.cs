using UnityEngine;
using TMPro;

public class CharacterUI : MonoBehaviour
{
    public InfoControls manager;
    public TextMeshProUGUI displayText;

    public void fixedUpdate()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        displayText.text = "";

        foreach (var character in manager.Characters)
        {
            displayText.text +=
                $"ID: {character.characterId} | " +
                $"Name: {character.characterName} | " +
                $"HP: {character.health} | " +
                $"Speed: {character.speed}\n";
        }
    }
}
