using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AssessmentOmniAcc.Models
{

    public class Stock
    {
        [JsonProperty("product_group_description")]
        public string product_group_description { get; set; }
        [JsonProperty("stock_category_description")]
        public string stock_category_description { get; set; }
        [DisplayName("Stock Code")]
        public string stock_code { get; set; }
        [DisplayName("Description")]
        public string stock_description { get; set; }
        [JsonProperty("unit_of_measure")]
        public string unit_of_measure { get; set; }
        [JsonProperty("pack")]
        public int pack { get; set; }
        [DisplayName("Bar code")]
        public string bar_code { get; set; }
        [JsonProperty("vat_code")]
        public string vat_code { get; set; }
        [JsonProperty("revenue_account")]
        public string revenue_account { get; set; }
        [JsonProperty("cost_price")]
        public decimal cost_price { get; set; }
        [JsonProperty("cost_price_per")]
        public int cost_price_per { get; set; }
        [JsonProperty("unit_volume")]
        public int unit_volume { get; set; }
        [JsonProperty("unit_weight")]
        public int unit_weight { get; set; }
        [JsonProperty("selling_price_currency")]
        public string selling_price_currency { get; set; }
        [JsonProperty("selling_price_excl")]
        public decimal selling_price_excl { get; set; }
        [JsonProperty("Selling Price")]
        public decimal selling_price_incl { get; set; }
        [JsonProperty("selling_price_markup")]
        public decimal selling_price_markup { get; set; }
        [JsonProperty("selling_price_measure")]
        public string selling_price_measure { get; set; }
        [DisplayName("Price")]
        public decimal incl_unit_selling_price { get; set; }
        [JsonProperty("selling_price_per")]
        public int selling_price_per { get; set; }
        [JsonProperty("customer_currency")]
        public string customer_currency { get; set; }
        [JsonProperty("customer_discount")]
        public string customer_discount { get; set; }
        [JsonProperty("customer_discount_type")]
        public string customer_discount_type { get; set; }
        [JsonProperty("customer_price_incl")]
        public string customer_price_incl { get; set; }
        [JsonProperty("customer_price")]
        public string customer_price { get; set; }
        [JsonProperty("customer_price_per")]
        public string customer_price_per { get; set; }
        [JsonProperty("customer_unit_price_excl")]
        public string customer_unit_price_excl { get; set; }
        [JsonProperty("customer_unit_price_incl")]
        public string customer_unit_price_incl { get; set; }
        [JsonProperty("stock_memo")]
        public string stock_memo { get; set; }
        [JsonProperty("available")]
        public string available { get; set; }
        [JsonProperty("reorder_qty")]
        public int reorder_qty { get; set; }
        [JsonProperty("level")]
        public decimal level { get; set; }
    }


    public class OurMainObject
    {
        public List<Stock> stock_export { get; set; }
        //public Stock[] stock_export { get; set; }
    }
}