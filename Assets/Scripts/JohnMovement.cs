using System.Collections;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public float ShootCooldown = 0.25f;
    public GameObject BulletPrefab;

    public int maxHealth = 5;
    public int currentHealth;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        currentHealth = maxHealth;

        if (HeartsUI.Instance != null)
            HeartsUI.Instance.UpdateHearts(currentHealth);
    }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.1f);

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + ShootCooldown)
        {
            Shoot();
            LastShoot = Time.time;
        }

        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal * Speed, Rigidbody2D.linearVelocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction = transform.localScale.x == 1.0f ? Vector3.right : Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.3f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        bullet.GetComponent<BulletScript>().SetOwner("Player");
    }

    public void Hit()
    {
        currentHealth--;

        if (HeartsUI.Instance != null)
            HeartsUI.Instance.UpdateHearts(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.PlayerDied();
        Destroy(gameObject);
    }

    public IEnumerator PowerMode(float extraJump, float fireRate, float duration)
    {
        float originalJump = JumpForce;
        float originalCooldown = ShootCooldown;

        JumpForce += extraJump;
        ShootCooldown = fireRate;

        yield return new WaitForSeconds(duration);

        JumpForce = originalJump;
        ShootCooldown = originalCooldown;
    }
}