using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    [SerializeField] private int price = 0;

    public int getPrice()
    {
        return price;
    }
}
