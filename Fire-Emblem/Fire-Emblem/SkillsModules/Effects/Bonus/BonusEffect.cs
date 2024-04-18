namespace Fire_Emblem;

public abstract class BonusEffect : Effect
{
    public abstract void ApplyEffect(Unit unit, Unit opponent);
    public abstract void RemoveEffect(Unit unit, Unit opponent);
}

public class IncreaseAtk : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseAtk(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.Atk += _changeFactor;
    }
    
    public override void RemoveEffect(Unit unit, Unit opponent)
    {
        unit.Atk -= _changeFactor;
    }
}

public class IncreaseDef : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseDef(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.Def += _changeFactor;
    }
    
    public override void RemoveEffect(Unit unit, Unit opponent)
    {
        unit.Def -= _changeFactor;
    }
}

public class IncreaseSpd : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseSpd(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.Spd += _changeFactor;
    }
    
    public override void RemoveEffect(Unit unit, Unit opponent)
    {
        unit.Spd -= _changeFactor;
    }
}

public class IncreaseRes : BonusEffect
{
    private int _changeFactor;
    
    public IncreaseRes(int changeFactor)
    {
        _changeFactor = changeFactor;
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.Res += _changeFactor;
    }
    
    public override void RemoveEffect(Unit unit, Unit opponent)
    {
        unit.Res -= _changeFactor;
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
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        unit.Atk += (int)(unit.Atk * (_changeFactor / 100));
    }
    
    public override void RemoveEffect(Unit unit, Unit opponent)
    {
        unit.Atk -= (int)(unit.Atk * (_changeFactor / 100));
    }
}

// Wrath
public class IncreaseAtkSpdByLostHP : BonusEffect
{
    private int _originalBonus;
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        _originalBonus = Math.Min(unit.HPMax - unit.HPCurrent, 30);
        unit.Atk += -_originalBonus;
        unit.Spd += -_originalBonus;
    }
    
    public override void RemoveEffect(Unit unit, Unit opponent)
    {
        unit.Atk -= _originalBonus;
        unit.Spd -= _originalBonus;
    }
}