using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace Escalation
{
    public static class Mailslot
    {
        internal const string MailslotName = @"\\.\mailslot\AutoBaloogan";

        static NativeMethods.SafeMailslotHandle hMailslot = null;
        private static void init()
        {
            if (hMailslot != null)
                return;
            // Try to open the mailslot with the write access.
            hMailslot = NativeMethods.CreateFile(
                MailslotName,                           // The name of the mailslot
                NativeMethods.FileDesiredAccess.GENERIC_WRITE,        // Write access 
                NativeMethods.FileShareMode.FILE_SHARE_READ,          // Share mode
                IntPtr.Zero,                            // Default security attributes
                NativeMethods.FileCreationDisposition.OPEN_EXISTING,  // Opens existing mailslot
                0,                                      // No other attributes set
                IntPtr.Zero                             // No template file
                );
            if (hMailslot.IsInvalid)
            {
                throw new Win32Exception();
            }

            Console.WriteLine("The mailslot ({0}) is opened.", MailslotName);

            // Write messages to the mailslot.

            // Append '\0' at the end of each message considering the native C++ 
            // Mailslot server (CppMailslotServer).
        }

        public static void Transmit(string message)
        {
            XElement e = new XElement("ChannelMessage");
            e.Add(new XElement("Text", message));
            e.Add(new XElement("Chan", "es_control"));
            try
            {
                WriteMailslot(e.ToString(SaveOptions.DisableFormatting));
            }
            catch (Exception ex)
            {

            }

        }


        /// <summary>
        /// Write a message to the specified mailslot
        /// </summary>
        /// <param name="hMailslot">Handle to the mailslot</param>
        /// <param name="lpszMessage">The message to be written to the slot</param>
        private static void WriteMailslot(string message)
        {
            init();
            int cbMessageBytes = 0;         // Message size in bytes
            int cbBytesWritten = 0;         // Number of bytes written to the slot

            byte[] bMessage = Encoding.Unicode.GetBytes(message);
            cbMessageBytes = bMessage.Length;

            bool succeeded = NativeMethods.WriteFile(
                hMailslot,                  // Handle to the mailslot
                bMessage,                   // Message to be written
                cbMessageBytes,             // Number of bytes to write
                out cbBytesWritten,         // Number of bytes written
                IntPtr.Zero                 // Not overlapped
                );
            if (!succeeded || cbMessageBytes != cbBytesWritten)
            {
                Console.WriteLine("WriteFile failed w/err 0x{0:X}",
                    Marshal.GetLastWin32Error());
            }
            else
            {
                Console.WriteLine("The message \"{0}\" is written to the slot",
                    message);
            }
        }
    }
}