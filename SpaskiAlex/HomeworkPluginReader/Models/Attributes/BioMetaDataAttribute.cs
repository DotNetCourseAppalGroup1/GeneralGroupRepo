using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Attributes
{
    public class BioMetaDataAttribute : Attribute
    {
        public string BioPath { get; set; }
        public BioMetaDataAttribute(string bioPath)
        {
            BioPath = bioPath;
        }
        public BioMetaDataAttribute()
        {
            this.BioPath = BioPath;
        }
    }
}
