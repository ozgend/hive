using Denolk.XchangeViewer.Models;
using Denolk.XchangeWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denolk.XchangeViewer
{
    public class XChangeApplication
    {
        public static XService Service { get; set; }

        public static void Start()
        {
            Service = null;
        }

    }
}