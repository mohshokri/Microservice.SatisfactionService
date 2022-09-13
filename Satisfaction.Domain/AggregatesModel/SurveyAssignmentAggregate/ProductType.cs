using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate
{
    public class ProductType : SmartEnum<ProductType>
    {
        public ProductType() : base(" ", -1)
        {

        }
        public ProductType(string name, int value) : base(name, value)
        {

        }
        public static readonly ProductType Trailer = new ProductType("تریلر", 1);
        public static readonly ProductType Scania = new ProductType("اسکانیا", 2);
        public static readonly ProductType Pilsan = new ProductType("پیلسان", 3);

    }
}
