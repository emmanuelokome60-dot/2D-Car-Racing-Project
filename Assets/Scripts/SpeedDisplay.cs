using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public Rigidbody2D playerRigidbody;

    void Update()
    {
        float speed = playerRigidbody.linearVelocity.magnitude;
        speedText.text = "SPEED: " + Mathf.RoundToInt(speed);
    }
}

