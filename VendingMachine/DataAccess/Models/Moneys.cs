

namespace DataAccess.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Moneys
    {
        public int Id { get; set; }

        public double MoneyType { get; set; }

        public int MoneyQuantity { get; set; }

    }
}
