using static Enums;
using UnityEngine;

public class GameTag : MonoBehaviour
{
    [SerializeField] private Tag myTag = Tag.Null;

    public Tag MyTag
    {
        get
        {
            return myTag;
        }
    }
}