using System.Runtime.InteropServices.ComTypes;

namespace Fire_Emblem;

public class DeadlyBlade : Bonus
{
    public DeadlyBlade()
    {
        this.Name = "Deadly Blade";
        this.Description = "Si la unidad inicia el combate con una espada, otorga Atk/Spd+8 durante el combate";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var firstCondition = new UnitStartsCombatCondition();
        var secondCondition = new UnitHasWeaponTypeCondition("Sword");
        var combinedAndCondition = new AndPairCondition(firstCondition, secondCondition);
        var effect = new IncreaseStats([StatType.Atk, StatType.Spd], [8, 8]);
        return new ConditionEffectPair[] { new ConditionEffectPair(combinedAndCondition, effect) };
    }
}