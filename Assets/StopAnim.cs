using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnim : MonoBehaviour
{

    Renderer rend;
    float offset; //kuvan sivuttaissiirtym‰
    float offDelta = 0.1f; //riippuu "sprite sheetin" osakuvien m‰‰r‰st‰, 1 per kuvien m‰‰r‰, voitaisiin laskea countMax-arvosta
    public int speed = 6; //Mit‰ suurempi luku, sit‰ hitaampi animaatio
    int speedCount; //laskuri kuvan vaihdolle
    int counter; //laskuri kuvien l‰pik‰ynnille
    int counterDelta = 1; //laskurin muutos
    int countMax = 10; //Osakuvien m‰‰r‰
    

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speedCount > speed)
        {
            //muutetaan offset
            rend.material.mainTextureOffset = new Vector2(offset, 0);
            speedCount = 0;
            //tarkistetaan ollaanko sheetin rajalla
            if (counter >= countMax)
            {
                //jos, niin nollataan laskuri ja offset
                counter = 0;
                offset = 0;
            }
            //p‰ivitet‰‰n laskuri ja offset
            offset += offDelta;
            counter += counterDelta;
        }
        speedCount++;
    }
}
