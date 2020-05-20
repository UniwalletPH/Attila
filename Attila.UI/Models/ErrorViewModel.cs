using System;

namespace Attila.UI.Models
{
    public class ErrorViewModel
    {
        public string Path { get; set; }

        public Exception Error { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
