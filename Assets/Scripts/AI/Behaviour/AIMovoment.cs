using UnityEngine;

public class AIMovoment : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;

    private Vector2 targetMovePoint = Vector2.zero;

    private bool needMove = false;

    [SerializeField] animation _animation;

    public float stopDistance = 0.1f;

    public bool targetArrived = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (_animation == null) _animation = GetComponent<animation>();
    }

    private void FixedUpdate()
    {
        if (needMove)
        {
            MoveToTarget();
        }

        UpdateAnimator();
    }

    private void MoveToTarget()
    {
        var directionToMove = (targetMovePoint
            - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)).normalized;

        Move(directionToMove);
    }

    public void SetTargetMovePint(Vector2 target)
    {
        targetArrived = false;
        targetMovePoint = target;
    }

    public void NeedMove(bool value)
    {
        needMove = value;
        if (!value)
        {
            moveH = 0f;
            moveV = 0f;
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void Move(Vector2 direction)
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetMovePoint) > stopDistance)
        {
            moveH = direction.x * moveSpeed;
            moveV = direction.y * moveSpeed;
            rb.linearVelocity = new Vector2(moveH, moveV);
        }
        else
        {
            targetArrived = true;
            NeedMove(false);
        }
    }

    private void UpdateAnimator()
    {
        Vector2 direction = new Vector2(moveH, moveV);
        if (_animation != null) _animation.SetDirection(direction);
    }

    public Vector2 GetMoveDirection() => new Vector2(moveH, moveV);

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(targetMovePoint, 0.15f);
    }
#endif
}
