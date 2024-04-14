using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    [SerializeField] RectTransform position;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] RectTransform endPosition;
    public float transitionTime = 10f;

    void Update()
    {

    }
}
