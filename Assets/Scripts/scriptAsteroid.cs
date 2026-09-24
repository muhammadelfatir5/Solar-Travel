using UnityEngine;

public class scriptAsteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    private ConstantForce2D constantForce2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        constantForce2D = GetComponent<ConstantForce2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -15.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            constantForce2D.enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }
}
