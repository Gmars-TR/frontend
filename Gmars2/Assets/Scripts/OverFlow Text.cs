using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OverFlowText : MonoBehaviour
{
    public TextMeshProUGUI text;       // Reference to the Text component
    public RectTransform container; // Reference to the container's RectTransform
    public RectTransform expandingBox;

    // Update is called once per frame
    void Update()
    {
        bool isOverflowing = text.preferredHeight > container.rect.height;
        if (isOverflowing)
        {
            expandingBox.sizeDelta = new Vector2(expandingBox.rect.size[0], expandingBox.rect.size[1] + 41f);
            expandingBox.position = new Vector3(expandingBox.position[0], expandingBox.position[1] + 8f, expandingBox.position[2]);
        }
    }
}
