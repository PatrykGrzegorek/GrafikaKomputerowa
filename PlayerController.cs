using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    public float jumpForce;
    public bool OnFloor;

    Rigidbody rb;
    float horizontal;
    float vertical;
    Vector3 movePosition;
    Vector3 newMovePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OnFloor = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontal = Input.GetAxis("Horizontal") * sprintSpeed;
            vertical = Input.GetAxis("Vertical") * sprintSpeed;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal") * speed;
            vertical = Input.GetAxis("Vertical") * speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && OnFloor)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            OnFloor = false;
        }

        movePosition = transform.right * horizontal + transform.forward * vertical;
        newMovePosition = new Vector3(movePosition.x, rb.velocity.y, movePosition.z);

        rb.velocity = newMovePosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            OnFloor = true;
        }
    }
}
