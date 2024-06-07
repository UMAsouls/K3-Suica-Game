using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clane_old : MonoBehaviour
{
    [SerializeField] private GameObject fruit;

    void ReleaseObj()
    {
        Vector2 pos = transform.position;
        Quaternion rot = Quaternion.identity;
        Instantiate(fruit, pos, rot);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) ReleaseObj();
    }
}
