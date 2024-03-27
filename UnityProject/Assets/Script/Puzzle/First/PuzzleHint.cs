using System.Collections;
using TMPro;
using UnityEngine;

namespace Script.Puzzle.First
{
    public class PuzzleHint : MonoBehaviour
    {
        private string fullText = "Unleash the power of electricity!";
        private TextMeshProUGUI textComponent;
        private Coroutine textCoroutine;

        private void Start()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
            // Start the coroutine once at the beginning
            textCoroutine = StartCoroutine(DisplayTextRoutine());
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