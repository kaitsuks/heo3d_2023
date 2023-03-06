using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create3DExplosion : MonoBehaviour
{
    public GameObject explosivePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateExplosion", 2);
    }

    void CreateExplosion()
    {
        GameObject newObject = Instantiate<GameObject>(explosivePrefab, transform.position, transform.rotation);
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
