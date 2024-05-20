namespace Fire_Emblem;

public class Guard : Skill
{
    private string _weaponOfOpponent;
    public Guard(string weaponOfOpponent)
    {
        this.Name = "Guard";
        this.Description = "Si el rival usa cierta arma, la unidad recibe -5 daño en cada ataque del rival";
        this._weaponOfOpponent = weaponOfOpponent;
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new OpponentHasWeaponTypeCondition(_weaponOfOpponent), 
            new ReduceReceivedDamageByAbsoluteValue(5)) 
        };
    }
}