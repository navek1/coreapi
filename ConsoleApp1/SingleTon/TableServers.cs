using System;
using System.Collections.Generic;
using System.Text;

namespace SingleTon
{
    public class TableServers
    {
        private static readonly TableServers _instance = new TableServers();
        private List<string> servers = new List<string>();
        private int nextserver = 0;
        private TableServers()
        {
            servers.Add("Tom");
            servers.Add("Bob");
            servers.Add("Mary");
        }
        public static TableServers GetTableserver()
        {
            return _instance;
        }
        public string GetNextServer()
        {
            string result = servers[nextserver];
            nextserver += 1;
            if (nextserver >= servers.Count)
            {
                nextserver = 0;
            }
            return result;
        }
    }
}
