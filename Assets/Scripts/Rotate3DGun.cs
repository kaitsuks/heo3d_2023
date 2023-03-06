using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Rotate3DGun : MonoBehaviour
{
    public float speed = 10f;
    public float speedY = 1f;
    private float spin = 0f;
    private float spinY = 0f;

    public float deltaF1 = 0.02f;
    public float deltaF2 = 0.1f;

    public float limit = 0.3f;
    public float limitY = 0.3f;

    public GameObject jalusta;

    float tiltAroundX;
    float tiltAroundY;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    float origXangle;
    float origYangle;
    float origZangle;

    float YForce = 100f;

    Dropdown dropdown;
    Dropdown dropdownBomb;

    //public int numberGuns; //TARPEETON
    public GameObject[] guns;
    public GameObject[] bombs;
    public GameObject[] bombPrefabs;
    //public GameObject[] ohjaimet;

    GameObject selectedGun;
    int selectedOhjain;
    GameObject selectedBomb;
    GameObject selectedBombPrefab;

    public float bombShootSpeed = 5f;
    public Vector3 bombShootDirection = new Vector3(1f, 1f, 1f);
    // The key to press to create the objects/projectiles
    public KeyCode bombKeyToPress = KeyCode.Q;

    // Start is called before the first frame update
    void Start()
    {
        //guns = new GameObject[numberGuns]; //EI NÄIN!
        origXangle = this.transform.rotation.x;
        origYangle = this.transform.rotation.y;
        origZangle = this.transform.rotation.z;

      //dropdown =  GameObject.Find("GunSelector").GetComponent<Dropdown>();
       // selectedGun = guns[0]; //asetetaan oletusase

        dropdownBomb = GameObject.Find("BombSelector").GetComponent<Dropdown>();
        //selectedBomb = bombs[0]; //asetetaan oletuspommi
        //selectedBombPrefab = bombPrefabs[0]; //asetetaan oletuspommiprefab

        bombs[1].SetActive(false);
        bombs[2].SetActive(false);
        bombs[3].SetActive(false);
    }

    void Awake()
    {
        dropdown = GameObject.Find("GunSelector").GetComponent<Dropdown>();
       // selectedGun = guns[0]; //asetetaan oletusase
       // selectedBomb = bombs[0]; //asetetaan oletuspommi
        //selectedBombPrefab = bombPrefabs[0]; //asetetaan oletuspommiprefab
        //SelectGun();
    }

    public void SelectGun()
    {
        UnityEngine.Debug.Log("Value on " + dropdown.value);
        selectedGun = guns[dropdown.value];
        selectedOhjain = dropdown.value;
        GameManager.ohjainNumero = selectedOhjain;
        UnityEngine.Debug.Log("Valittu ase on " + selectedGun.ToString());
        UnityEngine.Debug.Log("Valittu ohjain on " + selectedOhjain.ToString());
    }

    public void SelectBomb()
    {
        UnityEngine.Debug.Log("Bomb Value on " + dropdownBomb.value);
        selectedBomb = bombs[dropdownBomb.value];
        selectedBombPrefab = bombPrefabs[dropdownBomb.value];
        UnityEngine.Debug.Log("Valittu pommi on " + selectedBomb.ToString());
        bombs[0].SetActive(false);
        bombs[1].SetActive(false);
        bombs[2].SetActive(false);
        bombs[3].SetActive(false);
        selectedBomb.SetActive(true);
    }

    public void ThrowBomb()
    {
        GameObject newObject = Instantiate<GameObject>(selectedBombPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedGun == null) return;
        
        if (Input.GetKeyDown("v"))
        {
            if (spin < 0f) spin = 0f; //lopetetaan kierto
            //UnityEngine.Debug.Log("Käännetään piippua alas" + spin);
            if(spin < limit/2) spin += deltaF1;
            else
            spin += deltaF2;
            if (spin > limit) spin = limit;
            tiltAroundX = jalusta.transform.rotation.x + spin * speed; // spin * speed;
            selectedGun.transform.Rotate(transform.right, tiltAroundX, Space.World); //TÄMÄ TOIMI!
        }
       

        if (Input.GetKeyDown("t"))
        {
            if (spin > 0f) spin = 0f; //lopetetaan kierto
            //UnityEngine.Debug.Log("Käännetään piippua ylös" + spin);
            if (spin > -limit/2) spin -= deltaF1;
            else
                spin -= deltaF2;
            if (spin < -limit) spin = -limit;
            tiltAroundX = jalusta.transform.rotation.x + spin * speed; // spin * speed;
            selectedGun.transform.Rotate(transform.right, tiltAroundX, Space.World); //TÄMÄ TOIMI!
        }

        if (Input.GetKeyDown("p"))
        {
            spin = 0f;
            //float origYangle = this.transform.rotation.y;
            //float origZangle = this.transform.rotation.z;
            selectedGun.transform.rotation = new Quaternion(origXangle, origYangle, origZangle, 1);
        }
        //left
        if (Input.GetKey("g"))
        {
            if (spinY < 0f) spinY = 0f; //lopetetaan kierto
            //UnityEngine.Debug.Log("Käännetään piippua oikealle" + spinY);
            if (spinY < limitY / 2) spinY += deltaF1;
            else
                spinY += deltaF2;
            if (spinY > limitY) spinY = limitY;
            tiltAroundY = jalusta.transform.rotation.y * spinY * speedY; // spin * speed;
            selectedGun.transform.Rotate(transform.up, tiltAroundY, Space.World); //TÄMÄ TOIMI!
        }

        //right
        if (Input.GetKey("f"))
        {
            if (spinY > 0f) spinY = 0f; //lopetetaan kierto
            //UnityEngine.Debug.Log("Käännetään piippua vasemmalle" + spinY);
            if (spinY > -limitY / 2) spinY -= deltaF1;
            else
                spinY -= deltaF2;
            if (spinY < -limit) spinY = -limitY;
            tiltAroundY = jalusta.transform.rotation.y * spinY * speedY; // spin * speed;
            selectedGun.transform.Rotate(transform.up, tiltAroundY, Space.World); //TÄMÄ TOIMI!
        }
        //straight
        if (Input.GetKeyDown("p"))
        {
            spinY = 0f;
            //float origYangle = this.transform.rotation.y;
            //float origZangle = this.transform.rotation.z;
            selectedGun.transform.rotation = new Quaternion(origXangle, origYangle, origZangle, 1);
        }


    }

    void FixedUpdate()
    {
        // Smoothly tilts a transform towards a target rotation.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // this.transform.rotation  = Quaternion.FromToRotation(Vector3.up, transform.forward);
        //this.transform.rotation = new Quaternion(jalusta.transform.rotation.x, jalusta.transform.rotation.y, jalusta.transform.rotation.z, 1);

        //tiltAroundX = jalusta.transform.rotation.x + spin * speed; // spin * speed;
        ////objectForYaw.Rotate(objectForYaw.up, 1f, Space.World);
        //this.transform.Rotate(transform.right, tiltAroundX, Space.World);

        //float tiltAroundY = jalusta.transform.rotation.y;  // -spin * 1000; // spin * speed;
        //float tiltAroundZ = 180f + jalusta.transform.rotation.z; // -jalusta.transform.rotation.y/18000f; //;  spin * speed;

        //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        //Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundY, tiltAroundZ);
     //   Quaternion target = Quaternion.Euler(tiltAroundX, 0f, 0f);
     //   this.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        // Rotate around Y axis
        //transform.RotateAround(transform.up, Time.deltaTime * -YForce * 100000f);

        //this.transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smooth);

        // UnityEngine.Debug.Log("Jalustan Y = " + jalusta.transform.rotation.y);

        //GetComponent<Rigidbody>().AddTorque(transform.up * -spin * speed);
    }
}
