using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingInTrans : MonoBehaviour
{
    public Color newColor;
    public float fadeSpeed = 0.2f;

    public SpriteRenderer curtain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curtain.color = Color.Lerp(curtain.color, newColor, fadeSpeed * Time.deltaTime);
    }
}
