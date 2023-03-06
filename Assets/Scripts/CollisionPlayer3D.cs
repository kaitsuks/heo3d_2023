using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer3D : MonoBehaviour
{
    //This is Main Camera in the Scene
    Camera m_MainCamera;
    AudioSource mainAudioSource;

    AudioSource audioSource;

    AudioSource soittajaAudioSource;

    GameObject[] audioControls;

    public GameObject soittaja;

    //AudioSource[] aSources;

    public bool bPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        //This enables Main Camera TARVITTAESSA
        m_MainCamera.enabled = true;
        audioSource = GetComponent<AudioSource>();
        mainAudioSource = m_MainCamera.GetComponent<AudioSource>();
        //soittaja = GameObject.Find("Soittaja");
        soittajaAudioSource = soittaja.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
       

        if (col.gameObject.tag == "Player")
        {
            audioControls = GameObject.FindGameObjectsWithTag("AudioControl");
            foreach (GameObject go in audioControls)
            {
                go.GetComponent<AudioSource>().Stop();
            }
            Debug.Log("SOUND COLLISION!");
          if(bPlay == true)
            {
                if(mainAudioSource != null)
                {
                    mainAudioSource.Stop();
                }


               //// soittajaAudioSource

               //      if (soittajaAudioSource != null)
               // {
               //     soittajaAudioSource.Stop();
               // }

                audioSource.Play();
            }
           
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            audioControls = GameObject.FindGameObjectsWithTag("AudioControl");
            foreach (GameObject go in audioControls)
            {
                go.GetComponent<AudioSource>().Stop();
            }
            Debug.Log("SOUND TRIGGER COLLISION!");
            if (bPlay == true)
            {
                if (mainAudioSource != null)
                {
                    mainAudioSource.Stop();
                }

                // soittajaAudioSource

                //if (soittajaAudioSource != null)
                //{
                //    soittajaAudioSource.Stop();
                //}

                audioSource.Play();
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
