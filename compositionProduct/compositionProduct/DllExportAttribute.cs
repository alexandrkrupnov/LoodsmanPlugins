using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DllExport
{
    /// <summary>
    /// Attribute added to a static C# method to export it
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DllExportAttribute : Attribute
    {
        private string m_exportName;
        private CallingConvention m_callingConvention;

        /// <summary>
        /// Constructor 1
        /// </summary>
        /// <param name="exportName"></param>
        public DllExportAttribute(string exportName)
            : this(exportName, System.Runtime.InteropServices.CallingConvention.StdCall)
        {
        }

        /// <summary>
        /// Constructor 2
        /// </summary>
        /// <param name="exportName"></param>
        /// <param name="callingConvention"></param>
        public DllExportAttribute(string exportName, CallingConvention callingConvention)
        {
            m_exportName = exportName;
            m_callingConvention = callingConvention;
        }

        /// <summary>
        /// Get the export name, or null to use the method name
        /// </summary>
        public string ExportName
        {
            get { return m_exportName; }
        }

        /// <summary>
        /// Get the calling convention
        /// </summary>
        public string CallingConvention
        {
            get
            {
                switch (m_callingConvention)
                {
                    case System.Runtime.InteropServices.CallingConvention.Cdecl:
                        return typeof(CallConvCdecl).FullName;

                    case System.Runtime.InteropServices.CallingConvention.FastCall:
                        return typeof(CallConvFastcall).FullName;

                    case System.Runtime.InteropServices.CallingConvention.StdCall:
                        return typeof(CallConvStdcall).FullName;

                    case System.Runtime.InteropServices.CallingConvention.ThisCall:
                        return typeof(CallConvThiscall).FullName;

                    case System.Runtime.InteropServices.CallingConvention.Winapi:
                        return typeof(CallConvStdcall).FullName;

                    default:
                        return "";
                }
            }
        }
    }
}