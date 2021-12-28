using UnityEngine;

public class SyncTransform : MonoBehaviour
{
    [SerializeField]
    private Transform Target;

    public Vector3 PositionOffset;

    private void Update()
    {
        transform.position = Target.position + PositionOffset;
        transform.rotation = Target.rotation;
    }

    public void InvertPositionOffset()
    {
        PositionOffset *= -1;
    }
}
