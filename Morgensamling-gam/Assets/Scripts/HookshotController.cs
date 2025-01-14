using UnityEngine;

public class HookshotController : MonoBehaviour
{
    public float Speed = 10;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.linearVelocity = Speed * transform.right;
        Destroy(this.gameObject, 3f);
    }
}
