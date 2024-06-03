using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour, IMixable, ICatchable
{
    [SerializeField] private string type;

    [SerializeField] private int score;

    [SerializeField] private GameObject nextFruit;

    private bool isDestroyed;

    private bool isCatched;

    public string GetFruitType()
    {
        return type;
    }

    public bool GetIsMixable()
    {
        return !isDestroyed && !isCatched;
    }

    public void Delete()
    {
        Destroy(gameObject);
        isDestroyed = true;
    }

    public void Catched()
    {
        isCatched = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
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

    bool able2Mix(IMixable obj){
       /// <summary>
       /// mix可能か判定
       /// </summary>

        if (obj == null) return false;

        return obj.GetFruitType() == type && !isDestroyed && !isCatched && obj.GetIsMixable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IMixable obj = collision.gameObject.GetComponent<IMixable>();

        if (able2Mix(obj)) FruitMix(obj);
    }

    private void FruitMix(IMixable obj)
    {
        /// <summary>
        /// タイプが同じだったらフルーツを合体(削除
        /// </summary>
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
