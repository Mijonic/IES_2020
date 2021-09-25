using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

        TAPCHANGER_CONTROL                  = 0x0001,
        REACTIVE_CAPABILITY_CURVE           = 0x0002,
        CURVE_DATA                          = 0x0003,
        SYNCHRONOUS_MACHINE                 = 0x0004,
        CONTROL                             = 0x0005,
        TERMINAL                            = 0x0006,
    }

    [Flags]
	public enum ModelCode : long
	{
		IDOBJ								= 0x1000000000000000,
		IDOBJ_GID							= 0x1000000000000104,
		//IDOBJ_DESCRIPTION					= 0x1000000000000207,
		//IDOBJ_MRID							= 0x1000000000000307,
		//IDOBJ_NAME							= 0x1000000000000407,	

		PSR									= 0x1100000000000000,

        EQUIPMENT                           = 0x1110000000000000,
        EQUIPMENT_AGGREGATE                 = 0x1110000000000101,
        EQUIPMENT_NORMALLYINSERVICE         = 0x1110000000000201,

        CONDEQ                              = 0x1111000000000000,
        CONDEQ_TERMINALS                    = 0x1111000000000119,

        REGULATINGCONDEQ                    = 0x1111100000000000,
        REGULATINGCONDEQ_CONTROLS           = 0x1111100000000119,
        REGULATINGCONDEQ_REGULATINGCONTROL  = 0x1111100000000209,

        ROTATINGMACHINE                     = 0x1111110000000000,

        SYNCHRONOUSMACHINE                  = 0x1111111000040000,
        SYNCHRONOUSMACHINE_REACTCAPABILCURV = 0x1111111000040109,


        REGULATINGCONTROL                   = 0x1120000000000000,
        REGULATINGCONTROL_DISCRETE          = 0x1120000000000101,
        REGULATINGCONTROL_MODE              = 0x112000000000020a,
        REGULATINGCONTROL_PHASE             = 0x112000000000030a,
        REGULATINGCONTROL_TARGETRANGE       = 0x1120000000000405,
        REGULATINGCONTROL_TARGETVALUE       = 0x1120000000000505,
        REGULATINGCONTROL_REGULATINGCONDEQS = 0x1120000000000619,

        TAPCHANGERCONTROL                   = 0x1121000000010000,
        TAPCHANGERCONTROL_LIMITVOLTAGE      = 0x1121000000010105,
        TAPCHANGERCONTROL_LINEDROPCOMPENSAT = 0x1121000000010201,
        TAPCHANGERCONTROL_LINEDROPR         = 0x1121000000010305,
        TAPCHANGERCONTROL_LINEDROPX         = 0x1121000000010405,
        TAPCHANGERCONTROL_REVERSELINEDROPR  = 0x1121000000010505,
        TAPCHANGERCONTROL_REVERSELINEDROPX  = 0x1121000000010605,

        CONTROL                             = 0x1200000000050000,
        CONTROL_REGCONDEQ                   = 0x1200000000050109,

        TERMINAL                            = 0x1300000000060000,
        TERMINAL_CONDEQ                     = 0x1300000000060109,

        CURVE                               = 0x1400000000000000,
        CURVE_CURVESTYLE                    = 0x140000000000010a,
        CURVE_XMULTIPLIER                   = 0x140000000000020a,
        CURVE_XUNIT                         = 0x140000000000030a,
        CURVE_Y1MULTIPLIER                  = 0x140000000000040a,    
        CURVE_Y1UNIT                        = 0x140000000000050a,
        CURVE_Y2MULTIPLIER                  = 0x140000000000060a,
        CURVE_Y2UNIT                        = 0x140000000000070a,
        CURVE_Y3MULTIPLIER                  = 0x140000000000080a,
        CURVE_Y3UNIT                        = 0x140000000000090a,
        CURVE_CURVEDATA                     = 0x1400000000001019,

        REACTIVECAPABILITYCURVE             = 0x1410000000020000,
        REACTIVECAPABILITYCURVE_SYNCMAHINES = 0x1410000000020119,
      

        CURVEDATA                           = 0x1500000000030000,
        CURVEDATA_XVALUE                    = 0x1500000000030105,
        CURVEDATA_Y1VALUE                   = 0x1500000000030205,
        CURVEDATA_Y2VALUE                   = 0x1500000000030305,
        CURVEDATA_Y3VALUE                   = 0x1500000000030405,
        CURVEDATA_CURVE                     = 0x1500000000030509,







	}

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


