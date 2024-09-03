using System;
using System.Collections.Generic;

namespace Amplifier
{
    public class ProductImage
    {
        public int product_id;
        public string alt = null;
        public string image = null;
        public string file_name = null;
        public int order = 1;
        public int thumbnail_width;
    }

    public class Price
    {
        public string product_external_id { get; set; }
        public string price_level_external_id { get; set; }
        public string external_id { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public int order { get; set; }
    }

    public class CategoryDiscount
    {
        public string category_external_id { get; set; }
        public string price_level_external_id { get; set; }
        public string external_id { get; set; }
        public decimal discount { get; set; }
        public int order { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
    }

    public class PriceLevel
    {
        public string name { get; set; }
        public string external_id { get; set; }
        public int order { get; set; }
        public bool is_global { get; set; }
        public bool is_enabled { get; set; }
        public bool is_promotional { get; set; }
    }

    public class PriceLevelAssigment
    {
        public string external_id { get; set; }
        public string price_level { get; set; }
        public string customer_category { get; set; }
        public string customer { get; set; }

    }

    public class Stock
    {
        public string product_external_id { get; set; }
        public string stock_level_external_id { get; set; }
        public string external_id { get; set; }
        public decimal quantity { get; set; }
        public decimal quantity_allocated { get; set; }
    }

    public class StockLocation
    {
        public string name { get; set; }
        public string external_id { get; set; }
    }

    public class ProductCategory
    {
        public string external_id { get; set; }
        public string parent_external_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string seo_tags { get; set; }
        public int order { get; set; }
        public string updatable_fields { get; set; }
    }

    public class ProductCategoryRelation
    {
        public string external_id { get; set; }
        public string category_external_id { get; set; }
        public string product_external_id { get; set; }
    }

    public class CustomerProductRelation
    {
        public string external_id { get; set; }
        public string product_external_id { get; set; }
        public string category_external_id { get; set; }
        public string customer_external_id { get; set; }
        public bool excluded { get; set; }
    }

    public class ProductAttributes
    {
        public ProductAttributes(string key, string atr_name, string atr_val)
        {
            this.key = key;
            this.atr_name = atr_name;
            this.atr_val = atr_val;
            this.is_b2b = true;
            this.is_msf = true;
            this.is_b2c = true;
            this.enabled_for_filtering = true;
            this.show_on_tile = false;
        }
        public ProductAttributes(string key, string atr_name, string atr_val, bool enabled_for_filtering, bool show_on_tile)
        {
            this.key = key;
            this.atr_name = atr_name;
            this.atr_val = atr_val;
            this.is_b2b = true;
            this.is_msf = true;
            this.is_b2c = true;
            this.enabled_for_filtering = enabled_for_filtering;
            this.show_on_tile = show_on_tile;
        }
        public string key { get; set; }
        public string atr_name { get; set; }
        public string atr_val { get; set; }
        public bool is_b2b { get; set; }
        public bool is_msf { get; set; }
        public bool is_b2c { get; set; }
        public bool enabled_for_filtering { get; set; }
        public bool show_on_tile { get; set; }
    }

    public class Product
    {
        public List<ProductAttributes> attributes { get; set; }
        public string name { get; set; }
        public string friendly_name { get; set; }
        public string short_description { get; set; }
        public string description { get; set; }
        public string short_code { get; set; }
        public string sku { get; set; }
        public string ean { get; set; }
        public string brand_short_code { get; set; }
        public int vat { get; set; }
        public string available_on { get; set; }
        public bool is_published { get; set; }
        public bool is_featured { get; set; }
        public decimal weight { get; set; }
        public string default_unit_of_measure { get; set; }
        public string external_id { get; set; }
        public string updatable_fields { get; set; }
        public string cumulative_unit_of_measure { get; set; }
        public decimal cumulative_converter { get; set; }
        public bool can_be_split { get; set; }
        public decimal cumulative_unit_ratio_splitter { get; set; }
        public bool unit_roundup { get; set; }
        public decimal default_price { get; set; }
        public bool is_b2b_product { get; set; }
        public bool is_b2c_product { get; set; }
        public bool is_msf_product { get; set; }
        public bool is_b2m_product { get; set; }
        public bool is_msk_product { get; set; }
        public string dimension_unit_of_measure { get; set; }
        public decimal dimension_width { get; set; }
        public decimal dimension_height { get; set; }
        public decimal dimension_depth { get; set; }        
        public bool is_product_saleable { get; set; }    
        public decimal piggy_bank_budget { get; set; }
        public int concession_a { get; set; }
        public int concession_b { get; set; }
        public int concession_c { get; set; }
        public decimal capacity { get; set; }
        public string sorting_column { get; set; }
        public bool is_bestseller { get; set; }
        public bool is_for_sale { get; set; }
        public string status_description { get; set; }
        public decimal minimal_price { get; set; }
        public int product_subtype { get; set; }
        public string sanitized_description { get; set; }
        public string cn_code { get; set; }
        public int order { get; set; }
    }


    public class RelatedProducts
    {
        public string external_id { get; set; }
        public List<RelatedProduct> related_products { get; set; }
    }

    public class RelatedProduct
    {
        public string external_id { get; set; }
    }
    
    public class UnitOfMeasure
    {
        public string product_external_id { get; set; }
        public string external_id { get; set; }
        public string name { get; set; }
        public decimal converter { get; set; }
        public bool can_be_split { get; set; }
        public decimal cumulative_unit_ratio_splitter { get; set; }
        public bool unit_roundup { get; set; }
        public decimal weight { get; set; }
        public decimal capacity { get; set; }

    }
    
    public class DefaultPriceOverwriteForCategoryDiscount
    {
        public string external_id { get; set; }
        public string price_level { get; set; }
        public string category_discount { get; set; }
        public int order { get; set; }
    }
    public class Manufacturer
    {
        public string external_id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public int order { get; set; }
        public string description { get; set; }
        public string seo_tags { get; set; }
        public bool is_hidden { get; set; }
        public bool is_featured { get; set;}
        public string short_code { get; set; }
        public string updatable_fields { get; set; }
    }
    
    public class Brand
    {
        public string external_id { get; set; }
        public string manufacturer_external_id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public int order { get; set; }
        public string description { get; set; }
        public string seo_tags { get; set; }
        public bool is_hidden { get; set; }
        public bool is_featured { get; set; }
        public string short_code { get; set; }
        public string updatable_fields { get; set; }
    }
}