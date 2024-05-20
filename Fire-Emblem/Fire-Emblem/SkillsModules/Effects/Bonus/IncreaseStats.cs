namespace Fire_Emblem;

public class IncreaseStats : BonusEffect
{
    private StatTypeList _bufferedStatsList;
    private ChangeFactorList _changeFactorsList;
    
    public IncreaseStats(StatTypeList bufferedStatsList, ChangeFactorList changeFactorsList)
    {
        _bufferedStatsList = bufferedStatsList;
        _changeFactorsList = changeFactorsList;
        this.SetPriority(1);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        for (int i = 0; i < _bufferedStatsList.Count; i++)
        {
            switch (_bufferedStatsList[i])
            {
                case StatType.Atk:
                    unit.BonusStatsDiff.Atk += _changeFactorsList[i];
                    break;
                case StatType.Spd:
                    unit.BonusStatsDiff.Spd += _changeFactorsList[i];
                    break;
                case StatType.Def:
                    unit.BonusStatsDiff.Def += _changeFactorsList[i];
                    break;
                case StatType.Res:
                    unit.BonusStatsDiff.Res += _changeFactorsList[i];
                    break;
            }
        }
    }
}