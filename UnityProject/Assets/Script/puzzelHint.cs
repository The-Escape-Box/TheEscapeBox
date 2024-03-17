using System.Collections;
using UnityEngine;
using TMPro;

public class PuzzleHint : MonoBehaviour
{
    public string fullText;
    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(DisplayTextRoutine());
    }

    IEnumerator DisplayTextRoutine()
    {
        while (true)
        {
            // Display text letter by letter
            foreach (char letter in fullText)
            {
                textComponent.text += letter;
                yield return new WaitForSeconds(0.1f); // Adjust the delay between letters if needed
            }

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Hide the text
            textComponent.text = "";

            // Wait for 30 seconds before displaying text again
            yield return new WaitForSeconds(30f);
        }
    }

    // Method to disable the text
    public void DisableText()
    {
        // Disable the text component
        textComponent.enabled = false;
    }
}
