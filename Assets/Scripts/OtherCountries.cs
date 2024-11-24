using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCountries : MonoBehaviour
{
    public Color color_1;
    public Color color_2;

    public SpriteRenderer[] otherCountries;

    private void Awake()
    {
        // Список для хранения SpriteRenderer'ов нужных дочерних объектов
        List<SpriteRenderer> validChildren = new List<SpriteRenderer>();

        // Проходим по всем дочерним объектам
        foreach (Transform child in transform)
        {
            // Проверяем, начинается ли имя дочернего объекта с символа "_"
            if (child.name.StartsWith("_"))
            {
                // Получаем компонент SpriteRenderer у дочернего объекта
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                // Если у дочернего объекта есть компонент SpriteRenderer, добавляем его в список
                if (spriteRenderer != null)
                {
                    validChildren.Add(spriteRenderer);
                }
            }
        }

        // Преобразуем список в массив
        otherCountries = validChildren.ToArray();
    }

    void Start()
    {
        for (int i = 0; i < otherCountries.Length; i++)
        {
            if (i % 2 == 0)
            {
                otherCountries[i].color = color_1;
            }
            else
            {
                otherCountries[i].color = color_2;
            }
        }
    }
}
