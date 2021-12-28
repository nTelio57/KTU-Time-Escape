using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float Sensitivity = 2.2f;

    [SerializeField]
    private Transform PlayerBody;

    private float _xRotation;

    private float _verticalClamp = 85f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (StateManager.IsLocked)
        {
            Cursor.lockState = CursorLockMode.Confined;
            return;
        }

        float delta = Sensitivity * Time.deltaTime * 100f;
        float mouseX = Input.GetAxis("Mouse X") * delta;
        float mouseY = Input.GetAxis("Mouse Y") * delta;

        var direction = new Vector2(mouseX, mouseY);
        UpdateLookRotation(direction);
    }

    private void UpdateLookRotation(Vector2 direction)
    {
        _xRotation -= direction.y;
        _xRotation = Mathf.Clamp(_xRotation, -_verticalClamp, _verticalClamp);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * direction.x);
    }
}
