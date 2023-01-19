using UnityEngine;
using UnityEngine.UI;

public class BackgroundMovement : MonoBehaviour
{
    private Image img;

    void Start()
    {
        img = GetComponent<Image>();

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        if (img)
        {
            Vector2 offset = new Vector2(Time.time * .1f, 0);
            img.material.mainTextureOffset = offset;
        }
    }
}