using System;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using Sentry;

namespace Amplifier
{
    public class Sentry: IDisposable
    {
        private Dictionary<string, ITransaction> _transactions = new Dictionary<string, ITransaction>();
        private static Sentry _instance = null;
        private static readonly object padlock = new object();
        public static string SentryDsn = String.Empty;

        Sentry()
        {
            SentryInit();
        }

        public static Sentry Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Sentry();
                    }
                    return _instance;
                }
            }
        }

        private void SentryInit()
        {
            SentrySdk.Init(o =>
            {
                o.Dsn = SentryDsn;
                o.Debug = false;
                o.TracesSampleRate = 0.1;
            });
        }

        public void Dispose()
        {
            SentrySdk.Close();
        }

        public ITransaction GetTransaction(string transactionName, string transactionOperation = null)
        {
            if (_transactions.ContainsKey(transactionName))
                return _transactions[transactionName];

            var transaction = SentrySdk.StartTransaction(
                transactionName,
                transactionOperation ?? ""
            );
            _transactions.Add(transactionName, transaction);
            return transaction;
        }

        public void ConfigureScope(string wsUrl, string wsUser)
        {
            SentrySdk.ConfigureScope(scope =>
                {
                    if(!string.IsNullOrEmpty(wsUrl))
                        scope.SetTag("TRANSLATOR-URL", wsUrl);
                    if(!string.IsNullOrEmpty(wsUser))
                        scope.SetTag("TRANSLATOR-USER", wsUser);
                });
        }
    }
}