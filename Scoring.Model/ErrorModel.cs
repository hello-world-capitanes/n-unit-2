using System;

namespace Scoring.Model
{
    [Serializable]
    public class ErrorModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
