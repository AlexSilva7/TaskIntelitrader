using QuickFix;
using log4net;
using log4net.Config;
using AcceptorFix;
using System.Reflection;
using QuickFix.DataDictionary;

public class Program
{

    [STAThread]
    static void Main(string[] args)
    {
        
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));

        SessionSettings settings = new SessionSettings(@"acceptor.cfg");

        var _log4net = LogManager.GetLogger(typeof(Program));
        DataDictionary data = new DataDictionary(@"C:\Users\Alex\Desktop\AcceptorFix\FIX44EntrypointGatewayEquities.xml");

        IApplication myApp = new FixApp(_log4net, data);
        IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
        ILogFactory logFactory = new FileLogFactory(settings);


        ThreadedSocketAcceptor acceptor = new ThreadedSocketAcceptor(
            myApp,
            storeFactory,
            settings,
            logFactory);


        acceptor.Start();
        System.Console.WriteLine("Escutando 5001");

        while (true)
        {
            System.Threading.Thread.Sleep(1000);
        }
        acceptor.Stop();
    }

}
