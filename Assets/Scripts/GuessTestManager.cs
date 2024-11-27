using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GuessTestManager : MonoBehaviour
{
    [SerializeField] private bool isPhishing;
    private VisualElement successPopupContainer;
    private VisualElement failPopupContainer;
    private VisualElement[] slidesExplanation;
    private Button btnIsPhishing;
    private Button btnNotPhishing;
    private TimerManager timerManager;
    private ScoreManager scoreManager;

    private void Start() 
    {
        timerManager = FindObjectOfType<TimerManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        var uiDocument = GameObject.FindObjectOfType<UIDocument>();
        var root = uiDocument.rootVisualElement;

        //var btnContainer = root.Q<VisualElement>("BtnContainer");
        btnIsPhishing = root.Q<Button>("btnIsPhishing");
        btnNotPhishing = root.Q<Button>("btnNotPhishing");

        failPopupContainer = root.Q<VisualElement>("FailPopupContainer");
        successPopupContainer = root.Q<VisualElement>("SuccessPopupContainer");

        slidesExplanation = root.Query<VisualElement>("Slide").ToList().ToArray();

        btnIsPhishing.clicked += OnClickIsPhishing;
        btnNotPhishing.clicked += OnClickIsNotPhishing; 
    }

    private void OnClickIsPhishing()
    {
        timerManager.isTimerRunning = false;
        if(isPhishing)
        {
            successPopupContainer.style.display = DisplayStyle.Flex;
            ScoreManager.AddScore(10);
        }else{
            failPopupContainer.style.display = DisplayStyle.Flex;
            ScoreManager.AddScore(-10);
        }
    }

    private void OnClickIsNotPhishing()
    {   
        timerManager.StopTimer();
        if(isPhishing)
        {
            failPopupContainer.style.display = DisplayStyle.Flex;
            slidesExplanation[0].style.display = DisplayStyle.Flex;
            ScoreManager.AddScore(-10);
        }else{
            successPopupContainer.style.display = DisplayStyle.Flex;
            ScoreManager.AddScore(10);
        }
    }
}
