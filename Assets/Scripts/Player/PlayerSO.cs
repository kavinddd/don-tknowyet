using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    public int hp;
    public int moveSpeed;
    public float attackSpeedModifier = 1f;
    public float movementSpeedModifer = 1f;

}
