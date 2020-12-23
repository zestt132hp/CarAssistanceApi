namespace CarAssistance.Exceptions
{
    public static class ExceptionMessageHeaders
    {
        public static string CanNotRecognizeInputModel => "Can't recognize input model";
        public static string CanNotFoundEntityWithId => "Can't found entity with id";

        public static string GetMessage(string message, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++) 
            {
                message += "= {" + i + "}";
            }

            return string.Format(message, parameters);
        }
    }
}
