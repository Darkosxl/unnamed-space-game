using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColor;
    private int colorIndex = 0;
    int len;
    float t = 0f;
    void Start()
    {
        //StartCoroutine(Renk());
    }

   

    void Update()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value);
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
        _img.color = Color.Lerp(_img.color, myColor[colorIndex], lerpTime*Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if(t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= myColor.Length) ? 0 : colorIndex;
        }
        //_img.color = newColor; 
        /* if (_img.color.r + 0.01f > 1f)
             _img.color = new Color(0, 0, 0, _img.color.a);
         else
             _img.color = new Color(_img.color.r + 0.01f, _img.color.b + 0.01f, _img.color.g + 0.01f, _img.color.a); ;
     */
    }
}
