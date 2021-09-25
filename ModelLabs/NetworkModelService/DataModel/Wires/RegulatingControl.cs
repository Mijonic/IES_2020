using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class RegulatingControl : PowerSystemResource
    {
        private bool discrete;
        private RegulatingControlModeKind mode;
        private PhaseCode phase;
        private float targetRange;
        private float targetValue;

        private List<long> regulatingCondEqs = new List<long>();


        public bool Discrete { get => discrete; set => discrete = value; }
        public RegulatingControlModeKind Mode { get => mode; set => mode = value; }
        public float TargetRange { get => targetRange; set => targetRange = value; }
        public float TargetValue { get => targetValue; set => targetValue = value; }
        public PhaseCode Phase { get => phase; set => phase = value; }
        public List<long> RegulatingCondEqs { get => regulatingCondEqs; set => regulatingCondEqs = value; }

        public RegulatingControl(long globalId) : base(globalId)
        {
        }

     

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                RegulatingControl x = (RegulatingControl)obj;
                return (x.discrete == this.discrete && x.mode == this.mode && x.phase == this.phase && x.targetRange == this.targetRange && x.targetValue == this.targetValue &&
                    (CompareHelper.CompareLists(x.regulatingCondEqs, this.regulatingCondEqs)));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.REGULATINGCONTROL_DISCRETE:
                case ModelCode.REGULATINGCONTROL_MODE:
                case ModelCode.REGULATINGCONTROL_PHASE:
                case ModelCode.REGULATINGCONTROL_TARGETRANGE:
                case ModelCode.REGULATINGCONTROL_TARGETVALUE:
                case ModelCode.REGULATINGCONTROL_REGULATINGCONDEQS:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                

                case ModelCode.REGULATINGCONTROL_DISCRETE:
                    prop.SetValue(discrete);
                    break;

                case ModelCode.REGULATINGCONTROL_MODE:
                    prop.SetValue((short)mode);
                    break;

                case ModelCode.REGULATINGCONTROL_PHASE:
                    prop.SetValue((short)phase);
                    break;

                case ModelCode.REGULATINGCONTROL_TARGETRANGE:
                    prop.SetValue(targetRange);
                    break;

                case ModelCode.REGULATINGCONTROL_TARGETVALUE:
                    prop.SetValue(targetValue);
                    break;

                case ModelCode.REGULATINGCONTROL_REGULATINGCONDEQS:
                    prop.SetValue(regulatingCondEqs);
                    break;

                    

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
               

                case ModelCode.REGULATINGCONTROL_DISCRETE:
                    discrete = property.AsBool();
                    break;

                case ModelCode.REGULATINGCONTROL_MODE:
                    mode = (RegulatingControlModeKind)property.AsEnum();
                    break;

                case ModelCode.REGULATINGCONTROL_PHASE:
                    phase = (PhaseCode)property.AsEnum();
                    break;

                case ModelCode.REGULATINGCONTROL_TARGETRANGE:
                    targetRange = property.AsFloat();
                    break;

                case ModelCode.REGULATINGCONTROL_TARGETVALUE:
                    targetValue = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return regulatingCondEqs.Count != 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {


            if (regulatingCondEqs != null && regulatingCondEqs.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.REGULATINGCONTROL_REGULATINGCONDEQS] = regulatingCondEqs.GetRange(0, regulatingCondEqs.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.REGULATINGCONDEQ_REGULATINGCONTROL:
                    regulatingCondEqs.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.REGULATINGCONDEQ_REGULATINGCONTROL:

                    if (regulatingCondEqs.Contains(globalId))
                    {
                        regulatingCondEqs.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }


        #endregion IReference implementation
    }
}
