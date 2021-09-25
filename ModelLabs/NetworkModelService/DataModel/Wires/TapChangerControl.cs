using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class TapChangerControl : RegulatingControl
    {

        private float limitVoltage;
        private bool lineDropCompensation;
        private float lineDropR;
        private float lineDropX;
        private float reverseLineDropR;
        private float reverseLineDropX;




        public TapChangerControl(long globalId) : base(globalId)
        {
        }


        public float LimitVoltage { get => limitVoltage; set => limitVoltage = value; }
        public bool LineDropCompensation { get => lineDropCompensation; set => lineDropCompensation = value; }
        public float LineDropR { get => lineDropR; set => lineDropR = value; }
        public float LineDropX { get => lineDropX; set => lineDropX = value; }
        public float ReverseLineDropR { get => reverseLineDropR; set => reverseLineDropR = value; }
        public float ReverseLineDropX { get => reverseLineDropX; set => reverseLineDropX = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                TapChangerControl x = (TapChangerControl)obj;
                return (x.limitVoltage == this.limitVoltage && x.lineDropCompensation == this.lineDropCompensation && x.lineDropR == this.lineDropR &&
                        x.lineDropX == this.lineDropX && x.reverseLineDropR == this.reverseLineDropR && x.reverseLineDropX == this.reverseLineDropX);
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
                case ModelCode.TAPCHANGERCONTROL_LIMITVOLTAGE:
                case ModelCode.TAPCHANGERCONTROL_LINEDROPCOMPENSAT:
                case ModelCode.TAPCHANGERCONTROL_LINEDROPR:
                case ModelCode.TAPCHANGERCONTROL_LINEDROPX:
                case ModelCode.TAPCHANGERCONTROL_REVERSELINEDROPR:
                case ModelCode.TAPCHANGERCONTROL_REVERSELINEDROPX:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                
                case ModelCode.TAPCHANGERCONTROL_LIMITVOLTAGE:
                    prop.SetValue(limitVoltage);
                    break;

                case ModelCode.TAPCHANGERCONTROL_LINEDROPCOMPENSAT:
                    prop.SetValue(lineDropCompensation);
                    break;

                case ModelCode.TAPCHANGERCONTROL_LINEDROPR:
                    prop.SetValue(lineDropR);
                    break;

                case ModelCode.TAPCHANGERCONTROL_LINEDROPX:
                    prop.SetValue(lineDropX);
                    break;

                case ModelCode.TAPCHANGERCONTROL_REVERSELINEDROPR:
                    prop.SetValue(reverseLineDropR);
                    break;

                case ModelCode.TAPCHANGERCONTROL_REVERSELINEDROPX:
                    prop.SetValue(reverseLineDropX);
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
             

                case ModelCode.TAPCHANGERCONTROL_LIMITVOLTAGE:
                    limitVoltage = property.AsFloat();
                    break;

                case ModelCode.TAPCHANGERCONTROL_LINEDROPCOMPENSAT:
                    lineDropCompensation = property.AsBool();
                    break;


                case ModelCode.TAPCHANGERCONTROL_LINEDROPR:
                    lineDropR = property.AsFloat();
                    break;

                case ModelCode.TAPCHANGERCONTROL_LINEDROPX:
                    lineDropX = property.AsFloat();
                    break;


                case ModelCode.TAPCHANGERCONTROL_REVERSELINEDROPR:
                    reverseLineDropR = property.AsFloat();
                    break;

                case ModelCode.TAPCHANGERCONTROL_REVERSELINEDROPX:
                    reverseLineDropX = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

       
    }
}
