using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public interface IUnitStats
    {
        int Strength { get; set; }
        int Dexterity { get; set; }
        int Endurance { get; set; }
    }

}
