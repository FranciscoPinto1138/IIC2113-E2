namespace Fire_Emblem;

public abstract class PenaltyEffect : Effect
{
    public abstract void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats);
}

public class DecreaseAtk : PenaltyEffect
{
    private int _changeFactor;
    
    public DecreaseAtk(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        opponentCombatStats.Atk -= _changeFactor;
    }
}

public class DecreaseDef : PenaltyEffect
{
    private int _changeFactor;
    
    public DecreaseDef(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        opponentCombatStats.Def -= _changeFactor;
    }
}

public class DecreaseSpd : PenaltyEffect
{
    private int _changeFactor;
    
    public DecreaseSpd(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        opponentCombatStats.Spd -= _changeFactor;
    }
}

public class IgnoreHalfDefandRes : PenaltyEffect
{
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        opponentCombatStats.Def -= (int)(opponentCombatStats.Def * 0.5);
        opponentCombatStats.Res -= (int)(opponentCombatStats.Res * 0.5);
    }
}