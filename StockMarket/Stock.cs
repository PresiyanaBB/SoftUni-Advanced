namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director,decimal pricePerShare,int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
        }

        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }


        //martketa = price + total //getter setter
        public decimal MarketCapitalization
        {
            get
            {
                return PricePerShare*TotalNumberOfShares;
            }
        }

        public override string ToString()
        {
            return $"Company: {CompanyName}\r\nDirector: {Director}\r\nPrice per share: ${PricePerShare}\r\nMarket capitalization: ${MarketCapitalization}";
        }
    }
}
