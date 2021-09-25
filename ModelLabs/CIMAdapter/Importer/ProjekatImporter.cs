using System;
using System.Collections.Generic;
using CIM.Model;
using FTN.Common;
using FTN.ESI.SIMES.CIM.CIMAdapter.Manager;

namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	/// <summary>
	/// PowerTransformerImporter
	/// </summary>
	public class ProjekatImporter
	{
		/// <summary> Singleton </summary>
		private static ProjekatImporter ptImporter = null;
		private static object singletoneLock = new object();

		private ConcreteModel concreteModel;
		private Delta delta;
		private ImportHelper importHelper;
		private TransformAndLoadReport report;


		#region Properties
		public static ProjekatImporter Instance
		{
			get
			{
				if (ptImporter == null)
				{
					lock (singletoneLock)
					{
						if (ptImporter == null)
						{
							ptImporter = new ProjekatImporter();
							ptImporter.Reset();
						}
					}
				}
				return ptImporter;
			}
		}

		public Delta NMSDelta
		{
			get 
			{
				return delta;
			}
		}
		#endregion Properties


		public void Reset()
		{
			concreteModel = null;
			delta = new Delta();
			importHelper = new ImportHelper();
			report = null;
		}

		public TransformAndLoadReport CreateNMSDelta(ConcreteModel cimConcreteModel)
		{
			LogManager.Log("Importing PowerTransformer Elements...", LogLevel.Info);
			report = new TransformAndLoadReport();
			concreteModel = cimConcreteModel;
			delta.ClearDeltaOperations();

			if ((concreteModel != null) && (concreteModel.ModelMap != null))
			{
				try
				{
					// convert into DMS elements
					ConvertModelAndPopulateDelta();
				}
				catch (Exception ex)
				{
					string message = string.Format("{0} - ERROR in data import - {1}", DateTime.Now, ex.Message);
					LogManager.Log(message);
					report.Report.AppendLine(ex.Message);
					report.Success = false;
				}
			}
			LogManager.Log("Importing PowerTransformer Elements - END.", LogLevel.Info);
			return report;
		}

		/// <summary>
		/// Method performs conversion of network elements from CIM based concrete model into DMS model.
		/// </summary>
		private void ConvertModelAndPopulateDelta()
		{
			LogManager.Log("Loading elements and creating delta...", LogLevel.Info);

            //// import all concrete model types (DMSType enum)
         

            ImportTapChangerControls();
            ImportReactiveCapabilityCurves();
            ImportCurveDatas();
            ImportSynchronousMachines();
            ImportControls();
            ImportTerminals();



            LogManager.Log("Loading elements and creating delta completed.", LogLevel.Info);
		}

        #region Import


        #region TapChangerControl

        private void ImportTapChangerControls()
        {
            SortedDictionary<string, object> cimTapChangerControls = concreteModel.GetAllObjectsOfType("FTN.TapChangerControl");
            if (cimTapChangerControls != null)
            {
                foreach (KeyValuePair<string, object> cimTapChangerControlPair in cimTapChangerControls)
                {
                    FTN.TapChangerControl cimTapChangerControl = cimTapChangerControlPair.Value as FTN.TapChangerControl;

                    ResourceDescription rd = CreateTapChangerControlResourceDescription(cimTapChangerControl);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("TapChangerControl ID = ").Append(cimTapChangerControl.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("TapChangerControl ID = ").Append(cimTapChangerControl.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }

        }

        private ResourceDescription CreateTapChangerControlResourceDescription(FTN.TapChangerControl cimTapChangerControl)
        {
            ResourceDescription rd = null;
            if (cimTapChangerControl != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.TAPCHANGER_CONTROL, importHelper.CheckOutIndexForDMSType(DMSType.TAPCHANGER_CONTROL));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimTapChangerControl.ID, gid);

                ////populate ResourceDescription
                ProjekatConverter.PopulateTapChangerControlProperties(cimTapChangerControl, rd);
            }
            return rd;
        }
        #endregion

        #region ReactiveCapabilityCurve

        private void ImportReactiveCapabilityCurves()
        {
            SortedDictionary<string, object> cimReactiveCapabilityCurves = concreteModel.GetAllObjectsOfType("FTN.ReactiveCapabilityCurve");
            if (cimReactiveCapabilityCurves != null)
            {
                foreach (KeyValuePair<string, object> cimReactiveCapabilityCurvePair in cimReactiveCapabilityCurves)
                {
                    FTN.ReactiveCapabilityCurve cimReactiveCapabilityCurve = cimReactiveCapabilityCurvePair.Value as FTN.ReactiveCapabilityCurve;

                    ResourceDescription rd = CreatecimReactiveCapabilityCurveResourceDescription(cimReactiveCapabilityCurve);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("ReactiveCapabilityCurve ID = ").Append(cimReactiveCapabilityCurve.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("ReactiveCapabilityCurve ID = ").Append(cimReactiveCapabilityCurve.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreatecimReactiveCapabilityCurveResourceDescription(FTN.ReactiveCapabilityCurve cimReactiveCapabilityCurve)
        {
            ResourceDescription rd = null;
            if (cimReactiveCapabilityCurve != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.REACTIVE_CAPABILITY_CURVE, importHelper.CheckOutIndexForDMSType(DMSType.REACTIVE_CAPABILITY_CURVE));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimReactiveCapabilityCurve.ID, gid);

                ////populate ResourceDescription
                ProjekatConverter.PopulateReactiveCapabilityCurveProperties(cimReactiveCapabilityCurve, rd);
            }
            return rd;
        }
        #endregion

        #region CurveData

        private void ImportCurveDatas()
        {
            SortedDictionary<string, object> cimCurveDatas = concreteModel.GetAllObjectsOfType("FTN.CurveData");
            if (cimCurveDatas != null)
            {
                foreach (KeyValuePair<string, object> cimCurveDataPair in cimCurveDatas)
                {
                    FTN.CurveData cimCurveData = cimCurveDataPair.Value as FTN.CurveData;

                    ResourceDescription rd = CreateCurveDataResourceDescription(cimCurveData);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("CurveData ID = ").Append(cimCurveData.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("CurveData ID = ").Append(cimCurveData.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateCurveDataResourceDescription(FTN.CurveData cimCurveData)
        {
            ResourceDescription rd = null;
            if (cimCurveData != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.CURVE_DATA, importHelper.CheckOutIndexForDMSType(DMSType.CURVE_DATA));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimCurveData.ID, gid);

                ////populate ResourceDescription
                ProjekatConverter.PopulateCurveDataProperties(cimCurveData, rd, importHelper, report);
            }
            return rd;
        }


        #endregion


        #region SynchronousMachine
        private void ImportSynchronousMachines()
        {
            SortedDictionary<string, object> cimSynchronousMachines = concreteModel.GetAllObjectsOfType("FTN.SynchronousMachine");
            if (cimSynchronousMachines != null)
            {
                foreach (KeyValuePair<string, object> cimSynchronousMachinePair in cimSynchronousMachines)
                {
                    FTN.SynchronousMachine cimSynchronousMachine = cimSynchronousMachinePair.Value as FTN.SynchronousMachine;

                    ResourceDescription rd = CreateSynchronousMachineResourceDescription(cimSynchronousMachine);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("SynchronousMachine ID = ").Append(cimSynchronousMachine.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("SynchronousMachine ID = ").Append(cimSynchronousMachine.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateSynchronousMachineResourceDescription(FTN.SynchronousMachine cimSynchronousMachine)
        {
            ResourceDescription rd = null;
            if (cimSynchronousMachine != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.SYNCHRONOUS_MACHINE, importHelper.CheckOutIndexForDMSType(DMSType.SYNCHRONOUS_MACHINE));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimSynchronousMachine.ID, gid);

                ////populate ResourceDescription
                ProjekatConverter.PopulateSynchronousMachineProperties(cimSynchronousMachine, rd, importHelper, report);
            }
            return rd;
        }
        #endregion


        #region Control

        private void ImportControls()
        {
            SortedDictionary<string, object> cimControls = concreteModel.GetAllObjectsOfType("FTN.Control");
            if (cimControls != null)
            {
                foreach (KeyValuePair<string, object> cimControlPair in cimControls)
                {
                    FTN.Control cimControl = cimControlPair.Value as FTN.Control;

                    ResourceDescription rd = CreateControlResourceDescription(cimControl);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("Control ID = ").Append(cimControl.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("Control ID = ").Append(cimControl.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateControlResourceDescription(FTN.Control cimControl)
        {
            ResourceDescription rd = null;
            if (cimControl != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.CONTROL, importHelper.CheckOutIndexForDMSType(DMSType.CONTROL));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimControl.ID, gid);

                ////populate ResourceDescription
                ProjekatConverter.PopulateControlProperties(cimControl, rd, importHelper, report);
            }
            return rd;
        }

        #endregion


        #region Terminal

        private void ImportTerminals()
        {
            SortedDictionary<string, object> cimTerminals = concreteModel.GetAllObjectsOfType("FTN.Terminal");
            if (cimTerminals != null)
            {
                foreach (KeyValuePair<string, object> cimTerminalPair in cimTerminals)
                {
                    FTN.Terminal cimTerminal = cimTerminalPair.Value as FTN.Terminal;

                    ResourceDescription rd = CreateTerminalResourceDescription(cimTerminal);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("Terminal ID = ").Append(cimTerminal.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("Terminal ID = ").Append(cimTerminal.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateTerminalResourceDescription(FTN.Terminal cimTerminal)
        {
            ResourceDescription rd = null;
            if (cimTerminal != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.TERMINAL, importHelper.CheckOutIndexForDMSType(DMSType.TERMINAL));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimTerminal.ID, gid);


                ////populate ResourceDescription
                ProjekatConverter.PopulateTerminalProperties(cimTerminal, rd, importHelper, report);
            }
            return rd;
        }
        
        #endregion
       
        #endregion Import
    }
}

