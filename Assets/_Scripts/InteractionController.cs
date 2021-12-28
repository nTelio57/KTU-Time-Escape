using UnityEngine;
using System.Collections;

public class InteractionController : MonoBehaviour
{
    public float MaxInteractionDistance = 2f;

    [SerializeField]
    private float DisplayTextDuration = 2f;

    public Inventory Inventory;
    public MinigameManager MinigameManager;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnExamine();
        }
    }

    private void OnExamine()
    {
        if (Physics.Raycast(
            transform.position,
            transform.forward,
            out var hit,
            MaxInteractionDistance
        ))
        {
            CheckFootballDeploy();
            CheckItemController(hit);
            CheckOpenable(hit);
            CheckKnob(hit);
            CheckBulbInput(hit);
            CheckSafe(hit);
        }
    }

    private void CheckItemController(RaycastHit hit)
    {
        var examinable = hit.collider.GetComponentInParent<ItemController>();
        if (examinable != null)
        {
            if (examinable.InteractableItem.Pickable)
            {
                if (Inventory.AddItem(examinable.InteractableItem))
                    Destroy(examinable.gameObject);
            }
            else if (examinable.InteractableItem.Examinable)
                StartCoroutine(HandleExamination(examinable));
        }
    }

    private void CheckOpenable(RaycastHit hit)
    {
        var door = hit.collider.GetComponent<Openable>();
        if (door != null)
        {
            if (door.IsLocked)
            {
                if (door.CheckKey(Inventory.GetEquippedItem()))
                    Inventory.RemoveItem(Inventory.GetSelectedIndex());
            }

            door.Trigger();
        }
    }

    private void CheckKnob(RaycastHit hit)
    {
        var knob = hit.collider.GetComponent<Knob>();
        if (knob != null)
        {
            var stoveMinigame = MinigameManager.StoveMinigame;
            knob.Trigger();
            if (!stoveMinigame.IsFinished)
            {
                stoveMinigame.Check();
            }
        }
    }

    private void CheckBulbInput(RaycastHit hit)
    {
        var bulbInput = hit.collider.GetComponent<BulbInput>();
        if (bulbInput != null)
        {
            if (!bulbInput.IsFixed)
            {
                if (bulbInput.Trigger(Inventory.GetEquippedItem()))
                {
                    Inventory.RemoveItem(Inventory.GetSelectedIndex());
                    MinigameManager.BulbMinigame.AddBulb();
                }
            }
        }
    }

    private void CheckFootballDeploy()
    {
        if (MinigameManager.FootballMinigame.Respawn(Inventory.GetEquippedItem()))
        {
            Inventory.RemoveItem(Inventory.GetSelectedIndex());
        }
    }

    private void CheckSafe(RaycastHit hit)
    {
        var safeKey = hit.collider.GetComponent<SafeKey>();
        if (safeKey != null)
        {
            safeKey.Trigger();
        }
    }

    private IEnumerator HandleExamination(ItemController examinable)
    {
        examinable.Activate(true);
        yield return new WaitForSeconds(DisplayTextDuration);
        examinable.Activate(false);
    }
}
