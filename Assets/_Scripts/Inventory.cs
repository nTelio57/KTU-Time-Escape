using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int InventorySize = 5;


    [SerializeField]
    private InventoryUI InventoryUI;


    private InteractableItem[] _items;
    private int _currentlySelectedItem = 0;
    private int _pickedItemsCount = 0;

    private const int KeyDelta = (int) KeyCode.Alpha1;

    private void Awake()
    {
        _items = new InteractableItem[InventorySize];
    }

    private void Start()
    {
        InventoryUI.UpdateUI(_items);
    }

    private void Update()
    {
        if (StateManager.IsLocked) return;
        HandleInput();
    }

    public bool AddItem(InteractableItem interactableItem)
    {
        bool status = false;
        if (_pickedItemsCount < InventorySize)
        {
            _items[GetFirstEmptyIndex()] = interactableItem;
            _pickedItemsCount++;
            status = true;
        }

        InventoryUI.UpdateUI(_items);
        StartCoroutine(InventoryUI.SetTitle(interactableItem.Name));
        return status;
    }

    private void HandleInput()
    {
        HandleNumberKeys();
        HandleMouseScroll();
    }

    private void HandleNumberKeys()
    {
        for (int i = 0; i < InventorySize; i++)
        {
            if (!Input.GetKeyDown((KeyCode) KeyDelta + i)) continue;

            SetCurrentlySelectedItem(i);
        }
    }

    private void HandleMouseScroll()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            SetCurrentlySelectedItem(_currentlySelectedItem + 1);
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            SetCurrentlySelectedItem(_currentlySelectedItem - 1);
        }
    }


    private void SetCurrentlySelectedItem(int index)
    {
        _currentlySelectedItem = ClampIndex(index);
        InventoryUI.SetSelectedFrame(_currentlySelectedItem);

        var currentItem = GetEquippedItem();
        StartCoroutine(currentItem != null ? InventoryUI.SetTitle(currentItem.Name) : InventoryUI.SetTitle(""));
    }

    private int ClampIndex(int index)
    {
        return index < 0 ? InventorySize - 1 : index % InventorySize;
    }

    public InteractableItem GetEquippedItem()
    {
        return _items[_currentlySelectedItem];
    }

    public void RemoveItem(int index)
    {
        _items[index] = null;
        InventoryUI.UpdateUI(_items);
        _pickedItemsCount--;
    }

    public int GetSelectedIndex()
    {
        return _currentlySelectedItem;
    }

    private int GetFirstEmptyIndex()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
                return i;
        }

        return -1;
    }
}
