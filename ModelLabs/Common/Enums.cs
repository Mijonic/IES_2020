using System;

namespace FTN.Common
{	
	public enum PhaseCode : short
	{
		Unknown = 0x0,
		N = 0x1,
		C = 0x2,
		CN = 0x3,
		B = 0x4,
		BN = 0x5,
		BC = 0x6,
		BCN = 0x7,
		A = 0x8,
		AN = 0x9,
		AC = 0xA,
		ACN = 0xB,
		AB = 0xC,
		ABN = 0xD,
		ABC = 0xE,
		ABCN = 0xF
	}

    public enum CurveStyle : short
    {
        ConstantYValue = 1,
        Formula = 2,
        RampYValue = 3,
        StraightLineYValues = 4
    }

    public enum RegulatingControlModeKind : short
    {
        Voltage = 1,
        ActivePower = 2,
        ReactivePower = 3,
        CurrentFlow = 4,
        Fixed = 5,
        Admittance = 6,
        TimeScheduled = 7,
        Temperature = 8,
        PowerFactor = 9
    }

    public enum UnitMultiplier : short
    {
        G = 1,
        M = 2,
        T = 3,
        c = 4,
        d = 5,
        k = 6,
        m = 7,
        micro = 8,
        n = 9,
        none = 10,
        p = 11
      
    }

    public enum UnitSymbol : short
    {
        A = 1,
        F = 2,
        H = 3,
        Hz = 4,
        J = 5,
        N = 6,
        Pa = 7,
        S = 8,
        V = 9,
        VA = 10,
        VAh = 11,
        VAr = 12,
        VArh = 13,
        W = 14,
        Wh = 15,
        deg = 16,
        degC = 17,
        g = 18,
        h = 19,
        m = 20,
        m2 = 21,
        m3 = 22,
        min = 23,
        none = 24,
        ohm = 25,
        rad = 26,
        s = 27
    }




}
