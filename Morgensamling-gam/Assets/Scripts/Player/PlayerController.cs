using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputActions _input;
    private Rigidbody2D _rigidbody2D;
    
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f,0.2f);

    public GameObject HookShotPrefab;

    private void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        playerIsGrounded = Physics2D.OverlapBox(transform.position - new Vector3(0,1f,0), groundBoxSize, 0f, whatIsGround);
        
        if (_input.Jump && playerIsGrounded)
        {
            _rigidbody2D.linearVelocityY = jumpSpeed;
        }

        if (_input.Shoot)
        {
            // var Angle = _input.MoveDir.x * transform.right;
            float angle = Mathf.Atan2(_input.MoveDir.y, _input.MoveDir.x) * Mathf.Rad2Deg;
            Instantiate(HookShotPrefab, transform.position,  Quaternion.Euler(0, 0, angle));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position - new Vector3(0,1f,0), groundBoxSize);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = _input.MoveDir.x * moveSpeed;
    }
}