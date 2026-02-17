using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InfoControls : MonoBehaviour
{

    public CharacterDatabase database;
    private List<CharacterData> runtimeCharacters;

    public IReadOnlyList<CharacterData> Characters => runtimeCharacters;

    public System.Action OnCharacterListChanged;

    private void Start()
    {
        runtimeCharacters = database.characters.Select(x => new CharacterData {
            characterId = x.characterId, 
            characterName = x.characterName, 
            health = x.health, 
            speed = x.speed }).ToList();
    }

    public void AddCharacter(int characterId, string name, int health, float speed)
    {
        if (runtimeCharacters.Any(x => x.characterId == characterId))
        {
            Debug.LogWarning("ID already exists!");
            return;
        }

        runtimeCharacters.Add(new CharacterData
        {
            characterId = characterId,
            characterName = name,
            health = health,
            speed = speed
        });
        Debug.Log("Character Added");
        OnCharacterListChanged?.Invoke();
    }

    public void UpdateCharacter(int characterId, string name, int health, float speed)
    {
        var character = runtimeCharacters.FirstOrDefault(x => x.characterId == characterId);

        if (character == null)
        {
            Debug.LogWarning("Character not found!");
            return;
        }

        character.characterName = name;
        character.health = health;
        character.speed = speed;

        Debug.Log("Character Updated");
    }

    public void RemoveCharacter(int characterId)
    {
        runtimeCharacters.RemoveAll(x => x.characterId == characterId);
        Debug.Log("Character Removed");
    }

}
