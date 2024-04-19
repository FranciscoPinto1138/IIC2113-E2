namespace Fire_Emblem;

public abstract class BonusEffect : Effect
{
    public abstract void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats);
}

public class IncreaseAtk : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseAtk(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        unitCombatStats.Atk += _changeFactor;
    }
}

public class IncreaseDef : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseDef(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        unitCombatStats.Def += _changeFactor;
    }
}

public class IncreaseSpd : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseSpd(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        unitCombatStats.Spd += _changeFactor;
    }
}

public class IncreaseRes : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseRes(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        unitCombatStats.Res += _changeFactor;
    }
}

// Pendiente de implementar Ignis y "Atk+50 % al primer ataque de la unidad"

// Ignis
public class IncreaseAtkByPercentage : BonusEffect
{
    private double _changeFactor;
    
    public IncreaseAtkByPercentage(double changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        unitCombatStats.Atk += (int)(unitCombatStats.Atk * (_changeFactor / 100));
    }
}

// Wrath
public class IncreaseAtkSpdByLostHP : BonusEffect
{
    private int _originalBonus;
    public override void ApplyEffect(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        _originalBonus = Math.Min(unitCombatStats.HPMax - unitCombatStats.HPCurrent, 30);
        unitCombatStats.Atk += -_originalBonus;
        unitCombatStats.Spd += -_originalBonus;
    }
}