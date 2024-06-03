using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Clane : MonoBehaviour
{

    [SerializeField] private GameObject[] fruits;

    [SerializeField] private float coolTime;

    private ICatchable catchedObj;

    private int fruitIdx;

    private bool isRelease;

    void CatchObj()
    {
        /// <summary>
        /// オブジェクトを出現、掴む
        /// </summary>
        fruitIdx = UnityEngine.Random.Range(0, fruits.Length);

        Vector2 pos = transform.position;
        Quaternion rot = Quaternion.identity;
        var obj = Instantiate(fruits[fruitIdx], pos, rot);

        catchedObj = obj.GetComponent<ICatchable>();
        catchedObj.Catched();
        
    }

    void ReleseObj()
    {
        /// <summary>
        /// オブジェクトを離す
        /// </summary>
        catchedObj.Released();
        catchedObj = null;
        isRelease = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        CatchObj();
        isRelease = false;
    }

    // Update is called once per frame
    async void Update()
    {
        if(isRelease)
        {
            isRelease = false;
            await UniTask.Delay(TimeSpan.FromSeconds(coolTime));
            CatchObj();
        }

        if (catchedObj == null) return;

        catchedObj.setPos(transform.position);
        if (Input.GetMouseButtonDown(0)) ReleseObj();
    }
}
