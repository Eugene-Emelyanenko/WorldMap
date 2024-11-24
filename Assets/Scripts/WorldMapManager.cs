using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WorldMapManager : MonoBehaviour
{
    [SerializeField] private CountryInfoController countryInfoController;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private List<Country> countries = new List<Country>();
    [SerializeField] private Color currentCountryColor = Color.red;
    [SerializeField] private float colorChangeDuration = 0.5f;
    [SerializeField] private Score score;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private float gameOverPanelMoveDuration = 1f;

    private List<string> remainingNames = new List<string>();
    private List<string> countryNames = new List<string>();
    private Country currentCountry;
    private Country previousCountry;

    private void Awake()
    {
        countries = FindObjectsOfType<Country>().ToList();
        foreach (Country country in countries)
        {
            countryNames.Add(country.GetCountryName());
        }
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowCountry()
    {
        if (countries.Count == 0)
        {
            cameraController.ResetCamera(ShowGameOverPanel);
            countryInfoController.HidePanel();
            currentCountry.SetColor(currentCountry.GetDefaultColor(), colorChangeDuration);
            Debug.Log("No countries in the list");
            return;
        }
        
        previousCountry = currentCountry;
    
        int randomIndex = Random.Range(0, countries.Count);
        currentCountry = countries[randomIndex];

        cameraController.MoveAndZoomToTargetCountry(currentCountry.GetTargetPoint(), currentCountry.GetCameraSize(), CameraMoveComplete);
        
        countries.RemoveAt(randomIndex);
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        
        LeanTween.moveY(gameOverPanel, 0f, gameOverPanelMoveDuration)
            .setEase(LeanTweenType.easeInOutQuad);
    }

    private void CameraMoveComplete()
    {
        currentCountry.SetColor(currentCountryColor, colorChangeDuration);
        
        SetRandomAnswers();
        countryInfoController.ShowPanel();
        
        if (previousCountry != null)
        {
            previousCountry.SetColor(previousCountry.GetDefaultColor(), colorChangeDuration);
        }
    }

    public void Answer(Text answerText)
    {
        if (answerText.text == currentCountry.GetCountryName())
        {
            countryInfoController.quizPanel.SetActive(false);
            countryInfoController.infoPanel.SetActive(true);
            score.IncreaseScore();
            countryInfoController.countryFlag.sprite = currentCountry.GetCountryFlag();
            countryInfoController.info.text = currentCountry.GetCountryInfo();
            countryInfoController.countryName.text = currentCountry.GetCountryName();
        }
        else
        {
            countryInfoController.HidePanel();
            ShowCountry();
        }
    }

    private void SetRandomAnswers()
    {
        remainingNames = new List<string>(countryNames);

        if(remainingNames.Contains(currentCountry.GetCountryName()))
            remainingNames.Remove(currentCountry.GetCountryName());
        
        foreach (GameObject button in countryInfoController.answerButtons)
        {
            Text buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                AssignRandomText(buttonText);
            }
            else
            {
                Debug.LogWarning("Не удалось найти компонент Text в дочерних объектах кнопки " + button.name);
            }
        }

        countryInfoController.answerButtons[Random.Range(0, countryInfoController.answerButtons.Length)]
            .GetComponentInChildren<Text>().text = currentCountry.GetCountryName();
    }
    
    private void AssignRandomText(Text buttonText)
    {
        if (remainingNames.Count > 0)
        {
            int randomIndex = Random.Range(0, remainingNames.Count);
            
            buttonText.text = remainingNames[randomIndex];
            
            remainingNames.RemoveAt(randomIndex);
        }
        else
        {
            Debug.LogWarning("Недостаточно текстов для всех кнопок!");
        }
    }
}
