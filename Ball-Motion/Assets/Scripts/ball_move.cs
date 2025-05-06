using System.Collections;
using UnityEngine;

public class ball_move : MonoBehaviour
{
    public float speed;
    private Rigidbody rigb;
    void Start()
    {
        rigb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(moveHoriz, 0.0f, moveVert);
        rigb.AddForce(movment * speed);
    }
}
