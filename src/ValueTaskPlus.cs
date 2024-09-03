namespace CSharpPlus;

/// <summary>
/// ValueTask  Extensions
/// </summary>
public static class ValueTaskPlus
{
    public static async ValueTask<(T1, T2)> WhenEach<T1, T2>(ValueTask<T1> item1, ValueTask<T2> item2) =>
        (await item1, await item2);

    public static async ValueTask<(T1, T2, T3)> WhenEach<T1, T2, T3>(
        ValueTask<T1> item1, ValueTask<T2> item2, ValueTask<T3> item3) =>
        (await item1, await item2, await item3);

    public static async ValueTask<(T1, T2, T3, T4)> WhenEach<T1, T2, T3, T4>(
        ValueTask<T1> item1, ValueTask<T2> item2, ValueTask<T3> item3, ValueTask<T4> item4) =>
        (await item1, await item2, await item3, await item4);

    public static async ValueTask<(T1, T2, T3, T4, T5)>
        WhenEach<T1, T2, T3, T4, T5>(
            ValueTask<T1> item1, ValueTask<T2> item2, ValueTask<T3> item3, ValueTask<T4> item4, ValueTask<T5> item5) =>
        (await item1, await item2, await item3, await item4, await item5);

    public static async ValueTask<(T1, T2, T3, T4, T5, T6)>
        WhenEach<T1, T2, T3, T4, T5, T6>(
            ValueTask<T1> item1, ValueTask<T2> item2, ValueTask<T3> item3, ValueTask<T4> item4, ValueTask<T5> item5,
            ValueTask<T6> item6
        ) =>
        (await item1, await item2, await item3, await item4, await item5,
            await item6);

    public static async ValueTask<(T1, T2, T3, T4, T5, T6, T7)>
        WhenEach<T1, T2, T3, T4, T5, T6, T7>(
            ValueTask<T1> item1, ValueTask<T2> item2, ValueTask<T3> item3, ValueTask<T4> item4, ValueTask<T5> item5,
            ValueTask<T6> item6, ValueTask<T7> item7
        ) =>
        (await item1, await item2, await item3, await item4, await item5,
            await item6, await item7);

    public static async ValueTask<(T1, T2, T3, T4, T5, T6, T7, T8)>
        WhenEach<T1, T2, T3, T4, T5, T6, T7, T8>(
            ValueTask<T1> item1, ValueTask<T2> item2, ValueTask<T3> item3, ValueTask<T4> item4, ValueTask<T5> item5,
            ValueTask<T6> item6, ValueTask<T7> item7,
            ValueTask<T8> item8
        ) =>
        (await item1, await item2, await item3, await item4, await item5,
            await item6, await item7, await item8);

    public static async ValueTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>
        WhenEach<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            ValueTask<T1> item1, ValueTask<T2> item2, ValueTask<T3> item3, ValueTask<T4> item4, ValueTask<T5> item5,
            ValueTask<T6> item6, ValueTask<T7> item7,
            ValueTask<T8> item8, ValueTask<T9> item9
        ) =>
        (await item1, await item2, await item3, await item4, await item5,
            await item6, await item7, await item8, await item9);

    public static async ValueTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>
        WhenEach<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            ValueTask<T1> item1, ValueTask<T2> item2, ValueTask<T3> item3, ValueTask<T4> item4, ValueTask<T5> item5,
            ValueTask<T6> item6, ValueTask<T7> item7,
            ValueTask<T8> item8, ValueTask<T9> item9, ValueTask<T10> item10
        ) =>
        (await item1, await item2, await item3, await item4, await item5,
            await item6, await item7, await item8, await item9, await item10);

    public static ValueTask<(T1, T2)> WhenEach<T1, T2>(in (ValueTask<T1>, ValueTask<T2>) values) =>
        WhenEach(values.Item1, values.Item2);

    public static ValueTask<(T1, T2, T3)> WhenEach<T1, T2, T3>(
        in (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>) values) =>
        WhenEach(values.Item1, values.Item2, values.Item3);

    public static ValueTask<(T1, T2, T3, T4)> WhenEach<T1, T2, T3, T4>(
        in (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>) values) =>
        WhenEach(values.Item1, values.Item2, values.Item3, values.Item4);

    public static ValueTask<(T1, T2, T3, T4, T5)>
        WhenEach<T1, T2, T3, T4, T5>(
            in (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>) values) =>
        WhenEach(values.Item1, values.Item2, values.Item3, values.Item4, values.Item5);

    public static ValueTask<(T1, T2, T3, T4, T5, T6)>
        WhenEach<T1, T2, T3, T4, T5, T6>(
            in (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>) values) =>
        WhenEach(values.Item1, values.Item2, values.Item3, values.Item4, values.Item5,
            values.Item6);

    public static ValueTask<(T1, T2, T3, T4, T5, T6, T7)>
        WhenEach<T1, T2, T3, T4, T5, T6, T7>(
            in (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>)
                values) =>
        WhenEach(values.Item1, values.Item2, values.Item3, values.Item4, values.Item5,
            values.Item6, values.Item7);

    public static ValueTask<(T1, T2, T3, T4, T5, T6, T7, T8)>
        WhenEach<T1, T2, T3, T4, T5, T6, T7, T8>(
            in (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
                ValueTask<T8>) values) =>
        WhenEach(values.Item1, values.Item2, values.Item3, values.Item4, values.Item5,
            values.Item6, values.Item7, values.Item8);

    public static ValueTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>
        WhenEach<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            in (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
                ValueTask<T8>, ValueTask<T9>) values) =>
        WhenEach(values.Item1, values.Item2, values.Item3, values.Item4, values.Item5,
            values.Item6, values.Item7, values.Item8, values.Item9);

    public static ValueTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>
        WhenEach<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            in (ValueTask<T1>, ValueTask<T2>, ValueTask<T3>, ValueTask<T4>, ValueTask<T5>, ValueTask<T6>, ValueTask<T7>,
                ValueTask<T8>, ValueTask<T9>, ValueTask<T10>) values) =>
        WhenEach(values.Item1, values.Item2, values.Item3, values.Item4, values.Item5,
            values.Item6, values.Item7, values.Item8, values.Item9, values.Item10);
}
