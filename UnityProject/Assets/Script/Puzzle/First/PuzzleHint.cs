using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Include this for scene management

namespace Script.Puzzle.First
{
    public class PuzzleHint : MonoBehaviour
    {
        private string fullText;
        private TextMeshProUGUI textComponent;
        private Coroutine textCoroutine;

        private void Start()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
            SetInitialText();
            // Start the coroutine once at the beginning
            textCoroutine = StartCoroutine(DisplayTextRoutine());
        }

        // Set the initial text based on the scene number
        private void SetInitialText()
        {
            // Get the current active scene number
            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
            // Check if the current scene is number 4
            if (sceneNumber == 4)
            {
                fullText = "Discover the cause you have been fighting for your entire life";
            }
            else
            {
                fullText = "Unleash the power of electricity!";
            }
        }

        // Coroutine to display text
        private IEnumerator DisplayTextRoutine()
        {
            while (true)
            {
                // Display text letter by letter
                foreach (var letter in fullText)
                {
                    textComponent.text += letter;
                    yield return new WaitForSeconds(0.1f); // Adjust the delay between letters if needed
                }

                // Wait for 5 seconds
                yield return new WaitForSeconds(5f);

                // Hide the text
                textComponent.text = "";

                // Wait for 30 seconds before displaying text again
                yield return new WaitForSeconds(10f);
            }
        }

        // Method to disable the text
        public void DisableText()
        {
            // Disable the text component
            textComponent.enabled = false;
        }

        // Method to set the text dynamically
        public void SetText(string newText)
        {
            // Update the fullText variable with the provided text
            fullText = newText;
            // Reset the text displayed
            textComponent.text = "";
            // Restart the coroutine to immediately display the new text
            if (textCoroutine != null)
                StopCoroutine(textCoroutine);
            textCoroutine = StartCoroutine(DisplayTextRoutine());
        }
    }
}
