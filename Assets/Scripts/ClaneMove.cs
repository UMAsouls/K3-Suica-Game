using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaneMove : MonoBehaviour
{
    [SerializeField] private float leftMax;
    [SerializeField] private float rightMax;

    private Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;
    }

    Vector2 getMousePosInWorld()
    {
        return gameCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x = getMousePosInWorld().x;

        if (pos.x <= leftMax) pos.x = leftMax;
        if (pos.x >= rightMax) pos.x = rightMax;

        gameObject.transform.position = pos;
    }
}
