using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour, IMixable
{
    [SerializeField] private string type;

    [SerializeField] private int score;

    [SerializeField] private GameObject nextFruit;

    private bool isDestroyed;

    public string GetFruitType()
    {
        return type;
    }

    public void Delete()
    {
        Destroy(gameObject);
        isDestroyed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IMixable obj = collision.gameObject.GetComponent<IMixable>();
        if (obj != null) FruitMix(obj);
    }

    private void FruitMix(IMixable obj)
    {
        /// <summary>
        /// タイプが同じだったらフルーツを合体(削除
        /// </summary>
        if (obj.GetFruitType() != type || isDestroyed) return;
        obj.Delete();
        Destroy(gameObject);
        if (nextFruit != null) Instantiate(nextFruit, transform.position, Quaternion.identity);

    }

    // Start is called before the first frame update
    void Start()
    {
        isDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
