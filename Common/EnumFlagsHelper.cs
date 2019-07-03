
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
public class EnumFlagsHelper:PropertyDrawer {

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        /*
         * 绘制多值枚举选择框,0 全部不选, -1 全部选中, 其他是枚举之和
         * 枚举值 = 当前下标值 ^ 2
         * 默认[0^2 = 1 , 1 ^2 = 2,  4, 16 , .....]
         */
        property.intValue = EditorGUI.MaskField(position, label, property.intValue
                                                , property.enumNames);

    }


    ////判断是否选择了该枚举值  放在有该枚举的类里
    //public bool IsSelectEventType(UnitLabel _eventType)
    //{
    //    // 将枚举值转换为int 类型, 1 左移 
    //    int index = 1 << (int)_eventType;
    //    // 获取所有选中的枚举值
    //    int eventTypeResult = (int)unitLabel;
    //    // 按位 与
    //    if ((eventTypeResult & index) == index)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}
