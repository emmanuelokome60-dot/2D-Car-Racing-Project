using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class LapCounter : MonoBehaviour
{
    // 1 reference
    public TextMeshProUGUI lapText;

    // 0 references
    public int lapCount = 0;

    // 0 references
    public int lapCountAI = 0;

    // 2 references
    public int totalLaps = 5; // 5 laps

    // 1 reference
    public GameObject endScreen;

    // 1 reference
    public TextMeshProUGUI gameResult;

    bool isGameEnd = false;

    // 0 references
    void Start()
    {
        endScreen.SetActive(false);
    }

    // 0 references
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isGameEnd == false)
        {
            lapCount++;
            Debug.Log("Laps: " + lapCount);
            lapText.text = "LAPS: " + lapCount;

            if (lapCount == totalLaps)
            {
                Debug.Log("You Win!");
                gameResult.text = "You Win!";
                endScreen.SetActive(true);
                isGameEnd = true;
                Invoke(nameof(RestartGame), 5f); // 5 seconds to read result
            }
        }

        if (other.CompareTag("AI") && isGameEnd == false)
        {
            lapCountAI++;
            Debug.Log("Lap ai: " + lapCountAI);

            if (lapCountAI == totalLaps)
            {
                Debug.Log("You Lose!");
                gameResult.text = "You Lose!";
                endScreen.SetActive(true);
                isGameEnd = true;
                Invoke(nameof(RestartGame), 5f); // 5 seconds to read result
            }
        }
    }

    // Player loses if AI completes totalLaps before player
    void Update()
    {
        if (isGameEnd == false && lapCountAI >= totalLaps && lapCount < totalLaps)
        {
            Debug.Log("You Lose! You did not complete " + totalLaps + " laps.");
            gameResult.text = "You Lose!\nYou did not complete " + totalLaps + " laps!";
            endScreen.SetActive(true);
            isGameEnd = true;
            Invoke(nameof(RestartGame), 5f); // 5 seconds to read result
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
