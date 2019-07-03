
public static class UnitCaculateValue  {

    /// <summary>计算攻击数值 AI可能调</summary>
    public static float CaculateAtkValue(UnitBase unit, UnitBase targetUnit)
    {
        //有个公式是护甲*0.06/(1+0.06*护甲)。假设有10点护甲，10*0.06/(1+0.06*10)=6/16=0.375.....
        //这是指抵挡37.5%的伤害，假设某种甲对某种攻击的伤害是75%，该单位护甲10，
        //那该单位所受实际伤害就是 =该攻击原始伤害*（1-37.5%）*75%也就是原始伤害的0.46875倍。
        //  float defValue = (targetUnit.baseDef + otherDef + targetUnit.inNode.terrainDef) * 0.06f / (1 + 0.06f * (targetUnit.baseDef + otherDef + targetUnit.inNode.terrainDef));//基础减伤   
        float hpbi = (unit.HPRatio / 12.5f)+0.2f;//让兵种至少保有0.2的攻击力
        float atkValue = (unit.baseAtk + unit.exAtk) * hpbi;//这里！！ 真正计算攻击生命是显示的数

        //---------------------计算抗性--------------------
        float changeValue = FinalResist(unit, targetUnit);
        //------------------------------------------------
        // float finalValue = atkValue * (1 - defValue) * changeValue; //计算基础防御和地形防御   
        changeValue -= targetUnit.allResist;
        if (changeValue<0)
        {
            changeValue = 0;
        }
        
        //---------------------计算铁炮-----------------
        if ((unit.unitLabel & UnitLabel.铁炮) != 0)
        {

            //如果是铁炮在攻击  远程威力下降3分之一
            float distance = GameController.instance.mapManager.CalculateG(unit.inNode, targetUnit.inNode);
            if (distance > 1)
            {
                atkValue *= 0.66f;
            }
        }
        //--------------------
        float finalValue = atkValue * changeValue;

        return MathCaculateHelper.SplitAndRound(finalValue, 2);
    }
    /// <summary>计算攻击数值 比例</summary>
    public static float CaculateAtkValueP(UnitBase unit, UnitBase targetUnit)
    {
        return MathCaculateHelper.SplitAndRound(CaculateAtkValue(unit, targetUnit), 2);
    }


    /// <summary>
    /// 目标的最终抗性计算
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="targetUnit"></param>
    /// <returns></returns>
    public static float FinalResist(UnitBase unit,UnitBase targetUnit)
    {
        float value=1;

        foreach (UnitLabel item in targetUnit.uA.resistList)
        {
            if ((unit.unitLabel&item)!=0)
            {
                value -= 0.2f;
            }
        }

        foreach (UnitLabel item in unit.uA.attackList)
        {
            if ((targetUnit.unitLabel&item)!=0)
            {
                value += 0.2f;
            }

        }

        return value;
    }
}
