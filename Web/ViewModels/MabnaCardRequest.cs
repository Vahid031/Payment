using Newtonsoft.Json;

namespace Web.ViewModels
{
    public class MabnaCardRequest
    {
        public string TerminalID { get; set; }

        public decimal Amount { get; set; }

        public string CallbackURL { get; set; }

        public string InvoiceID { get; set; }

        public string Payload { get; set; }
    }
}
