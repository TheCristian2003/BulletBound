using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float jumpBoost = 5f;
    public float rapidFireCooldown = 0.1f;
    public float duration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        JohnMovement john = other.GetComponent<JohnMovement>();

        if (john != null)
        {
            john.StartCoroutine(john.PowerMode(
                jumpBoost,
                rapidFireCooldown,
                duration
            ));

            Destroy(gameObject);
        }
    }
}