using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class SensitiveDataAttribute : Attribute
    {
        public DataType dataType;

        public SensitiveDataAttribute(DataType dataType)
        {
            this.dataType = dataType;
        }
    }


    public enum DataType { Passport, Family, VinCode }
}
