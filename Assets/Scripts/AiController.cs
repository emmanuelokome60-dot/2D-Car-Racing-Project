using UnityEngine;

public class AIController : MonoBehaviour
{
    // 1 reference
    public Transform[] waypoints;

    // 1 reference
    public float speed = 3f;

    // 0 references
    public float startDelay = 0f; // Add delay for each AI car

    // 0 references
    private int waypointIndex = 0;
    private Rigidbody2D rb;
    private bool canMove = false; // Controls when AI starts moving

    // 0 references
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        Invoke(nameof(StartMoving), startDelay); // Wait before moving
    }

    void StartMoving()
    {
        canMove = true; // Allow movement after delay
    }

    void Update()
    {
        if (!canMove) return; // Don't move until delay is done

        Vector2 direction = waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }
}
