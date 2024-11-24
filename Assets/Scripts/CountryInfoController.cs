using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryInfoController : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public float showDuration = 0.5f;
    public float showXPoint = -300f;
    public float hideXPoint = 300f;
    
    [Header("Quiz Panel")]
    public GameObject quizPanel;
    public GameObject[] answerButtons;
    public Text questionText;

    [Header("Info Panel")] 
    public GameObject infoPanel;
    public Image countryFlag;
    public Text info;
    public Text countryName;

    private void Start()
    {
        panelRectTransform.gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        infoPanel.SetActive(false);
        quizPanel.SetActive(true);
        panelRectTransform.gameObject.SetActive(true);
        LeanTween.moveX(panelRectTransform, showXPoint, showDuration)
            .setEase(LeanTweenType.easeOutExpo);
    }

    public void HidePanel()
    {
        LeanTween.moveX(panelRectTransform, hideXPoint, showDuration)
            .setEase(LeanTweenType.easeOutExpo);
    }
}
