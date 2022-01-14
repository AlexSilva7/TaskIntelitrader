using QuickFix;
using Message = QuickFix.Message;
using QuickFix.DataDictionary;

namespace AcceptorFix
{

    public class FixApp : IApplication
    {
        private readonly log4net.ILog _logger;
        private readonly DataDictionary _dataDictionary;

        public FixApp(log4net.ILog logger, DataDictionary dataDictionary)
        {
            _logger = logger;
            _dataDictionary = dataDictionary;
        }

        public void FromApp(Message msg, SessionID sessionID)
        {
            string mensagem = Decode.Message(msg, _dataDictionary);
            _logger.Info(mensagem);

            string str = msg.ToString().Replace("\u0001", "|");
            Console.WriteLine("IN:  " + str);
        }

        public void ToApp(Message msg, SessionID sessionID)
        {
            string mensagem = Decode.Message(msg, _dataDictionary);
            _logger.Info(mensagem);

            string str = msg.ToString().Replace("\u0001", "|");
            Console.WriteLine("OUT:  " + str);
        }

        public void FromAdmin(Message msg, SessionID sessionID)
        {
            string mensagem = Decode.Message(msg, _dataDictionary);
            _logger.Info(mensagem);

            string str = msg.ToString().Replace("\u0001", "|");
            Console.WriteLine("IN:  " + str);
        }


        public void ToAdmin(Message msg, SessionID sessionID)
        {
            string mensagem = Decode.Message(msg, _dataDictionary);
            _logger.Info(mensagem);

            string str = msg.ToString().Replace("\u0001", "|");
            Console.WriteLine("OUT:  " + str);
        }


        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID) { }
        public void OnLogon(SessionID sessionID) { /*_logger.Info(sessionID);*/ }

    }

}
