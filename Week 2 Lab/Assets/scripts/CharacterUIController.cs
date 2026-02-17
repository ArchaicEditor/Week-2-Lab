using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIController : MonoBehaviour
{
    public InfoControls manager;

    public InputField idInput;
    public InputField nameInput;
    public InputField healthInput;
    public InputField speedInput;

    public void OnAddButton()
    {
        manager.AddCharacter(
            int.Parse(idInput.text),
            nameInput.text,
            int.Parse(healthInput.text),
            float.Parse(speedInput.text)
        );
    }

    public void OnUpdateButton()
    {
        manager.UpdateCharacter(
            int.Parse(idInput.text),
            nameInput.text,
            int.Parse(speedInput.text),
            float.Parse(healthInput.text)
        );
    }

    public void OnRemoveButton()
    {
        manager.RemoveCharacter(
            int.Parse(idInput.text)
        );
    }
}
