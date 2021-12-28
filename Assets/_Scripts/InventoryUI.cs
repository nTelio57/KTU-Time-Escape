using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Text ItemTitleText;
    private float _itemTitleTime = 1f;

    [SerializeField]
    private Sprite DefaultFrameSprite;

    [SerializeField]
    private Sprite SelectedFrameSprite;

    [SerializeField]
    private InventorySlot[] Slots;

    public void UpdateUI(InteractableItem[] items)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (items[i] != null)
            {
                Slots[i].ItemIcon.enabled = true;
                Slots[i].ItemIcon.sprite = items[i].Icon;
            }
            else
            {
                Slots[i].ItemIcon.enabled = false;
                Slots[i].ItemIcon.sprite = null;
            }
        }
    }

    public void SetSelectedFrame(int index)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            //Slots[i].Frame.sprite = i == index ? SelectedFrameSprite : DefaultFrameSprite;
            //Slots[i].Frame.gameObject.SetActive(i == index ? true : false);
            Slots[i].Frame.color = i == index ? Color.green : Color.white;
        }
    }

    public IEnumerator SetTitle(string title)
    {
        ItemTitleText.text = title;
        yield return new WaitForSeconds(_itemTitleTime);
        ItemTitleText.text = "";
    }
}
