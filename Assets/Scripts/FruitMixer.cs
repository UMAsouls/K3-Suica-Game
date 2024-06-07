using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMixer : MonoBehaviour, IMixable
{
    [SerializeField] private string type;

    [SerializeField] private int score;

    [SerializeField] private GameObject nextFruit;

    private ICatchable catchable;

    private bool isDestroyed;

    public void Delete()
    {
        Destroy(gameObject);
        isDestroyed = true;
    }

    public string GetFruitType()
    {
        return type;
    }

    public bool GetIsMixable()
    {
        return !isDestroyed && !catchable.GetIsCatched();
    }

    bool able2Mix(IMixable obj)
    {
        /// <summary>
        /// mix可能か判定
        /// </summary>

        if (obj == null) return false;

        return obj.GetFruitType() == type && GetIsMixable() && obj.GetIsMixable();
    }

    private void FruitMix(IMixable obj)
    {
        /// <summary>
        /// タイプが同じだったらフルーツを合体(削除
        /// </summary>
        obj.Delete();
        Delete();
        if (nextFruit != null) Instantiate(nextFruit, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IMixable obj = collision.gameObject.GetComponent<IMixable>();

        if (able2Mix(obj)) FruitMix(obj);
    }

    // Start is called before the first frame update
    void Start()
    {
        catchable = GetComponent<ICatchable>();
        isDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
