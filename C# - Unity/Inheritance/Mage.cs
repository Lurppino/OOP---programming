using UnityEngine;

public class Mage : Character
{
    public int MagicPower { get; private set; }

    public override void Attack() 
    {
        Debug.Log($"{Name}heitt‰‰ tulipallon"); 
    }
}
