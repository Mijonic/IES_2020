using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal : IdentifiedObject
    {
        private long conductingEquipment = 0;

        public Terminal(long globalId) : base(globalId)
        {
        }

        public long ConductingEquipment { get => conductingEquipment; set => conductingEquipment = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal x = (Terminal)obj;
                return (x.conductingEquipment == this.conductingEquipment);
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

        #region IAccess
        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.TERMINAL_CONDEQ:
                    return true;

                default:
                    return base.HasProperty(property);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONDEQ:
                    property.SetValue(conductingEquipment);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONDEQ:
                    conductingEquipment = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion


        #region IReference implementation

      

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {

            if (conductingEquipment != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CONDEQ] = new List<long>();
                references[ModelCode.TERMINAL_CONDEQ].Add(conductingEquipment);
            }


            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
          
            base.AddReference(referenceId, globalId);
           
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
          
           base.RemoveReference(referenceId, globalId);
          
        }

        #endregion IReference implementation



    }
}
