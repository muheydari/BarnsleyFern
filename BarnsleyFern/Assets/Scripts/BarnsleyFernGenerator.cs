using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * 2020-11-11
 * Email me at 
 * muheydari@gmail.com 
 * 
 * https://en.wikipedia.org/wiki/Barnsley_fern
 * The Barnsley fern is a fractal named after the British mathematician Michael Barnsley
 * The fern is one of the basic examples of self-similar sets, i.e. 
 * it is a mathematically generated pattern that can be reproducible at any magnification or reduction * 
 */
public class BarnsleyFernGenerator : MonoBehaviour
{

    public Vector2 Area = new Vector2(800, 600);
    public int MaxGeneration = 100000;
    public PrimitiveType type = PrimitiveType.Sphere;
    public float Size = 0.3f;
    public int GenerationSpeed = 20;
    public Color color = Color.green;
    int count = 0;
    float x = 0.0f, y = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (count > MaxGeneration)
        {
            Debug.Log("Maximum generation unit");
            return;
        }
        for (int i = 0; i < GenerationSpeed; i++)
        {
            Step();
        }
        
    }


    void Step()
    {
        float nextX, nextY;
        float r = Random.value;
        if (r < 0.01)
        {
            nextX = 0;
            nextY = 0.16f * y;
        }
        else if (r < 0.86)
        {
            nextX = 0.85f * x + 0.04f * y;
            nextY = -0.04f * x + 0.85f * y + 1.6f;
        }
        else if (r < 0.93)
        {
            nextX = 0.20f * x - 0.26f * y;
            nextY = 0.23f * x + 0.22f * y + 1.6f;
        }
        else
        {
            nextX = -0.15f * x + 0.28f * y;
            nextY = 0.26f * x + 0.24f * y + 0.44f;
        }

        // Scaling and positioning
        float plotX = Area.x * (x + 3.0f) / 6.0f;
        float plotY = Area.y - Area.y * ((y + 2.0f) / 14.0f );

        drawFilledCircle(plotX, plotY);

        x = nextX;
        y = nextY;
    }

    private void drawFilledCircle(float plotX, float plotY)
    {
        GameObject t = GameObject.CreatePrimitive(type);
        t.transform.position = new Vector3(plotX,0,plotY);
        t.transform.localScale = Vector3.one * Size;
        t.transform.parent = this.transform;
        t.GetComponent<Renderer>().material.color = color;
        count++;
    }


}
