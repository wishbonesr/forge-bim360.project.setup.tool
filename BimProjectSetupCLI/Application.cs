/////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved
// Written by Forge Partner Development
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM 'AS IS' AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
/////////////////////////////////////////////////////////////////////

using NLog;
using System;
using System.Reflection;
using BimProjectSetupCommon;
using BimProjectSetupCommon.Workflow;

namespace Autodesk.BimProjectSetup
{
    internal class Application
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
        private AppOptions options = null;

        private FolderWorkflow folderProcess = null;
        private ProjectWorkflow projectProcess = null;
        private ServiceWorkflow serviceProcess = null;
        private AccountWorkflow accountProcess = null;
        private ProjectUserWorkflow projectUserProcess = null;

        public Application(AppOptions options)
        {
            this.options = options;
        }
        public bool Initialize()
        {
            bool result = false;
            try
            {
                folderProcess = new FolderWorkflow(options);
                projectProcess = new ProjectWorkflow(options);
                serviceProcess = new ServiceWorkflow(options);
                accountProcess = new AccountWorkflow(options);
                projectUserProcess = new ProjectUserWorkflow(options);

                result = true;
            }
            catch (Exception e)
            {
                result = false;
                Log.Error(e, "Error during intitialization");
            }
            return result;
        }
        public void Process()
        {
            //the following -o switch was added, but too may overloads were needed
            //to get the options to the csvexporter    
            //if (options.ExportPath != null)
            //{
            if (true == options.ExportUsers)
                {
                    Log.Info($"");
                    Log.Info($"Writing Export File for Account Users");
                    Log.Info($"");
                    accountProcess.ExportUsersCsv();
                }
                if (true == options.ExportProjects)
                {
                    Log.Info($"");
                    Log.Info($"Writing Export File for Projects List");
                    Log.Info($"");
                    projectProcess.ExportProjectsToCsv();
                }
                if (true == options.ExportProjectUsers)
                {
                    Log.Info($"");
                    Log.Info($"Writing Export File for Project Users");
                    Log.Info($"");
                    projectUserProcess.ExportUsersCsv();
                }
            //}
            if (options.FilePath != null)
            {
                if (options.CopyFolders)
                {
                    folderProcess.CopyFoldersProcess();
                }
                else
                {
                    projectProcess.CreateProjectsProcess();
                }
            }
            if (options.ServiceFilePath != null)
            {
                serviceProcess.ActivateServicesProcess();
            }
            if (options.UserFilePath != null)
            {
                if (options.UpdateProjectUsers)
                {
                    projectUserProcess.UpdateProjectUsersFromCsvProcess();
                }
                else if (options.AddProjectUsers)
                {
                    projectUserProcess.AddProjectUsersFromCsvProcess();
                }
                else if (options.UpdateAccountUsers)
                {
                    accountProcess.UpdateUsersFromCsv();
                }
                else if (options.AddAccountUsers)
                {
                    accountProcess.AddUsersFromCsv();
                }
                else 
                {
                    Console.WriteLine("Arg [-u] must be used with one of the following [AA] [AP] [UP] [UA]");
                    Console.WriteLine("");
                    PrintHelp();
                }
            }
        }
        internal static void PrintHelp()
        {
            Console.WriteLine("Usage: Autodesk.BimProjectSetup [-o] [-p] [-x] [-u] [-c] [-s] [-a] [-b] [-t] [-z] [-e] [-d] [-r] [-h] [--CF] [--EU] [--UP]");
            Console.WriteLine("  -o        Output path for exports");
            Console.WriteLine("  -p        Path to CSV input file for project creation");
            Console.WriteLine("  -x        Path to CSV input file for service activation");
            Console.WriteLine("  -u        Path to CSV input file with user information (account or project - see respective templates");
            Console.WriteLine("  -c        Forge client ID");
            Console.WriteLine("  -s        Forge client secret");
            Console.WriteLine("  -a        BIM 360 Account ID");
            Console.WriteLine("  -b        BaseUrl (default= \"https://developer.api.autodesk.com\"");
            Console.WriteLine("  -t        Separator character (default = ';')");
            Console.WriteLine("  -z        Service Separator character (default = ',')");
            Console.WriteLine("  -e        Encoding (default = UTF-8)");
            Console.WriteLine("  -d        Date time format pattern (default = yyyy-MM-dd)");
            Console.WriteLine("  -r        Trial run [true/false] (default = false)");
            Console.WriteLine("  -h        Email address of the BIM 360 Account admin");
            // Switches
            Console.WriteLine("  --CF      Copy folders");
            Console.WriteLine("  --AR      Admin Industry Role");
            Console.WriteLine("  --EU      Use the EU region account");
            Console.WriteLine("  --AP      Add Project Users Access, Companies, or Roles");
            Console.WriteLine("  --AA      Add Account Users Access, Companies, or Roles");
            Console.WriteLine("  --UP      Update Project User Access, Companies, or Roles");
			Console.WriteLine("  --UA      Update Account User Access, Companies, or Roles");
            Console.WriteLine("  --UE      Users Export");
            Console.WriteLine("  --PUE     Projects Users Export");
            Console.WriteLine("  --PE      Projects List Export");
            Console.WriteLine("At least one path to an input file must be provided with the -p or -x options");
        }
        internal static void PrintHeader()
        {
            Console.WriteLine($"Autodesk Consulting BIM 360 Project Setup Tool v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}");
            Console.WriteLine("Copyright (c) 2018 Autodesk, Inc. All rights reserved.");
            Console.WriteLine("");
        }
    }
}
