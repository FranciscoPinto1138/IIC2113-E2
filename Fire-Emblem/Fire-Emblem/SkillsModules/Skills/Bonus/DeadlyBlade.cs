using System.Runtime.InteropServices.ComTypes;

namespace Fire_Emblem;

public class DeadlyBlade : Skill
{
    public DeadlyBlade()
    {
        this.Name = "Deadly Blade";
        this.Description = "Si la unidad inicia el combate con una espada, otorga Atk/Spd+8 durante el combate";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new AndPairCondition(new UnitStartsCombatCondition(), new UnitHasWeaponTypeCondition("Sword")), 
            new IncreaseStats([StatType.Atk, StatType.Spd], [8, 8])) 
        };
    }
}