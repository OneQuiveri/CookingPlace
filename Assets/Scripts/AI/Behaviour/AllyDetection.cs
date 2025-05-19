using Unity.VisualScripting;
using UnityEngine;

public class AllyDetection : MonoBehaviour 
{
    public LayerMask LayerMask;

    public Vector2 detectDirection;

    private bool allyNearby = false;

    public bool AllyNearby => allyNearby;

    public float rayDistance = 0.5f;

    [SerializeField] CircleCollider2D userCollision;

    private void Awake()
    {
        userCollision = GetComponent<CircleCollider2D>();
    }

    private void Update() 
    {
        CheckAlly();
    }

    private void CheckAlly()
    {
        Vector2 origin = (Vector2)transform.position + detectDirection.normalized * (userCollision.radius + 0.12f);

        RaycastHit2D hit = Physics2D.Raycast(origin, detectDirection.normalized, rayDistance, LayerMask);

        allyNearby = hit.collider != null && hit.collider.gameObject != gameObject;

    }

    private void OnDrawGizmos()
    {
        if (userCollision == null) return;

        Vector2 origin = (Vector2)transform.position + detectDirection.normalized * (userCollision.radius + 0.12f);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(origin, detectDirection.normalized * rayDistance);

    }
}
