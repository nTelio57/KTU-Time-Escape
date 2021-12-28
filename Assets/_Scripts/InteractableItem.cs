using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable Item", menuName = "Interactable Item")]
public class InteractableItem : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool Pickable;
    public bool Examinable;
}
