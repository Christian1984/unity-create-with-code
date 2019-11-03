using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _gravityModifier = 1;
    
    public static GameManager instance;
    public static float gravityModifier { get { return instance._gravityModifier; }}

    void Awake() {
        if (!instance) {
            instance = this;
        }
    }

    void Update() {
        Physics.gravity = Vector3.down * instance._gravityModifier * 10;
    }
}
