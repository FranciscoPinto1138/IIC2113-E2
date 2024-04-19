namespace Fire_Emblem;

public class NeutralizePenaltyOnStats : Effect
{
    private List< StatType> _statsToNeutralize;
    
    public NeutralizePenaltyOnStats(List< StatType> statsToNeutralize)
    {
        _statsToNeutralize = statsToNeutralize;
    }

    public void ApplyEffect(Unit unit, Unit opponent)
    {
        foreach (var stat in _statsToNeutralize)
        {
            switch (stat)
            {
                case StatType.Atk:
                    unit.PenaltyNeutralizationManager.Atk = 0;
                    break;
                case StatType.Spd:
                    unit.PenaltyNeutralizationManager.Spd = 0;
                    break;
                case StatType.Def:
                    unit.PenaltyNeutralizationManager.Def = 0;
                    break;
                case StatType.Res:
                    unit.PenaltyNeutralizationManager.Res = 0;
                    break;
                case StatType.HP:
                    unit.PenaltyNeutralizationManager.HP = 0;
                    break;
            }
        }
    }
}