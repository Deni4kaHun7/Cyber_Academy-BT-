using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    // Static variable to store the player's score, shared across all instances
    public static int score = 0;

    // Static reference to the UI label used to display the score
    public static Label scoreLabel;

    private void Start()
    {
        // Find the UIDocument in the scene and access the root UI element
        var uiDocument = GameObject.FindObjectOfType<UIDocument>();
        var root = uiDocument.rootVisualElement;

        // Find the label named "scoreLabel" in the UI hierarchy
        scoreLabel = root.Q<Label>("scoreLabel");

        // Set the initial text of the score label
        scoreLabel.text = $"Score:{score}";
    }

    // Static method to add points to the player's score
    public static void AddScore(int points)
    {
        // Increase the score by the given points, ensuring it doesn't go below zero
        score = Mathf.Max(0, score + points);

        // Update the score label with the new score
        scoreLabel.text = $"Score:{score}";
    }
}
