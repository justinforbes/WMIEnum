﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SharpCIMEnum.Commands.Cmds
{
    class ReturnRunningProcesses : Models.Command
    {
        public override string CommandName => "Processes";

        public override string Description => "return all running process";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string[] fields = new string[] { "Name", "ProcessId", "SessionId" };

            outData = Utils.Extensions.Extensions.ObjProperties(outData, fields, "SELECT * FROM Win32_Process");

            return outData.ToString();
        }
    }
}
