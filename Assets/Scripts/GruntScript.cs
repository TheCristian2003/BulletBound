using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public Transform John;
    public GameObject BulletPrefab;

    public float detectionDistance = 3.0f;
    public float shootCooldown = 1.5f;

    private int Health = 3;
    private float LastShoot;

    void Update()
    {
        if (John == null) return;

        Vector3 lookDirection = John.position - transform.position;

        if (lookDirection.x >= 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Vector2.Distance(transform.position, John.position);

        if (distance < detectionDistance && Time.time > LastShoot + shootCooldown)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction = (John.position - transform.position).normalized;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.3f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        bullet.GetComponent<BulletScript>().SetOwner("Enemy");
    }

    public void Hit()
    {
        Health -= 1;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}