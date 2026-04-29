using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    void Start()
    {
        // Position camera at track center with wide view
        transform.position = new Vector3(0, 0, -15f);
    }
}
