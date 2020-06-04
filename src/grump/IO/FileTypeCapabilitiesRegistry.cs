// using System;
// using System.Collections.Generic;
// using Grump.Abstractions;
//
// namespace Grump.IO
// {
//     public class FileTypeCapabilitiesRegistry : IFileTypeCapabilitiesRegistry
//     {
//         internal static readonly IFileTypeCapabilitiesRegistry Instance = new FileTypeCapabilitiesRegistry();
//
//         private IDictionary<Type, IDictionary<Type, Delegate>> RegisteredHandlers = new Dictionary<Type, IDictionary<Type, Delegate>>();
//
//         public void Register<TFile, TCapability>(FileCapabilityDelegate<TFile, TCapability> handler) where TFile : File where TCapability : IFileCapability
//         {
//             var fileType = typeof(TFile);
//             var capabilityType = typeof(TCapability);
//
//             if (!RegisteredHandlers.ContainsKey(fileType))
//             {
//                 // First time we are taking capabilities for this file type.
//                 RegisteredHandlers.Add(typeof(TFile), new Dictionary<Type, Delegate>());
//             }
//
//             var capabilitiesForType = RegisteredHandlers[fileType];
//
//             if (capabilitiesForType.ContainsKey(capabilityType))
//             {
//                 throw new InvalidOperationException("One of the file capabilities you are attempting to register, is already registered.");
//             }
//
//             capabilitiesForType.Add(capabilityType, handler);
//         }
//
//         public FileCapabilityDelegate<TFile, TCapability> GetCapabilityHandler<TFile, TCapability>()
//             where TFile : File where TCapability : IFileCapability
//         {
//
//         }
//     }
// }