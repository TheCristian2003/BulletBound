using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        JohnMovement john = other.GetComponent<JohnMovement>();

        if (john != null)
        {
            GameManager.Instance.Victory();
        }
    }
}
