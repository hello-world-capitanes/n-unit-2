namespace Scoring.Exceptions.Token
{
    public class MissingParameterException : ScoringException
    {
        private static int _httpCode = 400;
        private static int _internalCode = 220;
        private static string _internalMessage = "Error parámetros erróneos";

        public MissingParameterException(string parameter) : base(_httpCode, _internalCode, _internalMessage)
        {
            this.setObservaciones(parameter);
        }

        public MissingParameterException(string parameter, string message) : base(_httpCode, _internalCode, _internalMessage, message)
        {
            this.setObservaciones(parameter);
        }

        private void setObservaciones(string parameter)
        {
            this.LlamadaObservaciones = string.Format("No se ha proporcionado el parámetro obligatorio {0}", parameter);
        }
    }
}
