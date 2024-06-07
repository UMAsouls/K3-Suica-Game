using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICatchable
{
    void Catched();

    bool GetIsCatched();

    void setPos(Vector2 pos);

    void Released();
}
