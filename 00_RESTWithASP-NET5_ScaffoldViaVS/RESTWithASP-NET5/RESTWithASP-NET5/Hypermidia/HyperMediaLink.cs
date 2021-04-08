﻿using System.Text;

namespace RESTWithASP_NET5.Hypermidia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        public string href;
        public string Href {
            get 
            { 
                object _lock = new(); 
                lock (_lock)
                {
                    StringBuilder sb = new(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set { href = value; }
        }
        public string Type { get; set; }
        public string Action { get; set; }

    }
}