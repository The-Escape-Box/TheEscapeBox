using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PuzzleManager : MonoBehaviour
{
    public Light[] spotlights;
    public PuzzleHint puzzleHint; // Reference to the PuzzleHint script

    private bool puzzleCompleted = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Change the color of spotlights to FFD580
            foreach (Light spotlight in spotlights)
            {
                spotlight.color = new Color(1f, 0.839f, 0.502f); // FFD580 in RGB
                Debug.LogWarning("Turn the Light on!");
            }

            // Set puzzleCompleted flag to true to prevent multiple executions
            puzzleCompleted = true;

            // Disable the puzzle hint text
            puzzleHint.DisableText();
        }
    }
}
