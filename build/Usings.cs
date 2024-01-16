global using System;
global using System.ComponentModel;
global using System.Collections.Generic;
global using System.Threading.Tasks;
global using System.Linq;
global using Helpers;
global using Nuke.Common;
global using Nuke.Common.IO;
global using Nuke.Common.ProjectModel;
global using Nuke.Common.Tooling;
global using Nuke.Common.Tools.Docker;
global using Nuke.Common.Tools.DotNet;
global using Nuke.Common.Tools.EntityFramework;
global using Nuke.Common.Tools.ReportGenerator;
global using Nuke.Common.Utilities;
global using Nuke.Common.Utilities.Collections;
global using Serilog;
global using static Helpers.Commands;
global using static Nuke.Common.EnvironmentInfo;
global using static Nuke.Common.IO.FileSystemTasks;
global using static Nuke.Common.Tools.Docker.DockerTasks;
global using static Nuke.Common.Tools.DotNet.DotNetTasks;
global using static Nuke.Common.Tools.EntityFramework.EntityFrameworkTasks;
global using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;