using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;
    public float lifeTime = 3f;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    private string ownerTag;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        if (Camera.main != null && Camera.main.GetComponent<AudioSource>() != null && Sound != null)
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);

        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction.normalized;
    }

    public void SetOwner(string owner)
    {
        ownerTag = owner;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }

        BulletScript otherBullet = other.GetComponent<BulletScript>();

        if (otherBullet != null && otherBullet.ownerTag != ownerTag)
        {
            Destroy(otherBullet.gameObject);
            Destroy(gameObject);
            return;
        }

        GruntScript grunt = other.GetComponent<GruntScript>();
        JohnMovement john = other.GetComponent<JohnMovement>();

        if (grunt != null && ownerTag == "Player")
        {
            grunt.Hit();
            Destroy(gameObject);
            return;
        }

        if (john != null && ownerTag == "Enemy")
        {
            john.Hit();
            Destroy(gameObject);
            return;
        }
    }
}