using UnityEngine;

public class ItemController : MonoBehaviour
{
    public InteractableItem InteractableItem;

    [SerializeField]
    private GameObject ExaminationText;

    [SerializeField]
    private Transform Player;

    private void Update()
    {
        if (ExaminationText.activeSelf)
        {
            var targetDirection = Player.position - ExaminationText.transform.position;
            var rotationDirection = Vector3.RotateTowards(
                ExaminationText.transform.forward,
                -targetDirection,
                1,
                0
            );

            ExaminationText.transform.rotation = Quaternion.LookRotation(rotationDirection);
        }
    }

    public void Activate(bool isActive)
    {
        ExaminationText.SetActive(isActive);
    }
}
