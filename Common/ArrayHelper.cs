using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ArrayHelper
{
    /// <summary>
    /// 辅助查找所用的委托哦
    /// </summary>
    public delegate bool FindHandler<T>(T p);
    /// <summary>
    /// 辅助最大最小的委托哦
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="p">数据源</param>
    /// <returns>比较的关键字</returns>
    public delegate TKey SelectHandler<T, TKey>(T p);


    /// <summary>
    /// 查找符合条件的所有元素
    /// </summary>
    /// <param name="array">数据源</param>
    /// <param name="handler">查找条件</param>
    /// <returns>找到的所有元素</returns>
    public static T[] FindAll<T>(T[] array, FindHandler<T> handler)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < array.Length; i++)
        {
            if (handler(array[i]))
                list.Add(array[i]);
        }
        return list.Count > 0 ? list.ToArray() : null;
    }
    /// <summary>
    /// 正序查找符合条件的第一个元素
    /// </summary>
    /// <param name="array">数据源</param>
    /// <param name="handler">条件</param>
    /// <returns>找到的元素</returns>
    public static T Find<T>(T[] array, FindHandler<T> handler)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (handler(array[i]))
            {
                return array[i];
            }
        }
        return default(T);
    }
    /// <summary>
    /// 倒序查找符合条件的第一个元素
    /// </summary>
    /// <param name="array">数据源</param>
    /// <param name="handler">条件</param>
    /// <returns>找到的元素</returns>
    public static T FindLast<T>(T[] array, FindHandler<T> handler)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (handler(array[i]))
            {
                return array[i];
            }
        }
        return default(T);
    }




    /// <summary>
    /// 通过某种方式比出最大的元素
    /// </summary>
    /// <param name="array">数据源</param>
    /// <param name="handler">比较条件</param>
    /// <returns>找到的元素</returns>
    public static T Max<T, TKey>(T[] array, SelectHandler<T, TKey> handler)
        where TKey : IComparable, IComparable<TKey>
    {
        T max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (handler(max).CompareTo(handler(array[i])) < 0)
            {
                max = array[i];
            }
        }
        return max;
    }
    /// <summary>
    /// 通过某种方式比出最小的元素
    /// </summary>
    /// <param name="array">数据源</param>
    /// <param name="handler">比较条件</param>
    /// <returns>找到的元素</returns>
    public static T Min<T, TKey>(T[] array, SelectHandler<T, TKey> handler)
        where TKey : IComparable, IComparable<TKey>
    {
        T min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (handler(min).CompareTo(handler(array[i])) > 0)
                min = array[i];
        }
        return min;
    }




    /// <summary>以某种方式排序 </summary>
    /// <param name="array">数据源</param>
    /// <param name="handler">排序条件</param>
    public static void OrderBy<T, TKey>(T[] array, SelectHandler<T, TKey> handler)
        where TKey : IComparable, IComparable<TKey>
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 1; j < array.Length; j++)
            {
                if (handler(array[i]).CompareTo(handler(array[j])) > 0)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }

    }

    /// <summary>
    /// 以某种方式倒序排序
    /// </summary>
    /// <param name="array">数据源</param>
    /// <param name="handler">排序条件</param>
    public static void OrderByDesceding<T, TKey>(T[] array, SelectHandler<T, TKey> handler)
    where TKey : IComparable, IComparable<TKey>
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 1; j < array.Length; j++)
            {
                if (handler(array[i]).CompareTo(handler(array[j])) < 0)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }

            }
        }
    }






    /// <summary>
    /// 提取数组中每个元素的某个数据，组成新的数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey">提取数据的类型</typeparam>
    /// <param name="array">源数据</param>
    /// <param name="handler">提取的条件</param>
    /// <returns>新数组</returns>
    public static TKey[] Select<T, TKey>(T[] array, SelectHandler<T, TKey> handler)
    {
        TKey[] newArray = new TKey[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = handler(array[i]);
        }
        return newArray;
    }
}
