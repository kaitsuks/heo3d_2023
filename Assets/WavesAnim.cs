using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.unity3d.com/ScriptReference/Material-mainTextureOffset.html
public class WavesAnim : MonoBehaviour
{
    // Scroll the main texture based on time

    float scrollSpeed = 0.1f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }
}
