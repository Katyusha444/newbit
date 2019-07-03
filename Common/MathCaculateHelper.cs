
using UnityEngine;

public static class MathCaculateHelper {

    /// <summary>四舍五入并保留几位小数</summary>
    public static float SplitAndRound(float a, int n)
    {
        a = a * Mathf.Pow(10, n);
        return (Mathf.Round(a)) / (Mathf.Pow(10, n));
    }
    /// <summary>四舍五入转化为整数 可能直接用roundtoint也成</summary>
    public static int SplitAndRoundToInt(float a)
    {
        a = a * Mathf.Pow(10, 0);
        float f = (Mathf.Round(a)) / (Mathf.Pow(10, 0));

        return (int)f ;
    }
    //参数value为要处理的浮点数，参数digit为要保留的小数点位数
    //public static double RoundFourFive(double value, int digit)
    //{
    //    double vt = Math.Pow(10, digit);
    //    //1.乘以倍数 + 0.5
    //    double vx = value * vt + 0.5;
    //    //2.向下取整
    //    double temp = Math.Floor(vx);
    //    //3.再除以倍数
    //    return (temp / vt);
    //}

    //    print("ceil9.5=" + Mathf.Ceil(9.5f));//10
    //print("ceilToInt9=" + Mathf.CeilToInt(9f));//9

    //print("roundtoint9.5=" + Mathf.RoundToInt(9.5f));//10
    //print("roundtoint10.5=" + Mathf.RoundToInt(10.5f));//10
    //print("(int)9.5=" + (int)9.5f);  //9
}
