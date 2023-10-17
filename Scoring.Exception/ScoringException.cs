using System;

namespace Scoring.Exceptions
{
    [Serializable]
    public abstract class ScoringException : Exception
    {

        public readonly int HttpCode;
        public readonly int InternalCode;
        public readonly string InternalMessage;
        public string LlamadaObservaciones = "";
        public int? TokenId;
        public int? UserServiceId;
        public string TmpCode;

        protected ScoringException(int httpCode, int internalCode, string internalMessage)
        {
            HttpCode = httpCode;
            InternalCode = internalCode;
            InternalMessage = internalMessage;            
        }
     

        protected ScoringException(int httpCode, int internalCode, string internalMessage, string message) : base(message)
        {
            HttpCode = httpCode;
            InternalCode = internalCode;
            InternalMessage = internalMessage;            
        }

        public override string ToString()
        {
            return InternalCode + ": " + InternalMessage;
        }


    }
}
