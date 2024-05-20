namespace Fire_Emblem;

public class NeutralizePenaltyOnStats : Effect
{
    private StatTypeList _statsToNeutralize;
    
    public NeutralizePenaltyOnStats(StatTypeList statsToNeutralize)
    {
        _statsToNeutralize = statsToNeutralize;
        this.SetPriority(1);
    }

    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        const int NEUTRALIZED_STAT_VALUE = 0; 
        foreach (var stat in _statsToNeutralize)
        {
            switch (stat)
            {
                case StatType.Atk:
                    unit.PenaltyNeutralizationManager.Atk = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Spd:
                    unit.PenaltyNeutralizationManager.Spd = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Def:
                    unit.PenaltyNeutralizationManager.Def = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Res:
                    unit.PenaltyNeutralizationManager.Res = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.HP:
                    unit.PenaltyNeutralizationManager.HP = NEUTRALIZED_STAT_VALUE;
                    break;
            }
        }
    }
}