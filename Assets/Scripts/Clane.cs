using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Clane : MonoBehaviour
{

    [SerializeField] private GameObject[] fruits;

    [SerializeField] private float coolTime;

    private GameObject catchedObj;

    private int fruitIdx;

    void CatchObj()
    {
        /// <summary>
        /// オブジェクトを出現、掴む
        /// </summary>
        fruitIdx = Random.Range(0, fruits.Length);

        Vector2 pos = transform.position;
        Quaternion rot = Quaternion.identity;
        catchedObj = Instantiate(fruits[fruitIdx], pos, rot);

        var rigid = catchedObj.GetComponent<Rigidbody2D>();
        rigid.isKinematic = true;
        
    }

    void ReleseObj()
    {
        /// <summary>
        /// オブジェクトを離す
        /// </summary>
        Vector2 pos = transform.position;
        Quaternion rot = Quaternion.identity;
        var obj = Instantiate(fruits[fruitIdx], pos, rot);

        catchedObj.SetActive(false);
        Destroy(catchedObj, coolTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        catchedObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(catchedObj == null) CatchObj();
        catchedObj.transform.position = transform.position;

        if(Input.GetMouseButtonDown(0) && catchedObj.activeSelf) ReleseObj();
    }
}
