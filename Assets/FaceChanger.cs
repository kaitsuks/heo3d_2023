using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    Renderer rend;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetOffset(float f)
    {
        offset = f;
    }

    public void SetOffset(string face)
    {
        switch (face)
        {
            case "joy":
                // code block
                offset = 0.0f;
                break;
            case "angry":
                // code block
                offset = 0.2f;
                break;
            case "sad":
                // code block
                offset = 0.4f;
                break;
            default:
                // code block
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) offset = 0.0f;
        if (Input.GetKeyDown("2")) offset = 0.2f;
        if (Input.GetKeyDown("3")) offset = 0.4f;
        if (Input.GetKeyDown("4")) offset = 0.6f;
        if (Input.GetKeyDown("5")) offset = 0.8f;
        //muutetaan offset
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
