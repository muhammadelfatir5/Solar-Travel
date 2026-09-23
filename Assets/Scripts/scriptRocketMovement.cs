using UnityEngine;

public class scriptRocketMovement : MonoBehaviour
{
    public float speed = 5f;
    public float limitY = 8f;
    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * moveInput * speed * Time.deltaTime);

        float clampedY = Mathf.Clamp(transform.position.y, -limitY, limitY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}