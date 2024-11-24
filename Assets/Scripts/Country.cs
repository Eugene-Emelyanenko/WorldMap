using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Country : MonoBehaviour
{
    [SerializeField] private string countryName = string.Empty;
    [SerializeField] private string countryInfo = string.Empty;
    [SerializeField] private Sprite countyFlag;
    [SerializeField] private Vector2 targetPoint = new Vector2();
    [SerializeField] private float cameraSize = 0f;

    private Color defaultColor;
    private Color[] colors = new[] { new Color(0.3f, 0.3f, 0.3f), new Color(0.4f, 0.4f, 0.4f) };
    private SpriteRenderer[] countrySprites;

    private void Awake()
    {
        countrySprites = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        defaultColor = colors[Random.Range(0, colors.Length)];
        SetColor(defaultColor, 0);
    }

    public void SetColor(Color color, float duration)
    {
        foreach (SpriteRenderer countrySprite in countrySprites)
        {
            LeanTween.value(countrySprite.gameObject, countrySprite.color, color, duration)
                .setOnUpdate((value) => {
                    countrySprite.color = value;
                });
        }
    }

    public Color GetDefaultColor() => defaultColor;

    public string GetCountryInfo() => countryInfo;

    public Sprite GetCountryFlag() => countyFlag;

    public string GetCountryName() => countryName;

    public Vector2 GetTargetPoint() => targetPoint;

    public float GetCameraSize() => cameraSize;
}
