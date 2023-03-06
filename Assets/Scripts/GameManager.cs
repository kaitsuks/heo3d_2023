using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    //private BoardManager boardScript;                        //Store a reference to our BoardManager which will set up the level.
    private int level = 3;                                    //Current level number, expressed in game as "Day 1".
    public static int score = 0;
    public static string playerName = "Oletusnimi";
    public static int enemiesNumber = 0;
    public static int maxEnemies = 20;

    [HideInInspector]
    public static int ohjainNumero; //käytössä olevan ampumisohjaimen (Object Shooter) numero

    public float detectPCTime = 1f;
    public float startSpawningEnemiesTime = 1f;
    public float stopSpawningEnemiesTime = 600f;
    GameObject go1;
    GameObject go2;
    //state booleans
    [HideInInspector]
    public bool bDetecting = true;
    [HideInInspector]
    public bool bRadaring = false;
    
    [HideInInspector]
    public Vector3 playerPosition;
    [HideInInspector]
    public Vector3 carPosition;
    Camera droneCam;
    GameObject drone;

    GameObject player;
    bool playerSet = false;
    private static bool pcDetected;
    GameObject ui;
    private static GameObject[] enemies;
    GameObject ehq;
    ObjectCreatorArea3D objectCreatorArea3D;

    GameObject[] ehqs;
    RahikainenCreatorArea3D[] rahikainens;

    int timex = 0;
   
    //Awake is always called before any Start functions
    void Awake()
    {
        //drone = GameObject.Find("DroneCamera");
        //droneCam = drone.GetComponent<Camera>();
        //detectorCam = GameObject.Find("CameraDetector").GetComponent<Camera>();
        
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene

        //DontDestroyOnLoad(gameObject);

        ui = GameObject.Find("UI");
        player = GameObject.Find("Soldier2");
        ehq = GameObject.Find("EnemyHeadQuarter1");

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    public void InitGame()
    {
        //Canvas canvas = ui.GetComponent<Canvas>();
        //canvas.GetComponent<UIScript>().InitUI();
        //ui.GetComponentInChildren<UIScript>().InitUI();
        
        // drone.SetActive(false);
        //DontDestroyOnLoad(player);
        //DontDestroyOnLoad(ui);
        objectCreatorArea3D = ehq.GetComponent<ObjectCreatorArea3D>();
        if(objectCreatorArea3D != null) {
          //  UnityEngine.Debug.Log("objectCreatorArea3D LÖYTYI"); 
        }
        Invoke("ArvoRahikainen", 1f);
    }

    void ArvoRahikainen()
    {
        int n = 0;
        ehqs = GameObject.FindGameObjectsWithTag("EnemyHQ");
        int l = ehqs.Length;
        rahikainens = new RahikainenCreatorArea3D[l];

        foreach (GameObject go in ehqs) {
            RahikainenCreatorArea3D rca = go.GetComponent<RahikainenCreatorArea3D>();
            if (rca != null)
            {
               // UnityEngine.Debug.Log("RahikainenCreatorArea3D LÖYTYI " + go);
                rahikainens[n] = rca;
                n++;
            }
        }
        int selected = UnityEngine.Random.Range(0, n);
        rahikainens[selected].SpawnRahikainen();
    }

    public static void ChangeEnemiesCount(int delta)
    {
        enemiesNumber += delta;
        //UnityEngine.Debug.Log("VIHOLLISIA " + enemiesNumber);
        //UnityEngine.Debug.Log("MAKSIMI VIHOLLISET " + maxEnemies);
    }

    public void AskForPause()
    {
        Invoke("Pause", 5f);
    }

    public void Pause()
    {
        timex = 1 - timex;
        if (timex == 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void SetFalse()
    {
        bDetecting = false;
        bRadaring = false;
    }

    public void Detecting()
    {
        bDetecting = true;
    }

    public void Radaring()
    {
        bDetecting = false;
        bRadaring = true;
    }

    public static void DetectPC(bool detected)
    {
        pcDetected = detected;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null)
        {
          //  UnityEngine.Debug.Log("ENEMIES" + enemies);
            foreach (GameObject g in enemies)
            {
                if (g != null)
                {
                  //  UnityEngine.Debug.Log("enemy " + g);
                    //g.transform.Find("Ohjain").gameObject; //.GetComponent<ShootThePlayer3D>().EnableShooting(true);
                    //GameObject gb = g.transform.Find("OhjainEnemy").gameObject;
                    
                    Transform[] children = g.GetComponentsInChildren<Transform>();
                    foreach (Transform child in children)
                    {
                        if (child.CompareTag("Weapon"))
                        {
                            //koodi
                          //  UnityEngine.Debug.Log("ASE LÖYTYI " + child);
                            child.GetComponent<ShootThePlayer3D>().EnableShooting(true);
                        }
                    }

                }
            }

            foreach (GameObject g in enemies)
            {
                if (g != null)
                {
                    // UnityEngine.Debug.Log("enemy attack" + g);
                    g.GetComponent<FollowTarget3D>().attackEnabled = true;
                }
            }
        }

    }

    //Update is called every frame.
    void Update()
    {
        // nothing to do
        if (player != null)
        {
            playerPosition = player.transform.position;
        }

        //UnityEngine.Debug.Log("Pelaajan " + playerName + " pisteet " + score);

        //detectPCTime;
        //startSpawningEnemiesTime;
        //stopSpawningEnemiesTime;

        if (Time.timeSinceLevelLoad > detectPCTime)
        {
           // UnityEngine.Debug.Log("Time Since Loaded : " + Time.timeSinceLevelLoad);
            //Time.timeScale = 0;
            DetectPC(true);
        }
        if (Time.timeSinceLevelLoad > startSpawningEnemiesTime)
        {
           // UnityEngine.Debug.Log("Time Since Loaded : " + Time.timeSinceLevelLoad);
            objectCreatorArea3D.StartSpawning();
        }
        if (Time.timeSinceLevelLoad > stopSpawningEnemiesTime)
        {
           // UnityEngine.Debug.Log("Time Since Loaded : " + Time.timeSinceLevelLoad);
            objectCreatorArea3D.StopSpawning();
        }

    }

}


