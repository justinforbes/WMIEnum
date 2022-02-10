﻿using System;
using System.Text;

using WMIEnum.Models;

namespace WMIEnum.Commands
{
    class ReturnTargetProcess : Models.Command
    {
        private string ProcName { get; set; }
        public override string CommandName => "TargetProcess";

        public override string Description => "Returns a specified process";

        public override string CommandExec(string[] args)
        {
            try {
                StringBuilder outData = new StringBuilder();

                if (args.Length != 1) { throw new WMIEnumException("[*] TargetInstalledPrograms [ProgramName]"); }

                ProcName = args[0];

                string[] fields = new string[] { "Name", "ProcessId", "SessionId" };

                outData = Utils.Extensions.Extensions.ObjProperties(outData, fields,
                    $"SELECT * FROM Win32_Process Where Name Like '%{ProcName}%'");

                return outData.ToString();
            } catch (WMIEnumException e) { return e.Message; }
        }
    }
}
