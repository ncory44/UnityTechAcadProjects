using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.WinGame();
        }
    }
}
