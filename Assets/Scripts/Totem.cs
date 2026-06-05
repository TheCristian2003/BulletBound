using UnityEngine;

public class Totem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        JohnMovement john = other.GetComponentInParent<JohnMovement>();

        if (john == null) return;

        GameManager.Instance.CollectTotem();
        Destroy(gameObject);
    }
}