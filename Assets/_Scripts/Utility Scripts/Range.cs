using UnityEngine;

[System.Serializable]
public struct FloatRange
{
    //
    // FloatRange
    // structs & classes

    // • • • • • • • • • • • • • • • • • • • • //

    //
    // V a r i a b l e s
    //

    [SerializeField]
    private float min;
    [SerializeField]
    private float max;

	// • • • • • • • • • • • • • • • • • • • • //

	//
	// P r o p e r t i e s
	//

    public float Min
    {
        get { return min; }
        set { min = value; }
    }

    public float Max
    {
        get { return min; }
        set { max = value; }
    }

    // • • • • • • • • • • • • • • • • • • • • //

    //
    // C & D
    //

    public FloatRange(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    // • • • • • • • • • • • • • • • • • • • • //

    //
    // U s e r
    //
    
    public void Set(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public float Get()
    {
        return Random.Range(min, max);
    }
}

[System.Serializable]
public struct IntRange
{
    //
    // IntRange
    // structs & classes

    // • • • • • • • • • • • • • • • • • • • • //

    //
    // V a r i a b l e s
    //

    [SerializeField]
    private int min;
    [SerializeField]
    private int max;

    // • • • • • • • • • • • • • • • • • • • • //

    //
    // P r o p e r t i e s
    //

    public int Min
    {
        get { return min; }
        set { min = value; }
    }

    public int Max
    {
        get { return min; }
        set { max = value; }
    }

    // • • • • • • • • • • • • • • • • • • • • //

    //
    // C & D
    //

    public IntRange(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    // • • • • • • • • • • • • • • • • • • • • //

    //
    // U s e r
    //

    public void Set(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public float Get()
    {
        return Random.Range(min, max);
    }

    public int GetInt()
    {
        return Random.Range(min, max);
    }

}
