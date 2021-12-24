namespace API_Cadastro.Logging
{
    public class CustomLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomLogger(string name, CustomLoggerProviderConfiguration config)
        {
            this.loggerName = name;
            this.loggerConfig = config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();    
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, 
            Exception exception, Func<TState, Exception, string> formatter)
        {
            string hora = DateTime.Now.ToLongTimeString();  
            
            string mensagem = string.Format("{0} -> {1}: {2} - {3}", hora, logLevel.ToString(),
                eventId.Id, formatter(state, exception));

            EscreverTextoNoArquivo(mensagem);
        }

        public void EscreverTextoNoArquivo(string mensagem)
        {
            string data = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            string caminhoArquivoLog = @$"..\Logs_Aplicacao\API_Cadastro_{data}.txt";

            //string caminhoArquivoLog = @$"Log/API_Cadastro_{data}.txt";

            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                streamWriter.WriteLine(mensagem);
                streamWriter.Close();
            }
        }
    }
}
