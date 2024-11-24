using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
    [SerializeField] private Text maxScore;
    void Start()
    {
        maxScore.text = PlayerPrefs.GetInt("maxScore", 0).ToString();
    }
}
