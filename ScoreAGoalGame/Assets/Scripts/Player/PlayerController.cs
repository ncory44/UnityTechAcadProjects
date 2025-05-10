using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float kickForce = 500f;
    public Transform kickOrigin;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowKickMessage(true);
            UIManager.Instance.ShowWinMessage(false);
        }
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0, moveV);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryKick();
        }
    }

    //kicks the ball
    void TryKick()
    {
        Collider[] hits = Physics.OverlapSphere(kickOrigin.position, 1.5f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Ball"))
            {
                Rigidbody ballRb = hit.GetComponent<Rigidbody>();
                if (ballRb != null)
                {
                    Vector3 direction = (hit.transform.position - transform.position).normalized;
                    ballRb.AddForce(direction * kickForce);
                }
            }
        }
    }
}
