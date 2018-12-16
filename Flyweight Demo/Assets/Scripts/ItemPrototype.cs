using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemPrototype")]
public class ItemPrototype : ScriptableObject {

    public string _itemName;
    public int _value;
    public float _weight;
    public StatBlock _stats;

}

[System.Serializable]
public struct StatBlock
{
    public int strength;
    public int dexterity;
    [SerializeField]
    private int intelligence;
}
