using Newtonsoft.Json;

namespace Web.ViewModels
{
    public class MabnaCardResponse
    {
        public string respcode { get; set; }

        public string digitalreceipt { get; set; }

        public string terminalid { get; set; }

        public string Tid { get; set; }

        public string InvoiceID { get; set; }

        public string Payload { get; set; }
    }
}
