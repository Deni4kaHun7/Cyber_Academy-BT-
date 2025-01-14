using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    private Button nextSlide;
    void Start()
    {
        var uiDocument = GameObject.FindObjectOfType<UIDocument>();
        var root = uiDocument.rootVisualElement;
        nextSlide = root.Q<Button>("nextSlide"); 

        nextSlide.clicked += NextSlide;
    }

    private void NextSlide()
    {
        SceneManager.LoadScene("Intro2");
    }
}
