using UnityEngine;
using UnityEngine.UI;

public class BackgroundMovement : MonoBehaviour
{
    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        if (img)
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            
            Vector2 offset = new Vector2(Time.time * .1f, 0);
            img.material.mainTextureOffset = offset;
        }
    }
}
