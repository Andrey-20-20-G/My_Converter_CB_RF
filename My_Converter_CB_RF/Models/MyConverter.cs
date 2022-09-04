namespace My_Converter_CB_RF.Models
{
    public class MyConverter
    {
        public decimal GBP { get; set; } //1
        public decimal ConvertToGBP(decimal priceRUB) => priceRUB / GBP;
        public decimal BYN { get; set; } //1
        public decimal ConvertToBYN(decimal priceRUB) => priceRUB / BYN;

        public decimal EUR { get; set; } //1
        public decimal ConvertToEUR(decimal priceRUB) => priceRUB / EUR;
        public decimal USD { get; set; } //1
        public decimal ConvertToUSD(decimal priceRUB) => priceRUB / USD;
        public decimal KZT { get; set; } //100
        public decimal ConvertToKZT(decimal priceRUB) => priceRUB / (KZT / 100);
        public decimal CNY { get; set; } //10
        public decimal ConvertToCNY(decimal priceRUB) => priceRUB / (CNY / 10);
        public decimal UAH { get; set; } //10
        public decimal ConvertToUAH(decimal priceRUB) => priceRUB / (UAH / 10);
        public decimal JPY { get; set; } // 100
        public decimal ConvertToJPY(decimal priceRUB) => priceRUB / (JPY / 100);
    }
}
