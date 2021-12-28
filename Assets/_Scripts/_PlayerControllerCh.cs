using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerControllerCh : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float gravity = -9.81f;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        var movement = transform.forward * dirZ + transform.right * dirX;
        controller.Move(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(-2 * gravity * 3);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
