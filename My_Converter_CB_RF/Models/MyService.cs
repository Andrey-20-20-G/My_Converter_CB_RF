using Microsoft.Extensions.Caching.Memory;

using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace My_Converter_CB_RF.Models
{
    public class MyService : BackgroundService
    {
        public readonly IMemoryCache memoryCache;

        public MyService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    XDocument xml = XDocument.Load("https://www.cbr.ru/scripts/XML_daily.asp");
                    MyConverter converter = new MyConverter();
                    converter.BYN = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute")
                        .FirstOrDefault(x => x.Element("NumCode").Value == "933").Elements("Value").FirstOrDefault().Value);
                    converter.USD = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute")
                        .FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value);
                    converter.GBP = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute")
                        .FirstOrDefault(x => x.Element("NumCode").Value == "826").Elements("Value").FirstOrDefault().Value);
                    converter.CNY = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute")
                        .FirstOrDefault(x => x.Element("NumCode").Value == "156").Elements("Value").FirstOrDefault().Value);
                    converter.EUR = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute")
                        .FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value);
                    converter.JPY = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute")
                        .FirstOrDefault(x => x.Element("NumCode").Value == "392").Elements("Value").FirstOrDefault().Value);
                    converter.KZT = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute")
                        .FirstOrDefault(x => x.Element("NumCode").Value == "398").Elements("Value").FirstOrDefault().Value);
                    converter.UAH = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute")
                        .FirstOrDefault(x => x.Element("NumCode").Value == "980").Elements("Value").FirstOrDefault().Value);
                    memoryCache.Set("key_currency", converter, TimeSpan.FromMinutes(1440));
                }
                catch (Exception ex)
                {

                }
                await Task.Delay(3600000, stoppingToken);
            }


        }
    }
}
