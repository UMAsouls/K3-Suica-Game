using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour, ICatchable
{
    private bool isCatched;

    public void Catched()
    {
        isCatched = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public bool GetIsCatched()
    {
        return isCatched;
    }

    public void Released()
    {
        isCatched = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void setPos(Vector2 pos)
    {
        transform.position = pos;
    }
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
