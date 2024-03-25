using System.Collections;
using TMPro;
using UnityEngine;

namespace Script.Utils
{
    public class TypeWriterEffect : MonoBehaviour
    {
        public float letterDelay = 0.1f; // Delay between each letter
        public string[] texts = new string[]{
            "You want to escape your dreams to reality?",
            "That is wrong and if you don't believe me!",
            "I will prove it to you"
        }; // Texts to display
        private string currentText = ""; // Text being displayed

        private TMP_Text textComponent;
        private int textIndex = 0;

        void Start()
        {
            textComponent = GetComponent<TMP_Text>();
            StartCoroutine(ShowText());
        }

        IEnumerator ShowText()
        {
            string fullText = texts[textIndex];
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(letterDelay);
            }
            // Wait for a few seconds before moving to the next text (optional)
            yield return new WaitForSeconds(2f);
            NextText();
        }

        // Advance to the next text
        void NextText()
        {
            textIndex = (textIndex + 1) % texts.Length;
            StartCoroutine(ShowText());
        }
    }
}
