using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "Scriptable Objects/CharacterDatabase")]
public class CharacterDatabase : ScriptableObject
{
    public List<CharacterData> characters = new List<CharacterData>();
}
